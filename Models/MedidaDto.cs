namespace proyectofinal_appmoviles.Models
{
    public class MedidaDto
{
    public string id { get; set; }
    public string titulo { get; set; }
    public string Descripcion { get; set; }
    public string imagen { get; set; }
}


    public class MedidaResponseDto
    {
        public bool exito { get; set; }
        public List<MedidaDto> datos { get; set; }
        public string mensaje { get; set; }
    }
}
