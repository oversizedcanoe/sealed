namespace Sealed.Domain.DTOs
{
    public record KeyPairDTO
    {
        public KeyDTO PrivateKey { get; set; }
        public KeyDTO PublicKey { get; set; }
    }
}
