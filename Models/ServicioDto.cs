namespace proyectofinal_appmoviles.Models
{
    public class ServicioDto
    {
        public string id { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string foto { get; set; } = string.Empty;

        // Alias para que funcione con el XAML anterior
        public string titulo => nombre;
        public string icono => foto;
    }

    public class ServicioResponseDto
    {
        public bool exito { get; set; }
        public List<ServicioDto> datos { get; set; } = new List<ServicioDto>();
        public string mensaje { get; set; } = string.Empty;
    }
}
