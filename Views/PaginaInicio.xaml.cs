namespace proyectofinal_appmoviles.Views;

public partial class PaginaInicio : ContentPage
{
	public PaginaInicio()
	{
		InitializeComponent();
	}


    private async void ContinuarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginChoicePage());
    }


}