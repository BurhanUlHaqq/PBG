<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditFacultyProjects.aspx.cs" Inherits="EditFacultyProjects" %>

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
    <artisteer:Article ID="artLinks" runat="server" Caption="Back to...">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <asp:HyperLink ID="lnkDepartment" runat="server">Department</asp:HyperLink><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="lnkFaculty" runat="server">Faculty</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artEditFacultyProject" Caption="Edit Projects" runat="server"
        meta:resourcekey="artContactsResource1">
        <ContentTemplate>
            <table cellpadding="20px" width="100%">
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    <strong>Title:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <strong>Project Details:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDetails" runat="server" Height="200px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <strong>Your Role:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRole" runat="server" Height="100px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Project URL:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtURL" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="btnSave" CssClass="art-button" runat="server" Text="Save" />
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdProjects" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableModelValidation="True" ForeColor="#333333" Width="100%">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ProjectTitle" HeaderText="Title" />
                                <asp:BoundField DataField="ProjectUrl" HeaderText="URL" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" CausesValidation="False"
                                                        CommandArgument='<%# Eval("ProjectID") %>' CommandName="Edit" Height="24px" ImageUrl="~/Admin/Admin/images/file_edit.png"
                                                        Width="24px" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnDelete" runat="server" AlternateText="Delete" CausesValidation="False"
                                                        CommandArgument='<%# Eval("ProjectID") %>' CommandName="Del" Height="24px" ImageUrl="~/Admin/Admin/images/dd.png"
                                                        OnClientClick="return confirm('Sure To Delete');" Width="24px" />
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
