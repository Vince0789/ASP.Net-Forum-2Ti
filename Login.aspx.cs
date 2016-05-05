using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
			return;

		TextBoxName.Attributes.Add("required", "required");
		TextBoxName.Attributes.Add("autofocus", "autofocus");
		TextBoxName.Attributes.Add("placeholder", "Name");

		TextBoxPassword.Attributes.Add("required", "required");
		TextBoxPassword.Attributes.Add("placeholder", "Password");

		string actie = Request.QueryString["do"];

		if(actie == "logout")
		{
			Session.Clear();
			Session.Abandon();

			LabelAlertText.Text = "You have been logged out.";
			PanelAlert.CssClass = "alert alert-success";
			PanelAlert.Visible = true;
		}
	}

	protected void ButtonLogin_Click(object sender, EventArgs e)
	{
		string name = TextBoxName.Text;
		string password = TextBoxPassword.Text;

		Member member = new BLMember().PerformLoginAttempt(name, password);

		if(member != null)
		{
			Session["member"] = member;
			Response.Redirect("index.aspx");
		}
		else
		{
			LabelAlertText.Text = "Invalid username or password.";
			PanelAlert.CssClass = "alert alert-danger";
			PanelAlert.Visible = true;
		}
	}
}