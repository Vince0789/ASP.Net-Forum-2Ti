<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="ContentUserMenu" ContentPlaceHolderID="ContentPlaceHolderUserMenu" runat="server">
  <asp:BulletedList ID="BulletedListUserMenu" runat="server" CssClass="nav navbar-nav navbar-right" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
  <div>
    <asp:ListView ID="ListViewCategories" runat="server" OnItemDataBound="ListViewCategories_ItemDataBound">
      <ItemTemplate>
        <section class="panel panel-default">
          <div class="panel-heading">
            <h2 class="panel-title">
              <%#Eval("Name")%>
            </h2>
          </div>
          <asp:ListView ID="ListViewForums" runat="server" OnItemDataBound="ListViewForums_ItemDataBound">
            <ItemTemplate>
                <div class="panel-body">
                  <div class="col-sm-9">
                    <h3><a href="ViewForum.aspx?id=<%#Eval("Id")%>"><%#Eval("Name")%></a></h3>
										<asp:Panel ID="PanelSubforums" runat="server" CssClass="asp-panel-inline">
											<span class="pull-left">&#x221F;</span>
											<asp:BulletedList ID="BulletedListSubforums" runat="server" CssClass="list-inline" DisplayMode="HyperLink"></asp:BulletedList>
										</asp:Panel>
                    <span class="help-block"><%#Eval("Description")%></span>
                  </div>
                  <div class="col-sm-3">
                      <strong><asp:Literal ID="LiteralTopicCount" runat="server" Text="0"></asp:Literal></strong> topics<br />
                      <strong><asp:Literal ID="LiteralPostCount" runat="server" Text="0"></asp:Literal></strong> replies<br />
                  </div>
                </div>
            </ItemTemplate>
          </asp:ListView>
        </section>
      </ItemTemplate>
    </asp:ListView>
  </div>
</asp:Content>

