using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewForum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int forumId;

        if (int.TryParse(Request.QueryString["id"], out forumId))
        {
            Forum forum = GetForum(forumId);

            foreach(Topic topic in forum.Topics)
            {
                if(topic.Posts.Count > 0)
                {
                    topic.Posts.OrderBy(post => post.CreatedDate);
                    topic.EerstePost = topic.Posts.First();
                    topic.LaatstePost = topic.Posts.Last();
                }
            }

            forum.Topics.OrderByDescending(topic => topic.Posts);

            LiteralForumNaam.Text = forum.Name;
            LiteralForumBeschrijving.Text = forum.Description;

            RepeaterTopics.DataSource = forum.Topics;
            RepeaterTopics.DataBind();
        }
    }

    protected Forum GetForum(int id)
    {
        AspLinqDataContext dc = new AspLinqDataContext();
        return (from Forum in dc.Forums where Forum.Id == id select Forum).Single();
    }

    protected List<Post> GetPostsInTopic(int topicId)
    {
        AspLinqDataContext dc = new AspLinqDataContext();
        return (from Post in dc.Posts where Post.TopicId == topicId select Post).ToList();
    }

    protected User GetAuteur(int userId)
    {
        AspLinqDataContext dc = new AspLinqDataContext();
        return (from User in dc.Users where User.Id == userId select User).Single();
    }
}