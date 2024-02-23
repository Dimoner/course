using System.Collections.Concurrent;
using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;

namespace ProfileDal.Users;

/// <inheritdoc />
internal class UserRepository : IUserRepository
{
    private static readonly ConcurrentDictionary<Guid, UserDal> Store = new();
    
    /// <inheritdoc />
    public async Task<string> GetUserNameAsync(Guid userId)
    {
        if (Store.TryGetValue(userId, out var user))
        {
            return user.Name;
        }

        throw new Exception("Пользователь не найден");
    }

    /// <inheritdoc />
    public async Task<Guid> CreateUserAsync(UserDal user)
    {
        if (user.Id == Guid.Empty)
        {
            user = user with { Id = Guid.NewGuid() };
        }
        
        if (Store.TryAdd(user.Id, user))
        {
            return user.Id;
        }
        
        throw new Exception("Ошибка добавления пользователя");
    }
}