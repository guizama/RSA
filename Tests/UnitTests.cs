using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSA.Controller;
using RSA.Domain;
using RSA.Repository;
using RSA.Services;
using RSA.Services.Interface;

namespace Test
{
    [TestClass]
    public class UnitTests
    {
        #region Insert

        [TestMethod]
        public void Insert_Crypto_1024()
        {
            EncryptedTextRepository rep = new();
            RSAEncryptionService rsa = new();
            LogService log = new();
            EncryptedTextService ser = new(rep, rsa, log);
            EncryptedTextController cont = new(ser);

            var req = new InsertRequest
            {
                TextData = "Insert_Crypto_1024",
                Encryption = true,
                KeySize = 1024,
                PrivateKeyPassword = "RSA"
            };

            var rowIncludedID = cont.TextManagement(req);

            Assert.IsTrue(rowIncludedID.UUID > 0);
            Assert.IsTrue(rowIncludedID.pkcs8 != null);
        }

        [TestMethod]
        public void Insert_Crypto_2048()
        {
            EncryptedTextRepository rep = new();
            RSAEncryptionService rsa = new();
            LogService log = new();
            EncryptedTextService ser = new(rep, rsa, log);
            EncryptedTextController cont = new(ser);

            var req = new InsertRequest
            {
                TextData = "Insert_Crypto_2048",
                Encryption = true,
                KeySize = 2048,
                PrivateKeyPassword = "RSA"
            };

            var rowIncludedID = cont.TextManagement(req);

            Assert.IsTrue(rowIncludedID.UUID > 0);
            Assert.IsTrue(rowIncludedID.pkcs8 != null);
        }

        [TestMethod]
        public void Insert_Crypto_4096()
        {
            EncryptedTextRepository rep = new();
            RSAEncryptionService rsa = new();
            LogService log = new();
            EncryptedTextService ser = new(rep, rsa, log);
            EncryptedTextController cont = new(ser);

            var req = new InsertRequest
            {
                TextData = "Insert_Crypto_4096",
                Encryption = true,
                KeySize = 4096,
                PrivateKeyPassword = "RSA"
            };

            var rowIncludedID = cont.TextManagement(req);

            Assert.IsTrue(rowIncludedID.UUID > 0);
            Assert.IsTrue(rowIncludedID.pkcs8 != null);
        }

        #endregion

        #region Consult

        [TestMethod]
        public void Consult_Crypto_1024()
        {
            EncryptedTextRepository rep = new();
            RSAEncryptionService rsa = new();
            LogService log = new();
            EncryptedTextService ser = new(rep, rsa, log);
            EncryptedTextController cont = new(ser);

            var id = rep.SelectLastIdByKeySize(1024);

            var rowSelectText = cont.TextManagement(id);

            Assert.IsTrue(rowSelectText.decryptedText == "Insert_Crypto_1024");
        }

        [TestMethod]
        public void Consult_Crypto_2048()
        {
            EncryptedTextRepository rep = new();
            RSAEncryptionService rsa = new();
            LogService log = new();
            EncryptedTextService ser = new(rep, rsa, log);
            EncryptedTextController cont = new(ser);

            var id = rep.SelectLastIdByKeySize(2048);

            var rowSelectText = cont.TextManagement(id);

            Assert.IsTrue(rowSelectText.decryptedText == "Insert_Crypto_2048");
        }

        [TestMethod]
        public void Consult_Crypto_4096()
        {
            EncryptedTextRepository rep = new();
            RSAEncryptionService rsa = new();
            LogService log = new();
            EncryptedTextService ser = new(rep, rsa, log);
            EncryptedTextController cont = new(ser);

            var id = rep.SelectLastIdByKeySize(4096);

            var rowSelectText = cont.TextManagement(id);

            Assert.IsTrue(rowSelectText.decryptedText == "Insert_Crypto_4096");
        }

        #endregion

        #region validation

        [TestMethod]
        public void Should_have_error_when_KeySize_wrong()
        {
            var validator = new InsertRequestValidator();
            var req = new InsertRequest
            {
                TextData = "UnitTestSerTrue",
                Encryption = true,
                KeySize = 102,
                PrivateKeyPassword = "tst"
            };

            var result = validator.Validate(req);

            Assert.IsTrue(result.Errors[0].ErrorMessage.Equals("Not Allowed Values"));
        }

        [TestMethod]
        public void Should_have_error_when_PrivateKeyPassword_null()
        {
            var validator = new InsertRequestValidator();
            var req = new InsertRequest
            {
                TextData = "UnitTestSerTrue",
                Encryption = true,
                KeySize = 1024,
                PrivateKeyPassword = ""
            };

            var result = validator.Validate(req);

            Assert.IsTrue(result.Errors[0].ErrorMessage.Equals("Private Key Password Must Be Informed"));
        }

        #endregion

        #region Crypto

        [TestMethod]
        public void Encrypt_Decrypt()
        {
            RSAEncryptionService rsa = new();

            var reqEncrypt = new InsertRequest
            {
                TextData = "Encrypt_Decrypt",
                Encryption = true,
                KeySize = 2048,
                PrivateKeyPassword = "RSA"
            };
            var encrypt = rsa.RSAEncrypt(reqEncrypt);

            var reqDecrypt = new SelectReturn
            {
                encryptedText = encrypt.encryptedText,
                keySize = 2048,
                privateKeyPassword = "RSA"
            };
            var decrypt = rsa.RSADecrypt(reqDecrypt);

            Assert.IsTrue(decrypt.Equals("Encrypt_Decrypt"));
        }

        #endregion

    }
}