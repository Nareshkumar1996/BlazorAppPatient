using BC = BCrypt.Net.BCrypt;

namespace Healthware.Assist.Core.Security
{
    public class PasswordEncryptionDecryption
    {
        public static string HashPassword(string password)
        {
            return BC.HashPassword(password, GetRandomSalt());
        }

        public static bool ValidatePassword(string password, string dbpassword)
        {
            if(dbpassword == null)
            {
                return false;
            }
            return BC.Verify(password, dbpassword);
        }
        private static string GetRandomSalt()
        {
            return BC.GenerateSalt(12);
        }

    }
}
