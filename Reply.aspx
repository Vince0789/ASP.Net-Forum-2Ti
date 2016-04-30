<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Reply.aspx.cs" Inherits="Reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
	<section class="row">
		<div class="col-sm-12">
			<h2>Reply to
				<asp:Literal ID="LiteralPaginaTitel" runat="server"></asp:Literal></h2>
		</div>
	</section>
	<section class="row">
		<div class="col-sm-12">
			<div class="form-group">
				<asp:Label runat="server" Text="Post contents" AssociatedControlID="TextBoxContent"></asp:Label>
				<asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine"></asp:TextBox>
			</div>
			<div class="form-group">
				<asp:Button ID="ButtonSubmit" runat="server" Text="Submit" UseSubmitBehavior="true" CssClass="btn btn-primary" OnClick="ButtonSubmit_Click" />
			</div>
		</div>
	</section>
</asp:Content>