namespace Sealed.Domain.Models;

public partial class KeyPair
{
    public long KeyPairId { get; set; }

    public long PrivateKeyId { get; set; }

    public long PublicKeyId { get; set; }

    public virtual Key PrivateKey { get; set; } = null!;

    public virtual Key PublicKey { get; set; } = null!;
}
