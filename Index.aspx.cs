using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
			return;

		Page.Title = "Forum Index";

		List<Forum> parents = GetParentForums();
		foreach (Forum parent in parents)
		{
			parent.Children = GetSubForums(parent.Id);
		}

		ListViewCategories.DataSource = parents;
		ListViewCategories.DataBind();
	}

	private List<Forum> GetParentForums()
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Forum in dc.Forums where Forum.ParentForumId == null select Forum).ToList();
	}

	private List<Forum> GetSubForums(int parentForumId)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Forum in dc.Forums where Forum.ParentForumId == parentForumId select Forum).ToList();
	}

	protected void ListViewCategories_ItemDataBound(object sender, ListViewItemEventArgs e)
	{
		ListView list = (ListView)e.Item.FindControl("ListViewForums");

		list.DataSource = ((Forum)e.Item.DataItem).Children;
		list.DataBind();
	}

	protected void ListViewForums_ItemDataBound(object sender, ListViewItemEventArgs e)
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
}