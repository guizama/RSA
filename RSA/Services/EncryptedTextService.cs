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
                return rep.InsertText(encryptedText);
            }
            else
            {
                return rep.InsertText(request.TextData);
            }

        }

        public SelectReturn SelectText(int id)
        {
            var ret = rep.SelectText(id);

            ret.decryptedText = rsa.RSADecrypt(ret.encryptedText, 1024);
            ret.encryptedText = null;
            
            return ret;

        }
    }
}