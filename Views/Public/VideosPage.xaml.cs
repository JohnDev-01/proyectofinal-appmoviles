using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class VideosPage : ContentPage
    {
        private VideosViewModel viewModel;

        public VideosPage()
        {
            InitializeComponent();
            viewModel = new VideosViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await viewModel.CargarVideos();
            }
            catch (System.Exception ex)
            {
                await DisplayAlert("Error", $"Error loading videos: {ex.Message}", "OK");
            }
        }
    }
}
