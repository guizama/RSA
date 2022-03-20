using RSA.Domain;

namespace RSA.Repository.Interface
{
    public interface IEncryptedTextRepository
    {
        InsertReturn InsertText(InsertReturn ret, InsertRequest request);
        SelectReturn SelectText(int id);
    }
}
