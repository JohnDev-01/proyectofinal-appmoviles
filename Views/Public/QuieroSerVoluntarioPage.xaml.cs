using System.Text.Json;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.Views.Public;

public partial class QuieroSerVoluntarioPage : ContentPage
{
    private readonly ApiService _apiService = new();

    public QuieroSerVoluntarioPage()
    {
        InitializeComponent();
    }

    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        // Validaciones básicas
        if (string.IsNullOrWhiteSpace(cedulaEntry.Text) ||
            string.IsNullOrWhiteSpace(nombreEntry.Text) ||
            string.IsNullOrWhiteSpace(apellidoEntry.Text) ||
            string.IsNullOrWhiteSpace(correoEntry.Text) ||
            string.IsNullOrWhiteSpace(telefonoEntry.Text) ||
            string.IsNullOrWhiteSpace(claveEntry.Text))
        {
            await DisplayAlert("Validación", "Por favor, completa todos los campos.", "OK");
            return;
        }

        var formData = new Dictionary<string, string>
        {
            { "cedula", cedulaEntry.Text! },
            { "nombre", nombreEntry.Text! },
            { "apellido", apellidoEntry.Text! },
            { "correo", correoEntry.Text! },
            { "telefono", telefonoEntry.Text! },
            { "clave", claveEntry.Text! }
        };

        enviarButton.IsEnabled = false;
        loadingIndicator.IsVisible = true;
        loadingIndicator.IsRunning = true;

        var response = await _apiService.PostFormDataAsync("registro.php", formData);

        enviarButton.IsEnabled = true;
        loadingIndicator.IsVisible = false;
        loadingIndicator.IsRunning = false;

        if (response.HasValue)
        {
            bool exito = response.Value.GetProperty("exito").GetBoolean();
            string mensaje = response.Value.GetProperty("mensaje").GetString() ?? "Sin mensaje";

            if (exito)
            {
                await DisplayAlert("Éxito", mensaje, "OK");
                LimpiarFormulario();
            }
            else
            {
                await DisplayAlert("Error", mensaje, "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "No se pudo completar el registro.", "OK");
        }
    }

    private void LimpiarFormulario()
    {
        cedulaEntry.Text = string.Empty;
        nombreEntry.Text = string.Empty;
        apellidoEntry.Text = string.Empty;
        correoEntry.Text = string.Empty;
        telefonoEntry.Text = string.Empty;
        claveEntry.Text = string.Empty;
    }
}
