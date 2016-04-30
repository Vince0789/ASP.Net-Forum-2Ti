using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reply : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
			return;

		Topic topic = Session["replyingToTopic"] as Topic;
		Post quotedPost = Session["quotedPost"] as Post;

		LiteralPaginaTitel.Text = topic.Title;

		if(quotedPost != null)
		{
			TextBoxContent.Text = string.Format("[quote name='{0}' date='{1}']{2}[/quote]", quotedPost.User.Name, quotedPost.CreatedDate, quotedPost.Content);
		}
	}

	protected void ButtonSubmit_Click(object sender, EventArgs e)
	{

	}
}