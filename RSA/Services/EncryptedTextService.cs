using RSA.Domain;
using RSA.Repository.Interface;
using RSA.Services.Interface;


namespace RSA.Services
{
    public class EncryptedTextService : IEncryptedTextService
    {
        private readonly IEncryptedTextRepository rep;
        private readonly IRSAEncrypt? rsa;

        public EncryptedTextService(IEncryptedTextRepository rep, IRSAEncrypt rsa)
        {
            this.rep = rep;
            this.rsa = rsa;
        }

        public EncryptedTextService(IEncryptedTextRepository rep)
        {
            this.rep = rep;
            rsa = null;
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
               
                //call the encrypt

                return rep.InsertText(request.TextData);
            }
            else
            {
                return rep.InsertText(request.TextData);
            }

        }

        public SelectReturn SelectText(int id)
        {
            var ret = rep.SelectText(id);

            ret.decryptedText = ret.encryptedText;

            //incluir decriptografia 
            //ret.decryptedText = descriptografar(ret.encryptedText);
            //ret.encryptedText = null;


            return ret;

        }
    }
}