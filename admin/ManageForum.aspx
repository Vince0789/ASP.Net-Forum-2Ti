<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminLayout.master" AutoEventWireup="true" CodeFile="ManageForum.aspx.cs" Inherits="admin_ManageForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
	<h2>Manage Forum: "<asp:Label ID="LabelPageTitle" runat="server" Text="" />"</h2>
	<section>
		<asp:Panel ID="PanelAlert" runat="server" CssClass="panel panel-default" Visible="false">
			<asp:Label ID="LabelAlert" runat="server" Text="Label"></asp:Label>
		</asp:Panel>
		<div class="form-group">
			<asp:Label ID="LabelForumName" runat="server" Text="Name" AssociatedControlID="TextBoxForumName"></asp:Label>
			<asp:TextBox ID="TextBoxForumName" runat="server"></asp:TextBox>
			<p class="help-block">Give the forum a name, for example <em>Discussions</em>.</p>
		</div>
		<div class="form-group">
			<asp:Label ID="LabelForumDescription" runat="server" Text="Description (optional)" AssociatedControlID="TextBoxForumDescription"></asp:Label>
			<asp:TextBox ID="TextBoxForumDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
			<p class="help-block">What's this forum about? The description will feature on the index or in a subforums list.</p>
		</div>
		<div class="form-group">
			<asp:Label ID="LabelForumParent" runat="server" Text="Parent" AssociatedControlID="DropDownListForumParent"></asp:Label>
			<asp:DropDownList ID="DropDownListForumParent" runat="server"></asp:DropDownList>
			<p class="help-block">Select which forum will act as the parent. </p>
		</div>
		<div class="form-group">
			<asp:Label ID="LabelForumCategory" runat="server" Text="Category" AssociatedControlID="CheckBoxForumCategory"></asp:Label>
			<asp:CheckBox ID="CheckBoxForumCategory" runat="server" CssClass="" />
			<p class="help-block">If this option is enabled, the forum will act as a 
				container for other subforums and no topics or posts can be created 
				within this forum. Forums that appear on the index are always treated
				as categories, regardless of this setting.
			</p>
		</div>
	</section>
  <hr />
  <section>
    <h3>Assigned moderators</h3>
    <asp:GridView ID="GridViewForumModerators" runat="server" CssClass="table table-hover table-hide-options" AutoGenerateColumns="False" OnRowDeleting="GridViewForumModerators_RowDeleting">
      <Columns>
        <asp:BoundField DataField="Name" HeaderText="Member" />
        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/key_delete.png" ShowDeleteButton="True" HeaderText="Permissions" />
      </Columns>
      <EmptyDataTemplate>
        <span class="text-muted">None</span>
      </EmptyDataTemplate>
    </asp:GridView>
  </section>
  <section>
    <div class="form-group">
			<asp:Button ID="ButtonSaveChanges" runat="server" Text="Save Changes" OnClick="ButtonSaveChanges_Click" CssClass="btn btn-primary"/>
			<asp:Button ID="ButtonDeleteForum" runat="server" Text="Delete this forum" OnClick="ButtonDeleteForum_Click" OnClientClick="return Confirmation();" CssClass="btn btn-danger"/>
		</div>
  </section>
	<script type="text/javascript">
		function Confirmation()
		{
			return confirm("You are about to remove this forum. There is no undoing this action.\nPermanently delete this forum?");
		}
	</script>
</asp:Content>

