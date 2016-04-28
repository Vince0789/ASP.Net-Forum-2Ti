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
        int topicId;

        if (int.TryParse(Request.QueryString["id"], out topicId))
        {
            Topic topic = GetTopic(topicId);

            RepeaterPosts.DataSource = topic.Posts;
            RepeaterPosts.DataBind();
        }
    }

    protected Topic GetTopic(int id)
    {
        AspLinqDataContext dc = new AspLinqDataContext();
        return (from Topic in dc.Topics where Topic.Id == id select Topic).Single();
    }
}