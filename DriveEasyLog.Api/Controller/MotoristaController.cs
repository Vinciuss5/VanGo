using Microsoft.AspNetCore.Mvc;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoristasController : ControllerBase
    {
        private readonly IMotoristaService _motoristaService;

        public MotoristasController(IMotoristaService motoristaService)
        {
            _motoristaService = motoristaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var motoristas = await _motoristaService.GetAllMotoristasAsync(true);
                if (motoristas == null) return NotFound("Nenhum motorista encontrado.");
                return Ok(motoristas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var motorista = await _motoristaService.GetMotoristaByIdAsync(id, true);
                if (motorista == null) return NotFound("Motorista não encontrado.");
                return Ok(motorista);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Motorista model)
        {
            try
            {
                var motorista = await _motoristaService.AddMotorista(model);
                if (motorista == null) return BadRequest("Erro ao tentar adicionar motorista.");
                return Created($"/api/motoristas/{motorista.Id}", motorista);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Motorista model)
        {
            try
            {
                var motorista = await _motoristaService.UpdateMotorista(id, model);
                if (motorista == null) return BadRequest("Erro ao tentar atualizar motorista.");
                return Ok(motorista);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }
    }
}