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
            forum.Topics.OrderByDescending(topic => topic.EerstePost.CreatedDate);

            LiteralForumNaam.Text = forum.Name;
            LiteralForumBeschrijving.Text = forum.Description;
            HyperLinkNewTopic.NavigateUrl = "NewTopic.aspx?forumId=" + forum.Id;

            RepeaterTopics.DataSource = forum.Topics;
            RepeaterTopics.DataBind();
        }

        ListItem[] listItems =
        {
            new ListItem("Pin"),
            new ListItem("Unpin"),
            new ListItem("Lock"),
            new ListItem("Unlock"),
            new ListItem("Delete")
        };

        DropDownListTopicAction.Items.AddRange(listItems);
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