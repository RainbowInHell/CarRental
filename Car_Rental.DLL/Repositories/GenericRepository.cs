using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    //TODO: Make update after adding the BaseEntiy asbtract class, which will have Id property.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CarRentalContext context = null;
        private readonly DbSet<T> dbSet = null;

        public GenericRepository()
        {
            context = new CarRentalContext();
            dbSet = context.Set<T>();
        }

        public GenericRepository(CarRentalContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);

            //Will be erased after update
            var Id = entity.GetType().GetProperty("ID").GetValue(entity, null);
            return (int)Id;
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}