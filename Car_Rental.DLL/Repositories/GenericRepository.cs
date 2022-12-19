using CarRental.DLL.Entities;
using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly CarRentalContext _context = null;
        private readonly DbSet<T> _dbSet = null;

        public GenericRepository(CarRentalContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                return;
            }

            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                return;
            }

            T existing = await _dbSet.FindAsync(entity.Id);

            if (existing != null)
            {
                _dbSet.Entry(existing).CurrentValues.SetValues(entity);
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                return;
            }

            _dbSet.Remove(entity);
        }
    }
}