<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Admin_Login" %>

<%@ Import Namespace="Artisteer" %>
<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artLogin" runat="server" Caption="Login">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="30%">
                            <tr>
                                <td align="right">
                                    Username:
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Password:
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdLogin" CssClass="art-button" runat="server" Text="Login" 
                                        onclick="cmdLogin_Click" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td align="center">
                                    <asp:Label ID="lblMessage" Visible="true" ForeColor="Red" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
