using Core.Dal.Base;
using Dal.Users;

namespace Dal
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Guid id);
        Task<PageList<T>> GetPageAsync(int pageNumber, int pageSize);
        Task<Guid> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
