using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Forum
/// </summary>
public partial class Forum
{
	protected Forum parent;
	protected IEnumerable<Forum> children;

	public Forum Parent
	{
		get
		{
			AspLinqDataContext dc = new AspLinqDataContext();
			return (from Forum in dc.Forums where Forum.Id == this.ParentForumId select Forum).SingleOrDefault();
		}
		set
		{
			this.Parent = value;
		}
	}

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

	public List<Member> GetModerators()
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from ForumModerator in dc.ForumModerators where ForumModerator.ForumId == this.Id select ForumModerator.Member).ToList();
	}
}
