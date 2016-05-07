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

        Member member = (Session["member"] as Member);

        if(member != null)
        {
            BulletedListUserMenu.Items.Add(new ListItem(member.Name, "UserCP.aspx"));

            if(member.IsAdmin())
            {
                BulletedListUserMenu.Items.Add(new ListItem("Admin CP", "admin/AdminCP.aspx"));
            }

            BulletedListUserMenu.Items.Add(new ListItem("Logout", "Login.aspx?do=logout"));
        }
        else
        {
            BulletedListUserMenu.Items.Add(new ListItem("Register", "Registration.aspx"));
            BulletedListUserMenu.Items.Add(new ListItem("Login", "Login.aspx"));
        }
    }

    public void GenerateBreadCrumb(Forum lastChild)
    {
        BLForum blForum = new BLForum();

        List<ListItem> items = new List<ListItem>();
        Forum breadcrumbForum = lastChild;

        while (breadcrumbForum != null)
        {
            items.Add(new ListItem(breadcrumbForum.Name, "ViewForum.aspx?id=" + breadcrumbForum.Id));
            breadcrumbForum = breadcrumbForum.ParentForumId.HasValue ? blForum.GetForumById(breadcrumbForum.ParentForumId.Value) : null;
        }

        items.Add(new ListItem("Forum Index", "Index.aspx"));
        items.Reverse();
        BulletedListBreadCrumb.Items.AddRange(items.ToArray());
    }
}
