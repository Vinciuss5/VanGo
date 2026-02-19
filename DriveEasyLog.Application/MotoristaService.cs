using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contratos;

namespace DriveEasyLog.Application
{
    public class MotoristaService : IMotoristaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMotoristaPersist _motoristaPersist;

        public MotoristaService(IGeralPersist geralPersist, IMotoristaPersist motoristaPersist)
    {
        _geralPersist = geralPersist;
        _motoristaPersist = motoristaPersist;
    }

        public async Task<Motorista> AddMotorista(Motorista model)
    {
        _geralPersist.Add(model);
        if (await _geralPersist.SaveChangesAsync())
            return await _motoristaPersist.GetMotoristaByIdAsync(model.Id, true);
        return null;
    }

        public async Task<Motorista> UpdateMotorista(Guid motoristaId, Motorista model)
    {
        var motorista = await _motoristaPersist.GetMotoristaByIdAsync(motoristaId, false);
        if (motorista == null) return null;

        model.Id = motoristaId;
        _geralPersist.Update(model);

        if (await _geralPersist.SaveChangesAsync())
            return await _motoristaPersist.GetMotoristaByIdAsync(model.Id, true);
        return null;
    }

        public async Task<bool> DeleteMotorista(Guid motoristaId)
    {
        var motorista = await _motoristaPersist.GetMotoristaByIdAsync(motoristaId, false);
        if (motorista == null) throw new Exception("Motorista não encontrado.");

        _geralPersist.Delete(motorista);
        return await _geralPersist.SaveChangesAsync();
    }

        public async Task<Motorista[]> GetAllMotoristasAsync(bool includeVeiculo = false) =>
        await _motoristaPersist.GetAllMotoristasAsync(includeVeiculo);

        public async Task<Motorista> GetMotoristaByIdAsync(Guid motoristaId, bool includeVeiculo = false) =>
        await _motoristaPersist.GetMotoristaByIdAsync(motoristaId, includeVeiculo);
    }
}