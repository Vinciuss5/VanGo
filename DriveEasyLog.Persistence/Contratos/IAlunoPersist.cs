using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Persistence.Contratos
{
    public interface IAlunoPersist
    {
        Task<Aluno[]> GetAllAlunosAsync(bool includeEscola = false, bool includeMotorista = false, bool includeResponsavel = false);
        Task<Aluno[]> GetAllAlunosByMotoristaIdAsync(Guid motoristaId);
        Task<Aluno[]> GetAllAlunosByPeriodoAsync(Periodo periodo, bool includeEscola = false, bool includeMotorista = false, bool includeResponsavel = false);
        Task<Aluno> GetAlunoByIdAsync(Guid alunoId, bool includeFull = false);
    }
}