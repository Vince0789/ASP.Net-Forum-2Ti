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

		// ===== DEBUG DEBUG DEBUG =====
		Session["member"] = GetMemberById(1);
		// =============================

		Page.Title = "Forum Index";

		ListViewCategories.DataSource = GetParentForums();
		ListViewCategories.DataBind();

		BulletedList breadcrumb = Master.FindControl("BulletedListBreadCrumb") as BulletedList;
		breadcrumb.Items.Add(new ListItem("Forum Index", "#"));
	}

	protected Member GetMemberById(int id)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Member in dc.Members where Member.Id == id select Member).SingleOrDefault();
	}

	private List<Forum> GetParentForums()
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Forum in dc.Forums where Forum.ParentForumId == null select Forum).ToList();
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
		Panel panelSubforums = e.Item.FindControl("PanelSubforums") as Panel;
		
		panelSubforums.Visible = forum.Children.Count > 0;

		if(panelSubforums.Visible)
		{
			BulletedList listSubforums = e.Item.FindControl("BulletedListSubforums") as BulletedList;

			foreach(Forum child in forum.Children)
			{
				listSubforums.Items.Add(new ListItem(child.Name, "ViewForum.aspx?id=" + child.Id));
			}
		}

		if (forum.Topics.Count > 0)
		{
			Literal topicCount = (Literal)e.Item.FindControl("LiteralTopicCount");
			topicCount.Text = forum.Topics.Count.ToString();

			Literal postCount = (Literal)e.Item.FindControl("LiteralPostCount");
			postCount.Text = (forum.Topics.Sum(topic => topic.Posts.Count)).ToString();
		}
	}
}