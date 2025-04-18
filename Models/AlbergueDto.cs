using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Models
{
    public class AlbergueResponseDto
    {
        public bool Exito { get; set; }
        public List<AlbergueDto>? Datos { get; set; }
        public string? Mensaje { get; set; }
    }

    public class AlbergueDto
    {
        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Capacidad { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

}
