<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminLayout.master" AutoEventWireup="true" CodeFile="SearchUsers.aspx.cs" Inherits="admin_SearchUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
	<div class="row">
		<div class="col-sm-12">
			<h2>Results for "<asp:Label ID="LabelQuery" runat="server" Text="Label"></asp:Label>"</h2>
		</div>
	</div>
	<div class="row">
		<div class="col-sm-1">
			<asp:Panel ID="PanelAlphabet" runat="server" CssClass="btn-group-sm btn-group-vertical"></asp:Panel>
		</div>
		<div class="col-sm-11">
			<asp:Panel ID="PanelAlert" runat="server" Visible="false">
				<asp:Label ID="LabelAlert" runat="server" Text="Label"></asp:Label>
			</asp:Panel>
			<asp:GridView
				ID="GridViewSearchResults"
				runat="server"
				AllowPaging="True"
				AllowSorting="True"
				AutoGenerateColumns="False"
				CssClass="table table-hover table-hide-options"
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
					<asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cross.png" EditImageUrl="~/images/user_edit.png" ShowEditButton="True" UpdateImageUrl="~/images/tick.png" />
					<asp:TemplateField ShowHeader="False">
						<ItemTemplate>
							<asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/images/user_delete.png" Text="Delete" OnClientClick="return confirmDelete();" />
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<PagerStyle CssClass="pagination-ys" />
			</asp:GridView>
		</div>
	</div>
	<script type="text/javascript">
		function confirmDelete() {
			return confirm("The member will be deleted permanently. Proceed?");
		}
	</script>
</asp:Content>

