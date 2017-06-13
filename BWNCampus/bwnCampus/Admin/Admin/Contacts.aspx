<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="Contacts.aspx.cs" Inherits="Admin_Admin_Contacts" %>

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
<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <script type="text/jscript" src="custom.js"></script>
    <artisteer:Article ID="artContacts" runat="server" Caption="Contacts">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%">
                            <tr>
                                <td align="right">
                                    <strong>Contact Title:</strong><asp:RequiredFieldValidator ID="Contacts" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtContactTitle" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <strong>Telephone:</strong>:<asp:RequiredFieldValidator ID="Telephone" runat="server" ControlToValidate="txtTelephone"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtTelephone" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Email:</strong>
                                    <asp:RequiredFieldValidator ID="Email" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:RegularExpressionValidator ID="Email1" runat="server" ControlToValidate="txtEmail"
                                        Display="Dynamic" ErrorMessage="Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdSave" CssClass="art-button" runat="server" Text="Save" OnClick="cmdSave_Click" />
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
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        EnableModelValidation="True" ForeColor="#333333" GridLines="Both">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="ContactTitle" HeaderText="Contact Title" />
                                            <asp:BoundField DataField="Telephone" HeaderText="Telephone" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                                                    CommandArgument='<%# Eval("ContactID") %>' Height="24px" Width="24px" CausesValidation="False"
                                                                    ImageUrl="~/Admin/Admin/images/file_edit.png" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnDel" runat="server" AlternateText="Delete" CommandName="Del"
                                                                    OnClientClick="return confirm('Sure To Delete');" CommandArgument='<%# Eval("ContactID") %>'
                                                                    Height="24px" Width="24px" CausesValidation="False" ImageUrl="~/Admin/Admin/images/dd.png" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
