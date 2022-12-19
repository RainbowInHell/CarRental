using CarRental.DLL.Entities;

namespace CarRental.DLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}