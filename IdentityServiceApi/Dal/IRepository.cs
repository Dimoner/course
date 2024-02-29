namespace Dal
{
    public interface IRepository<T> where T : class
    {
        Task<T?> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Create(T item);
        Task<T> Update(T item);
        Task<bool> Delete(Guid id);
    }
}
