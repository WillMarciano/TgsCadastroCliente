using Application.Dtos;

namespace Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(UserUpdateDto userUpdate);
    }
}
