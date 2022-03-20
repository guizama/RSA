using RSA.Domain;

namespace RSA.Repository.Interface
{
    public interface IEncryptedTextRepository
    {
        InsertReturn InsertText(string text, int keySize, string privateKeyPassword);
        SelectReturn SelectText(int id);
    }
}
