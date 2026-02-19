namespace DriveEasyLog.Persistence;

using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contexto;
using DriveEasyLog.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

public class AlunoPersist : IAlunoPersist
{
    private readonly DriveEasyContext _context;

    public AlunoPersist(DriveEasyContext context)
    {
        _context = context;
    }
    public async Task<Aluno[]> GetAllAlunosAsync(bool includeEscola = false, bool includeResponsavel = false, bool includeMotorista = false)
    {
        IQueryable<Aluno> query = _context.Alunos;

        if (includeResponsavel) query = query.Include(a => a.Responsavel);
        if (includeEscola) query = query.Include(a => a.Escola);
        if (includeMotorista) query = query.Include(a => a.Motorista);

        query = query.AsNoTracking().OrderBy(a => a.Nome);

        return await query.ToArrayAsync();
    }

    public async Task<Aluno[]> GetAllAlunosByMotoristaIdAsync(Guid motoristaId)
    {
        IQueryable<Aluno> query = _context.Alunos
            .Where(a => a.MotoristaId == motoristaId);

        return await query.AsNoTracking().ToArrayAsync();
    }

    public async Task<Aluno[]> GetAllAlunosByPeriodoAsync(Periodo periodo, bool includeEscola = false, bool includeResponsavel = false, bool includeMotorista = false)
    {
        IQueryable<Aluno> query = _context.Alunos;

        if (includeResponsavel) query = query.Include(a => a.Responsavel);
        if (includeEscola) query = query.Include(a => a.Escola);
        if (includeMotorista) query = query.Include(a => a.Motorista);

        query = query.Where(a => a.Periodo == periodo)
                     .AsNoTracking()
                     .OrderBy(a => a.Nome);

        return await query.ToArrayAsync();
    }

    public async Task<Aluno> GetAlunoByIdAsync(Guid alunoId, bool includeFull = false)
    {
    IQueryable<Aluno> query = _context.Alunos;
    
        if (includeFull)
        {
            query = query.Include(a => a.Responsavel)
                         .Include(a => a.Escola)
                         .Include(a => a.Motorista);
        }
    
    return await query.AsNoTracking() // Isso evita conflito de ID no banco durante o Update
                      .FirstOrDefaultAsync(a => a.Id == alunoId);
    }   
}