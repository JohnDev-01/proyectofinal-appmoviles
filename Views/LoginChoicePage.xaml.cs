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
        // Aqui se navegara al menu de inicio sin necesidad de iniciar sesion
        // Application.Current.MainPage = new InicioPage();
    }

}