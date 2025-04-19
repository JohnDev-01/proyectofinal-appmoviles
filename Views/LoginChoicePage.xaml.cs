using proyectofinal_appmoviles.Views.Public;
using proyectofinal_appmoviles.ViewModels;
using proyectofinal_appmoviles.Views.Private;

namespace proyectofinal_appmoviles.Views;

public partial class LoginChoicePage : ContentPage
{
    public LoginChoicePage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private void OnEntrarComoInvitadoClicked(object sender, EventArgs e) 
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new NavigationPage(new InicioPage(new InicioViewModel()));
        }
    }
}
