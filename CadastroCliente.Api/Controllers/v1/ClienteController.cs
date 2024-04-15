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
    public class ClienteController(IClienteService clienteService, IUserService userService) : ApiControllerBase
    {
        private const string ERRORRESPONSE = "Erro ao ao tentar * cliente";

        /// <summary>
        /// Retorna dados do cliente
        /// </summary>
        /// 
        /// <returns></returns>
        [HttpGet("GetCliente")]
        public async Task<IActionResult> GetCliente()
        {
            try
            {
                var cliente = await clienteService.GetClienteByIdAsync(User.GetUserId());
                return cliente == null ? NoContent() : Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ERRORRESPONSE.Replace("*", "recuperar")}: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza dados do cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("AtualizaCliente")]
        public async Task<IActionResult> AtualizaCliente(ClienteUpdateDto model)
        {
            try
            {
                var cliente = await clienteService.UpdateCliente(User.GetUserId(), model);
                return cliente == null ? NoContent() : Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ERRORRESPONSE.Replace("*", "atualizar")}: {ex.Message}");
            }
        }
    }
}
