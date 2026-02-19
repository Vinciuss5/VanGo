using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Application.Contratos
{
    public interface IAlunosService
    {
        Task<Aluno>AddAlunoAsync(Aluno model);
        Task<Aluno>UpdateAlunoAsync(Guid alunoId, Aluno model);
        Task<bool>DeleteAlunoAsync(Guid alunoId);

        Task<Aluno[]> GetAllAlunosAsync(bool includeEscola = false, bool includeMotorista = false, bool includeResponsavel = false);
        Task<Aluno[]> GetAllAlunosByMotoristaIdAsync(Guid motoristaId);
        Task<Aluno[]> GetAllAlunosByPeriodoAsync(Periodo periodo, bool includeEscola = false, bool includeMotorista = false, bool includeResponsavel = false);
        Task<Aluno> GetAlunoByIdAsync(Guid alunoId, bool includeEscola = false, bool includeMotorista = false, bool includeResponsavel = false);
        
    }
}