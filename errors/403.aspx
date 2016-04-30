<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="403.aspx.cs" Inherits="errors_403" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
	<% Response.StatusCode = 403; %>
	<div class="row">
		<div class="col-sm-12">
			<h1>Forbidden</h1>
			<p>You do not have permission to access the requested resource.</p>
		</div>
	</div>
</asp:Content>