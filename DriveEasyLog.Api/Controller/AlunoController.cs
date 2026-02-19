using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DriveEasyLog.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunosService _alunosService;
        public AlunoController(IAlunosService alunosService)
        {
            _alunosService = alunosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var alunos = await _alunosService.GetAllAlunosAsync(true, true);
                if (alunos == null) return NotFound("Nenhum aluno encontrado.");
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar alunos. Erro: {ex.Message}");
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var aluno = await _alunosService.GetAlunoByIdAsync(Id, true, true);
                if (aluno == null) return NotFound("Aluno não encontrado.");
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar aluno. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            
            try
            {
                var aluno = await _alunosService.AddAlunoAsync(model);
                if (aluno == null) return BadRequest("Erro ao adicionar aluno.");
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar aluno. Erro: {ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(Guid Id, [FromBody] Aluno model)
        {
            try
            {
                var aluno = await _alunosService.UpdateAlunoAsync(Id, model);
                if (aluno == null) return BadRequest("Erro ao atualizar aluno.");
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar aluno. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var deleted = await _alunosService.DeleteAlunoAsync(Id);
                if (!deleted) return BadRequest("Erro ao deletar aluno.");
                return Ok("Aluno deletado.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar aluno. Erro: {ex.Message}");
            }
        }
    }
}