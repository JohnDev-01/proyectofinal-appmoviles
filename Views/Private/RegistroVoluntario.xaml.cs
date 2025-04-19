using proyectofinal_appmoviles.Services;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views.Private;

public partial class RegistroVoluntario : ContentPage
{
    private readonly ApiService _apiService;

    public RegistroVoluntario()
    {
        InitializeComponent();
        _apiService = new ApiService();
    }

    private async void OnRegistroClicked(object sender, EventArgs e)
    {
        MensajeLabel.Text = "";

        var cedula = CedulaEntry.Text;
        var nombre = NombreEntry.Text;
        var apellido = ApellidoEntry.Text;
        var correo = CorreoEntry.Text;
        var telefono = TelefonoEntry.Text;
        var clave = ClaveEntry.Text;

        if (string.IsNullOrWhiteSpace(cedula) ||
            string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(apellido) ||
            string.IsNullOrWhiteSpace(correo) ||
            string.IsNullOrWhiteSpace(telefono) ||
            string.IsNullOrWhiteSpace(clave))
        {
            MensajeLabel.Text = "Todos los campos son obligatorios.";
            return;
        }

        var form = new Dictionary<string, string>
            {
                { "cedula", cedula },
                { "nombre", nombre },
                { "apellido", apellido },
                { "correo", correo },
                { "telefono", telefono },
                { "clave", clave }
            };

        var response = await _apiService.PostFormDataAsync("registro.php", form);

        if (response.HasValue && response.Value.ValueKind == JsonValueKind.Object)
        {
            var json = response.Value;

            if (json.GetProperty("exito").GetBoolean())
            {
                await DisplayAlert("Registro exitoso", json.GetProperty("mensaje").GetString(), "OK");
                await Navigation.PopAsync();
            }
            else
            {
                MensajeLabel.Text = json.GetProperty("mensaje").GetString();
            }
        }
        else
        {
            MensajeLabel.Text = "Ocurrió un error al registrar. Intente nuevamente.";
        }
    }

}