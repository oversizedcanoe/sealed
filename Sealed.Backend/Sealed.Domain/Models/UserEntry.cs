using System.ComponentModel.DataAnnotations;

namespace Sealed.Domain.Models;

public partial class UserEntry
{
    public long UserEntryId { get; set; }

    public long PrivateKeyId { get; set; }

    [MaxLength(500)]
    public string EntryText { get; set; }

    public virtual Key PrivateKey { get; set; } = null!;
}
