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
        List<Member> results = blMember.FindMembersByName(query).OrderBy(m => m.Name).ToList();

        GridViewSearchResults.DataSource = results;
        GridViewSearchResults.DataBind();
    }
}