using Microsoft.AspNetCore.Mvc;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsaveisController : ControllerBase
    {
        private readonly IResponsavelService _responsavelService;

        public ResponsaveisController(IResponsavelService responsavelService)
        {
            _responsavelService = responsavelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var responsaveis = await _responsavelService.GetAllResponsaveisAsync(true);
                if (responsaveis == null) return NotFound("Nenhum responsável encontrado.");
                return Ok(responsaveis);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Responsavel model)
        {
            try
            {
                var responsavel = await _responsavelService.AddResponsavel(model);
                if (responsavel == null) return BadRequest("Erro ao tentar adicionar responsável.");
                return Ok(responsavel);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }
    }
}