using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Models
{
    public class SituacionResponseDto
    {
        public bool Exito { get; set; }
        public List<SituacionDto>? Datos { get; set; }
        public string? Mensaje { get; set; }
    }

    public class SituacionDto
    {
        public string? Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Fecha { get; set; }
        public string? ReportadoPor { get; set; }
    }

}
