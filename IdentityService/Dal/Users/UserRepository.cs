using System.Collections.Concurrent;
using IdentityDal.Users.Interfaces;
using IdentityDal.Users.Models;

namespace IdentityDal.Users;

/// <inheritdoc />
internal class UserRepository : IUserRepository
{
    private static readonly ConcurrentDictionary<Guid, UserDal> UserStore = new();
    private static readonly List<FriendDal> FriendsStore = new();
    
    public async Task<Guid> CreateUserAsync(UserDal user)
    {
        if (UserStore.TryAdd(user.Id, user))
        {
            return user.Id;
        }

        throw new Exception("Пользователь уже существует");
    }

    public async Task<UserDal> GetUserByIdAsync(Guid id)
    {
        if (UserStore.TryGetValue(id, out var model))
        {
            return model;
        }

        throw new Exception("Пользователь не существует");
    }

    public async Task<UserDal> GetUserByUsernameAsync(string username)
    {
        var user = UserStore.Values.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            return user;
        }
        
        throw new Exception("Пользователь не существует");
    }

    public async Task<ICollection<UserDal>> GetUserFriendsAsync(Guid userId)
    {
        var result = new List<UserDal>();
        if (UserStore.ContainsKey(userId))
        {
            return FriendsStore
                .Where(f => f.User1Id == userId || f.User2Id == userId)
                .Select(f => f.User1Id == userId ? UserStore[f.User2Id] : UserStore[f.User1Id])
                .ToList();
        }

        throw new Exception("Пользователя не существует");
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        if (UserStore.TryRemove(userId, out var model))
        {
            return;
        }
        
        throw new Exception("Пользователя не существует");
    }

    public async Task<UserDal> UpdateUser(UserDal updatedModel)
    {
        if (UserStore.TryGetValue(updatedModel.Id, out var currentModel))
        {
            currentModel.AvatarUrl = updatedModel.AvatarUrl;
            currentModel.Username = updatedModel.Username;
            currentModel.Description = updatedModel.Description;
            currentModel.Email = updatedModel.Email;
            return currentModel;
        }
        
        throw new Exception("Пользователя не существует");
    }

    public async Task MakeUsersFriendsAsync(Guid userId1, Guid userId2)
    {
        FriendsStore.Add(new FriendDal
        {
            User1Id = userId1,
            User2Id = userId2
        });
    }
}