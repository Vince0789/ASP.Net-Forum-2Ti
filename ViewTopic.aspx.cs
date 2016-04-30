using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewTopic : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
			return;

		// ===== DEBUG DEBUG DEBUG =====
		Session["user"] = GetUserById(2);
		// =============================

		// id in querystring?
		int topicId;

		if (!int.TryParse(Request.QueryString["id"], out topicId))
		{
			throw new HttpException(400, "Bad Request");
		}

		Topic topic;

		// bestaand topic?
		if((topic = GetTopic(topicId)) == null)
		{
			throw new HttpException(404, "Not Found");
		}

		// ja!
		Page.Title = LiteralTopicTitle.Text = topic.Title;
		HiddenFieldTopicId.Value = topic.Id.ToString();

		RepeaterPosts.DataSource = topic.Posts;
		RepeaterPosts.DataBind();
	}

	protected Topic GetTopic(int id)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Topic in dc.Topics where Topic.Id == id select Topic).SingleOrDefault();
	}

	protected void ButtonReply_Click(object sender, EventArgs e)
	{
		Session["replyingToTopic"] = GetTopic(int.Parse(HiddenFieldTopicId.Value));
		Response.Redirect("Reply.aspx");
	}

	protected void RepeaterPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		// variabelen die we nodig hebben
		Forum forum = GetTopic(int.Parse(HiddenFieldTopicId.Value)).Forum;
		User user = Session["user"] as User;
		Post post = e.Item.DataItem as Post;
		bool isMod = user.IsAdmin() || forum.GetModerators().Contains(user);

		// post optie lijst vinden
		BulletedList options = e.Item.FindControl("BulletedListPostOptions") as BulletedList;

		// gebruiker kan eigen posts bewerken
		if(isMod || post.User.Id == user.Id)
		{
			options.Items.Add(new ListItem("Edit", "EditPost.aspx?id=" + post.Id));
		}

		// moderators opties
		if(isMod)
		{
			// toon ip boven post
			(e.Item.FindControl("PanelModeratorPostDetails") as Panel).Visible = true;

			// voeg delete optie toe aan lijst
			options.Items.Add(new ListItem("Delete", "DeletePost.aspx?id=" + post.Id));
		}

		// voeg citeer optie toe aan lijst
		options.Items.Add(new ListItem("Quote", "Reply.aspx"));
	}

	protected bool IsUserLoggedIn()
	{
		return Session["user"] is User;
	}

	protected User GetUserById(int id)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from User in dc.Users where User.Id == id select User).SingleOrDefault();
	}
}