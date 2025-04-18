using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.Models;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class AlbergueDetailPage : ContentPage
    {
        public AlbergueDetailPage(AlbergueDto albergue)
        {
            InitializeComponent();
            BindingContext = albergue;
        }
    }
}
