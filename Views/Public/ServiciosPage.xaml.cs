using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using System.Collections.ObjectModel;

namespace proyectofinal_appmoviles.Views
{
    public partial class ServiciosPage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();
        private ObservableCollection<ServicioDto> _servicios;

        public ServiciosPage()
        {
            InitializeComponent();
            _servicios = new ObservableCollection<ServicioDto>();
            ServiciosCollection.ItemsSource = _servicios;
            CargarServicios();
        }

        private async void CargarServicios()
        {
            var response = await _apiService.GetServiciosAsync();

            if (response != null && response.exito && response.datos != null)
            {
                _servicios.Clear();
                foreach (var servicio in response.datos)
                {
                    // Agrega ruta completa al icono si es necesario
                    servicio.icono = $"https://adamix.net/defensa_civil/def/images/{servicio.icono}";
                    _servicios.Add(servicio);
                }
            }
            else
            {
                await DisplayAlert("Error", "No se pudieron cargar los servicios", "OK");
            }
        }
    }
}
