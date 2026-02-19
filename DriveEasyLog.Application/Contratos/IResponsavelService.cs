using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Application.Contratos
{
    public interface IResponsavelService
    {
        Task<Responsavel> AddResponsavel(Responsavel model);
        Task<Responsavel> UpdateResponsavel(Guid responsavelId, Responsavel model);
        Task<bool> DeleteResponsavel(Guid responsavelId);
        Task<Responsavel[]> GetAllResponsaveisAsync(bool includeAlunos = false);
        Task<Responsavel> GetResponsavelByIdAsync(Guid responsavelId, bool includeAlunos = false);
    }
}