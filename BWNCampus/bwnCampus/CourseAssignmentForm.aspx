<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="CourseAssignmentForm.aspx.cs" Inherits="CourseAssignmentForm" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register Src="CourseControl.ascx" TagName="CourseControl" TagPrefix="uc1" %>
<%@ Reference Control="~/CourseControl.ascx" %>
<%@ Register Src="ViewAllCourses.ascx" TagName="ViewAllCourses" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="Server">
    <script language="javascript" type="text/javascript">
        function allCourseTogle() {
            document.getElementById("divAllCourses").style.visibility = false;
        }
    </script>
    <style type="text/css">
        .style2
        {
            width: 99px;
        }
        .style4
        {
            width: 95px;
        }
        .style5
        {
            width: 14px;
        }
        .style6
        {
            width: 68px;
        }
        .style7
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Sidebar1ContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="fullSheetContentPlaceHolder" runat="Server">
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
    <h2 class="art-PostHeader">
        <asp:Label ID="lblCaption" runat="server" Text="Course Assignment Form"></asp:Label>
    </h2>
    <div class="art-PostContent">
        <table width="100%">
            <tr>
                <td>
                    <h3>
                        <asp:Label ID="lblTeacherName" runat="server"></asp:Label></h3>
                    <asp:Label ID="lblDesignation" runat="server"></asp:Label>,
                    <asp:Label ID="lblDepartmentName" runat="server"></asp:Label>
                    <asp:Label ID="lblDepartmentID" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="AJAXPanal">
            <table width="100%">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td align="left" width="35px">
                                    Year:
                                </td>
                                <td align="left" class="style6">
                                    <asp:DropDownList ID="txtYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" class="style5">
                                    &nbsp;
                                </td>
                                <td align="left" class="style4">
                                    <table class="style2" id="TblSemesterType">
                                        <tr>
                                            <td align="left">
                                                Semster:
                                            </td>
                                            <td align="left">
                                                <asp:RadioButton ID="rdbSpring" Text="" runat="server" GroupName="Semester" AutoPostBack="True"
                                                    OnCheckedChanged="rdbSpring_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                Spring
                                            </td>
                                            <td align="left">
                                                <asp:RadioButton ID="rdbFall" Text="" runat="server" GroupName="Semester" AutoPostBack="True"
                                                    OnCheckedChanged="rdbFall_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                Fall
                                            </td>
                                            <td align="left">
                                                <asp:RadioButton ID="rdbSummer" Text="" runat="server" GroupName="Semester" AutoPostBack="True"
                                                    Enabled="False" />
                                            </td>
                                            <td align="left">
                                                Summer
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="CourseContainer">
                            <uc1:CourseControl ID="ucCourse" runat="server" Visible="False" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlClasses" runat="server" Visible="False" AutoPostBack="True"
                            OnDataBound="ddlClasses_DataBound" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="divAllCourses" style="position: static; top: 0px; right: 0px">
        <table class="style1" style="width: 600px">
        <tr>
        <td colspan ="2" align="center">
                    <asp:Button ID="btnAllCourses" runat="server" Text="Show All Selected Courses" 
                        OnClick="btnAllCourses_Click" Visible="False" />
        </td>
        </tr> 
            <tr>
                <td align="center">
                    <asp:Label ID="headerTxt" runat="server" Font-Bold="True" Font-Size="Medium" 
                        Text="All Courses Selected By Any Teacher In This Department" 
                        Visible="False"></asp:Label>
                </td>
                <td align="center">
                    <asp:ImageButton ID="iBtnExit" runat="server" ImageUrl="~/images/minimize.png" 
                        onclick="iBtnExit_Click" Visible="False" ToolTip="Minimize/Close/Hide" />
                </td>
            </tr>
            <tr>
                <td class="style7" colspan="2">
                    <asp:Panel ID="panalAllCourse" runat="server" 
                        Width="600px" ScrollBars="Auto" Height="250px" Visible="False">
                        <uc2:ViewAllCourses ID="controlViewAllCourses" runat="server" Visible="True" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
            <div class="cleared">
            </div>
        </div>
    </div>
</asp:Content>
