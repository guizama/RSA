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
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        public InsertReturn RSAEncrypt(InsertRequest request)
        {
            string data = request.TextData;
            var rsa = new RSACryptoServiceProvider(request.KeySize);
            var _privateKey = rsa.ToXmlString(true);
            var _publicKey = rsa.ToXmlString(false);

            string path = @"publicKey.txt";
            if (!File.Exists(path))
            {
                File.WriteAllTextAsync(path, _publicKey);
            }
            string path2 = @"privateKey.txt";
            if (!File.Exists(path2))
            {
                File.WriteAllTextAsync(path2, _privateKey);
            }

            var rsa2 = new RSACryptoServiceProvider(request.KeySize);

            string publicKey = System.IO.File.ReadAllText("publicKey.txt");
            rsa2.FromXmlString(publicKey);


            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();

            var ret = Convert.ToBase64String(encryptedByteArray);
            var pkcs = rsa2.ExportPkcs8PrivateKey;

            return null;
        }

        public InsertReturn RSADecrypt(string txt, int keySize)
        {
            var data = Convert.FromBase64String(txt);
            var rsa2 = new RSACryptoServiceProvider(keySize);

            string privateKey = System.IO.File.ReadAllText("privateKey.txt");
            rsa2.FromXmlString(privateKey);

            var dataToDecrypt = data;
            var decryptedByte = rsa2.Decrypt(dataToDecrypt, false);

            var ret = _encoder.GetString(decryptedByte);

            return null;
        }
    }
}
