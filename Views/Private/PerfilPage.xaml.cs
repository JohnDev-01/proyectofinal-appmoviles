using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;

namespace proyectofinal_appmoviles.Views.Private
{
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage(PerfilViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
