using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;
using Microsoft.Maui.ApplicationModel;
using System;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class AcercaDePage : ContentPage
    {

        public AcercaDePage()
        {
            InitializeComponent();
            BindingContext = new AcercaDeViewModel();
        }
        private async void OnTelegramClicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var link = button.CommandParameter?.ToString();

            if (!string.IsNullOrWhiteSpace(link))
            {
                try
                {
                    await Launcher.Default.OpenAsync(link);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "No se pudo abrir Telegram: " + ex.Message, "OK");
                }
            }
        }


        private void OnPhoneClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string phoneNumber)
            {
                try
                {
                    Launcher.OpenAsync($"tel:{phoneNumber}");
                }
                catch (Exception)
                {
                    // Manejo de error si el dispositivo no puede hacer llamadas
                    DisplayAlert("Error", "No se pudo abrir el marcador.", "OK");
                }
            }
        }

        
        private void OnEmailClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string email)
            {
                try
                {
                    Launcher.OpenAsync(new Uri($"mailto:{email}"));
                }
                catch (Exception)
                {
                    DisplayAlert("Error", "No se pudo abrir la app de correo.", "OK");
                }
            }
        }

    }
}
