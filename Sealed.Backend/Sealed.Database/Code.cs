using System;
using System.Collections.Generic;

namespace Sealed.Database;

public partial class Code
{
    public long Codeid { get; set; }

    public Guid? Code1 { get; set; }

    public int? Codetypeid { get; set; }

    public virtual Codetype? Codetype { get; set; }

    public virtual ICollection<Userentry> Userentries { get; set; } = new List<Userentry>();
}
