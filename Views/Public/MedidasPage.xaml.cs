using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.ViewModels;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class MedidasPage : ContentPage
    {
        private MedidasViewModel ViewModel => BindingContext as MedidasViewModel;

        public MedidasPage()
        {
            InitializeComponent();
            BindingContext = new MedidasViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel != null)
            {
                ViewModel.Navigation = Navigation;
                if (ViewModel.Medidas.Count == 0)
                {
                    ViewModel.LoadMedidasCommand.Execute(null);
                }
            }
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel == null)
                return;

            var selectedMedida = e.CurrentSelection.Count > 0 ? e.CurrentSelection[0] as MedidaDto : null;
            if (selectedMedida != null)
            {
                ViewModel.SelectMedidaCommand.Execute(selectedMedida);
                ((CollectionView)sender).SelectedItem = null; // Deselect item
            }
        }
    }
}
