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

		// id in querystring?
		int topicId;

		if (!int.TryParse(Request.QueryString["id"], out topicId))
		{
			throw new HttpException(400, "Bad Request");
		}

		Topic topic;

		// bestaand topic?
		if ((topic = GetTopic(topicId)) == null)
		{
			throw new HttpException(404, "Not Found");
		}

		// ja!
		BulletedList breadcrumb = Master.FindControl("BulletedListBreadCrumb") as BulletedList;

		// opbouwen in omgekeerde volgorde
		List<ListItem> items = new List<ListItem>();
		ListItem itemTopic = new ListItem(topic.Title, "#");
		itemTopic.Attributes.Add("class", "active");
		items.Add(itemTopic);

		Forum forum = topic.Forum;

		while (forum != null)
		{
			items.Add(new ListItem(forum.Name, "ViewForum.aspx?id=" + forum.Id));
			forum = forum.ParentForumId.HasValue ? GetForumById(forum.ParentForumId.Value) : null;
		}

		items.Add(new ListItem("Forum Index", "Index.aspx"));

		items.Reverse();
		breadcrumb.Items.AddRange(items.ToArray());

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
		Reply(GetTopic(int.Parse(HiddenFieldTopicId.Value)), null);
	}

	protected void RepeaterPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		// variabelen die we nodig hebben
		Forum forum = GetTopic(int.Parse(HiddenFieldTopicId.Value)).Forum;
		Member member = Session["member"] as Member;
		Post post = e.Item.DataItem as Post;

		bool isMod = member.IsAdmin() || forum.GetModerators().Contains(member);

		// post id instellen
		(e.Item.FindControl("HiddenFieldPostId") as HiddenField).Value = post.Id.ToString();

		// post optie lijst vinden
		BulletedList options = e.Item.FindControl("BulletedListPostOptions") as BulletedList;

		// gebruiker kan eigen posts bewerken
		if (isMod || post.Member.Id == member.Id)
		{
			options.Items.Add(new ListItem("Edit", "EditPost.aspx?id=" + post.Id));
		}

		// moderators opties
		if (isMod)
		{
			// toon ip boven post
			(e.Item.FindControl("PanelModeratorPostDetails") as Panel).Visible = true;

			// eerste post mag niet verwijderd worden
			if (e.Item.ItemIndex != 0)
			{
				// voeg delete optie toe aan lijst
				options.Items.Add(new ListItem("Delete", "DeletePost.aspx?id=" + post.Id));
			}
		}

		// voeg citeer optie toe aan lijst
		options.Items.Add(new ListItem("Quote", "Reply.aspx"));
	}

	protected bool IsUserLoggedIn()
	{
		return Session["member"] is Member;
	}

	protected Forum GetForumById(int id)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Forum in dc.Forums where Forum.Id == id select Forum).SingleOrDefault();
	}

	protected Post GetPostById(int id)
	{
		AspLinqDataContext dc = new AspLinqDataContext();
		return (from Post in dc.Posts where Post.Id == id select Post).SingleOrDefault();
	}

	protected void BulletedListPostOptions_Click(object sender, BulletedListEventArgs e)
	{
		BulletedList options = sender as BulletedList;
		RepeaterItem item = options.Parent as RepeaterItem;

		if(options.Items[e.Index].Text == "Quote")
		{
			Topic topic = GetTopic(int.Parse(HiddenFieldTopicId.Value));
			Post quotedPost = GetPostById(int.Parse((item.FindControl("HiddenFieldPostId") as HiddenField).Value));
			Reply(topic, quotedPost);
		}
	}

	protected void Reply(Topic topic, Post quotedPost)
	{
		Session["replyingToTopic"] = topic;
		Session["quotedPost"] = quotedPost;
		Response.Redirect("Reply.aspx");
	}
}