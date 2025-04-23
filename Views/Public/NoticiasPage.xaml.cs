using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class NoticiasPage : ContentPage
    {
        private readonly ApiService _apiService;

        public NoticiasPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            NoticiasRefreshView.Refreshing += NoticiasRefreshView_Refreshing;
            _ = CargarNoticiasAsync();
        }

        private async void NoticiasRefreshView_Refreshing(object sender, EventArgs e)
        {
            await CargarNoticiasAsync();
            NoticiasRefreshView.IsRefreshing = false;
        }

        private async Task CargarNoticiasAsync()
{
    var response = await _apiService.GetAsync<NoticiaResponseDto>("noticias.php");
    if (response != null && response.exito)
    {
        NoticiasList.ItemsSource = response.datos;
    }
    else
    {
        MensajeLabel.Text = response?.mensaje ?? "No se pudieron cargar las noticias";
        MensajeLabel.IsVisible = true;
    }
}

    }
}
