using CarRental.DLL.Entities;

namespace CarRental.DLL.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task Delete(T entity);
    }
}