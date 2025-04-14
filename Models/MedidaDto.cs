using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Models
{
    public class MedidaResponseDto
    {
        public bool Exito { get; set; }
        public List<MedidaDto>? Datos { get; set; }
        public string? Mensaje { get; set; }
    }

    public class MedidaDto
    {
        public string? Id { get; set; }
        public string? Descripcion { get; set; }
    }

}
