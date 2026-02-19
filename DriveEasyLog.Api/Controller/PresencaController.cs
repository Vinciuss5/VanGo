using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace DriveEasyLog.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencaService _presencaService;
        public PresencaController(IPresencaService presencaService) { _presencaService = presencaService; }

    [HttpPut("marcar-ausencia/{viagemId}/{alunoId}")]
        public async Task<IActionResult> MarcarAusencia(Guid viagemId, Guid alunoId, [FromBody] string observacao)
        {
            try 
            {
                var sucesso = await _presencaService.MarcarAusenciaAsync(viagemId, alunoId, observacao);
                return sucesso ? Ok("Ausência registrada com sucesso.") : BadRequest("Presença não encontrada.");
            }
            catch (Exception ex) 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }
    [HttpPut("registrar-embarque/{viagemId}/{alunoId}")]
        public async Task<IActionResult> RegistrarEmbarque(Guid viagemId, Guid alunoId)
        {
            try 
            {   
                var sucesso = await _presencaService.RegistrarEmbarqueAsync(viagemId, alunoId);
                return sucesso ? Ok("Embarque registrado!") : BadRequest("Não foi possível registrar o embarque.");
            }
            catch (Exception ex) 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        } 
    }
}