using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contratos;

namespace DriveEasyLog.Application
{
    public class ResponsavelService : IResponsavelService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IResponsavelPersist _responsavelPersist;

        public ResponsavelService(IGeralPersist geralPersist, IResponsavelPersist responsavelPersist)
    {
        _geralPersist = geralPersist;
        _responsavelPersist = responsavelPersist;
    }

        public async Task<Responsavel> AddResponsavel(Responsavel model)
    {
        _geralPersist.Add(model);
        if (await _geralPersist.SaveChangesAsync())
            return await _responsavelPersist.GetResponsavelByIdAsync(model.Id, true);
        return null;
    }

        public async Task<Responsavel> UpdateResponsavel(Guid responsavelId, Responsavel model)
    {
        var responsavel = await _responsavelPersist.GetResponsavelByIdAsync(responsavelId, false);
        if (responsavel == null) return null;

        model.Id = responsavelId;
        _geralPersist.Update(model);

        if (await _geralPersist.SaveChangesAsync())
            return await _responsavelPersist.GetResponsavelByIdAsync(model.Id, true);
        return null;
    }

        public async Task<bool> DeleteResponsavel(Guid responsavelId)
    {
        var resp = await _responsavelPersist.GetResponsavelByIdAsync(responsavelId, false);
        if (resp == null) throw new Exception("Responsável não encontrado.");

        _geralPersist.Delete(resp);
        return await _geralPersist.SaveChangesAsync();
    }

        public async Task<Responsavel[]> GetAllResponsaveisAsync(bool includeAlunos = false) =>
        await _responsavelPersist.GetAllResponsaveisAsync(includeAlunos);

        public async Task<Responsavel> GetResponsavelByIdAsync(Guid responsavelId, bool includeAlunos = false) =>
        await _responsavelPersist.GetResponsavelByIdAsync(responsavelId, includeAlunos);
    }
}