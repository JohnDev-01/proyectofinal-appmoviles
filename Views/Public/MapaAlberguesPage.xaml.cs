using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.Views
{
    public partial class MapaAlberguesPage : ContentPage
    {
        private readonly ApiService _apiService;

        public MapaAlberguesPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            CargarAlberguesEnMapa();
        }

        private async void CargarAlberguesEnMapa()
        {
            try
            {
                var respuesta = await _apiService.GetAlberguesAsync();
                if (respuesta?.Exito == true && respuesta.Datos != null)
                {
                    foreach (var albergue in respuesta.Datos)
                    {
                        if (double.TryParse(albergue.Lat, out double lat) &&
                            double.TryParse(albergue.Lng, out double lng))
                        {
                            var location = new Location(lat, lng);
                            var pin = new Pin
                            {
                                Label = albergue.Edificio,
                                Address = $"{albergue.Ciudad} - {albergue.Coordinador}",
                                Type = PinType.Place,
                                Location = location
                            };

                            pin.MarkerClicked += async (s, args) =>
                            {
                                args.HideInfoWindow = true;
                                await DisplayAlert("Albergue",
                                    $"{albergue.Edificio}\nCiudad: {albergue.Ciudad}\nTeléfono: {albergue.Telefono}\nCapacidad: {albergue.Capacidad}",
                                    "OK");
                            };

                            mapa.Pins.Add(pin);
                        }
                    }

                    // Center map on first albergue
                    var primer = respuesta.Datos.FirstOrDefault();
                    if (primer != null && double.TryParse(primer.Lat, out double firstLat) &&
                        double.TryParse(primer.Lng, out double firstLng))
                    {
                        mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(firstLat, firstLng), Distance.FromKilometers(5)));
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron cargar los albergues", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
