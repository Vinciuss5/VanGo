using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Persistence.Contexto;
using DriveEasyLog.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace DriveEasyLog.Application
{
    public class PresencaService : IPresencaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly DriveEasyContext _context;

        public PresencaService(IGeralPersist geralPersist, DriveEasyContext context)
        {
            _geralPersist = geralPersist;
            _context = context;
        }
        public async Task<bool> MarcarAusenciaAsync(Guid viagemId, Guid alunoId, string observacao)
        {
            var presenca = await _context.Presencas
                .FirstOrDefaultAsync(p => p.ViagemId == viagemId && p.AlunoId == alunoId);

            if (presenca == null)
                return false;

            presenca.VaiHoje = false;
            presenca.Observacao = observacao;
            presenca.Confirmado = DateTime.UtcNow;  

            _geralPersist.Update(presenca);
            return await _geralPersist.SaveChangesAsync();
        }
        public async Task<bool> RegistrarEmbarqueAsync(Guid viagemId, Guid alunoId)
        {
            var presenca = await _context.Presencas
                .FirstOrDefaultAsync(p => p.ViagemId == viagemId && p.AlunoId == alunoId);

            if (presenca == null || !presenca.VaiHoje) // Não embarca se estiver marcado como ausente
                return false;

            presenca.Embarcou = true;
            presenca.HorarioEmbarque = DateTime.Now;

            _geralPersist.Update(presenca);
            return await _geralPersist.SaveChangesAsync();
        }    
    }
}