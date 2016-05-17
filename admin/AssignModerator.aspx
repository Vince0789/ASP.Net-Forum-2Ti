<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminLayout.master" AutoEventWireup="true" CodeFile="AssignModerator.aspx.cs" Inherits="admin_AssignModerator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
  <h2><asp:Literal ID="LiteralMemberName" runat="server"></asp:Literal></h2>
  <section>
    <h3>Current permissions</h3>
    <asp:Label ID="LabelNoPermissions" runat="server" Text="This user currently isn't moderating any forums." CssClass="text-muted"></asp:Label>
    <asp:Repeater ID="RepeaterPermissions" runat="server" OnItemDataBound="RepeaterPermissions_ItemDataBound">
        <HeaderTemplate><ul class="list-inline list-subforums"></HeaderTemplate>
        <ItemTemplate>
          <li><asp:HyperLink ID="HyperLinkManageForum" runat="server">HyperLink</asp:HyperLink></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
  </section>
  <section>
    <h3>Add Permission</h3>
    <div class="form-inline">
      <div class="form-group">
        <asp:DropDownList ID="DropDownListForums" runat="server"></asp:DropDownList>
        <asp:Button ID="ButtonAddModerator" runat="server" Text="Add" CssClass="btn btn-primary" />
      </div>
    </div>
  </section>
</asp:Content>

