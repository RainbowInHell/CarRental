namespace CarRental.DLL.Interfaces
{
    public interface IGenericRepository<BaseEntity> where BaseEntity : class
    {
        Task<IEnumerable<BaseEntity>> GetAllAsync();
        Task<BaseEntity> GetByIdAsync(int id);
        Task InsertAsync(BaseEntity entity);
        Task UpdateAsync(BaseEntity entity);
        void Delete(BaseEntity entity);
    }
}