<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="DepartmentDetails.aspx.cs" Inherits="DepartmentDetails" %>

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
                    Programs
                </h2>
                <div class="art-PostContent">
                    <asp:DataList ID="lstPrograms" runat="server" 
                        onitemcommand="lstPrograms_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkProgramName" runat="server" CommandArgument='<%# Eval("ProgramID") %>'
                                Text='<%# Eval("ProgramName") %>' CommandName="ProgramDetails"></asp:LinkButton>
                            (<asp:Label ID="lblDuration" runat="server" Text='<%# Eval("Duration") %>'></asp:Label>)
                        </ItemTemplate>
                    </asp:DataList>
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
                    
                </h2>
                <div class="art-PostContent">
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td valign="top">
                                            <h1>
                                                <asp:Label ID="lblDepartmentName" runat="server"></asp:Label></h1>
                                        </td>
                                        <td align="right">
                                            <asp:Image ID="imgLogo" runat="server" Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DataList ID="lstFaculty" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                    Width="100%" onitemcommand="lstFaculty_ItemCommand">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td rowspan="2">
                                                    <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%# Eval("FacultyImage") %>'
                                                        Width="50px" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkFacultyName" runat="server" Text='<%# Eval("FacultyName") %>'
                                                        CommandArgument='<%# Eval("FacultyID") %>' CommandName="FacultyDetails"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
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
