using Core.Dal.Base;

namespace Domain.Interfaces
{
    /// <summary>
    /// Base repository interface for every other repositories 
    /// that would be designed for a specific entity
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gettng entity by id 
        /// </summary>
        Task<TEntity> GetAsync(Guid id);

        /// <summary>
        /// Get list of entities of a certain size 
        /// starting from a certain point in the db
        /// </summary>
        Task<PageList<TEntity>> GetPageAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Add entity to db
        /// </summary>
        Task<Guid> CreateAsync(TEntity entity);

        /// <summary>
        /// Update or create entity
        /// </summary>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete entity by id
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}
