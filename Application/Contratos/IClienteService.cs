using Application.Dtos;

namespace Application.Contratos
{
    public interface IClienteService
    {
        Task<ClienteDto?> AddCliente(int userId, ClienteDto model);
        Task<ClienteDto?> UpdateCliente(int userId, ClienteUpdateDto model);
        Task<ClienteDto?> GetClienteByIdAsync(int userId);
        Task<byte[]> GetCustomerLogo(int id);
    }
}
