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

	public List<Forum> GetAll()
	{
		return (from Forum in dc.Forums select Forum).ToList();
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

    public bool AddModerator(Forum forum, Member member)
    {
        if (member.IsForumModerator(forum))
            return false;

        ForumModerator moderator = new ForumModerator();
        moderator.ForumId = forum.Id;
        moderator.MemberId = member.Id;

        dc.ForumModerators.InsertOnSubmit(moderator);
        dc.SubmitChanges();
        return true;
    }

    public bool RemoveModerator(Forum forum, Member member)
    {
        ForumModerator moderator = (from ForumModerator in dc.ForumModerators where ForumModerator.MemberId == member.Id where ForumModerator.ForumId == forum.Id select ForumModerator).SingleOrDefault();

        if (moderator == null)
            return false;

        dc.ForumModerators.DeleteOnSubmit(moderator);
        dc.SubmitChanges();
        return true;
    }

	public void Insert(ref Forum forum)
	{
		dc.Forums.InsertOnSubmit(forum);
		dc.SubmitChanges();
	}

	public void Update(ref Forum forum)
	{
		Forum handle = this.GetForumById(forum.Id);

		handle.Id = forum.Id;
		handle.Name = forum.Name;
		handle.Description = forum.Description;
		handle.ParentForumId = forum.ParentForumId;
		handle.IsCategory = forum.IsCategory;

		dc.SubmitChanges();
		forum = handle;
	}

	// recursief tellen
	public int CountAllTopics(Forum forum)
	{
		int total = forum.Topics.Count;

		foreach(Forum child in forum.Children)
		{
			total += CountAllTopics(child);
		}

		return total;
	}

	public int CountAllPosts(Forum forum)
	{
		int total = forum.Topics.Sum(topic => topic.Posts.Count);

		foreach (Forum child in forum.Children)
		{
			total += CountAllPosts(child);
		}

		return total;
	}

}