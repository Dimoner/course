using Domain.Entities;

namespace Domain.Interfaces;

public interface IStorePost
{
    Task<Post[]> GetAllAsync();
    
    Task<Guid> AddPost(Post post);
}