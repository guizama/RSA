using RSA.Domain;

namespace RSA.Services.Interface
{
    public interface IRSAEncrypt
    {
        //InsertReturn RSAEncrypt(InsertRequest request);
        //InsertReturn RSADecrypt(string txt, int keySize);

        string RSAEncrypt(InsertRequest request);
        string RSADecrypt(string txt, int keySize);

    }
}
