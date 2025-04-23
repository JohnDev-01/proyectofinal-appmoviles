namespace proyectofinal_appmoviles.Models
{
    public class NoticiaDto
    {
        public string id { get; set; } = string.Empty;
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty; // Aunque en el JSON viene como "contenido"
        public string contenido { get; set; } = string.Empty;   // Usamos ambos por compatibilidad
        public string fecha { get; set; } = string.Empty;
        public string foto { get; set; } = string.Empty;

        // Alias para que funcione el binding del XAML
        public string imagen => foto;

        // Alias para compatibilidad con XAML
        public string fecha_publicacion => fecha;
    }

    public class NoticiaResponseDto
    {
        public bool exito { get; set; }
        public List<NoticiaDto> datos { get; set; } = new List<NoticiaDto>();
        public string mensaje { get; set; } = string.Empty;
    }
}
