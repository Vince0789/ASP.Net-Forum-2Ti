using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

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
			TextBoxContent.Text = string.Format("[quote name='{0}' date='{1}']{2}[/quote]", quotedPost.Member.Name, quotedPost.CreatedDate, quotedPost.Content);
		}

    (Master as Layout).GenerateBreadCrumb(topic.Forum);
	}

	protected void ButtonSubmit_Click(object sender, EventArgs e)
	{
		Topic topic = Session["replyingToTopic"] as Topic;
		Member member = Session["member"] as Member;

		if(topic == null || member == null)
		{
			Response.Redirect("~/Login.aspx", true);
		}

		string content = TextBoxContent.Text;

		ParseQuotes(ref content);

		Post post = new Post();
		post.TopicId = topic.Id;
		post.MemberId = member.Id;
		post.Content = content;
		post.CreatedDate = DateTime.Now;
		post.FromIP = Request.UserHostAddress;

		new BLPost().Insert(post);
		Response.Redirect("~/ViewTopic.aspx?id=" + topic.Id);
	}

	protected void ParseQuotes(ref string content)
	{
		string pattern = @"\[quote\s{0,1}(.*?)\](.*)\[\/quote\]";
		Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

		Match m = r.Match(content);

		while(m.Success)
		{
			string options = m.Groups[1].Value;
			string quotedText = m.Groups[2].Value;

			string name;
			DateTime date;

			ParseQuoteOptions(options, out name, out date);
			content = r.Replace(content, "<blockquote><p>" + quotedText + "</p><footer>" + name + ", " + date.ToString() + "</footer></blockquote>");

			m = m.NextMatch();
		}
	}

	protected void ParseQuoteOptions(string options, out string quotedName, out DateTime quotedDate)
	{
		quotedName = "Unknown";
		quotedDate = DateTime.Now;

		string pattern = @"(\w+)='(.+?)'";
		Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

		Match m = r.Match(options);

		while(m.Success)
		{
			string key = m.Groups[1].Value;
			string value = m.Groups[2].Value;

			switch(key)
			{
				case "name":
					quotedName = value;
					break;
				case "date":
					quotedDate = DateTime.Parse(value);
					break;
			}

			m = m.NextMatch();
		}
	}
}