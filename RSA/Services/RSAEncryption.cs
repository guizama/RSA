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

            SaveKeys(_publicKey, _privateKey, request.KeySize);

            var rsa2 = new RSACryptoServiceProvider(request.KeySize);
            var publicKey = ReadKey(KeyType.publicKey, request.KeySize);
            rsa2.FromXmlString(publicKey);

            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();

            var encryptedText = Convert.ToBase64String(encryptedByteArray);
            //var pkcs = rsa2.ExportPkcs8PrivateKey;

            return encryptedText;
        }

        public string RSADecrypt(string txt, int keySize)
        {
            var data = Convert.FromBase64String(txt);
            var rsa2 = new RSACryptoServiceProvider(keySize);

            var privateKey = ReadKey(KeyType.privateKey, keySize);
            rsa2.FromXmlString(privateKey);

            var dataToDecrypt = data;
            var decryptedByte = rsa2.Decrypt(dataToDecrypt, false);

            var decryptedText = _encoder.GetString(decryptedByte);

            return decryptedText;
        }

        private void SaveKeys(string publicKey, string privateKey, int keySize)
        {
            string path = @"publicKey" + keySize.ToString() + ".txt";
            if (!File.Exists(path))
            {
                File.WriteAllTextAsync(path, publicKey);
            }
            string path2 = @"privateKey" + keySize.ToString() + ".txt";
            if (!File.Exists(path2))
            {
                File.WriteAllTextAsync(path2, privateKey);
            }
        }

        private string ReadKey(KeyType type, int keySize)
        {
            switch (type)
            {
                case KeyType.publicKey:
                    try
                    {
                        return System.IO.File.ReadAllText("publicKey" + keySize.ToString() + ".txt");
                    }
                    catch
                    {
                        throw new Exception("No saved keys");
                    }
                    break;
                case KeyType.privateKey:
                    try
                    {
                        return System.IO.File.ReadAllText("privateKey" + keySize.ToString() + ".txt");
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
    }
}
