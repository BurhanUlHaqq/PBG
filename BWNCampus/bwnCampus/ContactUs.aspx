<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

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
<asp:Content ID="Content6" ContentPlaceHolderID="fullSheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artContactUs" runat="server" align="center" Caption="Contact Us">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="60%">
                            <tr>
                                <td align="left">
                                    Message Title:
                                    <asp:RequiredFieldValidator ID="MessageTitle" runat="server" ControlToValidate="txtMessageTitle"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtMessageTitle" runat="server" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Messages Details:
                                    <asp:RequiredFieldValidator ID="MessageDetails" runat="server" ControlToValidate="txtMessagesDetails"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtMessagesDetails" runat="server" TextMode="MultiLine" Width="400px"
                                        Height="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Sender Name:
                                    <asp:RequiredFieldValidator ID="SenderName" runat="server" ControlToValidate="txtMessageSenderName"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtMessageSenderName" runat="server" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Sender Email
                                    <asp:RequiredFieldValidator ID="SenderEmail" runat="server" ControlToValidate="txtMessageSenderEmail"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:RegularExpressionValidator ID="MessageSenderEmail" runat="server" ControlToValidate="txtMessageSenderEmail"
                                        Display="Dynamic" ErrorMessage="Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtMessageSenderEmail" runat="server" Width="400px" OnTextChanged="txtMessageSenderEmail_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Sender Phone
                                    <asp:RequiredFieldValidator ID="SenderPhone" runat="server" ControlToValidate="txtMessageSenderPhone"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtMessageSenderPhone" runat="server" Width="400px" OnTextChanged="txtMessageSenderPhone_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdSend" CssClass="art-button" runat="server" Text="Send" OnClick="cmdSend_Click" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
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
