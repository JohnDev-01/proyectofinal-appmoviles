﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Models
{
    public class MiembroResponseDto
    {
        public bool Exito { get; set; }
        public List<MiembroDto>? Datos { get; set; }
        public string? Mensaje { get; set; }
    }

    public class MiembroDto
    {
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Cargo { get; set; }  // Added role property
        public string? Foto { get; set; }   // Added photo/avatar property
        public string? Telegram { get; set; } // Added Telegram contact property
    }
}
