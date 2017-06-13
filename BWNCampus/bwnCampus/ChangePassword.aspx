<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

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
<asp:Content ID="Content6" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <div class="art-Post">
        <div class="art-Post-tl">
        </div>
        <div class="art-Post-tr">
        </div>
        <div class="art-Post-bl">
        </div>
        <div class="art-Post-br">
        </div>
        <div class="art-Post-tc">
        </div>
        <div class="art-Post-bc">
        </div>
        <div class="art-Post-cl">
        </div>
        <div class="art-Post-cr">
        </div>
        <div class="art-Post-cc">
        </div>
        <div class="art-Post-body">
            <div class="art-Post-inner">
                <h2 class="art-PostHeader">
                    Change Password
                </h2>
                <div class="art-PostContent">
                    <table width="70%">
                        <tr>
                            <td align="right">
                                <strong>Username: </strong>
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                                    ControlToValidate="txtUsername" ErrorMessage="*"></asp:RequiredFieldValidator>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Old Password: </strong>
                                <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>New Password: </strong>
                                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Confirm Old Password: </strong>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                                <asp:CompareValidator ID="cfvConfirmPassword" runat="server" 
                                    ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" 
                                    ErrorMessage="Password and Confirm Password are not same"></asp:CompareValidator>
                            </td>
                            <td>
                                <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                    <asp:Button ID="cmdSave" CssClass="art-button" runat="server" Text="Save" 
                                    onclick="cmdSave_Click" />
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="cleared">
                </div>
            </div>
            <div class="cleared">
            </div>
        </div>
    </div>
</asp:Content>
