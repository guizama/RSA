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
        //#region InsertTests

        //[TestMethod]
        //public void InsertDataBaseRepTest()
        //{
        //    EncryptedTextRepository rep = new();

        //    var rowIncludedID = rep.InsertText("UnitTestRep", 0, "");

        //    Assert.IsTrue(rowIncludedID.UUID > 0);
        //}

        //[TestMethod]
        //public void InsertDataEncryptFalseSerTest()
        //{
        //    EncryptedTextRepository rep = new();
        //    RSAEncryptionService rsa = new();
        //    LogService log = new();
        //    EncryptedTextService ser = new(rep, rsa, log);

        //    var req = new InsertRequest
        //    {
        //        TextData = "UnitTestSerFalse",
        //        Encryption = false
        //    };

        //    var rowIncludedID = ser.InsertText(req);

        //    Assert.IsTrue(rowIncludedID.UUID > 0);
        //}

        //[TestMethod]
        //public void InsertDataEncryptTrueSerTest()
        //{
        //    EncryptedTextRepository rep = new();
        //    RSAEncryptionService rsa = new();
        //    LogService log = new();
        //    EncryptedTextService ser = new(rep, rsa, log);

        //    var req = new InsertRequest
        //    {
        //        TextData = "UnitTestSerTrue",
        //        Encryption = true,
        //        KeySize = 1024,
        //        PrivateKeyPassword = "tst"
        //    };

        //    var rowIncludedID = ser.InsertText(req);

        //    Assert.IsTrue(rowIncludedID.UUID > 0);
        //}

        //[TestMethod]
        //public void InsertDataEncryptFalseContTest()
        //{
        //    EncryptedTextRepository rep = new();
        //    RSAEncryptionService rsa = new();
        //    LogService log = new();
        //    EncryptedTextService ser = new(rep, rsa, log);
        //    EncryptedTextController cont = new(ser);

        //    var req = new InsertRequest
        //    {
        //        TextData = "UnitTestContFalse",
        //        Encryption = false
        //    };

        //    var rowIncludedID = cont.TextManagement(req);

        //    Assert.IsTrue(rowIncludedID.UUID > 0);
        //}

        [TestMethod]
        public void InsertDataEncryptTrueContTest()
        {
            EncryptedTextRepository rep = new();
            RSAEncryptionService rsa = new();
            LogService log = new();
            EncryptedTextService ser = new(rep, rsa, log);
            EncryptedTextController cont = new(ser);

            var req = new InsertRequest
            {
                TextData = "GZM7",
                Encryption = true,
                KeySize = 2048,
                PrivateKeyPassword = "tst"
            };

            var rowIncludedID = cont.TextManagement(req);

            Assert.IsTrue(rowIncludedID.UUID > 0);
        }

        //#endregion

        //#region SelectTests

        //[TestMethod]
        //public void SelectDataBaseRepTest()
        //{
        //    EncryptedTextRepository rep = new();

        //    var rowSelectText = rep.SelectText(1);

        //    Assert.IsTrue(rowSelectText.encryptedText != null);
        //}

        //[TestMethod]
        //public void SelectDataBaseSerTest()
        //{
        //    EncryptedTextRepository rep = new();
        //    RSAEncryptionService rsa = new();
        //    LogService log = new();
        //    EncryptedTextService ser = new(rep, rsa, log);

        //    var rowSelectText = ser.SelectText(1);

        //    Assert.IsTrue(rowSelectText.decryptedText != null);
        //}

        [TestMethod]
        public void SelectDataBaseContTest()
        {
            EncryptedTextRepository rep = new();
            RSAEncryptionService rsa = new();
            LogService log = new();
            EncryptedTextService ser = new(rep, rsa, log);
            EncryptedTextController cont = new(ser);

            var rowSelectText = cont.TextManagement(43);

            Assert.IsTrue(rowSelectText.decryptedText == "GZM7");
        }

        //#endregion

        //#region validation

        //[TestMethod]
        //public void Should_have_error_when_KeySize_wrong()
        //{
        //    var validator = new InsertRequestValidator();
        //    var req = new InsertRequest
        //    {
        //        TextData = "UnitTestSerTrue",
        //        Encryption = true,
        //        KeySize = 102,
        //        PrivateKeyPassword = "tst"
        //    };

        //    var result = validator.Validate(req);

        //    Assert.IsTrue(result.Errors[0].ErrorMessage.Equals("Not Allowed Values"));
        //}

        //[TestMethod]
        //public void Should_have_error_when_PrivateKeyPassword_null()
        //{
        //    var validator = new InsertRequestValidator();
        //    var req = new InsertRequest
        //    {
        //        TextData = "UnitTestSerTrue",
        //        Encryption = true,
        //        KeySize = 1024,
        //        PrivateKeyPassword = ""
        //    };

        //    var result = validator.Validate(req);

        //    Assert.IsTrue(result.Errors[0].ErrorMessage.Equals("Private Key Password Must Be Informed"));
        //}


        //#endregion

        //#region Crypto

        //[TestMethod]
        //public void Encrypt()
        //{
        //    RSAEncryptionService rsa = new();

        //    var req = new InsertRequest
        //    {
        //        TextData = "UnitTestSerTrue",
        //        Encryption = true,
        //        KeySize = 2048,
        //        PrivateKeyPassword = "tst"
        //    };

        //    rsa.RSAEncrypt(req);
        //    //Assert.IsTrue(rowIncludedID.UUID > 0);
        //}

        //#endregion

    }
}