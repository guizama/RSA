using RSA.Domain;
using RSA.Repository.Interface;
using RSA.Services.Interface;
using static RSA.Enums.Enums;

namespace RSA.Services
{
    public class EncryptedTextService : IEncryptedTextService
    {
        private readonly IEncryptedTextRepository rep;
        private readonly IRSAEncryptService rsa;
        private readonly ILogService log;

        public EncryptedTextService(IEncryptedTextRepository rep, IRSAEncryptService rsa, ILogService log)
        {
            this.rep = rep;
            this.rsa = rsa;
            this.log = log;
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
                var encrypt = rsa.RSAEncrypt(request);
                var ret =  rep.InsertText(encrypt, request);

                var logDomain = new LogDomain
                {
                    logType = LogType.INSERT,
                    when = DateTime.Now,
                    id = ret.UUID,
                    encrypted = true
                };
                log.LogRegister(logDomain);

                return ret;
            }
            else
            {
                var insertReturn = new InsertReturn { encryptedText = request.TextData };
                request.KeySize = 0;
                request.PrivateKeyPassword = "";
                var ret = rep.InsertText(insertReturn, request);

                var logDomain = new LogDomain
                {
                    logType = LogType.INSERT,
                    when = DateTime.Now,
                    id = ret.UUID,
                    encrypted = false
                };
                log.LogRegister(logDomain);

                return ret;
            }

        }

        public SelectReturn SelectText(int id)
        {
            var ret = rep.SelectText(id);

            if (ret.keySize > 0)
            {
                if (ret.encryptedText == null)
                    throw new Exception("Text not found");
                if (ret.keySize > 0 && (ret.privateKeyPassword == null || ret.privateKeyPassword == ""))
                    throw new Exception("No Private Password");
                ret.decryptedText = rsa.RSADecrypt(ret);
                ret.encryptedText = null;

                var logDomain = new LogDomain
                {
                    logType = LogType.CONSULT,
                    when = DateTime.Now,
                    id = ret.id,
                    encrypted = true
                };
                log.LogRegister(logDomain);

                return ret;
            }
            else
            {
                ret.decryptedText = ret.encryptedText;
                ret.encryptedText = null;
                ret.keySize = 0;
                ret.privateKeyPassword = null;

                var logDomain = new LogDomain
                {
                    logType = LogType.CONSULT,
                    when = DateTime.Now,
                    id = ret.id,
                    encrypted = false
                };
                log.LogRegister(logDomain);

                return ret;
            }
        }
    }
}