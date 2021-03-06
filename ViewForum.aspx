﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="ViewForum.aspx.cs" Inherits="ViewForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
	<!-- forum title -->
	<section class="panel panel-default">
		<div class="panel-heading">
			<h2 class="panel-title">
				<asp:Literal ID="LiteralForumNaam" runat="server"></asp:Literal>
			</h2>
		</div>
		<div class="panel-body">
			<p><asp:Literal ID="LiteralForumBeschrijving" runat="server"></asp:Literal></p>
			<p class="text-muted">
				Moderators of this forum: <asp:Label ID="LabelForumModerators" runat="server" Text="Administrators"></asp:Label>
			</p>
		</div>
	</section>

	<!-- subforum list -->
	<asp:Panel ID="PanelSubforums" runat="server">
		<section class="panel panel-default">
			<div class="panel-heading">
				<h2 class="panel-title">Subforums</h2>
			</div>
			<asp:ListView ID="ListViewSubforums" runat="server" OnItemDataBound="ListViewSubforums_ItemDataBound">
				<ItemTemplate>
						<div class="panel-body">
							<div class="col-sm-9">
								<h3><a href="ViewForum.aspx?id=<%#Eval("Id")%>"><%#Eval("Name")%></a></h3>
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
	</asp:Panel>
	<!-- topic list -->
	<asp:Panel ID="PanelTopicList" runat="server">
		<section>
			<asp:GridView ID="GridViewTopics" runat="server" CssClass="table" CellSpacing="-1" GridLines="None" OnRowDataBound="GridViewTopics_RowDataBound" OnPageIndexChanging="GridViewTopics_PageIndexChanging">
				<Columns>
					<asp:TemplateField HeaderText="Locked">
						<ItemTemplate>
							<asp:Image ID="ImageTopicLocked" runat="server" Width="16" Height="16" ImageUrl="~/images/lock.png" AlternateText="Locked" ToolTip="Locked" Visible="false" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Title">
						<ItemTemplate>
								<asp:Label ID="LabelTopicPinned" runat="server" Text="Pinned" CssClass="badge" Visible="false" />
								<a href="ViewTopic.aspx?id=<%#Eval("Id")%>"><%#Eval("Title")%></a><br />
								Started by <%#Eval("EerstePost.Member.Name")%>, <time class="timeago" datetime="<%#Eval("EerstePost.CreatedDate", "{0:o}")%>"><%#Eval("EerstePost.CreatedDate", "{0:dddd d MMMM yyyy, HH:mm}")%></time> 
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Number of Posts">
						<ItemTemplate>
							<asp:Label ID="LabelPostsInTopic" runat="server" Text="Label"></asp:Label>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Last Post">
						<ItemTemplate>
							<%#Eval("LaatstePost.Member.Name")%><br />
							<time class="timeago" datetime="<%#Eval("LaatstePost.CreatedDate", "{0:o}")%>"><%#Eval("LaatstePost.CreatedDate", "{0:dddd d MMMM yyyy, HH:mm}")%></time>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Select">
						<ItemTemplate>
							<asp:CheckBox ID="CheckBoxSelectTopic" runat="server" Visible="false"/>
							<asp:HiddenField ID="HiddenFieldTopicId" runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<PagerStyle CssClass="pagination-ys" />
				<EmptyDataTemplate>
					<span class="text-muted">There are no topics in this forum yet.</span>
				</EmptyDataTemplate>
			</asp:GridView>
		</section>
		<section>
			<asp:Panel ID="PanelTopicOptions" runat="server" CssClass="form-inline pull-left" Visible="false">
				With selected:
				<asp:DropDownList ID="DropDownListTopicAction" runat="server" CssClass="form-control" />
				<asp:Button ID="ButtonTopicAction" runat="server" Text="Go" OnClick="ButtonTopicAction_Click" CssClass="btn btn-btn-default"/>
			</asp:Panel>
			<div class="pull-right">
				<asp:HyperLink ID="HyperLinkNewTopic" runat="server" CssClass="btn btn-primary">New topic</asp:HyperLink>
			</div>
		</section>
	</asp:Panel>
</asp:Content>

