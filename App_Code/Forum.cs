using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Forum
/// </summary>
public partial class Forum
{
	protected IEnumerable<Forum> children;
    protected IEnumerable<Member> moderators;

	public List<Forum> Children
	{
		get
		{
			AspLinqDataContext dc = new AspLinqDataContext();
			return (from Forum in dc.Forums where Forum.ParentForumId == this.Id select Forum).ToList();
		}
		set
		{
			this.Children = value;
		}
	}

    public IEnumerable<Member> Moderators
    {
        get { return this.ForumModerators.Select(fm => fm.Member).OrderBy(m => m.Name); }
    }
}
