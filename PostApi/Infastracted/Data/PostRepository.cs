using ProfileDal.Entities;

namespace ProfileDal;

public class PostRepository : IStorePost
{
    public async Task<Guid> AddPost(Post post)
    {
        return Guid.NewGuid();
    }
}