using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Application.Contratos
{
    public interface IViagemService
    {
        Task<Viagem> IniciarViagemAsync(Guid motoristaId, int periodo);
        Task<Viagem> FinalizarViagemAsync(Guid viagemId);
        Task<Viagem> GetViagemByIdAsync(Guid viagemId, bool includePresencas = true);
        Task<Viagem> GetViagemAtivaByMotoristaIdAsync(Guid motoristaId);
    }
}