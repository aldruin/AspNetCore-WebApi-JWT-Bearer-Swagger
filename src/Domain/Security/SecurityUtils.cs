using CashFlowAPI.Domain.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace CashFlowAPI.Domain.Security;
public sealed class SecurityUtils
{
    public static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];
        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
        {
            rngCsp.GetBytes(salt);
        }
        return salt;
    }

    public static string HashSHA256(string password, byte[] salt)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
            Array.Copy(passwordBytes, combinedBytes, passwordBytes.Length);
            Array.Copy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

            byte[] hashBytes = sha256.ComputeHash(combinedBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}