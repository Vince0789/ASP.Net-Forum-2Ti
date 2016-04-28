<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="ViewTopic.aspx.cs" Inherits="ViewTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
  <div>
    <section>
      <asp:Repeater ID="RepeaterPosts" runat="server">
        <ItemTemplate>
          <div class="row">
            <div class="col-md-3 col-sm-12">
              <div class="panel panel-default">
                <div class="panel-heading">
                  <%#Eval("User.Name")%>
                </div>
                <div class="panel-body">
                  Member since: <%#Eval("User.RegistrationDate", "{0:d}")%>
                </div>
              </div>
            </div>
            <div class="col-md-9 col-sm-12">
              <div class="panel panel-default">
                <div class="panel-body">
                  <div><%#Eval("CreatedDate")%></div>
                  <%#Eval("Content")%>
                </div>
              </div>
            </div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </section>
  </div>
</asp:Content>

