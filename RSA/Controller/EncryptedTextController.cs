using Microsoft.AspNetCore.Mvc;
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

        [Route("/v1/text-management")]
        public InsertReturn TextManagement(InsertRequest request)
        {
            return ser.InsertText(request);
        }

        [Route("/v1/text-management?id={text_id}")]
        public SelectReturn TextManagement(int id)
        {
            return ser.SelectText(id);
        }
    }
}
