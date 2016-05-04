﻿using System;
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

		Forum forum = ForumFromQueryString();
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

			GridViewTopics.AutoGenerateColumns = false;
			GridViewTopics.ShowHeader = false;
			GridViewTopics.AllowPaging = true;
			GridViewTopics.PagerSettings.Mode = PagerButtons.NumericFirstLast;
			GridViewTopics.DataSource = forum.Topics.OrderByDescending(topic => topic.IsPinned).ThenByDescending(topic => topic.LaatstePost.CreatedDate).ToList();
			GridViewTopics.DataBind();

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

	protected Forum ForumFromQueryString()
	{
		int forumId;

		if (!int.TryParse(Request.QueryString["id"], out forumId))
			throw new HttpException(400, "Bad Request");

		Forum forum = new BLForum().GetForumById(forumId);

		if (forum == null)
			throw new HttpException(404, "Not Found");

		return forum;
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

	protected void GridViewTopics_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			Topic topic = e.Row.DataItem as Topic;

			(e.Row.FindControl("LabelTopicPinned") as Label).Visible = topic.IsPinned;
			(e.Row.FindControl("ImageTopicLocked") as Image).Visible = topic.IsLocked;

			Label labelPostsInTopic = e.Row.FindControl("LabelPostsInTopic") as Label;
			int replies = topic.Posts.Count - 1;
			labelPostsInTopic.Text = replies.ToString() + "&nbsp;";
			labelPostsInTopic.Text += (replies == 1) ? "reply" : "replies";
		}
	}

	protected void GridViewTopics_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		Forum forum = ForumFromQueryString();

		GridViewTopics.PageIndex = e.NewPageIndex;
		GridViewTopics.DataSource = forum.Topics.OrderByDescending(topic => topic.IsPinned).ThenByDescending(topic => topic.LaatstePost.CreatedDate).ToList();
		GridViewTopics.DataBind();
	}

	protected void GridViewTopics_PageIndexChanged(object sender, EventArgs e)
	{

	}
}