using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AssignModerator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        Member member = GetMemberFromQueryString();

        LiteralMemberName.Text = member.Name;
        PopulateRepeater(member);
    }
    
    protected Member GetMemberFromQueryString()
    {
        int memberId;

        if (!int.TryParse(Request.QueryString["memberId"], out memberId))
            throw new HttpException(400, "Bad Request");

        Member member = new BLMember().GetMemberById(memberId);

        if (member == null)
            throw new HttpException(404, "Not Found");

        return member;
    }

    protected void PopulateRepeater(Member member)
    {
        RepeaterPermissions.Visible = false;
        LabelNoPermissions.Visible = false;

        List<Forum> forums = member.ForumModerators.Select(fm => fm.Forum).OrderBy(f => f.Name).ToList();

        if (forums.Count > 0)
        {
            RepeaterPermissions.DataSource = forums;
            RepeaterPermissions.DataBind();
            RepeaterPermissions.Visible = true;
        }
        else
        {
            LabelNoPermissions.Visible = true;
        }
    }

    protected void RepeaterPermissions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink link = e.Item.FindControl("HyperLinkManageForum") as HyperLink;
            Forum forum = e.Item.DataItem as Forum;

            link.Text = forum.Name;
            link.NavigateUrl = "~/admin/ManageForum.aspx?id=" + forum.Id;
        }
    }

    private void Page_LoadComplete(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        // pagina laadt voor master page ... 
        // treeview ophalen uit masterpage en in dropdown steken
        AdminLayout masterPage = Master as AdminLayout;
        TreeView treeViewForums = masterPage.FindControl("TreeViewForums") as TreeView;

        foreach (TreeNode n in treeViewForums.Nodes)
        {
            PrintRecursive(n);
        }
    }

    // https://msdn.microsoft.com/en-us/library/wwc698z7%28v=vs.110%29.aspx
    private void PrintRecursive(TreeNode treeNode)
    {
        StringBuilder title = new StringBuilder();

        for (int i = 0; i < treeNode.Depth + 1; i++)
        {
            title.Append("-");
        }

        title.Append(" ");
        title.Append(treeNode.Text);

        DropDownListForums.Items.Add(new ListItem(title.ToString(), treeNode.Value));

        // Print each node recursively.
        foreach (TreeNode tn in treeNode.ChildNodes)
        {
            PrintRecursive(tn);
        }
    }

    protected void ButtonAddModerator_Click(object sender, EventArgs e)
    {
        BLForum blForum = new BLForum();

        Forum forum = blForum.GetForumById(int.Parse(DropDownListForums.SelectedValue));
        Member member = GetMemberFromQueryString();

        blForum.AddModerator(forum, member);
        PopulateRepeater(member);
    }
}