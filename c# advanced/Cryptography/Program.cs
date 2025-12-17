using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;




public class Program
{

    public static string Encrypt_UsingHashAlgorithm(string Data)
    {
        using(SHA256 sha256 = SHA256.Create())
        {
            byte[] HashedByte = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Data));
            return BitConverter.ToString(HashedByte);
        }
    }

    public static string Encrypt_UsingSymmetricAlgorithm(string Data, string Key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = new byte[aesAlg.BlockSize / 8];

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        
            using (var msEncrypt = new System.IO.MemoryStream())
            {
                using(var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using(var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(Data);
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    public static string Decrypt_UsingSymmetricAlgorithm(string EncryptedData, string Key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = new byte[aesAlg.BlockSize / 8];

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var msDecryptor = new System.IO.MemoryStream(Convert.FromBase64String(EncryptedData)))
            using (var csDecryptor = new CryptoStream(msDecryptor, decryptor, CryptoStreamMode.Read))
            using (var srDecryptor = new System.IO.StreamReader(csDecryptor))
            {
                return srDecryptor.ReadToEnd();
            }
        }
    }

    public static string Encrypt_UsingAsymmetricAlgorithm(string Data, string PublicKey)
    {
        try
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(PublicKey);

                byte[] encryptedData = rsa.Encrypt(System.Text.Encoding.UTF8.GetBytes(Data), false);
                return Convert.ToBase64String(encryptedData);
            }
        }
        catch(CryptographicException e)
        {
            Console.WriteLine($"A Cryptographic error occurred: {e.Message}");
            throw;
        }       
    }

    public static string Decrypt_UsingAsymmetricAlgorithm(string EncryptedData, string PrivateKey)
    {
        try
        {
            using(RSACryptoServiceProvider rsa =  new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(PrivateKey);

                byte[] decryptedData = rsa.Decrypt(Convert.FromBase64String(EncryptedData), false);
                return System.Text.Encoding.UTF8.GetString(decryptedData);
            }
        }
        catch(CryptographicException e)
        {
            Console.WriteLine($"A Cryptographic error occurred: {e.Message}");
            throw;
        }
    }

    static public void EncryptFile_UsingAesAlgorithm(string InputFile, string OutputFile, string Key, byte[] iv)
    {
        using(Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = iv;

            using (FileStream fsInput = new FileStream(InputFile, FileMode.Open))
            using (FileStream fsOutput = new FileStream(OutputFile, FileMode.Create))
            using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
            using (CryptoStream csEncrypt = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
            {
               fsOutput.Write(iv, 0, iv.Length);
               fsInput.CopyTo(csEncrypt);
            }
        }
    }

    static public void DecryptFile_UsingAesAlgorithm(string InputFile, string OutputFile, string Key, byte[] iv)
    {
        using(Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = iv;



            using(FileStream fsInput = new FileStream(InputFile, FileMode.Open))
            using(FileStream fsOutput = new FileStream(OutputFile, FileMode.Create))
            using(ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
            using(CryptoStream csDecrypt = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
            {
                fsInput.Seek(iv.Length, SeekOrigin.Begin);
                csDecrypt.CopyTo(fsOutput);
            }
        }
    }




    public static void Main()
    {
        string Data = "AbdullahSaeed";

        
        string Hash = Encrypt_UsingHashAlgorithm(Data);
        Console.WriteLine($"Data Encrypted Using Hash Algorithm: {Hash}\n\n");

        string Symmetric = Encrypt_UsingSymmetricAlgorithm(Data, "1234567890123456");
        Console.WriteLine($"Data Encrypted Using Symmetric Algorithm: {Symmetric}\n\n");
        string DecryptedSymmetric = Decrypt_UsingSymmetricAlgorithm(Symmetric, "1234567890123456");
        Console.WriteLine($"Data Decrypted Using Symmetric Algorithm: {DecryptedSymmetric}\n\n");
       


        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            string AsymmetricEncrypted = Encrypt_UsingAsymmetricAlgorithm(Data, publicKey);
            Console.WriteLine($"Data Encrypted Using Asymmetric Algorithm: {AsymmetricEncrypted}\n\n");
            string DecryptedAsymmetric = Decrypt_UsingAsymmetricAlgorithm(AsymmetricEncrypted, privateKey);
            Console.WriteLine($"Data Decrypted Using Asymmetric Algorithm: {DecryptedAsymmetric}\n\n");
        }




        string inputFile = "c:\\Image\\MyImage.jpg";
        string encryptedFile = "c:\\Image\\encrypted.jpg";
        string decryptedFile = "c:\\Image\\decrypted.jpg";


        string Key = "1234567890123456";
        byte[] iv;
        using (Aes aesalg = Aes.Create())
        {
            iv = aesalg.IV;
        }
        EncryptFile_UsingAesAlgorithm(inputFile, encryptedFile, Key, iv);
        DecryptFile_UsingAesAlgorithm(encryptedFile, decryptedFile, Key, iv);
        Console.ReadKey();


    }









}