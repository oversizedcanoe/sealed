namespace Sealed.Database.Models;

public partial class UserEntry
{
    public long UserEntryId { get; set; }

    public long PublicKeyId { get; set; }

    public virtual Key PublicKey { get; set; } = null!;
}
