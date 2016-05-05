using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		PanelAlert.Visible = false;
		BulletedListErrors.Items.Clear();

		if (IsPostBack)
			return;

		(Master as Layout).GenerateBreadCrumb(null);
	}

	protected void ButtonRegister_Click(object sender, EventArgs e)
	{
		const int MIN_PASSWORD_LENGTH = 5;

		string name = TextBoxName.Text;
		string password = TextBoxPassword.Text;
		string repeatPassword = TextBoxPasswordRepeat.Text;

		BLMember blMember = new BLMember();

		if (string.IsNullOrWhiteSpace(name))
			AddError("Name must not be empty.");

		if (password.Length < MIN_PASSWORD_LENGTH)
			AddError("Password must be at least " + MIN_PASSWORD_LENGTH.ToString() + " characters long.");

		if(blMember.IsNameInUse(name))
			AddError("This username is already in use.");

		if(password != repeatPassword)
			AddError("Passwords don't match.");

		if(!CheckBoxTerms.Checked)
			AddError("You must accept the terms of service.");

		if (BulletedListErrors.Items.Count > 0)
		{
			PanelAlert.Visible = true;
		}
		else
		{
			Member member = new BLMember().Create(name, password);

			if(member != null)
			{
				Session["member"] = member;
				Response.Redirect("index.aspx");
			}
			else
			{
				AddError("An unexpected error occured. Please try again. If the problem persists, please notify the administrator.");
				PanelAlert.Visible = true;
			}
		}

	}

	protected void AddError(string text)
	{
		BulletedListErrors.Items.Add(text);
	}
}