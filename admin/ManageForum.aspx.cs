using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ManageForum : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		PanelAlert.Visible = false;

		int forumId;

		if (!int.TryParse(Request.QueryString["id"], out forumId))
			throw new HttpException(400, "Bad Request");

		BLForum blForum = new BLForum();

		Forum forum = blForum.GetForumById(forumId);

		if (forum == null)
		{
			forum = new Forum();
			forum.Name = "New Forum";
		}

		LabelPageTitle.Text = forum.Name;
		Page.Title = "Manage Forum: \"" + forum.Name + "\"";

		// dit is blijkbaar niet expliciet nodig, gvd een uur zitten vloeken op deze bug
		// Page.LoadComplete += new EventHandler(Page_LoadComplete); 

		DropDownListForumParent.Items.Add(new ListItem("(None)", "0"));
        PopulateGridView(forum);
	}

    private void PopulateGridView(Forum forum)
    {
        GridViewForumModerators.DataSource = forum.Moderators;
        GridViewForumModerators.DataKeyNames = new string[] { "Id" };
        GridViewForumModerators.DataBind();
    }

	private void Page_LoadComplete(object sender, EventArgs e)
	{
		// pagina laadt voor master page ... 
		// treeview ophalen uit masterpage en in dropdown steken
		AdminLayout masterPage = Master as AdminLayout;
		TreeView treeViewForums = masterPage.FindControl("TreeViewForums") as TreeView;

		foreach (TreeNode n in treeViewForums.Nodes)
		{
			PrintRecursive(n);
		}

		// form vullen
		Forum forum = new BLForum().GetForumById(int.Parse(Request.QueryString["id"]));

		if(forum == null)
		{
			forum = new Forum();
			ButtonDeleteForum.Visible = false;
			ButtonSaveChanges.Text = "Create";
		}

		TextBoxForumName.Text = forum.Name;
		TextBoxForumDescription.Text = forum.Description;
		DropDownListForumParent.SelectedValue = (forum.ParentForumId == null) ? "0" : forum.ParentForumId.ToString();
		CheckBoxForumCategory.Checked = forum.IsCategory;
	}

	// https://msdn.microsoft.com/en-us/library/wwc698z7%28v=vs.110%29.aspx
	private void PrintRecursive(TreeNode treeNode)
	{
		StringBuilder title = new StringBuilder();

		for(int i = 0; i < treeNode.Depth + 1; i++)
		{
			title.Append("-");
		}

		title.Append(" ");
		title.Append(treeNode.Text);

		DropDownListForumParent.Items.Add(new ListItem(title.ToString(), treeNode.Value));

		// Print each node recursively.
		foreach (TreeNode tn in treeNode.ChildNodes)
		{
			PrintRecursive(tn);
		}
	}

	protected void ButtonSaveChanges_Click(object sender, EventArgs e)
	{
		BLForum blForum = new BLForum();
		Forum forum = blForum.GetForumById(int.Parse(Request.QueryString["id"]));

		if(forum == null)
			forum = new Forum();

		int? parentForumId = int.Parse(DropDownListForumParent.SelectedValue);

		forum.Name = TextBoxForumName.Text;
		forum.Description = TextBoxForumDescription.Text;
		forum.ParentForumId = (parentForumId == 0) ? null : parentForumId;
		forum.IsCategory = CheckBoxForumCategory.Checked;

		if (forum.Id == 0)
		{
			blForum.Insert(ref forum);
		}
		else
		{
			blForum.Update(ref forum);
		}

		// refresh om tree te updaten
		Response.Redirect(Request.RawUrl);
	}

	protected void ButtonDeleteForum_Click(object sender, EventArgs e)
	{

	}

	protected void ShowAlert(string text, string cssClass = "alert alert-success")
	{
		LabelAlert.Text = text;
		PanelAlert.CssClass = cssClass;
		PanelAlert.Visible = true;
	}

    protected void GridViewForumModerators_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BLMember blMember = new BLMember();
        BLForum blForum = new BLForum();

        Member member = blMember.GetMemberById((int)GridViewForumModerators.DataKeys[e.RowIndex]["Id"]);
        Forum forum = blForum.GetForumById(int.Parse(Request.QueryString["id"]));

        blForum.RemoveModerator(forum, member);
        PopulateGridView(forum);
    }
}