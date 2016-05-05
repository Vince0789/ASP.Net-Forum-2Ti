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

	public List<Topic> GetTopicsById(List<int> topicIds)
	{
		return (from Topic in dc.Topics where topicIds.Contains(Topic.Id) select Topic).ToList();
	}

	public void Delete(Topic topic)
	{
		dc.Posts.DeleteAllOnSubmit(topic.Posts);
		dc.Topics.DeleteOnSubmit(topic);
		dc.SubmitChanges();
	}

	public void Delete(List<Topic> topics)
	{
		foreach(Topic topic in topics)
		{
			this.Delete(topic);
		}
	}

	public void SetPinned(int topicId, bool pinned)
	{
		Topic newTopic = (from Topic in dc.Topics where Topic.Id == topicId select Topic).Single();
		newTopic.IsPinned = pinned;
		dc.SubmitChanges();
	}

	public void SetPinned(List<Topic> topics, bool pinned)
	{
		List<Topic> newTopics = (from Topic in dc.Topics where topics.Contains(Topic) select Topic).ToList();

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

	public void SetLocked(List<Topic> topics, bool locked)
	{
		List<Topic> newTopics = (from Topic in dc.Topics where topics.Contains(Topic) select Topic).ToList();

		foreach (Topic topic in newTopics)
		{
			topic.IsLocked = locked;
		}

		dc.SubmitChanges();
	}
}