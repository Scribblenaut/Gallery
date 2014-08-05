<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
.Invisible
{
    opacity:0;
}
.Invisible:hover
{
    opacity:1;
}
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <br />
    <br />
    <br />
    <br />
    <div id = "ImageContainer" 
        style="padding: 10px; background-color: #333333; border-radius:10px; width: auto; display: inline-block;" 
        align="center">
        <h1 style="color: #FFFFFF; float: left; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #FFFFFF; text-align: left; width: 100%;">Featured</h1><br />
    <asp:datalist id="Featured" runat="server" RepeatDirection="Horizontal" 
            CellPadding="2" >
        <ItemTemplate>
                <div id="ImageInfo" style="border-style: solid; border-width: 1px; border-color: 
rgba(255, 255, 255, 0); width:30px; height:180px; background-color:rgba(114, 114, 114, 0.5); position:absolute; z-index: 1; " class="Invisible">
            <asp:ImageButton id="up" runat="server" style="margin:38px 0px 30px 0px;" 
                        ImageUrl="~/Images/arrow-up.png" onclick="up_Click" 
                        AlternateText='<%# Bind("Name")%>'></asp:ImageButton><br />
            <asp:Label id="score" runat="server" ToolTip='<%# Bind("Name") %>' 
                        style="margin:30px 0px 30px 0px;" Text="<% Bind("Score") %>"></asp:Label><br />
            <asp:ImageButton id="down" runat="server" style="margin:30px 0px 30px 0px;" 
                        ImageUrl="~/Images/arrow-down.png" onclick="down_Click"
                        AlternateText='<%# Bind("Name")%>'></asp:ImageButton>
                        <asp:XmlDataSource id="Data" runat="server" DataFile='<%# Eval("Name") + ".xml"%>'></asp:XmlDataSource>
            </div>
            <asp:ImageButton id="Featured1" runat="server" style="background-color:Black; position:relative; width:180px; height:180px;"
                ImageUrl='<%# Bind("Name","~/Images/All/{0}")%>' Width="100%" 
                onclick="Featured1_Click" CssClass="Image" ></asp:ImageButton>
        </ItemTemplate> 
        <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom"  />
    </asp:datalist>
        <a href="Images.aspx?Category=Featured" style="text-decoration: underline; color: #FFFFFF; text-align: right; float: right;">See More</a>
    <h1 style="color: #FFFFFF; float: left; text-align: left; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #FFFFFF; width: 100%;">Popular</h1><br />
        <asp:datalist id="Popular" runat="server" RepeatDirection="Horizontal" 
            CellPadding="2">
        <ItemTemplate>
                <div id="Div1" style="border-style: solid; border-width: 1px; border-color: 
rgba(255, 255, 255, 0); width:30px; height:180px; background-color:rgba(114, 114, 114, 0.5); position:absolute; z-index: 1; " class="Invisible" class="Invisible">
            <asp:ImageButton id="up1" runat="server" style="margin:38px 0px 30px 0px;" 
                        ImageUrl="~/Images/arrow-up.png" onclick="up_Click"
                        AlternateText='<%# Bind("Name")%>'></asp:ImageButton><br />
            <asp:Label id="score1" runat="server" style="margin:30px 0px 30px 0px;" Text="Label">0</asp:Label><br />
            <asp:ImageButton id="down1" runat="server" style="margin:30px 0px 30px 0px;" 
                        ImageUrl="~/Images/arrow-down.png" onclick="down_Click"
                        AlternateText='<%# Bind("Name")%>'></asp:ImageButton>

            </div>
            <asp:ImageButton id="Popular1" runat="server" style="background-color:Black; width:180px; height:180px;"
                ImageUrl='<%# Bind("Name","~/Images/All/{0}")%>' Width="100%" 
                onclick="Popular1_Click" CssClass="Image" ></asp:ImageButton>
        </ItemTemplate> 
        <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom"  />
    </asp:datalist>
            <a href="Images.aspx?Category=Popular" style="color: #FFFFFF; text-decoration: underline; text-align: right; float: right;">See More</a>
    <h1 style="color: #FFFFFF; float: left; text-align: left; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #FFFFFF; width: 100%;">New</h1><br />
        <asp:datalist id="New" runat="server" RepeatDirection="Horizontal" 
            CellPadding="2">
        <ItemTemplate>
                <div id="Div2" style="border-style: solid; border-width: 1px; border-color: 
rgba(255, 255, 255, 0); width:30px; height:180px; background-color:rgba(114, 114, 114, 0.5); position:absolute; z-index: 1; " class="Invisible">
            <asp:ImageButton id="up2" runat="server" style="margin:38px 0px 30px 0px;" 
                        ImageUrl="~/Images/arrow-up.png" onclick="up_Click"
                        AlternateText='<%# Bind("Name")%>'></asp:ImageButton><br />
            <asp:Label id="score2" runat="server" style="margin:30px 0px 30px 0px;" Text="Label">0</asp:Label><br />
            <asp:ImageButton id="down2" runat="server" style="margin:30px 0px 30px 0px;" 
                        ImageUrl="~/Images/arrow-down.png" onclick="down_Click"
                        AlternateText='<%# Bind("Name")%>'></asp:ImageButton>

            </div>
            <asp:ImageButton id="New1" runat="server" style="background-color:Black; width:180px; height:180px;"
                ImageUrl='<%# Bind("Name","~/Images/All/{0}")%>' Width="100%" 
                onclick="New1_Click" CssClass="Image" ></asp:ImageButton>
        </ItemTemplate> 
        <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom"  />
    </asp:datalist>
            <a href="Images.aspx?Category=New" style="color: #FFFFFF; text-decoration: underline; text-align: right; float: right;">See More</a>
    </div>
</asp:Content>
