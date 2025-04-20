using proyectofinal_appmoviles.Services;
using System.Text.Json;

namespace proyectofinal_appmoviles.Views.Private;

public partial class MisSituacionesPage : ContentPage
{
    private readonly ApiService _apiService;

    public MisSituacionesPage()
    {
        InitializeComponent();
        _apiService = new ApiService();
        CargarSituaciones();
    }

    private async void CargarSituaciones()
    {
        try
        {
            LoadingIndicator.IsVisible = true;
            var token = _apiService.GetToken();

            var form = new Dictionary<string, string> { { "token", token } };
            var response = await _apiService.PostFormDataAsync("situaciones.php", form);

            if (response.HasValue && response.Value.ValueKind == JsonValueKind.Object)
            {
                var json = response.Value;

                if (json.GetProperty("exito").GetBoolean())
                {
                    var datos = json.GetProperty("datos");
                    var situaciones = new List<SituacionModel>();


                    foreach (var item in datos.EnumerateArray())
                    {
                        var situacion = new SituacionModel();

                        if (item.TryGetProperty("titulo", out var tituloProp))
                            situacion.titulo = tituloProp.GetString();

                        if (item.TryGetProperty("descripcion", out var descProp))
                            situacion.descripcion = descProp.GetString();

                        if (item.TryGetProperty("fecha_creacion", out var fechaProp))
                            situacion.fecha_creacion = fechaProp.GetString();

                        situaciones.Add(situacion);
                    }



                    /*foreach (var item in datos.EnumerateArray())
                    {
                        situaciones.Add(new SituacionModel
                        {
                            titulo = item.GetProperty("titulo").GetString(),
                            descripcion = item.GetProperty("descripcion").GetString(),
                            fecha_creacion = item.GetProperty("fecha_creacion").GetString()
                        });
                    }*/

                    SituacionesList.ItemsSource = situaciones;
                }
                else
                {
                    MensajeLabel.Text = json.GetProperty("mensaje").GetString();
                    MensajeLabel.IsVisible = true;
                }
            }
            else
            {
                MensajeLabel.Text = "No se pudo obtener las situaciones.";
                MensajeLabel.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
        }
    }
}

public class SituacionModel
{
    public string titulo { get; set; }
    public string descripcion { get; set; }
    public string fecha_creacion { get; set; }
}