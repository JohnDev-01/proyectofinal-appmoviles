using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class NoticiasPage : ContentPage
    {
        private NoticiasViewModel viewModel;

        public NoticiasPage()
        {
            InitializeComponent();
            viewModel = new NoticiasViewModel();
            BindingContext = viewModel; // Ensure the ViewModel is imported
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.CargarNoticias(); // Fetch news articles when the page appears
        }
    }
}
