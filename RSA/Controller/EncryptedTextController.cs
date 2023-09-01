using Microsoft.AspNetCore.Mvc;
using RSA.Domain;
using RSA.Services.Interface;

namespace RSA.Controller
{
    [ApiController]
    public class EncryptedTextController
    {
        private readonly IEncryptedTextService ser;

        public EncryptedTextController(IEncryptedTextService ser)
        {
            this.ser = ser;
        }

        [HttpPost]
        [Route("/v1/text-management")]
        public InsertReturn TextManagement(InsertRequest request)
        {
            return ser.InsertText(request);
        }

        [HttpPost]
        [Route("/v1/text-management")]
        public SelectReturn TextManagement(int id)
        {
            return ser.SelectText(id);
        }
    }
}
