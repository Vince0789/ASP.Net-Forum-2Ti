<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminLayout.master" AutoEventWireup="true" CodeFile="SearchUsers.aspx.cs" Inherits="admin_SearchUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
	<h2>Results for "<asp:Label ID="LabelQuery" runat="server" Text="Label"></asp:Label>"</h2>
  <asp:GridView ID="GridViewSearchResults" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table" CellSpacing="-1" GridLines="None" OnPageIndexChanging="GridViewSearchResults_PageIndexChanging">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Username" />
      <asp:BoundField DataField="RegistrationDate" HeaderText="Member since" DataFormatString="{0:dd MMM yyyy}" />
    </Columns>
    <PagerStyle CssClass="pagination-ys" />
  </asp:GridView>
</asp:Content>

