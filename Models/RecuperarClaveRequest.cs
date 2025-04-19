using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Models
{
    public class RecuperarClaveRequest
    {
        public string cedula { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
    }
}
