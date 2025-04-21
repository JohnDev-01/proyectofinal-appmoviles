using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using proyectofinal_appmoviles.ViewModels;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views.Public
{
    public class NoticiaPublicaModel
    {
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string fecha { get; set; }
        public string foto { get; set; }
    }

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
               //  NoticiasCollection.ItemsSource = response.datos;
            }
            else
            {
                await DisplayAlert("Error", response?.mensaje ?? "No se pudieron cargar las noticias", "OK");
            }

        }

    }
}
