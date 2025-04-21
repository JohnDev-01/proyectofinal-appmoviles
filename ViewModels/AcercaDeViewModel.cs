using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.ViewModels
{
    public class AcercaDeViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        private ObservableCollection<MiembroDto> _miembros;
        public ObservableCollection<MiembroDto> Miembros
        {
            get => _miembros;
            set
            {
                _miembros = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public AcercaDeViewModel()
        {
            _apiService = new ApiService();
            Miembros = new ObservableCollection<MiembroDto>();
        }

        public async Task LoadMiembrosAsync()
        {
            IsLoading = true;
            var response = await _apiService.GetMiembrosAsync();
            if (response != null && response.exito && response.datos != null)
            {
                Miembros.Clear();
                foreach (var miembro in response.datos)
                {
                    Miembros.Add(miembro);
                }
            }
            IsLoading = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
