using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SearchUsers : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		PanelAlert.Visible = false;

		if (IsPostBack)
			return;

		PopulateGridView();

	}

	protected void GridViewSearchResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridViewSearchResults.PageIndex = e.NewPageIndex;
		PopulateGridView();
	}

	protected void PopulateGridView()
	{
		string query = Request.QueryString["query"];

		if (string.IsNullOrWhiteSpace(query))
			throw new HttpException(400, "Bad Request");

		LabelQuery.Text = query;

		BLMember blMember = new BLMember();
		List<Member> results = blMember.FindMembersByName(query);

		GridViewSearchResults.DataSource = results;
		GridViewSearchResults.DataBind();
	}

	protected void GridViewSearchResults_RowEditing(object sender, GridViewEditEventArgs e)
	{

	}

	protected void GridViewSearchResults_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		int primaryKey = (int)GridViewSearchResults.DataKeys[e.RowIndex]["Id"];

		BLMember blMember = new BLMember();

		Member member = blMember.GetMemberById(primaryKey);

		if(!blMember.Delete(member))
		{
			LabelAlert.Text = "Member \"" + member.Name + "\" cannot be deleted at this time. He/she still has active posts, or is an administrator of this forum.";
			PanelAlert.CssClass = "alert alert-danger";
			e.Cancel = true;
		}
		else
		{
			LabelAlert.Text = "Member \"" + member.Name + "\" was deleted.";
			PanelAlert.CssClass = "alert alert-warning";
			PopulateGridView();
		}

		PanelAlert.Visible = true;
	}

	protected void GridViewSearchResults_Sorting(object sender, GridViewSortEventArgs e)
	{

	}
}
 