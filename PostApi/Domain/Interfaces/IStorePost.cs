using ProfileDal.Entities;

namespace ProfileDal;

public interface IStorePost
{ 
    Task<Guid> AddPost(Post post);
}