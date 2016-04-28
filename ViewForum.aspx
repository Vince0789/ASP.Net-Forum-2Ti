<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="ViewForum.aspx.cs" Inherits="ViewForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
  <div>
    <section class="panel panel-default">
      <div class="panel-heading">
        <h2 class="panel-title">
          <asp:Literal ID="LiteralForumNaam" runat="server"></asp:Literal>
        </h2>
      </div>
      <div class="panel-body">
        <asp:Literal ID="LiteralForumBeschrijving" runat="server"></asp:Literal>
      </div>
    </section>
    <section>
      <table class="table">
        <asp:Repeater ID="RepeaterTopics" runat="server">
          <ItemTemplate>
            <tr>
              <td><a href="ViewTopic.aspx?id=<%#Eval("Id")%>"><%#Eval("Title")%></a></td>
              <td>Geplaatst door: <%#Eval("EerstePost.User.Name")%></td>
              <td>Geplaatst op: <%#Eval("EerstePost.CreatedDate")%></td>
              <td>Laatste bericht door: <%#Eval("LaatstePost.User.Name")%></td>
              <td>Laatste bericht geplaatst op: <%#Eval("LaatstePost.CreatedDate")%></td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
      </table>
    </section>
  </div>
</asp:Content>

