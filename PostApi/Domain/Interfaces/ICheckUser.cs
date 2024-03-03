namespace Domain.Interfaces;

public interface ICheckUser
{
    Task CheckUserExistAsync(Guid userId);
}