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
        // Implement the desired functionality for the OnNoticiasClicked event
        // For example, navigate to a news page or display a message
        await DisplayAlert("Noticias", "Noticias clicked!", "OK");
    }

    private async void OnServiciosClicked(object sender, EventArgs e)
    {
        // Implement the desired functionality for the OnServiciosClicked event
        // For example, navigate to a services page or display a message
        await DisplayAlert("Servicios", "Servicios clicked!", "OK");
    }

    private async void OnVideosClicked(object sender, EventArgs e)
    {
        // Implement the desired functionality for the OnVideosClicked event
        await DisplayAlert("Videos", "Videos clicked!", "OK");
    }

    private async void OnAlberguesClicked(object sender, EventArgs e)
    {
        // Implement the desired functionality for the OnAlberguesClicked event
        await DisplayAlert("Albergues", "Albergues clicked!", "OK");
    }

    private async void OnMedidasClicked(object sender, EventArgs e)
    {
        // Implement the desired functionality for the OnMedidasClicked event
        await DisplayAlert("Medidas", "Medidas clicked!", "OK");
    }

    private async void OnMiembrosClicked(object sender, EventArgs e)
    {
        // Implement the desired functionality for the OnMiembrosClicked event
        await DisplayAlert("Miembros", "Miembros clicked!", "OK");
    }

    private async void OnVoluntarioClicked(object sender, EventArgs e)
    {
        // Implement the desired functionality for the OnVoluntarioClicked event
        await DisplayAlert("Voluntario", "Voluntario clicked!", "OK");
    }

    private async void OnAcercaClicked(object sender, EventArgs e)
    {
        // Implement the desired functionality for the OnAcercaClicked event
        await DisplayAlert("Acerca", "Acerca clicked!", "OK");
    }
}
}
