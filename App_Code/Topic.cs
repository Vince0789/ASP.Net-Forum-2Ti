using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Topic
/// </summary>
public partial class Topic
{
    protected Member author;
    protected Post eerstePost;
    protected Post laatstePost;

    public Post EerstePost
    {
        get
        {
            return this.Posts.OrderBy(post => post.CreatedDate).FirstOrDefault();
        }
    }

    public Post LaatstePost
    {
        get
        {
            return this.Posts.OrderBy(post => post.CreatedDate).LastOrDefault();
        }
    }

	public void SetPinned(bool pinned)
	{
		this.IsPinned = pinned;
		new BLTopic().SetPinned(this.Id, this.IsPinned);
	}

	public void SetLocked(bool locked)
	{
		this.IsLocked = locked;
		new BLTopic().SetLocked(this.Id, this.IsLocked);
	}
}