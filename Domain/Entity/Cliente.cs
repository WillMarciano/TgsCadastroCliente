using Domain.Identity;

namespace Domain.Entity
{
    public class Cliente : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] Logotipo { get; set; } // Representa a imagem como um array de bytes
        public IEnumerable<Logradouro> Logradouros { get; set; }
    }
}
