using proyectofinal_appmoviles.Services;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views.Private;
public class NoticiaModel
{
    public string titulo { get; set; }
    public string descripcion { get; set; }
    public string fecha { get; set; }
    public string foto { get; set; }
}


public partial class NoticiasPrivadasPage : ContentPage
{
    private readonly ApiService _apiService;

    public NoticiasPrivadasPage()
    {
        InitializeComponent();
        _apiService = new ApiService();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarNoticiasAsync();

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

                if (root.GetProperty("exito").GetBoolean())
                {
                    var noticias = new List<NoticiaModel>();
                    var datos = root.GetProperty("datos");

                    foreach (var item in datos.EnumerateArray())
                    {
                        noticias.Add(new NoticiaModel
                        {
                            titulo = item.GetProperty("titulo").GetString(),
                            descripcion = item.GetProperty("contenido").GetString(),
                            fecha = item.GetProperty("fecha").GetString(),
                            foto = item.GetProperty("foto").GetString()
                        });
                    }

                    NoticiasList.ItemsSource = noticias;
                    MensajeLabel.IsVisible = false;
                }
                else
                {
                    MensajeLabel.Text = root.GetProperty("mensaje").GetString();
                    MensajeLabel.IsVisible = true;
                }
            }
            else
            {
                MensajeLabel.Text = "❌ Error al obtener noticias. La respuesta no es válida.";
                MensajeLabel.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            MensajeLabel.Text = $"🚨 Error inesperado: {ex.Message}";
            MensajeLabel.IsVisible = true;
        }
    }



}
