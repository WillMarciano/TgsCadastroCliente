using Application.Dtos;

namespace Application.Contratos
{
    public interface ILogradouroService
    {
        Task<IEnumerable<LogradouroDto>?> GetAllLogradourosAsync(int userId);
        Task<LogradouroDto?> GetLogradouroByIdAsync(int userId, int logradouroId);
        Task<bool> DeleteLogradouro(int userId, int logradouroId);
        Task<LogradouroDto> SaveLogradouro(int userId, LogradouroDto model);
        Task<List<LogradouroDto>> SaveLogradourosAsync(int userId, List<LogradouroDto> model);
    }
}
