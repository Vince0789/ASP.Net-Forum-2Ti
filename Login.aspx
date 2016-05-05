<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
	<div class="row">
		<div class="col-md-4 col-md-offset-4">
			<asp:Panel ID="PanelAlert" runat="server" Visible="false">
				<asp:Label ID="LabelAlertText" runat="server" Text="Alert"></asp:Label>
			</asp:Panel>
			<h2 class="form-signin-heading">Please sign in</h2>

			<asp:Label ID="Label1" runat="server" Text="Name" AssociatedControlID="TextBoxName" CssClass="sr-only" />
			<asp:TextBox ID="TextBoxName" runat="server" />

			<asp:Label ID="Label2" runat="server" Text="Password" AssociatedControlID="TextBoxPassword" CssClass="sr-only" />
			<asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" />

			<div>
				<asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="btn btn-lg btn-primary btn-block" OnClick="ButtonLogin_Click"/>
			</div>
		</div>
	</div>
</asp:Content>

