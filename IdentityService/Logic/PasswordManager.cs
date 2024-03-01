using System.Security.Cryptography;
using IdentityLogic.Users.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace IdentityLogic;

public class PasswordManager : IPasswordManager
{
    public string GenerateSalt()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
    }

    public string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
        return hashed;
    }

    public bool ComparePassword(string password, string hash, string salt)
    {
        return hash == HashPassword(password, salt);
    }
}