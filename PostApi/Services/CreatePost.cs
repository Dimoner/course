using ProfileDal.Entities;
using Services;

namespace ProfileDal;

public class CreatePost : ICreatePost
{
    private readonly IStorePost _storePost;
    private readonly ICheckUser _checkUser;

    public CreatePost(IStorePost storePost, ICheckUser checkUser)
    {
        _storePost = storePost;
        _checkUser = checkUser;
    }
    
    public async Task<Guid> CreatePostAsync(Post post)
    {
        await _checkUser.CheckUserExistAsync(post.UserId);
        
        var id = await _storePost.AddPost(post);

        return id;
    }
}