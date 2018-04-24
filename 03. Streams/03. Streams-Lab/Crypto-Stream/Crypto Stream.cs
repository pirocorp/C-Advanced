using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class CryptoStreamDemo  
{
    const string EncryptionKey = "ABCDEFGH";
    const string FilePath = "../../encrypted.txt";

    public static void Main()
    {
        var text = string.Join(Environment.NewLine, File.ReadAllLines("../../Crypto Stream.cs"));

        SaveEncrypted(text, EncryptionKey, FilePath);

        var result = Decrypt(EncryptionKey, FilePath);
        Console.WriteLine(result);
    }

    public static string Decrypt(string key, string path)
    {
        var fileStream = new FileStream(path, FileMode.Open);
        
        using (fileStream)
        {
            var cryptoProvider = new DESCryptoServiceProvider();
            cryptoProvider.Key = Encoding.ASCII.GetBytes(key);
            cryptoProvider.IV = Encoding.ASCII.GetBytes(key);

            var cryptoStream = new CryptoStream(fileStream, cryptoProvider.CreateDecryptor(), CryptoStreamMode.Read);
            
            using (cryptoStream)
            {
                using (var reader = new StreamReader(cryptoStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }

    public static void SaveEncrypted(string text, string key, string path)
    {
        var destinationStream =
            new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

        using (destinationStream)
        {
            var cryptoProvider = new DESCryptoServiceProvider();

            cryptoProvider.Key = Encoding.ASCII.GetBytes(key);
            cryptoProvider.IV = Encoding.ASCII.GetBytes(key);

            CryptoStream cryptoStream = new CryptoStream(destinationStream,
               cryptoProvider.CreateEncryptor(), CryptoStreamMode.Write);

            using (cryptoStream)
            {
                byte[] data = Encoding.ASCII.GetBytes(text);

                cryptoStream.Write(data, 0, data.Length);
            }
        }
    }
}
