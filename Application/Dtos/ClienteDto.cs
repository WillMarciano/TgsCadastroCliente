using Domain.Entity;

namespace Application.Dtos
{
    public record ClienteDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public byte[]? Logotipo { get; set; } 
        public List<Logradouro>? Logradouros { get; set; }
        public DateTime? DataRegistro { get; set; }
    }
}
