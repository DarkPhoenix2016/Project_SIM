using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;

namespace Project_SIM.Models
{
    
    public class Authenticator
    {
        public static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public static bool ValidateLogin(string password, string hashedPassword)
        {
           return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }

}

