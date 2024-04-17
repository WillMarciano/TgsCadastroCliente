using Application.Contratos;
using Application.Dtos;
using Asp.Versioning;
using AutoMapper;
using CadastroCliente.Api.Controllers.Shared;
using CadastroCliente.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Api.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    public class EnderecoController(ILogradouroService logradouroService) : ApiControllerBase
    {
        private const string ERRORRESPONSE = "Erro ao tentar * endereço";

        /// <summary>
        /// Busca lista de endereços do Cliente
        /// </summary>
        /// 
        /// <returns></returns>
        /// <response code="200">Retorna a lista de endereços</response>
        /// <response code="204">Retorna caso não tenha endereços</response>
        /// <response code="401">Retorna caso não esteja autenticado</response>
        /// <response code="500">Retorna caso ocorra um erro interno</response>
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("BuscarEnderecos")]

        public async Task<IActionResult> BuscarEnderecos()
        {
            try
            {
                var endereco = await logradouroService.GetAllLogradourosAsync(User.GetUserId());
                return endereco == null || endereco.Count() < 1 ? NoContent() : Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ERRORRESPONSE.Replace("*", "recuperar")}: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca Endeço por Id
        /// </summary>
        /// 
        /// <returns></returns>
        /// <param name="logradouroId"></param>
        /// <response code="200">Retorna a lista de endereços</response>
        /// <response code="204">Retorna caso não tenha endereços</response>
        /// <response code="401">Retorna caso não esteja autenticado</response>
        /// <response code="500">Retorna caso ocorra um erro interno</response>
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("BuscarEndereco/{logradouroId}")]
        public async Task<IActionResult> BuscarEndereco(int logradouroId)
        {
            try
            {
                var endereco = await logradouroService.GetLogradouroByIdAsync(User.GetUserId(), logradouroId);
                return endereco == null ? NoContent() : Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                       $"{ERRORRESPONSE.Replace("*", "recuperar")}: {ex.Message}");
            }
        }   

        /// <summary>
        /// Deleta um endereço
        /// </summary>
        /// <param name="logradouroId"></param>
        /// <returns></returns>
        /// <response code="200">Retorna Ok</response>
        /// <response code="204">Retorna NoContent</response>
        /// <response code="401">Retorna Unauthorized</response>
        /// <response code="500">Retorna InternalServerError</response>
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeletarEndereco/{logradouroId}")]
        public async Task<IActionResult> DeletarEndereco(int logradouroId)
        {
            try
            {
                var endereco = await logradouroService.DeleteLogradouro(User.GetUserId(), logradouroId);
                return endereco ? Ok(new { message = "Deletado" }) : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                       $"{ERRORRESPONSE.Replace("*", "deletar")}: {ex.Message}");
            }
        }

        /// <summary>
        /// Salvar ou atualiza endereço
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Retorna o endereço</response>
        /// <response code="204">Retorna caso não tenha endereços</response>
        /// <response code="401">Retorna caso não esteja autenticado</response>
        /// <response code="500">Retorna caso ocorra um erro interno</response>
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("SalvarEndereco")]
        public async Task<IActionResult> SalvarEndereco(LogradouroDto model)
        {
            try
            {
                var endereco = await logradouroService.SaveLogradouro(User.GetUserId(), model);
                return endereco == null ? NoContent() : Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                       $"{ERRORRESPONSE.Replace("*", "salvar")}: {ex.Message}");
            }
        }
    }
}
