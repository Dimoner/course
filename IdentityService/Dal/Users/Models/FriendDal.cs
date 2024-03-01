namespace IdentityDal.Users.Models;

/// <summary>
/// Связь Пользователь-пользователь
/// </summary>
public class FriendDal
{
    public required Guid User1Id { get; init; }
    
    public required Guid User2Id { get; init; }
}