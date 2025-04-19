using proyectofinal_appmoviles.Services;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views.Private;

public partial class CambiarClave : ContentPage
{
    private readonly ApiService _apiService;

    public CambiarClave()
    {
        InitializeComponent();
        _apiService = new ApiService();
    }

    private async void OnCambiarClaveClicked(object sender, EventArgs e)
    {
        MensajeLabel.Text = "";

        var claveAnterior = ClaveAnteriorEntry.Text;
        var claveNueva = ClaveNuevaEntry.Text;

        if (string.IsNullOrWhiteSpace(claveAnterior) || string.IsNullOrWhiteSpace(claveNueva))
        {
            MensajeLabel.Text = "Todos los campos son obligatorios.";
            return;
        }

        var token = _apiService.GetToken();
        if (string.IsNullOrWhiteSpace(token))
        {
            await DisplayAlert("Error", "Token no disponible. Debe iniciar sesión nuevamente.", "OK");
            return;
        }

        var form = new Dictionary<string, string>
            {
                { "token", token },
                { "clave_anterior", claveAnterior },
                { "clave_nueva", claveNueva }
            };

        var response = await _apiService.PostFormDataAsync("cambiar_clave.php", form);

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
            MensajeLabel.Text = "Ocurrió un error al cambiar la clave.";
        }
    }

}