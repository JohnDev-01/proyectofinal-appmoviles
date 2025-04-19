using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Views.Private;

public partial class MenuPrivado : ContentPage
{
    public MenuPrivado()
    {
        InitializeComponent();
    }

    private void OnNoticiasClicked(object sender, EventArgs e)
    {
        // Navegar o mostrar contenido de noticias
    }

    private void OnReportarClicked(object sender, EventArgs e)
    {
        // Navegar al reporte de situación
    }

    private void OnMisSituacionesClicked(object sender, EventArgs e)
    {
        // Mostrar situaciones del usuario
    }

    private void OnMapaClicked(object sender, EventArgs e)
    {
        // Navegar al mapa
    }

    private async void OnCambiarClaveClicked(object sender, EventArgs e)
    {
        // Navegar al cambio de contraseña
        await Navigation.PushAsync(new CambiarClave());
    }
}