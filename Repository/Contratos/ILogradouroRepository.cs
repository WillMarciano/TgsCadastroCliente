using Domain.Entity;

namespace Repository.Contratos
{
    public interface ILogradouroRepository : IGeralRepository
    {
        Task<Logradouro[]?> GetLogradourosByClienteIdAsync(int clienteId);
        Task<Logradouro?> GetLogradouroByIdAsync(int clienteId, int logradouroId);
    }
}
