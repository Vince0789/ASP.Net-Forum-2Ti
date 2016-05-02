using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
    }

    public void GenerateBreadCrumb(Forum lastChild)
    {
        List<ListItem> items = new List<ListItem>();
        Forum breadcrumbForum = lastChild;

        while (breadcrumbForum != null)
        {
            items.Add(new ListItem(breadcrumbForum.Name, "ViewForum.aspx?id=" + breadcrumbForum.Id));
            breadcrumbForum = breadcrumbForum.ParentForumId.HasValue ? GetForumById(breadcrumbForum.ParentForumId.Value) : null;
        }

        items.Add(new ListItem("Forum Index", "Index.aspx"));
        items.Reverse();
        BulletedListBreadCrumb.Items.AddRange(items.ToArray());
    }

    protected Forum GetForumById(int id)
    {
        AspLinqDataContext dc = new AspLinqDataContext();
        return (from Forum in dc.Forums where Forum.Id == id select Forum).SingleOrDefault();
    }
}
