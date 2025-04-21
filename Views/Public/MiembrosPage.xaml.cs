using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using System.Collections.ObjectModel;

namespace proyectofinal_appmoviles.Views
{
    public partial class MiembrosPage : ContentPage
    {
        private readonly ApiService _apiService = new();
        public ObservableCollection<MiembroDto> MiembrosLista { get; set; } = new();

        public MiembrosPage()
        {
            InitializeComponent();
            BindingContext = this;
            CargarMiembrosDesdeApi();
        }

        private async void CargarMiembrosDesdeApi()
        {
            try
            {
                var response = await _apiService.GetMiembrosAsync();

                if (response != null && response.exito && response.datos != null)
                {
                    MiembrosLista.Clear();
                    foreach (var miembro in response.datos)
                    {
                        MiembrosLista.Add(miembro);
                    }
                }
                else
                {
                    await DisplayAlert("Error", response?.mensaje ?? "No se pudieron cargar los miembros.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Excepción", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}
