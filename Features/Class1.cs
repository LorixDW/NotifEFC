using System.Security.Cryptography;
using System.Text;
namespace Features
{
    public class Feature
    {
        public static String Hash(String str)
        {
            var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}