using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using System.Collections.ObjectModel;

namespace proyectofinal_appmoviles.Views
{
    public partial class ServiciosPage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();
        private readonly ObservableCollection<ServicioDto> _servicios = new();

        public ServiciosPage()
        {
            InitializeComponent();
            ServiciosCollection.ItemsSource = _servicios;
            _ = CargarServicios();
        }

        private async Task CargarServicios()
        {
            var response = await _apiService.GetServiciosAsync();

            if (response != null && response.exito && response.datos != null)
            {
                _servicios.Clear();

                foreach (var servicio in response.datos)
                {
                    _servicios.Add(servicio);
                }
            }
            else
            {
                await DisplayAlert("Error", response?.mensaje ?? "No se pudieron cargar los servicios", "OK");
            }

        }
    }
}
