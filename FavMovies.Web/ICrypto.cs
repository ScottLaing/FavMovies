using System.Security.Cryptography;
using System.Text;

namespace testWebMVCApp
{
    public interface ICrypto
    {
        string EncryptString(string plainText, string salt = Constants.Salt);
        string DecryptString(string cipherText, string salt = Constants.Salt);
    }
}
