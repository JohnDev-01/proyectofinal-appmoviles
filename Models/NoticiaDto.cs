using System;

namespace proyectofinal_appmoviles.Models
{
    public class NoticiaDto
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public string fecha_publicacion { get; set; }
    }

    public class NoticiaResponseDto
    {
        public bool exito { get; set; }
        public List<NoticiaDto> datos { get; set; }
        public string mensaje { get; set; }
    }
}
