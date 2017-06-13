<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="Faculty.aspx.cs" Inherits="Admin_Admin_Faculty" %>

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
    <artisteer:Article ID="artFaculty" runat="server" Caption="Faculty">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%">
                            <tr>
                                <td align="right">
                                    <strong>Faculty Name:</strong><asp:RequiredFieldValidator ID="rfvFacultyName" runat="server" ControlToValidate="txtFacultyName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtFacultyName" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <strong>Designation: </strong>
                                </td>
                                <td align="right">
                                    <asp:DropDownList ID="ddlDesignation" runat="server" Width="306px">
                                        <asp:ListItem Value="1">Lecturer</asp:ListItem>
                                        <asp:ListItem Value="2">Assistant Professor</asp:ListItem>
                                        <asp:ListItem Value="3">Associate Professor</asp:ListItem>
                                        <asp:ListItem Value="4">Professor</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <strong>Department:</strong>
                                </td>
                                <td align="right">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="306px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Image<asp:RequiredFieldValidator ID="rfvImage" runat="server" 
                                        ControlToValidate="fulFacultyImage" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    : </strong>
                                </td>
                                <td align="right">
                                    <asp:FileUpload ID="fulFacultyImage" Width="306px" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Username:</strong></td>
                                <td align="right">
                                    <asp:TextBox ID="txtUsername" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Password: </strong></td>
                                <td align="right">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdSave" CssClass="art-button" runat="server" Text="Save" />
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
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td align="center">
                        <asp:HyperLink ID="linkVisiting" runat="server" 
                            NavigateUrl="~/Admin/Admin/VisitingFaculty.aspx">Add Visiting Faculty</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:GridView ID="grdFaculty" runat="server" EnableModelValidation="True" Width="100%"
                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="FacultyName" HeaderText="Name" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                                        CommandArgument='<%# Eval("FacultyID") %>' Height="24px" Width="24px" CausesValidation="False"
                                                        ImageUrl="~/Admin/Admin/images/file_edit.png" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnDelete" runat="server" AlternateText="Delete" CommandName="Del"
                                                        OnClientClick="return confirm('Sure To Delete');" CommandArgument='<%# Eval("FacultyID") %>'
                                                        CausesValidation="False" Height="24px" ImageUrl="~/Admin/Admin/images/dd.png"
                                                        Width="24px" />
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
            </ContentTemplate>
    </artisteer:Article>
</asp:Content>
