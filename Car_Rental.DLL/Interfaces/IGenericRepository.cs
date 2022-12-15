namespace CarRental.DLL.Interfaces
{
    //TODO: Make update after adding the BaseEntiy asbtract class, which will have Id property.
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}