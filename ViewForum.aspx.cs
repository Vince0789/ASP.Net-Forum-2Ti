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

		Forum forum = GetForumById(forumId);

		if(forum == null)
			throw new HttpException(404, "Not Found");

		// breadcrumb opbouwen in omgekeerde volgorde
		BulletedList breadcrumb = Master.FindControl("BulletedListBreadCrumb") as BulletedList;
		List<ListItem> items = new List<ListItem>();
		Forum breadcrumbForum = forum;

		while (breadcrumbForum != null)
		{
			items.Add(new ListItem(breadcrumbForum.Name, "ViewForum.aspx?id=" + breadcrumbForum.Id));
			breadcrumbForum = breadcrumbForum.ParentForumId.HasValue ? GetForumById(breadcrumbForum.ParentForumId.Value) : null;
		}

		items.Add(new ListItem("Forum Index", "Index.aspx"));
		items.Reverse();
		breadcrumb.Items.AddRange(items.ToArray());
		// end breadcrumb

		Page.Title = forum.Name;
		LiteralForumNaam.Text = forum.Name;
		LiteralForumBeschrijving.Text = forum.Description != null ? forum.Description : forum.Name;

		PanelSubforums.Visible = forum.Children.Count > 0;
		PanelTopicList.Visible = !forum.IsCategory;

		if(PanelSubforums.Visible)
		{
			ListViewSubforums.DataSource = forum.Children;
			ListViewSubforums.DataBind();
		}

		if (PanelTopicList.Visible)
		{
			forum.Topics.OrderByDescending(topic => topic.EerstePost.CreatedDate);
			HyperLinkNewTopic.NavigateUrl = "NewTopic.aspx?forumId=" + forum.Id;

			RepeaterTopics.DataSource = forum.Topics;
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

	protected Forum GetForumById(int id)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Forum in dc.Forums where Forum.Id == id select Forum).SingleOrDefault();
	}

	protected List<Post> GetPostsInTopic(int topicId)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Post in dc.Posts where Post.TopicId == topicId select Post).ToList();
	}

	protected Member GetAuteur(int memberId)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Member in dc.Members where Member.Id == memberId select Member).Single();
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
}