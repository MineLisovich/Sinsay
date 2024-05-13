using System.Security.Cryptography;
using System.Text;

namespace Sinsay.Sevices
{
    public class PasswordHashService
    {
        public static string CreateHash(string value)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new();
                foreach (byte b in hash) 
                { 
                    sb.Append(b.ToString("x2")); // Преобразование в шестнадцатеричное представление
                }
                return sb.ToString();
            }
        }
    }
}
