using Application.Dtos;

namespace Application.Contratos
{
    public interface IClienteService
    {
        Task<ClienteDto?> AddClienteAsync(int userId, ClienteDto model);
        Task<ClienteDto?> UpdateClienteAsync(int userId, ClienteUpdateDto model);
        Task<bool> SaveLogoAsync(int userId, LogotipoDto model);
        Task<ClienteDto?> GetClienteByIdAsync(int userId);
        Task<byte[]?> GetLogoAsync(int id);
    }
}
