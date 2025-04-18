using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using System.Linq;

namespace proyectofinal_appmoviles.ViewModels
{
    public class AlberguesViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        public ObservableCollection<AlbergueDto> Albergues { get; set; } = new ObservableCollection<AlbergueDto>();
        private ObservableCollection<AlbergueDto> _allAlbergues = new ObservableCollection<AlbergueDto>();

        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    FilterAlbergues();
                }
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
        public bool IsEmpty => !IsLoading && Albergues.Count == 0 && !HasError;

        private AlbergueDto? _selectedAlbergue;
        public AlbergueDto? SelectedAlbergue
        {
            get => _selectedAlbergue;
            set
            {
                if (_selectedAlbergue != value)
                {
                    _selectedAlbergue = value;
                    OnPropertyChanged();
                    if (_selectedAlbergue != null)
                    {
                        OnAlbergueSelected(_selectedAlbergue);
                    }
                }
            }
        }

        public ICommand RefreshCommand { get; }
        public ICommand AlbergueSelectedCommand { get; }

        public AlberguesViewModel()
        {
            _apiService = new ApiService();
            RefreshCommand = new Command(async () => await LoadAlberguesAsync());
            AlbergueSelectedCommand = new Command<AlbergueDto>(OnAlbergueSelected);
            Task.Run(async () => await LoadAlberguesAsync());
        }

        private async void OnAlbergueSelected(AlbergueDto albergue)
        {
            if (albergue == null)
                return;

            // Navigation logic will be handled in the view's code-behind
            // This method can be used for additional logic if needed
        }

        private async Task LoadAlberguesAsync()
        {
            IsLoading = true;
            ErrorMessage = string.Empty;
            try
            {
                var response = await _apiService.GetAlberguesAsync();
                if (response != null && response.Exito && response.Datos != null)
                {
                    // Add mock coordinates for demonstration
                    var random = new System.Random();
                    foreach (var albergue in response.Datos)
                    {
                        if (!albergue.Latitude.HasValue || !albergue.Longitude.HasValue)
                        {
                            // Assign mock coordinates (example: random or fixed for demo)
                            albergue.Latitude = 18.5 + random.NextDouble() * 0.1;
                            albergue.Longitude = -69.9 + random.NextDouble() * 0.1;
                        }
                    }
                    _allAlbergues = new ObservableCollection<AlbergueDto>(response.Datos);
                    FilterAlbergues();
                }
                else
                {
                    ErrorMessage = response?.Mensaje ?? "Error al cargar los albergues.";
                    Albergues.Clear();
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessage = $"Error de conexión: {ex.Message}";
                Albergues.Clear();
            }
            finally
            {
                IsLoading = false;
                OnPropertyChanged(nameof(IsEmpty));
                OnPropertyChanged(nameof(HasError));
            }
        }

        private void FilterAlbergues()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Albergues = new ObservableCollection<AlbergueDto>(_allAlbergues);
            }
            else
            {
                var filtered = _allAlbergues.Where(a =>
                    (!string.IsNullOrEmpty(a.Nombre) && a.Nombre.ToLower().Contains(SearchText.ToLower())) ||
                    (!string.IsNullOrEmpty(a.Direccion) && a.Direccion.ToLower().Contains(SearchText.ToLower()))
                );
                Albergues = new ObservableCollection<AlbergueDto>(filtered);
            }
            OnPropertyChanged(nameof(Albergues));
            OnPropertyChanged(nameof(IsEmpty));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
