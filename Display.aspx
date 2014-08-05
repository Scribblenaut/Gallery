<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Display.aspx.cs" Inherits="Display" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "Info" 
        style="width: 250px; display:inline-block; padding:80px; height: 100%; float:right; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif;" 
        align="left">
    <h1 id="Name" runat="server" style="color: #FFFFFF;">Image</h1>
    By: <asp:label id="Author" runat="server" text=""></asp:label><br />
    Votes: <asp:label id = "Votes" runat="server" text="Label"></asp:label><br />
    Tags: <asp:literal id = "Tags" runat="server"></asp:literal><br />
    Download Links:<asp:literal id="DownloadLinks" runat="server"></asp:literal>
</div>
<div id="MainImageContainer" style="padding: 80px; display:inline-block; height: 100%">
        <asp:imagebutton id="MainImage" runat="server" ImageAlign="Left" style="float:inherit; display:inline-block; border:solid 1px #383838; max-height: 66%; max-width:700px;"
         ImageUrl="~/Images/Featured/NightLifeBlack.png" onclick="MainImage_Click">
        </asp:imagebutton>
</div>
</asp:Content>

