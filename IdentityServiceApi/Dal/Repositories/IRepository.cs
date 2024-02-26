namespace Dal.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> Get(Guid id);
        Task<bool> Create(T item);
        Task<T> Update(T item);
        Task<bool> Delete(Guid id);
    }
}
