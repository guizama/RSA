using RSA.Domain;
using RSA.Services.Interface;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace RSA.Services
{
    public class RSAEncryption //: IRSAEncrypt
    {
        //    request.Encryption;
        //    request.TextData;
        //    request.PrivateKeyPassword;
        //    request.KeySize;

        public void RSA(InsertRequest request, int op)
        {
        }
        //    try
        //    {
        //        UnicodeEncoding ByteConverter = new UnicodeEncoding();

        //        byte[] dataToEncrypt = ByteConverter.GetBytes("Test data");

        //       // WriteRSAInfoToFile();

        //        string enc = Encrypt(dataToEncrypt);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Encryption failed.");
        //    }

        //    #region trash
        //    //op 1 = encrypt
        //    //op 2 = decrypt

        //    //    UnicodeEncoding ByteConverter = new UnicodeEncoding();

        //    //    byte[] dataToEncrypt = ByteConverter.GetBytes(request.TextData);
        //    //    byte[] encryptedData;
        //    //    byte[] decryptedData;

        //    //    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(request.KeySize))
        //    //    {

        //    //        //Pass the data to ENCRYPT, the public key information 
        //    //        //(using RSACryptoServiceProvider.ExportParameters(false),
        //    //        //and a boolean flag specifying no OAEP padding.


        //    //        try
        //    //        {
        //    //            string publicKey = System.IO.File.ReadAllText("publicKey.txt");
        //    //            RSA.ImportFromPem(publicKey);
        //    //        }
        //    //        catch
        //    //        {
        //    //            var publicKey = RSA.ExportRSAPublicKey();
        //    //            //File.WriteAllBytesAsync("publicKey.txt", publicKey);
        //    //        }

        //    //        try
        //    //        {
        //    //            string privateKey = System.IO.File.ReadAllText("privateKey.txt");
        //    //            //RSA.FromXmlString(privateKey);
        //    //        }
        //    //        catch
        //    //        {

        //    //           var privateKey = RSA.ExportRSAPrivateKey();
        //    //           File.WriteAllBytesAsync("privateKey.txt", privateKey);
        //    //        }

        //    //        encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), request);

        //    //        //Pass the data to DECRYPT, the private key information 
        //    //        //(using RSACryptoServiceProvider.ExportParameters(true),
        //    //        //and a boolean flag specifying no OAEP padding.
        //    //        //decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
        //    //    }
        //    //}
        //    //catch (ArgumentNullException)
        //    //{
        //    //    //Catch this exception in case the encryption did
        //    //    //not succeed.
        //    //    throw new Exception("Encryption failed.");
        //    //}
        //    #endregion
        //}

        //static void WriteRSAInfoToFile()
        //{
        //    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        //    TextWriter writer = new StreamWriter("publicKey.xml");
        //    string publicKey = RSA.ToXmlString(false);
        //    writer.Write(publicKey);
        //    writer.Close();

        //    writer = new StreamWriter("privateKey.xml");
        //    string privateKey = RSA.ToXmlString(true);
        //    writer.Write(privateKey);
        //    writer.Close();
        //}

        //static string Encrypt(byte[] data)
        //{
        //    UnicodeEncoding ByteConverter = new UnicodeEncoding();
        //    RSACryptoServiceProvider encrypt = new RSACryptoServiceProvider();
        //    TextReader reader = new StreamReader("publicKey.xml");
        //    string publicKey = reader.ReadToEnd();
        //    reader.Close();

        //    encrypt.FromXmlString(publicKey);

        //    byte[] encryptedData = encrypt.Encrypt(data, false);

        //    var tst = ByteConverter.GetString(encryptedData);
        //    return tst;
        //}

        //public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, InsertRequest request)
        //{
        //    try
        //    {
        //        byte[] encryptedData;
        //        //Create a new instance of RSACryptoServiceProvider.
        //        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(request.KeySize))
        //        {

        //            //Import the RSA Key information. This only needs
        //            //toinclude the public key information.
        //            string privateKey = System.IO.File.ReadAllText("privateKey.txt");
        //            var newPK = privateKey.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "");

        //            byte[] bytesPrivateKey = System.Convert.FromBase64String(newPK);

        //            int bytesRead;
        //            RSA.ImportRSAPrivateKey(bytesPrivateKey, out bytesRead);

        //            //RSA.ImportFromPem(privateKey); //ImportParameters(RSAKeyInfo);

        //            //Encrypt the passed byte array and specify OAEP padding.  
        //            //OAEP padding is only availablre on Microsoft Windows XP or
        //            //later.  

        //            encryptedData = RSA.Encrypt(DataToEncrypt, false);
        //        }

        //        string base64String = Convert.ToBase64String(encryptedData);

        //        return encryptedData;
        //    }
        //    catch (CryptographicException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}



    }
}
