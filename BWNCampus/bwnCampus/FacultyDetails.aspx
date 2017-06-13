<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="FacultyDetails.aspx.cs" Inherits="FacultyDetails" %>

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
                    Edit Information
                </h2>
                <div class="art-PostContent">
                    <asp:Panel ID="pnlLogin" runat="server" Width="90%">
                        <table width="100%">
                            <tr>
                                <td>
                                    Username:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Password:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdLogin" CssClass="art-button" runat="server" Text="Login" 
                                        onclick="cmdLogin_Click" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMessage" runat="server" Text="Invalid Username or Password" Visible="false"
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlProfile" runat="server" Visible="false">
                        <table width="95%">
                            <tr>
                                <td>
                                    <asp:HyperLink ID="lnkEditProfile" runat="server" NavigateUrl="EditFacultyProfile.aspx">Edit Profile</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="lnkPapers" runat="server" NavigateUrl="EditFacultyResearchPapers.aspx">Edit Papers</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="lnkEditProjects" runat="server" NavigateUrl="EditFacultyProjects.aspx">Edit Projects</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="lnkChangePassword" runat="server" NavigateUrl="ChangePassword.aspx">Change Password</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="lnkAssignCourse" runat="server" NavigateUrl="CourseAssignmentForm.aspx">Assign Courses</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="LinkVisitingAssignCourse" runat="server" 
                                        NavigateUrl="~/AssignVisitingCourses.aspx">Assign Visiting Courses</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="LinkPayBill" runat="server" NavigateUrl="~/PayBill.aspx">Pay Bill</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="LinkVisiterPayBill" runat="server" 
                                        NavigateUrl="~/VisiterPayBill.aspx">Visitor Pay Bill</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="btnLogout" CssClass="art-button" runat="server" 
                                        Text="Logout" onclick="btnLogout_Click1" />
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:HyperLink ID="lnkDepartment" runat="server" NavigateUrl="">Back to Department</asp:HyperLink>
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
                    <asp:Label ID="lblFacultyName" runat="server"></asp:Label>
                </h2>
                <div class="art-PostContent">
                    <table width="100%">
                        <tr>
                            <td>
                                <strong>Gender:</strong>
                                <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
                                &nbsp;
                            </td>
                            <td rowspan="5" align="right">
                                <asp:Image ID="imgFaculty" runat="server" Width="100px" />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Designation: </strong>
                                <asp:Label ID="lblDesignation" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Qualification: </strong>
                                <asp:Label ID="lblQualification" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Specialization: </strong>
                                <asp:Label ID="lblSpecialization" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Objectives:</strong>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblObjectives" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <br />
                                <asp:DataList ID="lstPapers" runat="server" Width="100%">
                                    <HeaderTemplate>
                                        <h3>
                                            Research Papers</h3>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <strong>
                                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("PaperTitle") %>'></asp:Label></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>Date Publish:</strong><asp:Label ID="lblDatePublish" runat="server" Text='<%# Eval("DatePublish") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>Abstract:</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAbstract" runat="server" Text='<%# Eval("PaperAbstract") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>Journal/Conference: </strong>
                                                    <asp:Label ID="lblJournalConfName" runat="server" Text='<%# Eval("JournalConferenceName") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>&nbsp;</strong><asp:HyperLink ID="lnkPaperUrl" runat="server" Text='<%# Eval("PaperUrl") %>'
                                                        NavigateUrl='<%# Eval("PaperUrl") %>' Target="_blank"></asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCoAuthor" runat="server" Text='<%# Eval("CoAurthors") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                        <hr width="100%" />
                                    </SeparatorTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DataList ID="lstProjects" runat="server" Width="100%">
                                    <HeaderTemplate>
                                        <h3>
                                            Projects</h3>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <strong>
                                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ProjectTitle") %>'></asp:Label></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>Details:</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDetails" runat="server" Text='<%# Eval("ProjectDetails") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>Roll:</strong>
                                                    <asp:Label ID="lblRoll" runat="server" Text='<%# Eval("RollInProject") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="lnkProjectUrl" runat="server" NavigateUrl='<%# Eval("ProjectUrl") %>'
                                                        Text='<%# Eval("ProjectUrl") %>'></asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
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
