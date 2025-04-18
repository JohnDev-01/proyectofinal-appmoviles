using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.Models;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class MedidaDetailPage : ContentPage
    {
        public MedidaDetailPage()
        {
            InitializeComponent();
        }

        public MedidaDetailPage(MedidaDto medida) : this()
        {
            if (medida != null)
            {
                DescripcionLabel.Text = medida.Descripcion ?? "No hay descripción disponible.";
            }
        }
    }
}
