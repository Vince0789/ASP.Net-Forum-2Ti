<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminLayout.master" AutoEventWireup="true" CodeFile="SearchUsers.aspx.cs" Inherits="admin_SearchUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
	<h2>Results for "<asp:Label ID="LabelQuery" runat="server" Text="Label"></asp:Label>"</h2>
	<asp:Panel ID="PanelAlert" runat="server" Visible="false">
		<asp:Label ID="LabelAlert" runat="server" Text="Label"></asp:Label>
	</asp:Panel>
  <asp:GridView 
		ID="GridViewSearchResults" 
		runat="server" 
		AllowPaging="True" 
		AllowSorting="True"
		AutoGenerateColumns="False" 
		CssClass="table table-hide-options" 
		DataKeyNames="Id" 
		OnPageIndexChanging="GridViewSearchResults_PageIndexChanging"
		OnRowEditing="GridViewSearchResults_RowEditing"
		OnRowCancelingEdit="GridViewSearchResults_RowCancelingEdit"
		OnRowDeleting="GridViewSearchResults_RowDeleting" 
		OnRowUpdating="GridViewSearchResults_RowUpdating"
		OnSorting="GridViewSearchResults_Sorting">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Username" />
      <asp:BoundField DataField="RegistrationDate" HeaderText="Member since" DataFormatString="{0:dd MMM yyyy}" />
    	<asp:BoundField DataField="Posts.Count" DataFormatString="{0:N0}" HeaderText="Posts" ReadOnly="True" />
    	<asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cross.png" EditImageUrl="~/images/user_edit.png" ShowEditButton="True" UpdateImageUrl="~/images/tick.png"/>
			<asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/user_delete.png" ShowDeleteButton="True" />
    </Columns>
    <PagerStyle CssClass="pagination-ys" />
  </asp:GridView>
</asp:Content>

