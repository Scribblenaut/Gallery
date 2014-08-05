<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tags.aspx.cs" Inherits="Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "TagsContainer" style="width: 100%; display:inline-block; padding:80px; height: 100%; float:left; font-family: Arial, Helvetica, sans-serif;" 
        align="left">
        <asp:literal id="Tag" runat="server"></asp:literal>
    </div>
</asp:Content>

