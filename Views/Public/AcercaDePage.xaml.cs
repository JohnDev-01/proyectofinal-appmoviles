using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class AcercaDePage : ContentPage
    {
        public ObservableCollection<Miembro> Miembros { get; set; }

        public AcercaDePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadMiembros();
        }

        private void LoadMiembros()
        {
            try
            {
                Miembros = new ObservableCollection<Miembro>
                {
                    new Miembro
                    {
                        Nombre = "Eliezer Palacio Ramos",
                        Matricula = "2023-1009",
                        Cargo = "Dev",
                        Foto = "imge.jpg",
                        Telefono = "+18495813273",
                        TelegramLink = "https://t.me/EliezerPalacioRamos"
                    },
                    new Miembro
                    {
                        Nombre = "Cristal Hernández",
                        Matricula = "2023-0985",
                        Cargo = "Dev",
                        Foto = "imgc.jpg",
                        Telefono = "+18492604310",
                        TelegramLink = "https://t.me/CristalOHR1210"
                    },
                    new Miembro
                    {
                        Nombre = "John Kerlin Silvestre",
                        Matricula = "2023-1192",
                        Cargo = "Dev y Líder",
                        Foto = "imgj.jpg",
                        Telefono = "+18096063232",
                        TelegramLink = "https://t.me/johnkerlin"
                    }
                };

                carousel.ItemsSource = Miembros;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Ocurrió un problema al cargar los miembros: " + ex.Message, "OK");
            }
        }
    }

    public class Miembro
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Cargo { get; set; }
        public string Foto { get; set; }
        public string Telefono { get; set; }
        public string TelegramLink { get; set; }
    }
}
