using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Views.Private;

public partial class MenuPrivado : ContentPage
{
    public MenuPrivado()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await SolicitarPermisosAsync();
    }
    private async Task SolicitarPermisosAsync()
    {
        var cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
        var locationStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        if (cameraStatus != PermissionStatus.Granted || locationStatus != PermissionStatus.Granted)
        {
            await DisplayAlert("Permisos necesarios", "Se requieren permisos de cámara y ubicación para continuar.", "OK");
        }
    }
    private async void OnNoticiasClicked(object sender, EventArgs e)
    {
        // Navegar o mostrar contenido de noticias
        await Navigation.PushAsync(new NoticiasPrivadasPage());
    }

    private async void OnReportarClicked(object sender, EventArgs e)
    {
        // Navegar al reporte de situación
        await Navigation.PushAsync(new NuevaSituacion());
    }

    private async void OnMisSituacionesClicked(object sender, EventArgs e)
    {
        // Mostrar situaciones del usuario
        await Navigation.PushAsync(new MisSituacionesPage());
    }

    private async void OnMapaClicked(object sender, EventArgs e)
    {
        // Navegar al mapa
        await Navigation.PushAsync(new MiMapaPage());
    }

    private async void OnCambiarClaveClicked(object sender, EventArgs e)
    {
        // Navegar al cambio de contraseña
        await Navigation.PushAsync(new CambiarClave());
    }
}