using RSA.Domain;

namespace RSA.Services.Interface
{
    public interface IRSAEncrypt
    {
        string EncryptText(InsertRequest request);
    }
}
