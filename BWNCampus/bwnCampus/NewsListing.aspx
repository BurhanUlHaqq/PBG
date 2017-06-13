<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="NewsListing.aspx.cs" Inherits="NewsListing" %>

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
<asp:Content ID="Content5" ContentPlaceHolderID="Sidebar1ContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="fullSheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artNewsList" runat="server" Caption="News">
        <ContentTemplate>
            <asp:DataList ID="lstNewsDetails" runat="server" Width="100%">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkNewsTitle" runat="server" CommandArgument='<%# Eval("NewsID") %>'
                                    CommandName="NewsDetails" Text='<%# Eval("NewsTitle") %>'></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltrNewsDetails" runat="server" Text='<%# Eval("NewsDetails") %>'></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="sSeprater">
                                &nbsp;
                                <asp:DataList ID="lstNewsDetails" runat="server" RepeatDirection="Horizontal" Width="100%">
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
                </ItemTemplate>
            </asp:DataList>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
