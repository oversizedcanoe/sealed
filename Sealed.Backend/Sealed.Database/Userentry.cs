using System;
using System.Collections.Generic;

namespace Sealed.Database;

public partial class Userentry
{
    public long Userentryid { get; set; }

    public long Publiccodeid { get; set; }

    public virtual Code Publiccode { get; set; } = null!;
}
