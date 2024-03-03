using Domain.Entities;

namespace Services.Intefaces;

public interface ICreatePost
{
    Task<Guid> CreatePostAsync(Post post);
    
    Task<Post[]> GetPostListAsync();
}