public class AlbergueDto
{
    public string Ciudad { get; set; } = string.Empty;
    public string Codigo { get; set; } = string.Empty;
    public string Edificio { get; set; } = string.Empty;
    public string Coordinador { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Capacidad { get; set; } = string.Empty;
    public string Lat { get; set; } = string.Empty;
    public string Lng { get; set; } = string.Empty;
}

public class AlbergueResponseDto
{
    public bool Exito { get; set; }
    public List<AlbergueDto> Datos { get; set; } = new();
    public string Mensaje { get; set; } = string.Empty;
}
