using System;
using System.Collections.Generic;

namespace Sealed.Database;

public partial class Codetype
{
    public int Codetypeid { get; set; }

    public string? Codetypename { get; set; }

    public virtual ICollection<Code> Codes { get; set; } = new List<Code>();
}
