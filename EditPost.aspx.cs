using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

public partial class EditPost : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
			return;

        Post post = GetPostFromQueryString();
		LiteralPaginaTitel.Text = "Editing post from " + post.Member.Name + " in " + post.Topic.Title;
        TextBoxContent.Text = UnParseHTML(post.Content);

        (Master as Layout).GenerateBreadCrumb(post.Topic.Forum);
	}

	protected void ButtonSubmit_Click(object sender, EventArgs e)
	{
        // moet dit zo ophalen ivm datacontext
        BLPost blPost = new BLPost();
        Post post = blPost.GetPostById(GetPostFromQueryString().Id);

        string content = TextBoxContent.Text;
        ParseQuotes(ref content);
        post.Content = content;

        blPost.Update();

		Response.Redirect("~/ViewTopic.aspx?id=" + post.Topic.Id);
	}

    protected Post GetPostFromQueryString()
    {
        int postId;

        if (!int.TryParse(Request.QueryString["id"], out postId))
            throw new HttpException(400, "Bad Request");

        Post post = new BLPost().GetPostById(postId);

        if (post == null)
            throw new HttpException(404, "Not Found");

        return post;
    }

    protected string UnParseHTML(string content)
    {
        string pattern = @"<blockquote><p>(.*?)<\/p><footer>(.*?),\s{0,1}(.*?)<\/footer><\/blockquote>";
        Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

        string output = content;
        Match m = r.Match(content);

        while(m.Success)
        {
            string text = m.Groups[1].Value;
            string name = m.Groups[2].Value;
            string date = m.Groups[3].Value;

            output = r.Replace(output, "[quote name='" + name + "' date='" + date + "']" + text + "[/quote]");
            m = m.NextMatch();
        }
        return output;
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