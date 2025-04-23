using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using proyectofinal_appmoviles.Models;

namespace proyectofinal_appmoviles.Views
{
    public partial class DetalleAlberguePage : ContentPage
    {
        public DetalleAlberguePage(AlbergueDto albergue)
        {
            InitializeComponent();

            lblEdificio.Text = albergue.Edificio;
            lblCiudad.Text = albergue.Ciudad;
            lblCoordinador.Text = $"👤 Coordinador: {albergue.Coordinador}";
            lblTelefono.Text = $"📞 Teléfono: {albergue.Telefono}";
            lblCapacidad.Text = $"🏢 Capacidad: {albergue.Capacidad}";
            lblCodigo.Text = $"🆔 Código: {albergue.Codigo}";
            lblLatLng.Text = $"📍 Lat: {albergue.Lat}, Lng: {albergue.Lng}";

            // Mostrar ubicación en el mapa
            if (double.TryParse(albergue.Lat, out double lat) &&
                double.TryParse(albergue.Lng, out double lng))
            {
                var location = new Location(lat, lng);
                mapaUbicacion.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(1)));

                var pin = new Pin
                {
                    Label = albergue.Edificio,
                    Address = albergue.Ciudad,
                    Type = PinType.Place,
                    Location = location
                };

                mapaUbicacion.Pins.Add(pin);
            }
        }
    }
}
