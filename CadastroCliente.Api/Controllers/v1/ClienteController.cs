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
        /// <returns></returns>
        /// <response code="200">Cliente recuperado com sucesso</response>
        /// <response code="201">Cliente não encontrado</response>
        /// <response code="204">Cliente não encontrado</response>
        /// <response code="400">Erro ao recuperar cliente</response>
        /// <response code="401">Erro usuário não autorizado</response>
        /// <response code="500">Erro ao recuperar cliente</response>
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("Buscar")]
        public async Task<IActionResult> Buscar()
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
        /// Atualiza dados do nome e logotipo do cliente
        /// </summary>
        /// <param name="model"></param>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        /// <response code="200">Cliente atualizado com sucesso</response>
        /// <response code="204">Cliente não encontrado</response>
        /// <response code="401">Erro usuário não autorizado</response>
        /// <response code="500">Erro ao atualizar cliente</response>
        [ProducesResponseType(typeof(ClienteUpdateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar([FromForm] ClienteUpdateDto model, IFormFile? uploadedFile)
        {
            try
            {
                // transforma a imagem em bytes
                if (uploadedFile != null)
                    model.Logotipo = GetBytesFromImage(uploadedFile);                

                var cliente = await clienteService.UpdateCliente(User.GetUserId(), model);
                return cliente == null ? NoContent() : Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ERRORRESPONSE.Replace("*", "atualizar")}: {ex.Message}");
            }
        }

        private byte[] GetBytesFromImage(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }
            return fileBytes;
        }


        /// <summary>
        /// Retorna logotipo do cliente
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Logotipo recuperado com sucesso</response>
        /// <response code="204">Logotipo não encontrado</response>
        /// <response code="401">Erro usuário não autorizado</response>
        /// <response code="500">Erro ao recuperar logotipo</response>
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("Logotipo")]
        public async Task<IActionResult> Logotipo()
        {
            try
            {
                var logo = await clienteService.GetCustomerLogo(User.GetUserId());
                if (logo == null || logo.Length == 0)
                    return NoContent();

                var stream = new MemoryStream(logo);
                var file = new FormFile(stream, 0, logo.Length, "logo", "logo.jpg");
                return File(file.OpenReadStream(), "image/jpeg");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                       $"{ERRORRESPONSE.Replace("*", "recuperar")}: {ex.Message}");
            }
        }
    }
}
