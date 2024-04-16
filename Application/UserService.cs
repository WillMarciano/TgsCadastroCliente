using Application.Contratos;
using Application.Dtos;
using AutoMapper;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Contratos;

namespace Application
{
    public class UserService(UserManager<User> userManager,
                             SignInManager<User> signInManager,
                             IMapper mapper,
                             IUserRepository userPersist,
                             IClienteService clienteService) : IUserService
    {

        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password)
        {
            try
            {
                var user = await userManager.Users
                             .SingleOrDefaultAsync(user => user.UserName == userUpdateDto.UserName.ToLower());

                return await signInManager.CheckPasswordSignInAsync(user, password, false);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDto?> CreateAccountAsync(UserLoginRegisterDto userRegister)
        {
            try
            {
                var user = mapper.Map<User>(userRegister);
                user.UserName = userRegister.Email;
                var result = await userManager.CreateAsync(user, userRegister.Password);

                if (result.Succeeded)
                {
                    CadastraCliente(user, userRegister.Nome!);
                    var userToReturn = mapper.Map<UserUpdateDto>(user);
                    return userToReturn;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Criar Usuário. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDto> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await userPersist.GetUserByUserNameAsync(userName);
                if (user == null) return null;

                var userUpdateDto = mapper.Map<UserUpdateDto>(user);
                return userUpdateDto;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar Usuário por Username. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            try
            {
                return await userManager.Users
                                         .AnyAsync(user => user.UserName == userName.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar se usuário existe. Erro: {ex.Message}");
            }
        }


        public async Task<bool> CadastraCliente(UserUpdateDto user)
        {
            var u = await userPersist.GetUserByUserNameAsync(user.UserName!);
            if (u == null) return false;

            var cliente = new ClienteDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email!,
                Logotipo = []
            };

            var r = clienteService.AddClienteAsync(u.Id!, cliente!);
            return r != null;

        }

        private void CadastraCliente(User user, string nome)
        {
            var cliente = new ClienteDto
            {
                Id = user.Id,
                Nome = nome,
                Email = user.Email!,
                Logotipo = []
            };

            clienteService.AddClienteAsync(user.Id, cliente);
        }


    }
}
