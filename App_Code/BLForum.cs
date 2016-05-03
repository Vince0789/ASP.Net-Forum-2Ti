using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLForum
/// </summary>
public class BLForum
{
    protected AspLinqDataContext dc;

    public BLForum()
    {
        dc = new AspLinqDataContext();
    }

    public Forum GetForumById(int id)
    {
        return (from Forum in dc.Forums where Forum.Id == id select Forum).SingleOrDefault();
    }

    public List<Forum> GetParentForums()
    {
        AspLinqDataContext dc = new AspLinqDataContext();
        return (from Forum in dc.Forums where Forum.ParentForumId == null select Forum).ToList();
    }
}