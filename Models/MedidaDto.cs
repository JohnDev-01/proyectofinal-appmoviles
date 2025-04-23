namespace proyectofinal_appmoviles.Models
{
    public class MedidaDto
    {
        public string id { get; set; } = string.Empty;
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string foto { get; set; } = string.Empty;
    }

    public class MedidaResponseDto
    {
        public bool exito { get; set; }
        public List<MedidaDto> datos { get; set; } = new List<MedidaDto>();
        public string mensaje { get; set; } = string.Empty;
    }
}
