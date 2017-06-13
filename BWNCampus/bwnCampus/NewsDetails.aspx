<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="NewsDetails.aspx.cs" Inherits="NewsDetails" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artNewsDetails" runat="server" Caption="News Details">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <b><u>
                            <asp:Label ID="lblNewsTitle" runat="server" Text=""></asp:Label>
                        </u></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="ltrNewsDetails" runat="server" Text=""></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="sSeprater">
                        &nbsp;
                        <asp:DataList ID="lstNewsImages" runat="server" RepeatDirection="Horizontal" Width="100%">
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <asp:Image ID="imgNewsImage" runat="server" ImageUrl='<%# Eval("ImageFilePath") %>'
                                                Width="75px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <asp:Label ID="lblImageTitle" runat="server" Text='<%# Eval("ImagesTitle") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
