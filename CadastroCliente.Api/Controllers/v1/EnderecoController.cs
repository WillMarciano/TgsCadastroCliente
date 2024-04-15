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
    public class EnderecoController(ILogradouroService logradouroService, IMapper mapper) : ApiControllerBase
    {
        private const string ERRORRESPONSE = "Erro ao tentar * endereço";

        /// <summary>
        /// Retorna dados do endereço
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
        [HttpGet("Buscar")]
        public async Task<IActionResult> Buscar()
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
        /// Atualiza Lista de endereços
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Retorna a lista de endereços</response>
        /// <response code="204">Retorna caso não tenha endereços</response>
        /// <response code="401">Retorna caso não esteja autenticado</response>
        /// <response code="500">Retorna caso ocorra um erro interno</response>
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("AtualizarLista")]
        public async Task<IActionResult> AtualizarLista(List<LogradouroDto> model)
        {
            try
            {
                var endereco = await logradouroService.SaveLogradourosAsync(User.GetUserId(), model);
                return endereco == null ? NoContent() : Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ERRORRESPONSE.Replace("*", "atualizar")}: {ex.Message}");
            }
        }

        /// <summary>
        /// Salva ou atualiza um endereço
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
        [HttpPost("Salvar")]
        public async Task<IActionResult> Salvar(LogradouroDto model)
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

        /// <summary>
        /// Delete um endereço
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
        [HttpDelete("Deletar")]
        public async Task<IActionResult> Deletar(int logradouroId)
        {
            try
            {
                var endereco = await logradouroService.DeleteLogradouro(User.GetUserId(), logradouroId);
                return endereco ? Ok() : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                       $"{ERRORRESPONSE.Replace("*", "deletar")}: {ex.Message}");
            }
        }

    }
}
