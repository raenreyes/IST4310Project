using System.Text;

namespace IST4310Project
{
    public class PasswordOneWayHash
    {
        internal static string GetHash(string password)
        {
            string ret;
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedPasswordBytes = sha256.ComputeHash(passwordBytes);

                ret = BitConverter.ToString(hashedPasswordBytes);
            }
                return ret;
        }
    }
}
