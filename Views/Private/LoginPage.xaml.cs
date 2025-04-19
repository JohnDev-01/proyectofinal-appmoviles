using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views.Private;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _apiService;

    public LoginPage()
    {
        InitializeComponent();
        _apiService = new ApiService();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        MessageLabel.Text = "";
        var cedula = CedulaEntry.Text;
        var clave = ClaveEntry.Text;

        if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(clave))
        {
            MessageLabel.Text = "Debe completar todos los campos.";
            return;
        }

        var form = new Dictionary<string, string>
            {
                { "cedula", cedula },
                { "clave", clave }
            };

        var response = await _apiService.PostFormDataAsync("iniciar_sesion.php", form);

        if (response.HasValue && response.Value.ValueKind == JsonValueKind.Object)
        {
            var json = response.Value;

            if (json.GetProperty("exito").GetBoolean())
            {
                var token = json.GetProperty("datos").GetProperty("token").GetString();
                _apiService.SetToken(token);
               
                Application.Current.MainPage = new NavigationPage(new MenuPrivado()); // Navegar a la p�gina principal
                // Navegar a la p�gina principal
            }
            else
            {
                MessageLabel.Text = json.GetProperty("mensaje").GetString();
            }
        }
        else
        {
            MessageLabel.Text = "Error inesperado. Intente de nuevo.";
        }
    }


    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        string cedula = await DisplayPromptAsync("Recuperar contrase�a", "Ingrese su c�dula:", "Aceptar", "Cancelar", "00000000000");
        if (string.IsNullOrWhiteSpace(cedula)) return;

        string correo = await DisplayPromptAsync("Recuperar contrase�a", "Ingrese su correo registrado:", "Aceptar", "Cancelar", "correo@ejemplo.com");
        if (string.IsNullOrWhiteSpace(correo)) return;

        var form = new Dictionary<string, string>
{
    { "cedula", cedula },
    { "correo", correo }
};

        var response = await _apiService.PostFormDataAsync("recuperar_clave.php", form);

        if (response.HasValue && response.Value.ValueKind == JsonValueKind.Object)
        {
            var json = response.Value;

            if (json.GetProperty("exito").GetBoolean())
            {
                await DisplayAlert("Recuperaci�n", json.GetProperty("mensaje").GetString(), "OK");
            }
            else
            {
                await DisplayAlert("Error", json.GetProperty("mensaje").GetString(), "OK");
            }
        }


    }
}
