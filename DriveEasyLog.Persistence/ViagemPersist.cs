using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contexto;
using DriveEasyLog.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace DriveEasyLog.Persistence
{
    public class ViagemPersist : IViagemPersist
    {
        private readonly DriveEasyContext _context;
        public ViagemPersist(DriveEasyContext context) { _context = context; }

        public async Task<Viagem[]> GetAllViagensByMotoristaIdAsync(Guid motoristaId, bool includePresencas = false)
        {
            IQueryable<Viagem> query = _context.Viagens;
    
            if (includePresencas)
                query = query.Include(v => v.Presencas).ThenInclude(p => p.Aluno);

            return await query.AsNoTracking()
                            .Where(v => v.MotoristaId == motoristaId)
                            .OrderByDescending(v => v.Inicio)
                            .ToArrayAsync();
        }   

        public async Task<Viagem> GetViagemByIdAsync(Guid viagemId, bool includePresencas = false)
        {
            IQueryable<Viagem> query = _context.Viagens;

            if (includePresencas)
                query = query.Include(v => v.Presencas).ThenInclude(p => p.Aluno);

            return await query.AsNoTracking().FirstOrDefaultAsync(v => v.Id == viagemId);
        }

        public async Task<Viagem> GetViagemAtivaByMotoristaIdAsync(Guid motoristaId)
        {
            IQueryable<Viagem> query = _context.Viagens;

    
            return await query
                .Include(v => v.Presencas)
                .ThenInclude(p => p.Aluno)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.MotoristaId == motoristaId && v.Finalizada == false);
        }
    }
}