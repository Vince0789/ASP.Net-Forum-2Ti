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
        List<Forum> parents = GetParentForums();
        foreach(Forum parent in parents)
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
        ListView list = (ListView) e.Item.FindControl("DataListForums");

        list.DataSource = ((Forum)e.Item.DataItem).Children;
        list.DataBind();
    }
}