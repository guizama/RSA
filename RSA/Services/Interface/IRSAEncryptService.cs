using RSA.Domain;

namespace RSA.Services.Interface
{
    public interface IRSAEncryptService
    {
        //InsertReturn RSAEncrypt(InsertRequest request);
        //InsertReturn RSADecrypt(string txt, int keySize);

        InsertReturn RSAEncrypt(InsertRequest request);
        string RSADecrypt(SelectReturn encryptedData);


    }
}
