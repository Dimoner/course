namespace IdentityLogic.Users.Interfaces;

public interface IPasswordManager
{
    string GenerateSalt();
    
    string HashPassword(string password, string salt);

    bool ComparePassword(string password, string hash, string salt);
}