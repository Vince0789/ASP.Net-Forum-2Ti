﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="ViewTopic.aspx.cs" Inherits="ViewTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
  <asp:HiddenField ID="HiddenFieldTopicId" runat="server" />
  <div>
    <section>
      <div class="row">
        <div class="col-sm-12">
          <h2>
            <asp:Literal ID="LiteralTopicTitle" runat="server"></asp:Literal></h2>
        </div>
      </div>
    </section>
    <section>
      <asp:Repeater ID="RepeaterPosts" runat="server" OnItemDataBound="RepeaterPosts_ItemDataBound">
        <ItemTemplate>
          <div class="row">
            <div class="col-sm-12">
              <div class="panel panel-default post-panel">
                <div class="panel-heading">
                  <%#Eval("CreatedDate")%>
                  <asp:Panel ID="PanelModeratorPostDetails" runat="server" CssClass="asp-panel-inline" Visible="false">
                    <small class="pull-right text-muted">(IP address: <%#Eval("FromIP")%>) &nbsp; 
										  <asp:CheckBox ID="CheckBoxSelectPost" runat="server" />
                    </small>
                  </asp:Panel>
                </div>
                <div class="panel-body post-container">
                  <div class="col-sm-3 post-miniprofile">
                    <%#Eval("Member.Name")%>
                    <ul>
                      <li>Member since: <%#Eval("Member.RegistrationDate", "{0:dd MMM yyyy}")%></li>
                      <li>Posts: <%#Eval("Member.PostCount")%></li>
                    </ul>
                  </div>
                  <div class="col-sm-9 post-content">
                    <%#Eval("Content")%>
                    <asp:BulletedList ID="BulletedListPostOptions" runat="server" CssClass="list-inline post-options" DisplayMode="LinkButton" OnClick="BulletedListPostOptions_Click" />
                  </div>
                </div>
              </div>
            </div>
          </div>
          <asp:HiddenField ID="HiddenFieldPostId" runat="server" />
        </ItemTemplate>
      </asp:Repeater>
      <div class="row">
        <div class="col-sm-12">
          <asp:Button ID="ButtonReply" runat="server" Text="Reply" CssClass="btn btn-primary pull-right" OnClick="ButtonReply_Click" />
        </div>
      </div>
    </section>
  </div>
</asp:Content>

