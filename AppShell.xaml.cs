using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.Services;
using proyectofinal_appmoviles.ViewModels;
using proyectofinal_appmoviles.Views;
using proyectofinal_appmoviles.Views.Private;

namespace proyectofinal_appmoviles;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        // Register routes
        Routing.RegisterRoute("historia", typeof(HistoriaPage));

        // Get services via dependency injection
        var authService = Handler?.MauiContext?.Services.GetService<AuthService>();
        var perfilViewModel = Handler?.MauiContext?.Services.GetService<PerfilViewModel>();
        var ajustesViewModel = Handler?.MauiContext?.Services.GetService<AjustesViewModel>();

        if (authService?.UsuarioAutenticado == true)
        {
            if (perfilViewModel != null)
            {
                Items.Add(new FlyoutItem
                {
                    Title = "Perfil",
                    Icon = "user.png",
                    Items = { new ShellContent { Content = new PerfilPage(perfilViewModel) } }
                });
            }

            if (ajustesViewModel != null)
            {
                Items.Add(new FlyoutItem
                {
                    Title = "Ajustes", 
                    Icon = "settings.png",
                    Items = { new ShellContent { Content = new AjustesPage(ajustesViewModel) } }
                });
            }
        }
    }
}
