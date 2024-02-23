namespace Services;

public interface ICheckUser
{
    Task CheckUserExistAsync(Guid userId);
}