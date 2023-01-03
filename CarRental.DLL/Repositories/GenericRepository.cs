using CarRental.DLL.Entities;
using CarRental.DLL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly CarRentalContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(CarRentalContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Entry(entity).State = EntityState.Deleted;
        }
    }
}