using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public record ClienteUpdateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres"), MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public required string Nome { get; set; }

    }
}
