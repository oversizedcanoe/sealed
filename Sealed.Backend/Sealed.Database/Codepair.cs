using System;
using System.Collections.Generic;

namespace Sealed.Database;

public partial class Codepair
{
    public long Privatecodeid { get; set; }

    public long Publiccodeid { get; set; }

    public virtual Code Privatecode { get; set; } = null!;

    public virtual Code Publiccode { get; set; } = null!;
}
