using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLTopic
/// </summary>
public class BLTopic
{
	protected AspLinqDataContext dc;

	public BLTopic()
	{
		dc = new AspLinqDataContext();
	}

	public List<Post> GetPostsInTopic(int topicId)
	{
		return (from Post in dc.Posts where Post.TopicId == topicId select Post).ToList();
	}

	public Member GetAuteur(int memberId)
	{
		return (from Member in dc.Members where Member.Id == memberId select Member).Single();
	}

	public void SetPinned(int topicId, bool pinned)
	{
		Topic newTopic = (from Topic in dc.Topics where Topic.Id == topicId select Topic).Single();
		newTopic.IsPinned = pinned;
		dc.SubmitChanges();
	}

	public void SetPinned(List<int> topicIds, bool pinned)
	{
		List<Topic> newTopics = (from Topic in dc.Topics where topicIds.Contains(Topic.Id) select Topic).ToList();

		foreach(Topic topic in newTopics)
		{
			topic.IsPinned = pinned;
		}

		dc.SubmitChanges();
	}

	public void SetLocked(int topicId, bool locked)
	{
		Topic newTopic = (from Topic in dc.Topics where Topic.Id == topicId select Topic).Single();
		newTopic.IsLocked = locked;
		dc.SubmitChanges();
	}

	public void SetLocked(List<int> topicIds, bool locked)
	{
		List<Topic> newTopics = (from Topic in dc.Topics where topicIds.Contains(Topic.Id) select Topic).ToList();

		foreach (Topic topic in newTopics)
		{
			topic.IsLocked = locked;
		}

		dc.SubmitChanges();
	}
}