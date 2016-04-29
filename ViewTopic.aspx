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
                  <ul>
                    <li>Member since: <%#Eval("User.RegistrationDate", "{0:d}")%></li>
                    <li>Posts: <%#Eval("User.PostCount")%></li>
                  </ul>
                  
                </div>
              </div>
            </div>
            <div class="col-md-9 col-sm-12">
              <div class="panel panel-default">
                <div class="panel-body">
                  <div><%#Eval("CreatedDate")%></div>
                  <%#Eval("Content")%>
                  <div class="btn-group pull-right">
                    <a class="btn btn-default" href="#">
                      <img src="images/pencil.png" alt="Edit" width="16" height="16" />
                    </a>
                    <a class="btn btn-default" href="#">
                      <img src="images/delete.png" alt="Delete" width="16" height="16" />
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <div class="row">
        <div class="col-sm-12">
          <asp:HyperLink ID="HyperLinkReply" runat="server" CssClass="btn btn-primary pull-right">Reply</asp:HyperLink>
        </div>
      </div>
    </section>
  </div>
</asp:Content>

