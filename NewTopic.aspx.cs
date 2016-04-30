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

		Topic newTopic = new Topic();
		newTopic.Title = TextBoxTitle.Text;
		newTopic.IsLocked = CheckBoxLock.Checked;
		newTopic.IsPinned = CheckBoxPin.Checked;
		newTopic.Forum = forum;

		forum.Topics.Add(newTopic);

		Post newPost = new Post();
		newPost.Topic = newTopic;
		newPost.CreatedDate = DateTime.Now;
		newPost.Content = TextBoxContent.Text;
		newPost.FromIP = Request.UserHostAddress;
		//newPost.User = ;

		newTopic.Posts.Add(newPost);

		dc.Topics.InsertOnSubmit(newTopic);
		dc.SubmitChanges();
	}
}