<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="400.aspx.cs" Inherits="errors_400" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
	<% Response.StatusCode = 400; %>
	<div class="row">
		<div class="col-sm-12">
			<h1>Bad Request</h1>
			<p>Your browser sent a request that this server could not understand.</p>
		</div>
	</div>
</asp:Content>