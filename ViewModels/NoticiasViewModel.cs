using proyectofinal_appmoviles.Models; // Add this line
using proyectofinal_appmoviles.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls; // Ensure this line is correct

namespace proyectofinal_appmoviles.ViewModels
{
    public class NoticiasViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService = new();
        public ObservableCollection<NoticiaModel> Noticias { get; set; } = new();
        public ICommand RefrescarCommand { get; }
        public ICommand SeleccionarNoticiaCommand { get; }

        private bool isCargando;
        public bool IsCargando
        {
            get => isCargando;
            set { isCargando = value; OnPropertyChanged(nameof(IsCargando)); }
        }

        public NoticiasViewModel()
        {
            RefrescarCommand = new Command(async () => await CargarNoticias());
            SeleccionarNoticiaCommand = new Command<NoticiaModel>(async (noticia) => await MostrarDetalle(noticia));
            _ = CargarNoticias();
        }

        public async Task CargarNoticias()
        {
            IsCargando = true;

            var resultado = await _apiService.GetAsync<List<NoticiaModel>>("noticias.php") ?? new List<NoticiaModel>();

            Noticias.Clear();

            if (resultado != null)
            {
                foreach (var noticia in resultado)
                    Noticias.Add(noticia);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudieron cargar las noticias.", "OK");
            }

            IsCargando = false;
        }

        private async Task MostrarDetalle(NoticiaModel noticia)
        {
            if (noticia != null)
            {
                await Application.Current.MainPage.DisplayAlert(noticia.titulo, noticia.contenido, "Cerrar");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string nombre) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
