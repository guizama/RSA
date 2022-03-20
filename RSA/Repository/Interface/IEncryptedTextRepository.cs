using RSA.Domain;

namespace RSA.Repository.Interface
{
    public interface IEncryptedTextRepository
    {
        InsertReturn InsertText(string texto);
        SelectReturn SelectText(int id);
    }
}
