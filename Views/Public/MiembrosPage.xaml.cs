using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.Views;

public partial class MiembrosPage : ContentPage
{
    private readonly ApiService _apiService = new();

    public MiembrosPage()
    {
        InitializeComponent();
        CargarMiembros();
    }

    private async void CargarMiembros()
    {
        try
        {
            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;

            var response = await _apiService.GetMiembrosAsync();

            if (response?.exito == true && response.datos != null)
            {
                miembrosCollectionView.ItemsSource = response.datos;
            }
            else
            {
                await DisplayAlert("Advertencia", "No se encontraron miembros para mostrar.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
        finally
        {
            loadingIndicator.IsVisible = false;
            loadingIndicator.IsRunning = false;
        }
    }
}
