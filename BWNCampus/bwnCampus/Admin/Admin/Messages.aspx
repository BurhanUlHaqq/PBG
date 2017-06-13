<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Admin_Admin_Messages" %>

<%@ Import Namespace="Artisteer" %>
<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artMessagesList" runat="server" Caption="Messages">
        <ContentTemplate>
            <asp:DataList ID="lstMessagesDetails" runat="server" Width="80%" BackColor="White"
                OnItemCommand="lstMessagesDetails_ItemCommand" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Size="Smaller" Font-Strikeout="False" Font-Underline="False" ForeColor="Black"
                GridLines="Horizontal" HorizontalAlign="Left">
                <AlternatingItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                <EditItemStyle Font-Bold="True" Font-Italic="False" Font-Names="Tahoma" Font-Overline="False"
                    Font-Size="14px" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                <ItemTemplate>
                    <table width="100%" border="0">
                        <tr>
                            <td>
                                <b><u>
                                    <h3>
                                        <asp:Label ID="lblMessageTitle" runat="server" Text='<%# Eval("MessageTitle") %>'
                                            CssClass=""></asp:Label></h3>
                                </u></b>&nbsp;by
                                <asp:Label ID="lblMessageSenderName" runat="server" Text='<%# Eval("MessageSenderName") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="art-PostContent">
                                <asp:Literal ID="ltrMessagesDetails" runat="server" Text='<%# Eval("MessagesDetails") %>'></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Eval("CreatedDate") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMessageSenderEmail" runat="server" Text='<%# Eval("MessageSenderEmail") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMessageSenderPhone" runat="server" Text='<%# Eval("MessageSenderPhone") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                    <asp:LinkButton ID="lnkReply" runat="server" CssClass="art-button" Text="Reply" CommandName="Reply"
                                        CommandArgument='<%# Eval("MessageSenderEmail") %>'></asp:LinkButton>
                                </span>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
