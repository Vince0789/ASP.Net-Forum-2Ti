<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
	<section class="row">
		<div class="col-md-4 col-md-offset-4">
			<asp:Panel ID="PanelAlert" runat="server" CssClass="alert alert-danger" Visible="false">
				<p><strong>Oops!</strong> Something went wrong. Please correct the errors below and try again.</p>
				<asp:BulletedList ID="BulletedListErrors" runat="server"></asp:BulletedList>
			</asp:Panel>
			<div class="form-group">
				<asp:Label ID="Label1" runat="server" Text="Name" AssociatedControlID="TextBoxName" />
				<asp:TextBox ID="TextBoxName" runat="server" />
			</div>
			<div class="form-group">
				<asp:Label ID="Label2" runat="server" Text="Password" AssociatedControlID="TextBoxPassword" />
				<asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" />
			</div>
				<div class="form-group">
				<asp:Label ID="Label3" runat="server" Text="Repeat password" AssociatedControlID="TextBoxPasswordRepeat" />
				<asp:TextBox ID="TextBoxPasswordRepeat" runat="server" TextMode="Password" />
			</div>
			<div class="form-group">
				<asp:Label ID="Label4" runat="server" Text="I agree to the terms of service" AssociatedControlID="CheckBoxTerms" />
				<asp:CheckBox ID="CheckBoxTerms" runat="server" />
			</div>
			<div class="form-group">
				<asp:Button ID="ButtonRegister" runat="server" Text="Register" CssClass="btn btn-primary btn-lg btn-block" OnClick="ButtonRegister_Click"/>
			</div>
		</div>
	</section>
</asp:Content>

