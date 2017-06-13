<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="VisiterPayBill.aspx.cs" Inherits="PayBill" %>

<%@ Import Namespace="Artisteer" %>
<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: small;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            font-size: medium;
        }
    </style>
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
   <div id="SideDiv" style="background-color: #E2E9E3; height: 100%;">

    <asp:Label ID="lblDepartmentID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDepartmentName" runat="server" Style="font-size: medium"></asp:Label>
    <br />
    <br />
                <asp:DropDownList ID="ddlTeacherName" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlTeacherName_SelectedIndexChanged">
                </asp:DropDownList>
    <br/>
    <span class="style3">Lecturer (Visitor)</span>&nbsp;
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
    <div id="bodyDiv" style="background-color: #E2E9E3">
        <asp:Label runat="server" Text="Faculty Payment Bills" ID="lblMainHeading" Style="font-size: x-large"></asp:Label>
        <br />
        <asp:Wizard ID="WizardBillSteps" runat="server" ActiveStepIndex="0" OnNextButtonClick="WizardBillSteps_NextButtonClick"
            Width="100%" FinishCompleteButtonText="Genrate Payment Bill" 
            onfinishbuttonclick="WizardBillSteps_FinishButtonClick" 
            StartNextButtonText="New Payment Bill">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Basic Info">
                    <table align="left" width="500px">
                        <tr>
                            <td align="right" colspan="2">
                                <table align="left">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAccount" runat="server" Text="HBL Bank A/c No: "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAccountNo" runat="server" Width="226px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAccountNo"
                                                ErrorMessage="*Required"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Income Tax Rate:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtIncomeTaxRate" runat="server" MaxLength="2"></asp:TextBox>
                                            <span class="style1"><strong>%</strong><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                runat="server" ControlToValidate="txtIncomeTaxRate" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Rate Per Lecture:</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRatePerLecture" runat="server" MaxLength="4"></asp:TextBox>
                                            Rs/-<span class="style1"><asp:RequiredFieldValidator 
                                                ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="txtRatePerLecture" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="btnAccountNoSave" runat="server" OnClick="btnAccountNoSave_Click"
                                                Text="Save/Update" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <asp:Label ID="lblAccountMessage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15px">
                                Year:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Semester:
                            </td>
                            <td>
                                <asp:RadioButton ID="rbSpring" runat="server" GroupName="rBtnSemester" Text="Spring"
                                    AutoPostBack="True" OnCheckedChanged="rbSpring_CheckedChanged" />
                                <asp:RadioButton ID="rbFall" runat="server" GroupName="rBtnSemester" Text="Fall"
                                    AutoPostBack="True" OnCheckedChanged="rbFall_CheckedChanged" />
                                <asp:RadioButton ID="rbSummer" runat="server" GroupName="rBtnSemester" Enabled="False"
                                    Text="Summer" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                Assigned Courses:
                                <asp:GridView ID="gvSelectedCourses" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    EmptyDataText="No Course is selected for this semester!" EnableModelValidation="True"
                                    ForeColor="#333333" GridLines="None" Width="596px" OnRowDeleting="gvSelectedCourses_RowDeleting">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                        <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                                        <asp:BoundField DataField="CourseClass" HeaderText="Class" />
                                        <asp:BoundField DataField="CourseType" HeaderText="Type" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/images/dd.png"
                                                    OnClientClick="return confirm('Do you want to delete this course?');" Text="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BorderWidth="0px" />
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#75A3A7" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#E2E9E3" BorderWidth="0px" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Add Lactures Dates">
                    <asp:Label ID="lblAddAttandanceHeader" runat="server" Style="font-weight: 700; font-size: medium;
                        color: #345D35" Text="Add Lectures Attandence"></asp:Label>
                    <br />
                    <table class="style2">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="200">
                                <asp:Calendar ID="CaledarDate" runat="server" BackColor="White" BorderColor="#3366CC"
                                    BorderWidth="1px" CellPadding="1" FirstDayOfWeek="Sunday" Font-Names="Verdana"
                                    Font-Size="8pt" ForeColor="#003399" Height="200px" OnDayRender="CaledarDate_DayRender"
                                    OnSelectionChanged="CaledarDate_SelectionChanged" TitleFormat="Month" Visible="False"
                                    Width="220px">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                                        Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </td>
                            <td align="left" width="*">
                                <asp:Panel ID="AttendanceContainer" runat="server" Height="200px" ScrollBars="Auto"
                                    Width="100px">
                                    <asp:DataList ID="AttendanceDateList" runat="server" OnDeleteCommand="AttendanceDateList_DeleteCommand">
                                        <ItemTemplate>
                                            <table class="style2">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblAttandenceShow" runat="server" Text='<%# Eval("Attandence") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="22px" ImageUrl="~/images/dd.png"
                                                            Width="24px" CommandName="Delete" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblAttandenceMessage" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblSelectedCourse" runat="server"></asp:Label>
                    <br />
                    <asp:DataList ID="AttendanceList" runat="server" BackColor="#91AEA0" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                        OnCancelCommand="AttendanceList_CancelCommand" OnEditCommand="AttendanceList_EditCommand"
                        Width="100%">
                        <AlternatingItemStyle BackColor="#CCCFFE" />
                        <EditItemTemplate>
                            <table class="style2">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCourse" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCourseCode" runat="server" Text='<%# Eval("CourseCode") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAttendence" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="linkbtnSave" runat="server" CommandName="Cancel">Done</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <ItemTemplate>
                            <table class="style2">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCourse" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCourseCode" runat="server" Text='<%# Eval("CourseCode") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="linkbtnEdit" runat="server" CommandName="Edit">Add Attandence</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                    <br />
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
        <br />
&nbsp;
        <asp:Button ID="btnPaymentBillCopy" runat="server" 
            onclick="btnPaymentBillCopy_Click" Text="Genrate Copy of Payment Bill" 
            Width="162px" Visible="False" />
    </div>
            <div class="cleared">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="fullSheetContentPlaceHolder" runat="Server">
</asp:Content>
