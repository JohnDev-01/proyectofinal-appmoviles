using proyectofinal_appmoviles.Views;

namespace proyectofinal_appmoviles;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new LoginChoicePage();
	}

	//protected override Window CreateWindow(IActivationState? activationState)
	//{
	//	return new Window(new AppShell());
	//}
}