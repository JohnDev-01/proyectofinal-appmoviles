using proyectofinal_appmoviles.Views.Public;

namespace proyectofinal_appmoviles.Views;

public partial class LoginChoicePage : ContentPage
{
	public LoginChoicePage()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
       // await Navigation.PushAsync(new LoginPage());
    }

    private async void OnGuestClicked(object sender, EventArgs e)
    {
        // Guardar que está en modo invitado
        Preferences.Set("IsGuest", true);
        Application.Current.MainPage = new InicioPage();
    }

}