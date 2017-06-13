<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="Admin_Admin_Department" %>

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
    <artisteer:Article ID="artDepartment" runat="server" Caption="Department">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%">
                            <tr>
                                <td align="right">
                                    <strong>Department Name: </strong>
                                    <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server" ControlToValidate="txtDepartmentName"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtDepartmentName" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <strong>Description: </strong>
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300px"
                                        Height="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Logo Image Path: </strong><asp:RequiredFieldValidator ID="ImageUpload" runat="server" ControlToValidate="fulLogoImage"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:FileUpload ID="fulLogoImage" Width="306px" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkPrograms" runat="server" CausesValidation="False">Add / Edit Programs</asp:LinkButton>
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
                                    <asp:GridView ID="grdDepartments" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        EnableModelValidation="True" ForeColor="#333333" Width="100%" OnSelectedIndexChanged="grdDepartments_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName">
                                                <ItemStyle Font-Bold="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreatedDateTime" HeaderText="Create DateTime" />
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                                                    CommandArgument='<%# Eval("DepartmentID") %>' Height="24px" Width="24px" CausesValidation="False"
                                                                    ImageUrl="~/Admin/Admin/images/file_edit.png" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnDelete" runat="server" AlternateText="Delete" CommandName="Del"
                                                                    CommandArgument='<%# Eval("DepartmentID") %>' Height="24px" Width="24px" OnClientClick="return confirm('Sure to Delete');"
                                                                    CausesValidation="False" ImageUrl="~/Admin/Admin/images/dd.png" />
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
