using CarRental.DLL.Entities;
using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly CarRentalContext context = null;

        public GenericRepository(CarRentalContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                return;
            }

            await context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                return;
            }

            T existing = await context.Set<T>().FindAsync(entity.Id);

            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(entity);
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                return;
            }

            context.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}