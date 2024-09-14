namespace Sealed.Database.Models;

public partial class KeyType
{
    public int KeyTypeId { get; set; }

    public string? KeyTypeName { get; set; }

    public virtual ICollection<Key> Keys { get; set; } = new List<Key>();
}
