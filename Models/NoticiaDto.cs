using System;

namespace proyectofinal_appmoviles.Models
{
    public class NoticiaModel
    {
        public int id { get; set; }
        public required string titulo { get; set; }
        public required string fecha { get; set; }
        public required string contenido { get; set; }
        public required string imagen { get; set; }
    }
}
