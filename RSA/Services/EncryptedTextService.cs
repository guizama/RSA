using RSA.Domain;
using RSA.Repository.Interface;
using RSA.Services.Interface;


namespace RSA.Services
{
    public class EncryptedTextService : IEncryptedTextService
    {
        private readonly IEncryptedTextRepository rep;
        private readonly IRSAEncrypt rsa;

        public EncryptedTextService(IEncryptedTextRepository rep, IRSAEncrypt rsa)
        {
            this.rep = rep;
            this.rsa = rsa;
        }

        public InsertReturn InsertText(InsertRequest request)
        {
            InsertRequestValidator validator = new InsertRequestValidator();
            var results = validator.Validate(request);
            string allMessages = results.ToString("~");

            if (allMessages.Length > 0)
                throw new Exception(allMessages);


            if (request.Encryption)
            {
                var encryptedText = rsa.RSAEncrypt(request);
                return rep.InsertText(encryptedText, request.KeySize, request.PrivateKeyPassword);
            }
            else
            {
                return rep.InsertText(request.TextData, 0, "");
            }

        }

        public SelectReturn SelectText(int id)
        {
            var ret = rep.SelectText(id);

            if (ret.keySize > 0)
            {
                if (ret.encryptedText == null)
                    throw new Exception("Text not found");
                if (ret.keySize > 0 && ret.privateKeyPassword == null)
                    throw new Exception("No Private Password");
                ret.decryptedText = rsa.RSADecrypt(ret);
                ret.encryptedText = null;

                return ret;
            }
            else
            {
                ret.decryptedText = ret.encryptedText;
                ret.encryptedText = null;

                return ret;
            }





        }
    }
}