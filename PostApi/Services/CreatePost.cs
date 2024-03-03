using Domain.Entities;
using Domain.Interfaces;
using ProfileConnectionLib;
using ProfileConnectionLib.ConnectionServices.Interfaces;
using Services.Intefaces;

namespace Services;

public class CreatePost : ICreatePost
{
    private readonly IStorePost _storePost;
    private readonly ICheckUser _checkUser;
    private readonly IProfileConnectionServcie _profileConnectionServcie;

    public CreatePost(IStorePost storePost, ICheckUser checkUser, IProfileConnectionServcie profileConnectionServcie)
    {
        _storePost = storePost;
        _checkUser = checkUser;
        _profileConnectionServcie = profileConnectionServcie;
    }
    
    public async Task<Guid> CreatePostAsync(Post post)
    {
        // мониторинг, отправим какое-то событие в очередь сообщений
        var res = await post.SaveAsync(_checkUser, _storePost);
        return res;
    }

    public async Task<Post[]> GetPostListAsync()
    {
        var postList = await _storePost.GetAllAsync();
        var userIdList = postList.Select(value => value.UserId).ToArray();
        // Span
        //var userList = await _profileConnectionServcie.GetUserNameListAsync(userIdList);

        return null;
        // return postList.Select(value =>
        // {
        //     
        // });
    }
}