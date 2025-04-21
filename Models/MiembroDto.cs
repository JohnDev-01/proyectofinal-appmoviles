namespace proyectofinal_appmoviles.Models
{
    public class MiembroDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cargo { get; set; }
        public string foto { get; set; }

        public string NombreCompleto => $"{nombre} {apellido}";
        public string FotoUrl => $"https://adamix.net/defensa_civil/def/fotos_miembros/{foto}";
    }

    public class MiembroResponseDto
    {
        public bool exito { get; set; }
        public List<MiembroDto> datos { get; set; }
        public string mensaje { get; set; }
    }
}
