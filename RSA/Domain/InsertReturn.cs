namespace RSA.Domain
{
    public class InsertReturn
    {
        public int UUID { get; set; }
        public string? pkcs8 { get; set; }
        public string encryptedText { get; set; }
    }
}
