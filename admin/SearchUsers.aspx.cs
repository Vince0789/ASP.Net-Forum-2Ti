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
		string query = Request.QueryString["query"];

		if (string.IsNullOrWhiteSpace(query))
			throw new HttpException(400, "Bad Request");

		LabelQuery.Text = query;
	}
}