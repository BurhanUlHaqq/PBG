<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="MessageReply.aspx.cs" Inherits="Admin_Admin_MessageReply" %>

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
<art:DefaultMenu ID="DefaultMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artMessageReply" runat="server" Caption="Message">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table style="width: 6%">
                            <tr>
                                <td align="right">
                                    To:&nbsp;
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    Subject:&nbsp;
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtSubject" runat="server" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    Message:
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Width="400px" Height="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdSend" CssClass="art-button" runat="server" Text="Send" OnClick="cmdSend_Click" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
