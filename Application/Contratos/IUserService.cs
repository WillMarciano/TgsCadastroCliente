using Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Contratos
{
    public interface IUserService
    {
        Task<bool> UserExistsAsync(string userName);
        Task<UserUpdateDto> GetUserByUserNameAsync(string userName);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password);
        Task<UserUpdateDto?> CreateAccountAsync(UserLoginRegisterDto userRegister);
    }
}
