using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public partial class User
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
}