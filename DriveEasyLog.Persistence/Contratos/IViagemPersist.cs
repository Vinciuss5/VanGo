using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Persistence.Contratos
{
    public interface IViagemPersist
    {
        Task<Viagem[]> GetAllViagensByMotoristaIdAsync(Guid motoristaId, bool includePresencas = false);
        Task<Viagem> GetViagemByIdAsync(Guid viagemId, bool includePresencas = false);
        Task<Viagem> GetViagemAtivaByMotoristaIdAsync(Guid motoristaId);

    }
}