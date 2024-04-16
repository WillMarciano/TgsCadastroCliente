namespace Application.Dtos
{
    public class ClienteDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public byte[]? Logotipo { get; set; } 
        public List<LogradouroDto>? Logradouros { get; set; }
        public DateTime? DataRegistro { get; set; }
    }
}
