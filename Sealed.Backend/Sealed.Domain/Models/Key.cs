namespace Sealed.Domain.Models;

public partial class Key
{
    public long KeyId { get; set; }

    public Guid Code { get; set; }

    public int KeyTypeId { get; set; }

    public virtual KeyType KeyType { get; set; } = null!;
}
