using proyectofinal_appmoviles.Views.Public;
using proyectofinal_appmoviles.ViewModels;

namespace proyectofinal_appmoviles.Views;

public partial class LoginChoicePage : ContentPage
{
    public LoginChoicePage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Login", "Login clicked!", "OK");
    }

    private void OnEntrarComoInvitadoClicked(object sender, EventArgs e) 
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new NavigationPage(new InicioPage(new InicioViewModel()));
        }
    }
}
