using Domain.Entity;

namespace Repository.Contratos
{
    public interface IClienteRepository : IGeralRepository
    {
        Task<Cliente?> GetClienteByIdAsync(int clienteId);
    }
}
