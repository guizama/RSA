using System.Runtime.Serialization;

namespace RSA.Domain
{
    public class InsertRequest
    {
        [DataMember(Name = "text_data")]
        public string TextData { get; set; }

        [DataMember(Name = "encryption")]
        public bool Encryption { get; set; }

        [DataMember(Name = "key_size")]
        public int KeySize { get; set; }

        [DataMember(Name = "private_key_password")]
        public string PrivateKeyPassword { get; set; }
    }
}
