<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true" CodeFile="AssignVisitingCourses.aspx.cs" Inherits="AssignVisitingCourses" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register src="ViewAllCourses.ascx" tagname="ViewAllCourses" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: small;
            color: #426343;
        }
        .style2
        {
            color: #394C3B;
        }
        .style3
        {
            width: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MenuContentPlaceHolder" Runat="Server">
<art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Sidebar1ContentPlaceHolder" Runat="Server">
    <asp:Label ID="lblDepartmentID" runat="server" Visible="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="SheetContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="fullSheetContentPlaceHolder" Runat="Server">
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
    <table width="500px" align="left">
        <tr>
            <td align="left" colspan="2">
                <asp:Label ID="lblDepartmentName" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#3C5E3E"></asp:Label>
&nbsp;<span class="style1"><strong>Assing Courses to Visiters</strong></span></td>
        </tr>
        <tr>
            <td align="right" class="style3">
                Teacher&nbsp;Name:</td>
            <td>
                <asp:DropDownList ID="ddlTeacherName" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlTeacherName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                Semester:</td>
            <td>
                <asp:RadioButton ID="rbSpring" runat="server" GroupName="rBtnSemester" 
                    Text="Spring" AutoPostBack="True" 
                    oncheckedchanged="rbSpring_CheckedChanged" />
                <asp:RadioButton ID="rbFall" runat="server" GroupName="rBtnSemester" 
                    Text="Fall" AutoPostBack="True" oncheckedchanged="rbFall_CheckedChanged" />
                <asp:RadioButton ID="rbSummer" runat="server" GroupName="rBtnSemester" 
                    Enabled="False" Text="Summer" AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                Year:</td>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                Programs:</td>
            <td>
                <asp:DropDownList ID="ddlPrograms" runat="server" AutoPostBack="True" 
                    ondatabound="ddlPrograms_DataBound" 
                    onselectedindexchanged="ddlPrograms_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                Courses:</td>
            <td>
                <asp:DropDownList ID="ddlCourses" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlCourses_SelectedIndexChanged" 
                    ondatabound="ddlCourses_DataBound">
                </asp:DropDownList>
                <asp:Label ID="lblCreditHrs" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="btnAddCourse" runat="server" onclick="btnAddCourse_Click" 
                    Text="Add Course" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:Label ID="lblSaveMessage" runat="server"></asp:Label>
            </td>

        </tr>
        <tr>
            <td align="center" colspan="2" class="style2">
                <strong>~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~</strong></td>

        </tr>
        <tr>
            <td align="right" colspan="2">
                                    <asp:Button ID="btnGenrateRF" runat="server" Text="Genrate Requistion Form" 
                                        Width="156px" onclick="btnGenrateRF_Click" />
            </td>

        </tr>
        <tr>
            <td align="left" colspan="2">
                <br />
            <asp:Label ID="lblSelectedCourses" runat="server" 
                Text="Selected Courses By You:"></asp:Label>
                        <asp:GridView ID="gvSelectedCourses" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                            Width="596px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                            EmptyDataText="No Course is selected for this semester!" 
                            onrowdeleting="gvSelectedCourses_RowDeleting">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                                <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                                <asp:BoundField DataField="CourseClass" HeaderText="Class" />
                                <asp:BoundField DataField="CourseType" HeaderText="Type" />
                                <asp:TemplateField HeaderText ="Action">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" commandName="Delete"
                                     OnClientClick="return confirm('Do you want to delete this course?');" Text="Delete" runat="server" ImageUrl="~/images/dd.png" />
                                </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BorderWidth="0px" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#75A3A7" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BorderWidth="0px" BackColor="#E2E9E3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <strong>~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~</strong></td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                    <asp:Label ID="headerTxt" runat="server" Font-Bold="True" Font-Size="Medium" 
                        Text="All Courses Selected By Any Teacher In This Department"></asp:Label>
                <uc1:ViewAllCourses ID="ShowAllCoursesControl" runat="server" />
            </td>
        </tr>
        </table>
            <div class="cleared">
            </div>
        </div>
    </div>
</asp:Content>

