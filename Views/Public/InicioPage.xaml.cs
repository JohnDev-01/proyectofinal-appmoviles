using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;

namespace proyectofinal_appmoviles.Views.Public
{
public partial class InicioPage : ContentPage
{
    public InicioPage(InicioViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnNoticiasClicked(object sender, EventArgs e)
    {
        // Navigate to NoticiasPage
        await Navigation.PushAsync(new NoticiasPage());
    }

    private async void OnServiciosClicked(object sender, EventArgs e)
    {
        // Navigate to ServiciosPage
        await Navigation.PushAsync(new ServiciosPage());
    }

    private async void OnVideosClicked(object sender, EventArgs e)
    {
        // Navigate to VideosPage
        await Navigation.PushAsync(new VideosPage());
    }

    private async void OnAlberguesClicked(object sender, EventArgs e)
    {
        // Navigate to AlberguesPage
        await Navigation.PushAsync(new AlberguesPage());
    }

    private async void OnMedidasClicked(object sender, EventArgs e)
    {
        // Navigate to MedidasPage
        await Navigation.PushAsync(new MedidasPage());
    }

    private async void OnMiembrosClicked(object sender, EventArgs e)
    {
        // Navigate to MiembrosPage
        await Navigation.PushAsync(new MiembrosPage());
    }

    private async void OnVoluntarioClicked(object sender, EventArgs e)
    {
        // Navigate to QuieroSerVoluntarioPage
        await Navigation.PushAsync(new QuieroSerVoluntarioPage());
    }

    private async void OnAcercaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AcercaDePage());
    }
    private void OnRegresarLoginClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LoginChoicePage();
    }
    }
}
