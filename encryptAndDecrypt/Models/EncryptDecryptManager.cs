using System.Security.Cryptography;
using System.Text;

namespace encryptAndDecrypt.Models
{
    public class EncryptDecryptManager
    {
       
        //private readonly static string key = "b1WcA5lR8A4es133Gbce2EaOq15aP9tR";

        public static string Encrypt(string text,string key)
        {
            byte[]iv=new byte[16];   //128 bit
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key =Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor=aes.CreateEncryptor(aes.Key,aes.IV);
                using (MemoryStream ms=new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(text);
                        }
                        array=ms.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public static string Decrypt(string text,string key)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(text);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream,decryptor,CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader=new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
