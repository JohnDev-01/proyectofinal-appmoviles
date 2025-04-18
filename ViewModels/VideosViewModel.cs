using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace proyectofinal_appmoviles.ViewModels
{
    public class VideosViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService = new();
        public ObservableCollection<VideoDto> Videos { get; set; } = new();
        public ICommand RefrescarCommand { get; }
        public ICommand SeleccionarVideoCommand { get; }

        private bool isCargando;
        public bool IsCargando
        {
            get => isCargando;
            set { isCargando = value; OnPropertyChanged(nameof(IsCargando)); }
        }

        public VideosViewModel()
        {
            RefrescarCommand = new Command(async () => await CargarVideos());
            SeleccionarVideoCommand = new Command<VideoDto>(async (video) => await ReproducirVideo(video));
            _ = CargarVideos();
        }

        public async Task CargarVideos()
        {
            IsCargando = true;

            try
            {
                var resultado = await _apiService.GetVideosAsync() ?? new System.Collections.Generic.List<VideoDto>();

                Videos.Clear();

                if (resultado != null)
                {
                    foreach (var video in resultado)
                    {
                        if (video != null)
                        {
                            video.titulo ??= "Sin título";
                            video.fecha ??= "Sin fecha";
                            video.miniatura ??= string.Empty;
                            video.url ??= string.Empty;
                            Videos.Add(video);
                        }
                    }
                }
                else
                {
                    await Application.Current!.MainPage!.DisplayAlert("Error", "No se pudieron cargar los videos.", "OK");
                }
            }
            catch (System.Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", $"Error cargando videos: {ex.Message}", "OK");
            }
            finally
            {
                IsCargando = false;
            }
        }

        private async Task ReproducirVideo(VideoDto video)
        {
            if (video != null && !string.IsNullOrEmpty(video.url))
            {
                try
                {
                    // Try to open the video URL internally or redirect to YouTube app/browser
                    await Launcher.Default.OpenAsync(video.url);
                }
                catch (System.Exception ex)
                {
                    await Application.Current!.MainPage!.DisplayAlert("Error", $"No se pudo reproducir el video: {ex.Message}", "OK");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string nombre) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
