<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="Course.aspx.cs" Inherits="Admin_Admin_Course" %>

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
    <artisteer:Article ID="artCourse" runat="server" Caption="Course">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%">
                            <tr>
                                <td align="right">
                                    <strong>Course Name: </strong>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtCourseName" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Course Code: </strong>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtCourseCode" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Credit Hours: </strong></td>
                                <td align="right">
                                    <asp:TextBox ID="txtCreditHours" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Semester: </strong>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtSemester" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="right">
                                    <strong>Details: </strong>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtDescription" runat="server" Height="200px" TextMode="MultiLine"
                                        Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300" 
                                        Text="Unable to save data" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdSave" CssClass="art-button" runat="server" Text="Save" />
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <h3><strong><asp:Label ID="lblProgramName" runat="server"></asp:Label></strong></h3>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="grdCourse" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
                            Width="50%">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                                <ItemStyle Font-Bold="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                                <asp:BoundField DataField="SemesterNO" HeaderText="Semester" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" 
                                                        CausesValidation="False" CommandArgument='<%# Eval("CourseID") %>' 
                                                        CommandName="Edit" Height="24px" ImageUrl="~/Admin/Admin/images/file_edit.png" 
                                                        Width="24px" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnDelete" runat="server" AlternateText="Delete" 
                                                        CausesValidation="False" CommandArgument='<%# Eval("CourseID") %>' 
                                                        CommandName="Del" Height="24px" ImageUrl="~/Admin/Admin/images/dd.png" 
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
