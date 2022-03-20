using RSA.Domain;
using RSA.Services.Interface;

namespace RSA.Controller
{
    public class EncryptedTextController
    {
        private readonly IEncryptedTextService ser;

        public EncryptedTextController(IEncryptedTextService ser)
        {
            this.ser = ser;
        }

        public InsertReturn TextManagement(InsertRequest request)
        {
            return ser.InsertText(request);
        }

        public SelectReturn TextManagement(int id)
        {
            return ser.SelectText(id);
        }
    }
}
