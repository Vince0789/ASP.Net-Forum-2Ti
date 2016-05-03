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
}