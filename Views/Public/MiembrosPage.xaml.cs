using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;
using Microsoft.Maui.ApplicationModel;
using System;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class MiembrosPage : ContentPage
    {
        private readonly MiembrosViewModel _viewModel;

        public MiembrosPage()
        {
            InitializeComponent();
            _viewModel = new MiembrosViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadMiembrosAsync();
        }

        private async void OnPhoneClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string phoneNumber && !string.IsNullOrWhiteSpace(phoneNumber))
            {
                try
                {
                    var uri = new Uri($"tel:{phoneNumber}");
                    await Launcher.OpenAsync(uri);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"No se pudo abrir el marcador telefónico: {ex.Message}", "OK");
                }
            }
        }

        private async void OnEmailClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string email && !string.IsNullOrWhiteSpace(email))
            {
                try
                {
                    var uri = new Uri($"mailto:{email}");
                    await Launcher.OpenAsync(uri);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"No se pudo abrir el cliente de correo: {ex.Message}", "OK");
                }
            }
        }
    }
}
