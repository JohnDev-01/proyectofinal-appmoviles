using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using proyectofinal_appmoviles.Services;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views.Private;

public partial class MiMapaPage : ContentPage
{
    private readonly ApiService _apiService;

    public MiMapaPage()
    {
        InitializeComponent();
        _apiService = new ApiService();
        CargarSituacionesEnMapa();
    }

    private async void CargarSituacionesEnMapa()
    {
        try
        {
            var token = _apiService.GetToken();

            var form = new Dictionary<string, string> { { "token", token } };
            var response = await _apiService.PostFormDataAsync("situaciones.php", form);

            if (response.HasValue && response.Value.ValueKind == JsonValueKind.Object)
            {
                var json = response.Value;

                if (json.GetProperty("exito").GetBoolean())
                {
                    var datos = json.GetProperty("datos");

                    foreach (var item in datos.EnumerateArray())
                    {
                        var titulo = item.GetProperty("titulo").GetString();
                        var descripcion = item.GetProperty("descripcion").GetString();
                        var latitud = double.Parse(item.GetProperty("latitud").GetString() ?? "0");
                        var longitud = double.Parse(item.GetProperty("longitud").GetString() ?? "0");

                        var pin = new Pin
                        {
                            Label = titulo,
                            Address = descripcion,
                            Location = new Location(latitud, longitud),
                            Type = PinType.Place
                        };

                        SituacionesMap.Pins.Add(pin);
                    }

                    if (datos.GetArrayLength() > 0)
                    {
                        var firstLocation = new Location(
                            double.Parse(datos[0].GetProperty("latitud").GetString() ?? "0"),
                            double.Parse(datos[0].GetProperty("longitud").GetString() ?? "0")
                        );

                        SituacionesMap.MoveToRegion(MapSpan.FromCenterAndRadius(firstLocation, Distance.FromKilometers(5)));
                    }
                }
                else
                {
                    await DisplayAlert("Error", json.GetProperty("mensaje").GetString(), "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}