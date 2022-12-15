using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CarRentalContext context = null;

        public GenericRepository()
        {
            this.context = new CarRentalContext();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
