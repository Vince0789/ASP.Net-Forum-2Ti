<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="NewTopic.aspx.cs" Inherits="NewTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
  <section class="row">
    <div class="col-md-9 col-sm-12">
      <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" ></asp:TextBox>
      <asp:Button ID="Button1" runat="server" Text="Button" UseSubmitBehavior="true" CssClass="btn btn-primary" />
    </div>
    <div class="col-md-3 col-sm-12">
      <div class="panel panel-default">
        <div class="panel-heading">
          <h3 class="panel-title">Options</h3>
        </div>
        <div class="panel-body">
          <div class="form-group">
          <div class="checkbox">
            <asp:CheckBox ID="CheckBoxPin" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="Pin" AssociatedControlID="CheckBoxPin" />
          </div>
          <div class="checkbox">
            <asp:CheckBox ID="CheckBoxLock" runat="server" />
            <asp:Label ID="Label2" runat="server" Text="Lock" AssociatedControlID="CheckBoxLock" />
          </div>
            </div>
        </div>
      </div>

    </div>
  </section>
</asp:Content>
