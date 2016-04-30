<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="errors_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
	<% Response.StatusCode = 404; %>
	<div class="row">
		<div class="col-sm-12">
			<h1>Not found</h1>
			<p>The resource you're looking for could not be found.</p>
		</div>
	</div>
</asp:Content>