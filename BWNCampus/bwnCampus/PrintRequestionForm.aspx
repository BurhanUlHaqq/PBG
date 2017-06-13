<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintRequestionForm.aspx.cs"
    Inherits="PrintRequestionForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script language="javascript" type ="text/javascript">
        function printPage() {
            window.print();
        }
        function notLoginUser() {
            document.getElementById("btnPrint").disabled = true;
            alert("You are Not Loged In");
            window.open("Default.aspx","_self");
        }
    </script>
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 376px;
        }
        .style4
        {
            width: 323px;
        }
        .style6
        {
            width: 31px;
        }
        .style8
        {
        }
        .style11
        {
            font-size: small;
            height: 19px;
        }
        .style12
        {
            height: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" id="divPage">
        <table class="style1" style="width: 700px; position: relative">
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td rowspan="2" width="105px">
                                <asp:Image ID="Image1" runat="server" Height="69px" Width="59px" ImageUrl="~/images/islamia-university-bahawalpur-IUB-Logo.png" />
                            </td>
                            <td align="left" colspan="2" valign="top">
                                <asp:Image ID="Image2" runat="server" Height="37px" ImageUrl="~/images/PaintHeader.png"
                                    Width="550px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;No:_______________&nbsp;
                            </td>
                            <td align="right">
                                Dated:_______________
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="PART-TIME/VISITING FACULTY REQUESTION FORM"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Text="Instruction on the Form"></asp:Label>
                                <br />
                                <span class="style8">1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Only one form will
                                    be completed in respect of one teacher in one semester.</span><br class="style8" />
                                <span class="style8">2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;All courses, whether
                                    in the department or outside of the Department proposed for the teacher will be&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    entered in the Form.</span><br class="style8" />
                                <span class="style8">3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The Form will be submitted
                                    with the signature of the Chairperson/Head of Department through the Dean.</span><br
                                        class="style8" />
                                <span class="style8">4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The form must be filled
                                    and submitted for Vice-Chancellor&#39;s Approval within 15 days of the start of
                                    the semester</span><br />
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text="Part-Time Teaching Request:"></asp:Label>
                                <br />
                                <span class="style8">Approval is solicited to the following Part-Time/Visiting facullity
                                    of teaching the classes as detailed below:</span><br />
                                <table class="style1">
                                    <tr>
                                        <td class="style2">
                                            <span class="style8">1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Name of Teacher:</strong>&nbsp;
                                            </span>
                                            <asp:Label ID="lblTeacherName" runat="server" Font-Underline="True"></asp:Label>
                                            <br class="style8" />
                                            <span class="style8">3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Department:</strong>&nbsp;
                                            </span>
                                            <asp:Label ID="lblDepartment" runat="server" Font-Underline="True"></asp:Label>
                                        </td>
                                        <td>
                                            <span class="style8">2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Designation:</strong>&nbsp;
                                            </span>
                                            <asp:Label ID="lblDesignation" runat="server" Font-Underline="True"></asp:Label>
                                            <br class="style8" />
                                            <span class="style8">4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Semester/Session:</strong>&nbsp;&nbsp;
                                            </span>
                                            <asp:Label ID="lblSemester" runat="server" Font-Underline="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="style8">
                                            5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Status:
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                Permanent&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox1" runat="server" Width="96px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                Contract&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox2" runat="server" Width="90px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                Visititng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox3" runat="server" Width="97px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Work Load of Regular/Contract
                    Teacher:<br />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:GridView ID="gvWorkLoad" runat="server" Width="100%" 
                        AutoGenerateColumns="False" EnableModelValidation="True" 
                        onrowcreated="gvWorkLoad_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr No" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseName" HeaderText="Title of the Course" />
                            <asp:BoundField DataField="CourseCode" HeaderText="Course Code" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseCredit" HeaderText="Course Credit Hrs" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Approved">
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Not<br/>Approved">
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left">
                    III.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Additional Part-Time
                    Course(s) requested due to foreign degree/qualification as listed.<br />
                    <table class="style1">
                        <tr>
                            <td>
                                Foreign Degree_____________
                            </td>
                            <td align="right">
                                Date of Degree________________
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table border="1" frame="box" width="100%">
                                    <tr>
                                        <td align="center" class="style6">
                                            Sr.<br />
                                            No
                                        </td>
                                        <td align="center" class="style4">
                                            Part-Time Courses(s)
                                        </td>
                                        <td align="center">
                                            Course Code
                                        </td>
                                        <td align="center">
                                            Course
                                            <br />
                                            Credit Hrs
                                        </td>
                                        <td align="center">
                                            Approved
                                        </td>
                                        <td align="center">
                                            Not<br />
                                            Approved
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style8" align="center">
                                            1
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style8" align="center">
                                            2
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                        <td class="style8">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    IV.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Visiting Faculty Teaching
                    Requst:<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Particular of visiting faculty:<br />
                    <table class="style1">
                        <tr>
                            <td>
                                Degree______________________________
                            </td>
                            <td align="center">
                                Specialization Subject____________
                            </td>
                            <td align="right">
                                Division__________
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">

                    <asp:GridView ID="gvVisiters" runat="server" Width="100%" 
                        AutoGenerateColumns="False" EnableModelValidation="True" 
                        onrowcreated="gvWorkLoad_RowCreated" 
                                    EmptyDataText="Please Select Courses First And Then Genrate This Form Again">
                        <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr No" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseName" 
                                HeaderText="Visiting Faculty Course(s)" />
                            <asp:BoundField DataField="CourseCode" HeaderText="Course Code" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseCredit" HeaderText="Course Credit Hrs" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Approved">
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Not<br/>Approved">
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:GridView>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" style="font-size: small">
                    V.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Certification &amp;
                    Verification:<br />
                    It is certified that the teacher concerned is teaching required teaching load as
                    indicated above and only two additional
                    <br />
                    Courses as part time as per University Policy.<br />
                    <table class="style1">
                        <tr>
                            <td class="style8">
                                Filled By:______________________________
                            </td>
                            <td align="right" class="style8">
                                Dated____________________
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style8">
                                Name &amp; Signature&nbsp;
                            </td>
                            <td class="style8">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="style1">
                        <tr>
                            <td class="style11">
                                Verified By:______________________________
                            </td>
                            <td align="right" class="style11">
                                Dated____________________
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style8">
                                Name &amp; Signature&nbsp;of Chairperson/Head of Department
                            </td>
                            <td class="style8">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="style1">
                        <tr>
                            <td class="style12">
                                Recommendation&nbsp; By Dean:______________________________
                            </td>
                            <td align="right" class="style12">
                                Dated____________________
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style8">
                                &nbsp;Signature&nbsp;of Dean
                            </td>
                            <td class="style8">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="style1">
                        <tr>
                            <td align="center" colspan="2">
                                ______________________________________________________________________________________________
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Approved by the Vice Chancellor
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table class="style1">
                                    <tr>
                                        <td>
                                            Total Course&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="TextBox4" runat="server" Width="82px"></asp:TextBox>
                                        </td>
                                        <td>
                                            Approved&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="TextBox5" runat="server" Width="82px"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Not Approved&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="TextBox6" runat="server" Width="82px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                ______________________________________________________________________________________
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                Vice-Chancellor
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input id="btnPrint" style="position: fixed; right: 0px; top: 0px" type="button"
            value="Print" onclick="printPage()" /></div>
    </form>
</body>
</html>
