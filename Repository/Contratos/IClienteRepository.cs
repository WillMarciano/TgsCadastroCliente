using Domain.Entity;

namespace Repository.Contratos
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetClienteByIdAsync(int clienteId);
    }
}
