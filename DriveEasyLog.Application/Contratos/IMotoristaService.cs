using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Application.Contratos
{
    public interface IMotoristaService
    {
        Task<Motorista> AddMotorista(Motorista model);
        Task<Motorista> UpdateMotorista(Guid motoristaId, Motorista model);
        Task<bool> DeleteMotorista(Guid motoristaId);
        Task<Motorista[]> GetAllMotoristasAsync(bool includeVeiculo = false);
        Task<Motorista> GetMotoristaByIdAsync(Guid motoristaId, bool includeVeiculo = false);
    }
}