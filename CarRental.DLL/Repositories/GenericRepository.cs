using CarRental.DLL.Entities;
using CarRental.DLL.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>? include = null)
        {
            var query = _dbSet.AsNoTracking();

            if (include != null)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id, Expression<Func<TEntity, object>>? include = null)
        {
            var query = _dbSet.AsNoTracking().Where(x => x.Id == id);

            if (include != null)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
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