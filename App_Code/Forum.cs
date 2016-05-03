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
		get
		{
			AspLinqDataContext dc = new AspLinqDataContext();
			return (from Forum in dc.Forums where Forum.ParentForumId == this.Id select Forum).ToList();
		}
	}


	public List<Member> GetModerators()
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from ForumModerator in dc.ForumModerators where ForumModerator.ForumId == this.Id select ForumModerator.Member).ToList();
	}
}