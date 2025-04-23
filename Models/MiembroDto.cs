namespace proyectofinal_appmoviles.Models
{
    public class MiembroDto
    {
        public string id { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public string cargo { get; set; } = string.Empty;
        public string foto { get; set; } = string.Empty;

        public string NombreCompleto => $"{nombre} {apellido}";
        public string FotoUrl => $"https://adamix.net/defensa_civil/def/fotos_miembros/{foto}";
    }

    public class MiembroResponseDto
    {
        public bool exito { get; set; }
        public List<MiembroDto> datos { get; set; } = new List<MiembroDto>();
        public string mensaje { get; set; } = string.Empty;
    }
}
