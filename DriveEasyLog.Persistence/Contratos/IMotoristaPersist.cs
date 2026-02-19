using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Persistence.Contratos
{
    public interface IMotoristaPersist
    {
        Task<Motorista[]> GetAllMotoristasAsync(bool includeVeiculo = false);
        Task<Motorista> GetMotoristaByIdAsync(Guid motoristaId, bool includeVeiculo = false);
    }
}