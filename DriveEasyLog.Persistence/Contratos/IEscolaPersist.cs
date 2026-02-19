using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Application.Contratos
{
    public interface IEscolaPersist
    {
        Task<Escola[]> GetAllEscolasAsync();
        Task<Escola> GetEscolaByIdAsync(Guid escolaId);
    }
}