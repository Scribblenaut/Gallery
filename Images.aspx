<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Images.aspx.cs" Inherits="Images" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.Image
{
    background-color:Black;
    border:1px solid darkgray;
    width:180px; height:180px;
}
.Image:hover
{
    background-color:Black;
    border:1px solid #00AAFF;
    width:180px; height:180px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <br />
        <br />
        <h1 id="Name" runat="server" style="color: #FFFFFF">Featured</h1><br />
    <asp:label runat="server" text="Tags: " ForeColor="White"></asp:label>
    <asp:literal id="Tags" runat="server" text=""> </asp:literal><br />
        <div id = "ImageContainer" 
        style="padding: 10px; background-color: #333333; border-radius:10px; width: auto; display: inline-block;" 
        align="center">
    <asp:datalist id="Datalist" runat="server" RepeatDirection="Horizontal" 
            CellPadding="2">
        <ItemTemplate>
            <asp:ImageButton ID="Image" runat="server" style="background-color:Black; width:180px; height:180px;"
                ImageUrl='<%# Bind("Name","~/Images/All/{0}")%>' Width="100%" 
                CssClass="Image" onclick="Image_Click"></asp:ImageButton>
                <div id="options" 
                style="visibility: hidden; background-color: #800000; height: 48px; position: absolute; top: 68px; left: 19px; width: 81px;">
                </div>
        </ItemTemplate> 
        <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom"  />
    </asp:datalist>
    </div>
</asp:Content>

