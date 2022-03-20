namespace RSA.Domain
{
    public class SelectReturn
    {
        public string? encryptedText { get; set; }
        public string? decryptedText { get; set; }
        public int keySize { get; set; }
        public string? privateKeyPassword { get; set; }
    }
}
