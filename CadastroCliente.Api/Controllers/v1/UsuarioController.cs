using Application.Contratos;
using Application.Dtos;
using Asp.Versioning;
using CadastroCliente.Api.Controllers.Shared;
using CadastroCliente.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Api.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsuarioController(IUserService userService, ITokenService tokenService) : ApiControllerBase
    {
        private const string ERRORRESPONSE = "Erro ao ao tentar * usuário";

        /// <summary>
        /// Atualiza o token do usuário.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna o token atualizado</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="401">Erro caso usuário não esteja autorizado</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Retorna erros caso ocorram</response>

        [ProducesResponseType(typeof(UserUpdateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("AtualizaToken")]
        public async Task<IActionResult> AtualizaToken()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await userService.GetUserByUserNameAsync(userName);
                if (user == null) return NotFound("Usuário não encontrado!");

                return Ok(
                new UserUpdateDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = tokenService.CreateTokenAsync(user).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Usuário. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Login do usuário via usuário/senha.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="usuarioLogin">Dados de login do usuário</param>
        /// <returns></returns>
        /// <response code="200">Login realizado com sucesso</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="401">Erro caso usuário não esteja autorizado</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto usuarioLogin)
        {
            try
            {
                var user = await userService.GetUserByUserNameAsync(usuarioLogin.Email);
                if (user == null) return Unauthorized("Usuário ou Senha Inválidos");

                var result = await userService.CheckUserPasswordAsync(user, usuarioLogin.Password);
                if (!result.Succeeded) return Unauthorized();

                return Ok(new
                {
                    userName = user.UserName,
                    email = user.Email,
                    token = tokenService.CreateTokenAsync(user).Result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ERRORRESPONSE.Replace("*", "logar o")}: {ex.Message}");
            }

        }


        /// <summary>
        /// Realiza o registro de um novo usuário.
        /// </summary>
        /// <param name="userRegister"></param>
        /// <returns></returns>
        /// <response code="200">Retorna o usuário criado</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("Registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar(UserLoginRegisterDto userRegister)
        {
            try
            {
                if (await userService.UserExistsAsync(userRegister.Email))
                    return BadRequest("Usuário informado já existe!");

                var user = await userService.CreateAccountAsync(userRegister);

                if (user != null)
                    return Ok(new
                    {
                        id = user.Id,
                        userName = user.UserName,
                        email = user.Email,
                        token = tokenService.CreateTokenAsync(user).Result
                    });

                return BadRequest("Usuário não criado, tente novamente mais tarde!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ERRORRESPONSE.Replace("*", "salvar")}: {ex.Message}");
            }
        }


    }
}
