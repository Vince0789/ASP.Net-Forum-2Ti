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
		if (IsPostBack)
			return;

		int forumId;

		if (!int.TryParse(Request.QueryString["id"], out forumId))
			throw new HttpException(400, "Bad Request");

		Forum forum = new BLForum().GetForumById(forumId);

		if (forum == null)
			throw new HttpException(404, "Not Found");

		(Master as Layout).GenerateBreadCrumb(forum);

		Page.Title = forum.Name;
		LiteralForumNaam.Text = forum.Name;
		LiteralForumBeschrijving.Text = forum.Description != null ? forum.Description : forum.Name;

		PanelSubforums.Visible = forum.Children.Count > 0;
		PanelTopicList.Visible = !forum.IsCategory;

		if (PanelSubforums.Visible)
		{
			ListViewSubforums.DataSource = forum.Children;
			ListViewSubforums.DataBind();
		}

		if (PanelTopicList.Visible)
		{
			string moderators = string.Join(", ", forum.ForumModerators.Select(fm => fm.Member.Name));
			LabelForumModerators.Text = (moderators.Length > 0) ? moderators : "Administrators";

			HyperLinkNewTopic.NavigateUrl = "NewTopic.aspx?forumId=" + forum.Id;

			RepeaterTopics.DataSource = forum.Topics.OrderByDescending(topic => topic.IsPinned).ThenByDescending(topic => topic.LaatstePost.CreatedDate);
			RepeaterTopics.DataBind();

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
	}

	protected void ListViewSubforums_ItemDataBound(object sender, ListViewItemEventArgs e)
	{
		Forum forum = e.Item.DataItem as Forum;

		if (forum.Topics.Count > 0)
		{
			Literal topicCount = (Literal)e.Item.FindControl("LiteralTopicCount");
			topicCount.Text = forum.Topics.Count.ToString();

			Literal postCount = (Literal)e.Item.FindControl("LiteralPostCount");
			postCount.Text = (forum.Topics.Sum(topic => topic.Posts.Count)).ToString();
		}
	}

	protected void RepeaterTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		Topic topic = e.Item.DataItem as Topic;

		(e.Item.FindControl("LabelTopicPinned") as Label).Visible = topic.IsPinned;
		(e.Item.FindControl("ImageTopicLocked") as Image).Visible = topic.IsLocked;

		Label labelPostsInTopic = e.Item.FindControl("LabelPostsInTopic") as Label;
		int replies = topic.Posts.Count - 1;
		labelPostsInTopic.Text = replies.ToString() + "&nbsp;";
		labelPostsInTopic.Text += (replies == 1) ? "reply" : "replies";
	}
}