using Microsoft.Maui.Controls;
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
            try
            {
                var token = _apiService.GetToken();

                var parametros = new Dictionary<string, string>
        {
            { "token", token }
        };

                var response = await _apiService.PostFormDataAsync("noticias_especificas.php", parametros);

                if (response.HasValue && response.Value.ValueKind == JsonValueKind.Object)
                {
                    var root = response.Value;

                    if (root.TryGetProperty("exito", out var exitoProp) && exitoProp.GetBoolean())
                    {
                        var lista = new List<NoticiaPublicaModel>();

                        if (root.TryGetProperty("datos", out var datos) && datos.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var item in datos.EnumerateArray())
                            {
                                lista.Add(new NoticiaPublicaModel
                                {
                                    titulo = item.GetProperty("titulo").GetString(),
                                    contenido = item.GetProperty("contenido").GetString(),
                                    fecha = item.GetProperty("fecha").GetString(),
                                    foto = item.GetProperty("foto").GetString()
                                });
                            }

                            NoticiasList.ItemsSource = lista;
                            MensajeLabel.IsVisible = false;
                        }
                        else
                        {
                            MensajeLabel.Text = "No se encontraron noticias.";
                            MensajeLabel.IsVisible = true;
                        }
                    }
                    else
                    {
                        MensajeLabel.Text = root.GetProperty("mensaje").GetString();
                        MensajeLabel.IsVisible = true;
                    }
                }
                else
                {
                    MensajeLabel.Text = "Respuesta inválida del servidor.";
                    MensajeLabel.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = $"❌ Error inesperado: {ex.Message}";
                MensajeLabel.IsVisible = true;
            }
        }

    }
}
