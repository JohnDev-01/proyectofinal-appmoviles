using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.ViewModels
{
    public class AcercaDeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Miembro> Miembros { get; set; }

        public AcercaDeViewModel()
        {

            Miembros = new ObservableCollection<MiembroDto>();
        }

        public async Task LoadMiembrosAsync()
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
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
