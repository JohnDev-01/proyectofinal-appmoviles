using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.ViewModels;
using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.ObjectModel;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class AcercaDePage : ContentPage
    {
        public ObservableCollection<Miembro> Miembros { get; set; }

        public AcercaDePage()
        {
            InitializeComponent();
            //BindingContext = new AcercaDeViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMiembrosAsync();
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

            carousel.ItemsSource = Miembros;
        }
        private async void OnTelegramClicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var link = button.CommandParameter?.ToString();

            if (!string.IsNullOrWhiteSpace(link))
            {
                try
                {
                    await Launcher.Default.OpenAsync(link);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "No se pudo abrir Telegram: " + ex.Message, "OK");
                }
            }
        }


        private void OnPhoneClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string phoneNumber)
            {
                try
                {
                    Launcher.OpenAsync($"tel:{phoneNumber}");
                }
                catch (Exception)
                {
                    // Manejo de error si el dispositivo no puede hacer llamadas
                    DisplayAlert("Error", "No se pudo abrir el marcador.", "OK");
                }
            }
        }

        
        private void OnEmailClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string email)
            {
                try
                {
                    Launcher.OpenAsync(new Uri($"mailto:{email}"));
                }
                catch (Exception)
                {
                    DisplayAlert("Error", "No se pudo abrir la app de correo.", "OK");
                }
            }
        }

    }
}
