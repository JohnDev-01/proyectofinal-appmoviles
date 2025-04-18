using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;
using proyectofinal_appmoviles.Models;
using System;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class AlberguesPage : ContentPage
    {
        private readonly AlberguesViewModel _viewModel;

        public AlberguesPage()
        {
            InitializeComponent();
            _viewModel = new AlberguesViewModel();
            BindingContext = _viewModel;
        }

        private async void OnVerMapaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAlbergue = e.CurrentSelection.FirstOrDefault() as AlbergueDto;
            if (selectedAlbergue == null)
                return;

            // Clear selection
            ((Microsoft.Maui.Controls.CollectionView)sender).SelectedItem = null;

            // Navigate to detail page
            await Navigation.PushAsync(new AlbergueDetailPage(selectedAlbergue));
        }
    }
}
