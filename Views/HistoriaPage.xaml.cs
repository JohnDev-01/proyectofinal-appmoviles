using Microsoft.Maui.Controls;

namespace proyectofinal_appmoviles.Views
{
    public partial class HistoriaPage : ContentPage
    {
        public HistoriaPage()
        {
            InitializeComponent();

            // Plantilla HTML para el embed de YouTube
            string htmlSource = @"
            <html>
                <head>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <style>
                        body { margin:0; padding:0; }
                        iframe { display: block; width: 100%; height: 100%; }
                    </style>
                </head>
                <body>
                    <iframe src='https://www.youtube.com/embed/UenHxG_089g?autoplay=0&controls=1'
                            frameborder='0'
                            allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture'
                            allowfullscreen>
                    </iframe>
                </body>
            </html>";

            // Asigna el HTML generado al WebView
            YoutubeVideo.Source = new HtmlWebViewSource { Html = htmlSource };
        }
    }
}
