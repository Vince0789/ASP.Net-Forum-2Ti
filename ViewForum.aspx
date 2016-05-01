<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="ViewForum.aspx.cs" Inherits="ViewForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
	<!-- forum title -->
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
			<table class="table">
				<asp:Repeater ID="RepeaterTopics" runat="server">
					<ItemTemplate>
						<tr>
							<td>
								<asp:CheckBox ID="CheckBoxSelectTopic" runat="server" /></td>
							<td><a href="ViewTopic.aspx?id=<%#Eval("Id")%>"><%#Eval("Title")%></a></td>
							<td>Geplaatst door: <%#Eval("EerstePost.Member.Name")%></td>
							<td>Geplaatst op: <%#Eval("EerstePost.CreatedDate")%></td>
							<td>Laatste bericht door: <%#Eval("LaatstePost.Member.Name")%></td>
							<td>Laatste bericht geplaatst op: <%#Eval("LaatstePost.CreatedDate")%></td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
			</table>
		</section>
		<section>
			With selected:
			<asp:DropDownList ID="DropDownListTopicAction" runat="server"></asp:DropDownList>
			<asp:HyperLink ID="HyperLinkNewTopic" runat="server" CssClass="btn btn-primary pull-right">New topic</asp:HyperLink>
		</section>
	</asp:Panel>
</asp:Content>

