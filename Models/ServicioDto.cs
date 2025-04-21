namespace proyectofinal_appmoviles.Models
{
    public class ServicioDto
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string icono { get; set; }
    }

    public class ServicioResponseDto
    {
        public bool exito { get; set; }
        public List<ServicioDto> datos { get; set; }
        public string mensaje { get; set; }
    }
}
