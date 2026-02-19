using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DriveEasyLog.Persistence
{
    public class EscolaPersist : IEscolaPersist
    {
        private readonly DriveEasyContext _context;
        public EscolaPersist(DriveEasyContext context) { _context = context; }

        public async Task<Escola[]> GetAllEscolasAsync() => 
        await _context.Escolas.AsNoTracking().OrderBy(e => e.Nome).ToArrayAsync();

        public async Task<Escola> GetEscolaByIdAsync(Guid escolaId) => 
        await _context.Escolas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == escolaId);
    }
}
