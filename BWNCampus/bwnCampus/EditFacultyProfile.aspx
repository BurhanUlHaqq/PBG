<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditFacultyProfile.aspx.cs" Inherits="EditFacultyProfile" %>

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
                    Back to...
                </h2>
                <div class="art-PostContent">
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
                    Edit Profile
                </h2>
                <div class="art-PostContent">
                    <table cellpadding="30px">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td width="30%">
                                            <strong>Name:</strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Gender:</strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlGender" runat="server" Width="306px">
                                                <asp:ListItem Value="1">Male</asp:ListItem>
                                                <asp:ListItem Value="0">Female</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Department:</strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" Width="306px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Designation:</strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDesignation" runat="server" Width="306px">
                                                <asp:ListItem Value="1">Lecturer</asp:ListItem>
                                                <asp:ListItem Value="2">Assistant Professor</asp:ListItem>
                                                <asp:ListItem Value="3">Associate Professor</asp:ListItem>
                                                <asp:ListItem Value="4">Professor</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <strong>Objectives:</strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtObjectives" runat="server" Height="100px" TextMode="MultiLine"
                                                Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Qualification:</strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQualification" runat="server" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Specialization:</strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSpecialization" runat="server" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Faculty Image:</strong>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fulImage" runat="server" Width="306px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Image ID="imgFaculty" runat="server" Width="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                                <asp:Button ID="cmdSave" CssClass="art-button" runat="server" Text="Save" />
                                            </span>
                                        </td>
                                    </tr>
                                </table>
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
