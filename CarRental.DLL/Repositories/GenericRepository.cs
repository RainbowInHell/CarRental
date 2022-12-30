using CarRental.DLL.Entities;
using CarRental.DLL.Contracts;
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
            return await _dbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Deleted;
        }
    }
}