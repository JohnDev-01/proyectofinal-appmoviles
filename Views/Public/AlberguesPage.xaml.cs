using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;
using proyectofinal_appmoviles.Models;
using System;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.Views.Public
{

    public class AlbergueDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string capacidad { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string provincia { get; set; }
    }
 
    public class AlbergueResponseDto
    {
        public bool exito { get; set; }
        public List<AlbergueDto> datos { get; set; }
        public string mensaje { get; set; }
    }
public partial class AlberguesPage : ContentPage
{
    private readonly ApiService _apiService = new ApiService();

    public AlberguesPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarAlberguesAsync();
    }

    private async Task CargarAlberguesAsync()
    {
        var response = await _apiService.GetAsync<AlbergueResponseDto>("albergues.php");
        if (response != null && response.exito)
        {
            AlberguesCollectionView.ItemsSource = response.datos;
        }
        else
        {
            await DisplayAlert("Error", response?.mensaje ?? "No se pudieron cargar los albergues", "OK");
        }
    }

    private async void OnVerMapaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapPage());
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedAlbergue = e.CurrentSelection.FirstOrDefault() as AlbergueDto;
        if (selectedAlbergue == null)
            return;

        ((CollectionView)sender).SelectedItem = null;
        await Navigation.PushAsync(new AlbergueDetailPage(selectedAlbergue));
    }
}
}