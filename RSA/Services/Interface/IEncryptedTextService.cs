using RSA.Domain;

namespace RSA.Services.Interface
{
    public interface IEncryptedTextService
    {
        InsertReturn InsertText(InsertRequest request);
        SelectReturn SelectText(int id);
    }
}
