namespace Domain.Entity
{
    public class Logradouro : Base
    {
        public string Endereco { get; set; }
        public int ClienteId { get; set; } // Chave estrangeira para Cliente
        public Cliente Cliente { get; set; } // Propriedade de navegação para o Cliente
    }
}