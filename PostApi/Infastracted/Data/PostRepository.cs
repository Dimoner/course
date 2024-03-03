using Domain.Entities;
using Domain.Interfaces;

namespace Infastracted.Data;

public class PostRepository : IStorePost
{
    public Task<Post[]> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddPost(Post post)
    {
        return Guid.NewGuid();
    }
}