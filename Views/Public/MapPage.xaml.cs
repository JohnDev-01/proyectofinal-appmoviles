using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Views.Public
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            InitMap();
        }

        private async void InitMap()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    var position = new Location(location.Latitude, location.Longitude);

                    myMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));

                    var pin = new Pin
                    {
                        Label = "Estoy aquí",
                        Address = "Ubicación actual",
                        Location = position,
                        Type = PinType.Place
                    };

                    myMap.Pins.Add(pin);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo obtener la ubicación: {ex.Message}", "OK");
            }
        }
    }
}
