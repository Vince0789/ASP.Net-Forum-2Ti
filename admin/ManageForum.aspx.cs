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
		int forumId;

		if (!int.TryParse(Request.QueryString["id"], out forumId))
			throw new HttpException(400, "Bad Request");

		BLForum blForum = new BLForum();

		Forum forum = blForum.GetForumById(forumId);

		if (forum == null)
			throw new HttpException(404, "Not Found");

		LabelPageTitle.Text = forum.Name;
		Page.Title = "Manage Forum: \"" + forum.Name + "\"";

		// dit is blijkbaar niet expliciet nodig, gvd een uur zitten vloeken op deze bug
		// Page.LoadComplete += new EventHandler(Page_LoadComplete); 

		DropDownListForumParent.Items.Add(new ListItem("(None)", "0"));
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

	}
}