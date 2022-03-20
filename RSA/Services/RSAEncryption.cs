using RSA.Domain;
using RSA.Services.Interface;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using static RSA.Enums.Enums;

namespace RSA.Services
{
    public class RSAEncryption : IRSAEncrypt
    {
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        public string RSAEncrypt(InsertRequest request)
        {
            string data = request.TextData;

            var rsa = new RSACryptoServiceProvider(request.KeySize);
            var _privateKey = rsa.ToXmlString(true);
            var _publicKey = rsa.ToXmlString(false);

            SaveKeys(_publicKey, _privateKey, request.KeySize, request.PrivateKeyPassword);

            var rsa2 = new RSACryptoServiceProvider(request.KeySize);
            var publicKey = ReadKey(KeyType.publicKey, request.KeySize, request.PrivateKeyPassword);
            rsa2.FromXmlString(publicKey);

            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();

            var encryptedText = Convert.ToBase64String(encryptedByteArray);
            //var pkcs = rsa2.ExportPkcs8PrivateKey;

            return encryptedText;
        }

        public string RSADecrypt(SelectReturn encryptedData)
        {
            var data = Convert.FromBase64String(encryptedData.encryptedText);
            var rsa2 = new RSACryptoServiceProvider(encryptedData.keySize);

            var privateKey = ReadKey(KeyType.privateKey, encryptedData.keySize, encryptedData.privateKeyPassword);
            rsa2.FromXmlString(privateKey);

            var dataToDecrypt = data;
            var decryptedByte = rsa2.Decrypt(dataToDecrypt, false);

            var decryptedText = _encoder.GetString(decryptedByte);

            return decryptedText;
        }

        private void SaveKeys(string publicKey, string privateKey, int keySize, string privateKeyPassword)
        {
            string path = @"publicKey" + keySize.ToString() + ".txt";
            if (!File.Exists(path))
            {
                var tdesPublicKey = TripleDESEncrypt(publicKey, privateKeyPassword);
                File.WriteAllTextAsync(path, tdesPublicKey);
            }
            string path2 = @"privateKey" + keySize.ToString() + ".txt";
            if (!File.Exists(path2))
            {
                var tdesPrivateKey = TripleDESEncrypt(privateKey, privateKeyPassword);
                File.WriteAllTextAsync(path2, tdesPrivateKey);
            }
        }

        private string ReadKey(KeyType type, int keySize, string privateKeyPassword)
        {
            switch (type)
            {
                case KeyType.publicKey:
                    try
                    {
                        var tdesPublicKey = System.IO.File.ReadAllText("publicKey" + keySize.ToString() + ".txt");
                        return TripleDESDecrypt(tdesPublicKey, privateKeyPassword);
                    }
                    catch
                    {
                        throw new Exception("No saved keys");
                    }
                    break;
                case KeyType.privateKey:
                    try
                    {
                        var tdesPrivateKey = System.IO.File.ReadAllText("privateKey" + keySize.ToString() + ".txt");
                        return TripleDESDecrypt(tdesPrivateKey, privateKeyPassword);
                    }
                    catch
                    {
                        throw new Exception("No saved keys");
                    }
                    break;
                default:
                    throw new Exception("Wrong type of key");
            }

        }

        private string TripleDESEncrypt(string textToEncrypt, string privateKeyPassword)
        {
            byte[] MyEncryptedArray = UTF8Encoding.UTF8
            .GetBytes(textToEncrypt);

            MD5CryptoServiceProvider MyMD5CryptoService = new
               MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
               (UTF8Encoding.UTF8.GetBytes(privateKeyPassword));

            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService
               .CreateEncryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(MyEncryptedArray, 0,
               MyEncryptedArray.Length);

            MyTripleDESCryptoService.Clear();

            return Convert.ToBase64String(MyresultArray, 0,
               MyresultArray.Length);
        }

        private string TripleDESDecrypt(string textToDecrypt, string privateKeyPassword)
        {
            byte[] MyDecryptArray = Convert.FromBase64String
            (textToDecrypt);

            MD5CryptoServiceProvider MyMD5CryptoService = new
               MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
               (UTF8Encoding.UTF8.GetBytes(privateKeyPassword));

            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService
               .CreateDecryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(MyDecryptArray, 0,
               MyDecryptArray.Length);

            MyTripleDESCryptoService.Clear();

            return UTF8Encoding.UTF8.GetString(MyresultArray);
        }
    }
}
