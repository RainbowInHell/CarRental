using CarRental.DLL.Entities;
using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly CarRentalContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CarRentalContext context)
        {
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
                throw new ArgumentNullException();
            }

            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}