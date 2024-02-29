namespace Dal
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
