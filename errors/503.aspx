<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="503.aspx.cs" Inherits="errors_503" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
	<% Response.StatusCode = 503; %>
	<div class="row">
		<div class="col-sm-12">
			<h1>Service Unavailable</h1>
			<p>Could not connect to the database server at this time. Please try again later.</p>
		</div>
	</div>
</asp:Content>