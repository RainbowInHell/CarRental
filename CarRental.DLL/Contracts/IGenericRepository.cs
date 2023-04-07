using CarRental.DLL.Entities;
using System.Linq.Expressions;

namespace CarRental.DLL.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>? include = null);
        Task<TEntity> GetByIdAsync(int id, Expression<Func<TEntity, object>>? include = null);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}