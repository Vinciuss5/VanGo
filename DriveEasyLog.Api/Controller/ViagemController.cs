using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DriveEasyLog.Api.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
public class ViagensController : ControllerBase
    {
        private readonly IViagemService _viagemService;
        public ViagensController(IViagemService viagemService) { _viagemService = viagemService; }

    [HttpPost("iniciar/{motoristaId}/{periodo}")]
        public async Task<IActionResult> Iniciar(Guid motoristaId, int periodo)
        {
            var viagem = await _viagemService.IniciarViagemAsync(motoristaId, periodo);
            return viagem != null ? Ok(viagem) : BadRequest("Erro ao iniciar viagem.");
        }

    [HttpPut("finalizar/{id}")]
        public async Task<IActionResult> Finalizar(Guid id)
        {
            var viagem = await _viagemService.FinalizarViagemAsync(id);
            return viagem != null ? Ok(viagem) : BadRequest("Erro ao finalizar viagem.");
        }

    [HttpGet("ativa/{motoristaId}")]
        public async Task<IActionResult> GetAtiva(Guid motoristaId)
        {
            try
            {
                var viagem = await _viagemService.GetViagemAtivaByMotoristaIdAsync(motoristaId);
                if (viagem == null) return NotFound("Nenhuma viagem em andamento.");
                return Ok(viagem);
            }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
        }
}
    }
}