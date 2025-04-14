using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Models
{
    public class NoticiaResponseDto
    {
        public bool Exito { get; set; }
        public List<NoticiaDto>? Datos { get; set; }
        public string? Mensaje { get; set; }
    }

    public class NoticiaDto
    {
        public string? Id { get; set; }
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public string? Fecha { get; set; }
    }

}
