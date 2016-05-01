using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewTopic : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
			return;

		int forumId;

		if (int.TryParse(Request.QueryString["forumId"], out forumId))
		{
			Forum forum = GetForum(forumId);
			this.Title = LiteralPaginaTitel.Text = "Post new topic in " + forum.Name;
			HiddenFieldForumId.Value = forum.Id.ToString();
		}


	}

	protected Forum GetForum(int id)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Forum in dc.Forums where Forum.Id == id select Forum).Single();
	}

	protected void ButtonSubmit_Click(object sender, EventArgs e)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		Forum forum = GetForum(int.Parse(HiddenFieldForumId.Value));

		// insert topic
		Topic newTopic = new Topic();
		newTopic.Title = TextBoxTitle.Text;
		newTopic.ForumId = forum.Id;
		newTopic.IsLocked = CheckBoxLock.Checked;
		newTopic.IsPinned = CheckBoxPin.Checked;

		dc.Topics.InsertOnSubmit(newTopic);
		dc.SubmitChanges();

		// insert post
		Post newPost = new Post();
		newPost.TopicId = newTopic.Id;
		newPost.MemberId = (Session["member"] as Member).Id;
		newPost.Content = TextBoxContent.Text;
		newPost.CreatedDate = DateTime.Now;
		newPost.FromIP = Request.UserHostAddress;

		dc.Posts.InsertOnSubmit(newPost);
		dc.SubmitChanges();

		Response.Redirect("~/ViewTopic.aspx?id=" + newTopic.Id);
	}
}