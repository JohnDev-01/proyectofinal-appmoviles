using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views;


public partial class AlberguesPage : ContentPage
{
    private List<AlbergueDto> _todosLosAlbergues = new();

    public AlberguesPage()
    {
        InitializeComponent();
        CargarAlbergues();
    }

    private async void CargarAlbergues()
    {
        try
        {
            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;

            var respuesta = await new ApiService().GetAlberguesAsync();

            if (respuesta?.Exito == true && respuesta.Datos != null)
            {
                _todosLosAlbergues = respuesta.Datos;
                alberguesCollectionView.ItemsSource = _todosLosAlbergues;
            }
            else
            {
                await DisplayAlert("Error", "No se pudo cargar la lista de albergues.", "OK");
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

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var query = e.NewTextValue?.ToLower() ?? "";

        var filtrados = _todosLosAlbergues.Where(x =>
            x.Ciudad.ToLower().Contains(query) ||
            x.Edificio.ToLower().Contains(query)).ToList();

        alberguesCollectionView.ItemsSource = filtrados;
    }

    private async void OnAlbergueSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is AlbergueDto albergue)
        {
            await Navigation.PushAsync(new DetalleAlberguePage(albergue));
            alberguesCollectionView.SelectedItem = null;
        }
    }
}
