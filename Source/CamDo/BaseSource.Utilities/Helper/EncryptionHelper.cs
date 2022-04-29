using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Utilities.Helper
{
    public class EncryptionHelper
    {
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("vntextcom123$%^&");
        private static string passPhrase = "Password@1";
        private const int keysize = 256;

        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                return "";
            }
        }
    }
}
