using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace proyectofinal_appmoviles.ViewModels
{
    public class ServiciosViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService = new();
        public ObservableCollection<ServicioDto> Servicios { get; set; } = new();

        public ICommand RefrescarCommand { get; }

        private bool isCargando;
        public bool IsCargando
        {
            get => isCargando;
            set { isCargando = value; OnPropertyChanged(nameof(IsCargando)); }
        }

        public ServiciosViewModel()
        {
            RefrescarCommand = new Command(async () => await CargarServicios());
            _ = CargarServicios();
        }

        public async Task CargarServicios()
        {
            IsCargando = true;

            var resultado = await _apiService.GetServiciosAsync();

            Servicios.Clear();

            if (resultado != null && resultado.Exito && resultado.Datos != null)
            {
                foreach (var servicio in resultado.Datos)
                    Servicios.Add(servicio);
            }
            else
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", resultado?.Mensaje ?? "No se pudieron cargar los servicios.", "OK");
            }

            IsCargando = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string nombre) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
