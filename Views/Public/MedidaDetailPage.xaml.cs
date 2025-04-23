using proyectofinal_appmoviles.Models;

namespace proyectofinal_appmoviles.Views;

public partial class DetalleMedidaPage : ContentPage
{
    public DetalleMedidaPage(MedidaDto medida)
    {
        InitializeComponent();

        lblTitulo.Text = medida.titulo;
        lblDescripcion.Text = medida.descripcion;
        imgMedida.Source = medida.foto;
    }
}
