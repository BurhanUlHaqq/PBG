<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditFacultyResearchPapers.aspx.cs" Inherits="EditFacultyResearchPapers" %>

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
    <artisteer:Article ID="artEditFacultyResearchPaper" runat="server" Caption="Research Papers"
        meta:resourcekey="artContactsResource1">
        <ContentTemplate>
            <table cellpadding="20px">
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    <strong>Title:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaperTitle" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Type: (Journal / Conference:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperType" runat="server" Width="306px">
                                        <asp:ListItem Value="Journal">Journal</asp:ListItem>
                                        <asp:ListItem>Conference</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <strong>Abstract: </strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAbstract" runat="server" Height="200px" TextMode="MultiLine"
                                        Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <strong>Date Publish: </strong>
                                </td>
                                <td>
                                    <asp:Calendar ID="dtpDatePublish" runat="server"></asp:Calendar>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Journal / Conference Name: </strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtJournalName" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Paper URL:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPapeURL" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Co-Author(s): </strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCoAuthor" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
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
                        <asp:GridView ID="grdResearchPapers" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableModelValidation="True" ForeColor="#333333" Width="100%">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="PaperTitle" HeaderText="Title" />
                                <asp:BoundField DataField="JournalConferenceName" HeaderText="Published in" />
                                <asp:BoundField DataField="PaperUrl" HeaderText="URL" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" CausesValidation="False"
                                                        CommandArgument='<%# Eval("PaperID") %>' CommandName="Edit" Height="24px" ImageUrl="~/Admin/Admin/images/file_edit.png"
                                                        Width="24px" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnDelete" runat="server" AlternateText="Delete" CausesValidation="False"
                                                        CommandArgument='<%# Eval("PaperID") %>' CommandName="Del" Height="24px" ImageUrl="~/Admin/Admin/images/dd.png"
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
