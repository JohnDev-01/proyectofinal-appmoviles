using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Maps;

namespace proyectofinal_appmoviles;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
              .UseMauiMaps()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Register services
		builder.Services.AddSingleton<Services.AuthService>();
		
		// Register ViewModels
		builder.Services.AddTransient<ViewModels.InicioViewModel>();
		builder.Services.AddTransient<ViewModels.PerfilViewModel>();
		builder.Services.AddTransient<ViewModels.AjustesViewModel>();
        builder.Services.AddTransient<ViewModels.AcercaDeViewModel>();

        return builder.Build();
	}
}
