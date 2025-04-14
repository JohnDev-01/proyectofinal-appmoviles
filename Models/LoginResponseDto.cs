using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Models
{
    public class LoginResponseDto
    {
        public bool Exito { get; set; }
        public string? Mensaje { get; set; }
        public UsuarioDto? Datos { get; set; }
    }

    public class UsuarioDto
    {
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Token { get; set; }
    }

}
