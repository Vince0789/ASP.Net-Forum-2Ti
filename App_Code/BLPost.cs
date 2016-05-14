using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLPost
/// </summary>
public class BLPost
{
	protected AspLinqDataContext dc;

	public BLPost()
	{
		dc = new AspLinqDataContext();
	}

	public int CountAll()
	{
		return dc.Posts.Count();
	}

	public Post GetPostById(int id)
	{
		return (from Post in dc.Posts where Post.Id == id select Post).SingleOrDefault();
	}

	public void Insert(Post post)
	{
		dc.Posts.InsertOnSubmit(post);
		dc.SubmitChanges();
	}

	public void Delete(Post post)
	{
		dc.Posts.DeleteOnSubmit(post);
		dc.SubmitChanges();
	}

}