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
    public class ResponsavelPersist : IResponsavelPersist
    {

        private readonly DriveEasyContext _context;
        public ResponsavelPersist(DriveEasyContext context) { _context = context; }

        public async Task<Responsavel[]> GetAllResponsaveisAsync(bool includeAlunos = false)
        {
            IQueryable<Responsavel> query = _context.Responsaveis;
            if (includeAlunos) query = query.Include(r => r.Alunos);

            return await query.AsNoTracking().OrderBy(r => r.Nome).ToArrayAsync();
        }

        public async Task<Responsavel> GetResponsavelByIdAsync(Guid responsavelId, bool includeAlunos = false)
        {
            IQueryable<Responsavel> query = _context.Responsaveis;
            if (includeAlunos) query = query.Include(r => r.Alunos);

            return await query.AsNoTracking().FirstOrDefaultAsync(r => r.Id == responsavelId);
        }   

    }
}