using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using proyectofinal_appmoviles.Services;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views.Private;

public partial class NuevaSituacion : ContentPage
{
    private readonly ApiService _apiService;
    private string _base64Foto = string.Empty;
    private string _latitud = string.Empty;
    private string _longitud = string.Empty;

    public NuevaSituacion()
    {
        InitializeComponent();
        _apiService = new ApiService();
        InicializarUbicacion();
    }

    private async void InicializarUbicacion()
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                _latitud = location.Latitude.ToString();
                _longitud = location.Longitude.ToString();

                SituacionMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Location(location.Latitude, location.Longitude), Distance.FromKilometers(1)));

                UbicacionLabel.Text = $"Latitud: {_latitud} | Longitud: {_longitud}";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo obtener la ubicación: " + ex.Message, "OK");
        }
    }

    private void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        _latitud = e.Location.Latitude.ToString();
        _longitud = e.Location.Longitude.ToString();
        UbicacionLabel.Text = $"Latitud: {_latitud} | Longitud: {_longitud}";
    }

    private async void OnTomarFotoClicked(object sender, EventArgs e)
    {
        try
        {
            var foto = await MediaPicker.CapturePhotoAsync();
            if (foto != null)
            {
                using var stream = await foto.OpenReadAsync();
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                _base64Foto = Convert.ToBase64String(ms.ToArray());

                FotoPreview.Source = ImageSource.FromStream(() => new MemoryStream(ms.ToArray()));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo tomar la foto: " + ex.Message, "OK");
        }
    }

    private async void OnEnviarReporteClicked(object sender, EventArgs e)
    {
        MensajeLabel.Text = "";

        var titulo = TituloEntry.Text;
        var descripcion = DescripcionEditor.Text;
        var token = _apiService.GetToken();

        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(descripcion)
            || string.IsNullOrWhiteSpace(_base64Foto) || string.IsNullOrWhiteSpace(_latitud) || string.IsNullOrWhiteSpace(_longitud))
        {
            MensajeLabel.Text = "Todos los campos son obligatorios, incluyendo foto y ubicación.";
            return;
        }

        var form = new Dictionary<string, string>
            {
                { "token", token },
                { "titulo", titulo },
                { "descripcion", descripcion },
                { "foto", _base64Foto },
                { "latitud", _latitud },
                { "longitud", _longitud }
            };

        var response = await _apiService.PostFormDataAsync("nueva_situacion.php", form);

        if (response.HasValue && response.Value.ValueKind == JsonValueKind.Object)
        {
            var json = response.Value;

            if (json.GetProperty("exito").GetBoolean())
            {
                await DisplayAlert("Éxito", json.GetProperty("mensaje").GetString(), "OK");
                await Navigation.PopAsync();
            }
            else
            {
                MensajeLabel.Text = json.GetProperty("mensaje").GetString();
            }
        }
        else
        {
            MensajeLabel.Text = "Error al enviar la situación. Intenta nuevamente.";
        }
    }

}
