using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GaraApp.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GaraDbContext _context;
        protected readonly DbSet<T> _db;

        public GenericRepository(GaraDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public Task<List<T>> GetAllAsync() => _db.AsNoTracking().ToListAsync();

        public Task<T?> GetByIdAsync(int id) => _db.FindAsync(id).AsTask();

        public Task AddAsync(T entity) => _db.AddAsync(entity).AsTask();

        public void Update(T entity) => _db.Update(entity);

        public void Remove(T entity) => _db.Remove(entity);

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
