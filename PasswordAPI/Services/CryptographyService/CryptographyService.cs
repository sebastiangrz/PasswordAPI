using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace PasswordAPI.Services.CryptoService
{
    public class CryptographyService : ICryptographyService
    {
        public string Encrypt(string value, string key)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(value);
            //Encrypt
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.Padding = PaddingMode.Zeros;
            crypt.BlockSize = 128;
            crypt.IV = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(key));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        public string Decrypt(string value, string key)
        {
            //Decrypt
            byte[] bytes = Convert.FromBase64String(value);
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.Padding = PaddingMode.Zeros;
            crypt.BlockSize = 128;
            crypt.IV = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(key));

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    return Encoding.Unicode.GetString(decryptedBytes).TrimEnd('\0');
                }
            }
        }
    }
}

