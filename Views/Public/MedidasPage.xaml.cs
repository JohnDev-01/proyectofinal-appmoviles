using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.Views;

public partial class MedidasPage : ContentPage
{
    private readonly ApiService _apiService = new();

    public MedidasPage()
    {
        InitializeComponent();
        CargarMedidas();
    }

    private async void CargarMedidas()
    {
        var resultado = await _apiService.GetMedidasAsync();

        if (resultado != null && resultado.exito)
        {
            ListaMedidas.ItemsSource = resultado.datos;
        }
        else
        {
            await DisplayAlert("Error", "No se pudieron obtener las medidas preventivas.", "OK");
        }
    }
}
