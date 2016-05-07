using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLayout : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
			return;

		GenerateBreadCrumb(null);

		Member member = (Session["member"] as Member);

		if (member != null)
		{
			BulletedListUserMenu.Items.Add(new ListItem(member.Name, "UserCP.aspx"));

			if (member.IsAdmin())
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

		// ---

		BLForum blForum = new BLForum();

		List<Forum> parents = blForum.GetParentForums();
		List<Forum> allForums = blForum.GetAll();

		foreach (Forum parent in parents)
		{
			TreeNode parentNode = new TreeNode();
			parentNode.Text = parent.Name;
			parentNode.Value = parent.Id.ToString();
			parentNode.NavigateUrl = "ManageForum.aspx?id=" + parent.Id;

			BuildTree(parent.Children, allForums, ref parentNode);

			TreeViewForums.Nodes.Add(parentNode);
		}
	}

	public void GenerateBreadCrumb(Forum lastChild)
	{
		BLForum blForum = new BLForum();

		List<ListItem> items = new List<ListItem>();
		Forum breadcrumbForum = lastChild;

		while (breadcrumbForum != null)
		{
			items.Add(new ListItem(breadcrumbForum.Name, "../ViewForum.aspx?id=" + breadcrumbForum.Id));
			breadcrumbForum = breadcrumbForum.ParentForumId.HasValue ? blForum.GetForumById(breadcrumbForum.ParentForumId.Value) : null;
		}

		items.Add(new ListItem("Forum Index", "../Index.aspx"));
		items.Reverse();
		BulletedListBreadCrumb.Items.AddRange(items.ToArray());
	}

	// http://stackoverflow.com/a/2976021
	public void BuildTree(List<Forum> currentLevel, List<Forum> allForums, ref TreeNode treeNode)
	{
		if (treeNode == null) return;

		TreeNode tnAdd = null;

		foreach (var forum in currentLevel)
		{
			tnAdd = new TreeNode();
			tnAdd.Text = forum.Name;
			tnAdd.Value = forum.Id.ToString();
			tnAdd.NavigateUrl = "ManageForum.aspx?id=" + forum.Id;

			BuildTree((from f in allForums
								 where f.ParentForumId == forum.Id
								 select f).ToList(), allForums, ref tnAdd);


			if (tnAdd != null)
				treeNode.ChildNodes.Add(tnAdd);
		}
	}
}
