using ProfileDal;
using ProfileDal.Entities;

namespace Services;

public interface ICreatePost
{
    Task<Guid> CreatePostAsync(Post post);
}