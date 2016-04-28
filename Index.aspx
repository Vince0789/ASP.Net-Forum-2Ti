<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigatie" Runat="Server">
  <ul>
    <li>
      <a href="#">Inloggen</a>
    </li>
  </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
  <div>
    Breadcrumb
  </div>
  <div>
    Forum list
  </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
  Footer. Geregistreerde leden e.a.

  &copy; 2016 Vince Vandormael
</asp:Content>

