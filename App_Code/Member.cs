using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Member
/// </summary>
public partial class Member
{
	protected int postCount;

	public int PostCount
	{
		get { return this.Posts.Count; }
	}

	// gebruiker 1 is admin
	public bool IsAdmin()
	{
		return this.Id == 1;
	}

	public bool IsForumModerator(Forum forum)
	{
		return this.IsAdmin() || forum.ForumModerators.Select(fm => fm.Member.Id).Contains(this.Id);
	}

	public void UpdatePassword(string newPassword)
	{
		new BLMember().UpdatePassword(this, newPassword);
	}
}