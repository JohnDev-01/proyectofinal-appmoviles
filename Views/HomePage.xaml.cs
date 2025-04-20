using proyectofinal_appmoviles.Views.Private;
using proyectofinal_appmoviles.Views.Public;
using System.Threading.Tasks;
using System.Windows.Input;

namespace proyectofinal_appmoviles.Views;

public class BotonItem
{
    public string Texto { get; set; }
}
public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        // Asignar comando general
        IrAComando = new Command<string>(async (texto) =>
        {
            switch (texto)
            {
                case "Noticias Públicas":
                    await Navigation.PushAsync(new NoticiasPage());
                    break;
                case "Servicios":
                    await Navigation.PushAsync(new ServiciosPage());
                    break;
                case "Videos":
                    await Navigation.PushAsync(new VideosPage());
                    break;
                case "Albergues":
                    await Navigation.PushAsync(new AlberguesPage());
                    break;
                case "Medidas Preventivas":
                    await Navigation.PushAsync(new MedidasPage());
                    break;
                case "Miembros":
                    await Navigation.PushAsync(new MiembrosPage());
                    break;
                case "Quiero ser voluntario":
                    await Navigation.PushAsync(new QuieroSerVoluntarioPage());
                    break;
                case "Acerca de":
                    await Navigation.PushAsync(new AcercaDePage());
                    break;
            }
        });

        // Datos fijos
        BotonesCollection.ItemsSource = new List<BotonItem>
        {
            new BotonItem { Texto = "Noticias Públicas" },
            new BotonItem { Texto = "Servicios" },
            new BotonItem { Texto = "Videos" },
            new BotonItem { Texto = "Albergues" },
            new BotonItem { Texto = "Medidas Preventivas" },
            new BotonItem { Texto = "Miembros" },
            new BotonItem { Texto = "Quiero ser voluntario" },
            new BotonItem { Texto = "Acerca de" }
        };

        BindingContext = this;
    }
    public ICommand IrAComando { get; set; }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ValidarEstaLogueado();
        await SolicitarPermisosAsync();
    }
    private void ValidarEstaLogueado()
    {
        var result = Preferences.Get("isLoggedIn", false);
        var userName = Preferences.Get("userName", string.Empty);
        stackOpcionesPrivadas.IsVisible = result;
        lblUserName.Text = $"Hola, {userName}!";
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
    private void OnBotonOpcionClicked(object sender, EventArgs e)
    {
        if (sender is Button boton && boton.Text != null)
        {
            string opcion = boton.Text;

            switch (opcion)
            {
                case "Página 1":
                    // Navega a la página 1
                    //Navigation.PushAsync(new Pagina1());
                    break;
                case "Página 2":
                    // Navega a la página 2
                    //Navigation.PushAsync(new Pagina2());
                    break;
                    // Y así sucesivamente
            }
        }
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new PaginaInicio());
    }

    private async void OnMenuPrivadoClicked(object sender, EventArgs e)
    {
        if (sender is Button boton)
        {
            switch (boton.Text)
            {
                case "📰 Noticias privadas (líneas a seguir)":
                    await Navigation.PushAsync(new NoticiasPrivadasPage());
                    break;
                case "🚨 Reportar situación":
                    await Navigation.PushAsync(new NuevaSituacion());
                    break;
                case "📋 Mis situaciones":
                    await Navigation.PushAsync(new MisSituacionesPage());
                    break;
                case "🗺️ Mapa de situaciones":
                    await Navigation.PushAsync(new MiMapaPage());
                    break;
                case "🔒 Cambiar contraseña":
                    await Navigation.PushAsync(new CambiarClave());
                    break;
            }
        }
    }

}