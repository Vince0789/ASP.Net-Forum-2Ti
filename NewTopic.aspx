<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="NewTopic.aspx.cs" Inherits="NewTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
  <section class="row">
    <div class="col-sm-12">
      <h2><asp:Literal ID="LiteralPaginaTitel" runat="server"></asp:Literal></h2>
    </div>
  </section>
  <section class="row">
    <div class="col-md-9 col-sm-12">
      <asp:HiddenField ID="HiddenFieldForumId" runat="server"></asp:HiddenField>
      <div class="form-group">
        <asp:Label runat="server" Text="Topic title" AssociatedControlID="TextBoxTitle"></asp:Label>
        <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
      </div>
      <div class="form-group">
        <asp:Label runat="server" Text="Post contents" AssociatedControlID="TextBoxContent"></asp:Label>
        <asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine"></asp:TextBox>
      </div>
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
              <p class="help-block">Pinned topics always appear at the top of the topic list.</p>
            </div>
            <div class="checkbox">
              <asp:CheckBox ID="CheckBoxLock" runat="server" />
              <asp:Label ID="Label2" runat="server" Text="Lock" AssociatedControlID="CheckBoxLock" />
              <p class="help-block">Locked topics cannot be replied to.</p>
            </div>
          </div>
        </div>
      </div>

    </div>
    <div class="form-group">
      <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" UseSubmitBehavior="true" CssClass="btn btn-primary" OnClick="ButtonSubmit_Click" />
    </div>
  </section>
</asp:Content>
