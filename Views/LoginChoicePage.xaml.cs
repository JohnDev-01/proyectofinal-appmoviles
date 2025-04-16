using proyectofinal_appmoviles.Views.Public;
using proyectofinal_appmoviles.ViewModels; // Added using directive for InicioViewModel

namespace proyectofinal_appmoviles.Views;

public partial class LoginChoicePage : ContentPage
{
	public LoginChoicePage()
	{
		InitializeComponent();
	}
private async void OnLoginClicked(object sender, EventArgs e)
{
    // Implement the desired functionality for the OnLoginClicked event
    await DisplayAlert("Login", "Login clicked!", "OK");
}

private async void OnEntrarComoInvitadoClicked(object sender, EventArgs e) 
    {
        Application.Current.MainPage = new InicioPage(new InicioViewModel());
    }

}