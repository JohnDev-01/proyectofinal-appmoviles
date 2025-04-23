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
        try
        {
            loadingIndicator.IsRunning = true;
            loadingIndicator.IsVisible = true;

            var response = await _apiService.GetMedidasAsync();
            if (response?.exito == true && response.datos != null && response.datos.Any())
            {
                medidasCollectionView.ItemsSource = response.datos;
            }
            else
            {
                await DisplayAlert("Advertencia", "No hay medidas disponibles para mostrar.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
        finally
        {
            loadingIndicator.IsRunning = false;
            loadingIndicator.IsVisible = false;
        }
    }

    private async void OnMedidaSeleccionada(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is MedidaDto medida)
        {
            await Navigation.PushAsync(new DetalleMedidaPage(medida));
            medidasCollectionView.SelectedItem = null;
        }
    }
}
