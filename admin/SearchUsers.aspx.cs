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
		GridViewSearchResults.EditIndex = e.NewEditIndex;
		PopulateGridView();
	}

	protected void GridViewSearchResults_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridViewSearchResults.EditIndex = -1;
		PopulateGridView();
	}

	protected Control GetUpdateControl(GridView gridView, int rowIndex, int controlIndex)
	{
		return gridView.Rows[rowIndex].Controls[controlIndex].Controls[0];
	}

	protected void GridViewSearchResults_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		// controls in de row
		TextBox textBoxNaam = GetUpdateControl(GridViewSearchResults, e.RowIndex, 0) as TextBox;
		TextBox textBoxRegistratieDatum = GetUpdateControl(GridViewSearchResults, e.RowIndex, 1) as TextBox;

		// input validation
		string naam = textBoxNaam.Text;
		DateTime registratieDatum;

		if (string.IsNullOrWhiteSpace(naam))
			e.Cancel = true;

		if(!DateTime.TryParse(textBoxRegistratieDatum.Text, out registratieDatum))
			e.Cancel = true;

		if(e.Cancel)
		{
			ShowAlert("An error occured while trying to update. Please ensure that the name is not empty and that the registration date is in the correct format.", "alert-danger");
		}
		else
		{
			// valide
			BLMember blMember = new BLMember();
			Member member = null;

			blMember.PrepareUpdate((int)GridViewSearchResults.DataKeys[e.RowIndex]["Id"], out member);

			member.Name = naam;
			member.RegistrationDate = registratieDatum;

			blMember.Update();

			GridViewSearchResults.EditIndex = -1;
			PopulateGridView();

			ShowAlert("Member was successfully updated!", "alert-success");
		}
	}

	protected void GridViewSearchResults_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		BLMember blMember = new BLMember();
		Member member = blMember.GetMemberById((int)GridViewSearchResults.DataKeys[e.RowIndex]["Id"]);

		if(!blMember.Delete(member))
		{
			ShowAlert("Member \"" + member.Name + "\" cannot be deleted at this time. He/she still has active posts, or is an administrator of this forum.", "alert-danger");
			e.Cancel = true;
		}
		else
		{
			ShowAlert("Member \"" + member.Name + "\" was deleted.", "alert-warning");
			PopulateGridView();
		}
	}

	protected void GridViewSearchResults_Sorting(object sender, GridViewSortEventArgs e)
	{

	}

	protected void ShowAlert(string text, string cssClass)
	{
		LabelAlert.Text = text;
		PanelAlert.CssClass = "alert " + cssClass;
		PanelAlert.Visible = true;
	}
}
 