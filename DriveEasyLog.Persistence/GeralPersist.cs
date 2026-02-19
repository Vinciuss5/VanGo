using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Persistence.Contexto;
using DriveEasyLog.Persistence.Contratos;

namespace DriveEasyLog.Persistence
{
    public class GeralPersist: IGeralPersist
    {
        private readonly DriveEasyContext _context;

        public GeralPersist(DriveEasyContext context)
        {
        _context = context;
        }

        public void Add<T>(T entity) where T : class => _context.Add(entity);
        public void Update<T>(T entity) where T : class => _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        public void Delete<T>(T entity) where T : class => _context.Remove(entity);
        public void DeleteRange<T>(T[] entityArray) where T : class => _context.RemoveRange(entityArray);

        public async Task<bool> SaveChangesAsync()
        {
        return (await _context.SaveChangesAsync()) > 0;
        }
    }
}