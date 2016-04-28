using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Forum
/// </summary>
public partial class Forum
{
    protected List<Forum> children;

    public List<Forum> Children
    {
        get;
        set;
    }
}