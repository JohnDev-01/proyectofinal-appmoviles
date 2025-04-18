using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using Microsoft.Maui.Controls;

namespace proyectofinal_appmoviles.ViewModels
{
    public class MedidasViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        public ObservableCollection<MedidaDto> Medidas { get; set; } = new ObservableCollection<MedidaDto>();

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        private bool _isError;
        public bool IsError
        {
            get => _isError;
            set { _isError = value; OnPropertyChanged(); }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        private bool _isEmpty;
        public bool IsEmpty
        {
            get => _isEmpty;
            set { _isEmpty = value; OnPropertyChanged(); }
        }

        public ICommand LoadMedidasCommand { get; }
        public ICommand SelectMedidaCommand { get; }

        public INavigation Navigation { get; set; }

        public MedidasViewModel()
        {
            _apiService = new ApiService();
            LoadMedidasCommand = new Command(async () => await LoadMedidasAsync());
            SelectMedidaCommand = new Command<MedidaDto>(async (medida) => await SelectMedidaAsync(medida));
        }

        public async Task LoadMedidasAsync()
        {
            IsLoading = true;
            IsError = false;
            IsEmpty = false;
            ErrorMessage = string.Empty;
            Medidas.Clear();

            var response = await _apiService.GetMedidasAsync();

            if (response == null)
            {
                IsError = true;
                ErrorMessage = "Error al cargar las medidas preventivas.";
            }
            else if (!response.Exito)
            {
                IsError = true;
                ErrorMessage = response.Mensaje ?? "Error desconocido.";
            }
            else if (response.Datos == null || response.Datos.Count == 0)
            {
                IsEmpty = true;
            }
            else
            {
                foreach (var medida in response.Datos)
                {
                    Medidas.Add(medida);
                }
            }

            IsLoading = false;
        }

        private async Task SelectMedidaAsync(MedidaDto medida)
        {
            if (medida == null || Navigation == null)
                return;

            await Navigation.PushAsync(new Views.Public.MedidaDetailPage(medida));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
