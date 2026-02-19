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
    public class MotoristaPersist : IMotoristaPersist
    {
        private readonly DriveEasyContext _context;
        public MotoristaPersist(DriveEasyContext context) { _context = context; }

        public async Task<Motorista[]> GetAllMotoristasAsync(bool includeVeiculo = false)
        {
            IQueryable<Motorista> query = _context.Motoristas;
            if (includeVeiculo) query = query.Include(m => m.Veiculo);

            return await query.AsNoTracking().OrderBy(m => m.Nome).ToArrayAsync();
        }

        public async Task<Motorista> GetMotoristaByIdAsync(Guid motoristaId, bool includeVeiculo = false)
        {
            IQueryable<Motorista> query = _context.Motoristas;
            if (includeVeiculo) query = query.Include(m => m.Veiculo);
            if (includeVeiculo) query = query.Include(m => m.Alunos);

            return await query.AsNoTracking().FirstOrDefaultAsync(m => m.Id == motoristaId);
        }
    }
}