using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Persistence.Contratos
{
    public interface IResponsavelPersist
    {
        Task<Responsavel[]> GetAllResponsaveisAsync(bool includeAlunos = false);
        Task<Responsavel> GetResponsavelByIdAsync(Guid responsavelId, bool includeAlunos = false);
    }
}