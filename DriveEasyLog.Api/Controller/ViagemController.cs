using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contexto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveEasyLog.Api.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ViagensController : ControllerBase
    {
        private readonly IViagemService _viagemService;
        private readonly IRotasService _rotasService;
        public ViagensController(DriveEasyContext context, IRotasService rotasService)
        {
            _context = context;
            _rotasService = rotasService;
        }
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
    
    [HttpPost("iniciar-rota-otimizada")]
        public async Task<IActionResult> IniciarRotaOtimizada([FromBody] CoordenadasDto origem)
        {
        // 1. Pega o ID do motorista logado pelo Token JWT
            var motoristaId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // 2. Busca no banco SÓ os alunos que confirmaram que vão hoje
            var alunosConfirmados = await _context.Presencas
                .Include(p => p.Aluno)
                .Where(p => p.MotoristaId == motoristaId && p.ConfirmadoHoje == true)
                .Select(p => p.Aluno.EnderecoOuCoordenada) 
                .ToListAsync();

            if (!alunosConfirmados.Any())
                return BadRequest("Nenhum aluno confirmado para hoje.");

        // 3. O SEGREDO: Chamar um serviço que você vai criar para otimizar
        // Esse serviço vai bater na API do Google e dizer: "Me dê a ordem mais rápida"
            var paradasOtimizadas = await _rotasService.CalcularMelhorOrdem(origem, alunosConfirmados);

        // Salva no banco que a viagem começou e qual é a ordem
        // ... lógica de salvar no banco ...

            return Ok(paradasOtimizadas); // Devolve a lista já na ordem certa!
        }   
    
    }

}