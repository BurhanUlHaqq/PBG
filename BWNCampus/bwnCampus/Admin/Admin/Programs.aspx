<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="Programs.aspx.cs" Inherits="Admin_Admin_Programs" %>

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
    <artisteer:Article ID="artPrograms" Caption="Programs" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%" border="0">
                            <tr>
                                <td align="right">
                                    <strong>Program Titlle: </strong>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Department: </strong>
                                </td>
                                <td align="right">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="306px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Duration: </strong>
                                </td>
                                <td align="right">
                                    <table width="80%">
                                        <tr>
                                            <td>
                                                Years:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtYear" runat="server" Width="91px"></asp:TextBox>
                                            </td>
                                            <td>
                                                Semester:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSemester" runat="server" Width="91px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Criteria: </strong>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtCriteria" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Fee &amp; Dues: </strong>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtFee" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="right">
                                    <strong>Description: </strong>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtDescription" runat="server" Height="200px" TextMode="MultiLine"
                                        Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdSave" CssClass="art-button" runat="server" Text="Save" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkAddEditCourse" runat="server" Visible="false">Add /Edit Courses </asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300" Text="Unable to Edit / Add Program"
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="grdPrograms" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableModelValidation="True" ForeColor="#333333" Width="50%">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ProgramName" HeaderText="Program Name">
                                    <ItemStyle Font-Bold="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Duration" HeaderText="Duration" />
                                <asp:BoundField DataField="Criteria" HeaderText="Criteria" />
                                <asp:BoundField DataField="Fee" HeaderText="Fee &amp; Dues" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" CausesValidation="False"
                                                        CommandArgument='<%# Eval("ProgramID") %>' CommandName="Edit" Height="24px" ImageUrl="~/Admin/Admin/images/file_edit.png"
                                                        Width="24px" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnDelete" runat="server" AlternateText="Delete" CausesValidation="False"
                                                        CommandArgument='<%# Eval("ProgramID") %>' CommandName="Del" Height="24px" ImageUrl="~/Admin/Admin/images/dd.png"
                                                        OnClientClick="return confirm('Sure to Delete');" Width="24px" />
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
