using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;

namespace proyectofinal_appmoviles.Views.Private
{
    public partial class AjustesPage : ContentPage
    {
        public AjustesPage(AjustesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
