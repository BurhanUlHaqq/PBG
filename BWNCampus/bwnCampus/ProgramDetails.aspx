<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProgramDetails.aspx.cs" Inherits="ProgramDetails" %>

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
                    Program Properties
                </h2>
                <div class="art-PostContent">
                    <table width="100%">
                        <tr>
                            <td>
                                <strong>Duration: </strong>
                            </td>
                            <td>
                                <asp:Label ID="lblDuration" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Criteria:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblCriteria" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fee &amp; Dures:
                            </td>
                            <td>
                                <asp:Label ID="lblFee" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HyperLink ID="lnkDepartment" runat="server">Back to Department</asp:HyperLink>
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
                    Electives List
                </h2>
                <div class="art-PostContent">
                    N/A
                </div>
                <div class="cleared">
                </div>
            </div>
            <div class="cleared">
            </div>
        </div>
    </div>
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
                    <asp:Label ID="lblCaption" runat="server" Text=""></asp:Label>
                </h2>
                <div class="art-PostContent">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DataList ID="lstSemesterList" runat="server" OnItemDataBound="lstSemesterList_ItemDataBound"
                                    Width="100%">
                                    <ItemTemplate>
                                        <table width="100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSemesterNo" runat="server" Text='<%# Eval("SemesterNo") %>' Visible="False"></asp:Label>
                                                    <asp:Label ID="lblSemsterName" runat="server" Text='<%# Eval("SemesterName") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DataList ID="lstCourses" runat="server" Width="70%" BackColor="White" BorderColor="#E7E7FF"
                                                        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                                                        <AlternatingItemStyle BackColor="#F7F7F7" />
                                                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                                        <ItemStyle BackColor="#E2E9E3" ForeColor="#4A3C8C" />
                                                        <ItemTemplate>
                                                            <table width="100%;">
                                                                <tr>
                                                                    <td width="20%">
                                                                        <asp:Label ID="lblCourseCode" runat="server" Text='<%# Eval("CourseCode") %>'></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                                                                    </td>
                                                                    <td width="10%">
                                                                        <asp:Label ID="lblCreditHours" runat="server" Text='<%# Eval("CreditHours") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
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
