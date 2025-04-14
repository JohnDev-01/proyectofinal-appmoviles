using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Models
{
    public class ServicioResponseDto
    {
        public bool Exito { get; set; }
        public List<ServicioDto>? Datos { get; set; }
        public string? Mensaje { get; set; }
    }

    public class ServicioDto
    {
        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }

}
