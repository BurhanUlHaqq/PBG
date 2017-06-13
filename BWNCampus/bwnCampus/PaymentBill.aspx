<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentBill.aspx.cs" Inherits="PaymentBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
        .style4
        {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
   </head>
<body>
    <form id="form1" runat="server">
    
    <table style="width: 1200px" align="center">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" Height="80px" 
                    ImageUrl="~/images/islamia-university-bahawalpur-IUB-Logo.png" Width="78px" />
            </td>
            <td align="center" valign="top">
                <asp:Image ID="Image2" runat="server" Height="28px" 
                    ImageUrl="~/images/PaintHeader.png" Width="451px" />
                <br />
                <span class="style2"><strong>Bahawalnagar Campus</strong></span><br />
                <span class="style2"><strong>Department of </strong></span>
                <asp:Label ID="lblDepartment" runat="server" 
                    style="font-weight: 700; font-size: large; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                <br />
                <asp:Label ID="lblbBillType" runat="server" 
                    style="font-weight: 700; font-size: large; font-family: Arial, Helvetica, sans-serif"></asp:Label>
&nbsp;<strong><span class="style2">Teacher&#39;s Bill For</span></strong>
                <asp:Label ID="lblSpringOrFall" runat="server" 
                    style="font-weight: 700; font-size: large; font-family: Arial, Helvetica, sans-serif"></asp:Label>
&nbsp;<strong><span class="style2">Semester</span></strong>
                <asp:Label ID="lblYear" runat="server" 
                    style="font-weight: 700; font-size: large; font-family: Arial, Helvetica, sans-serif"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="style1">
                    <tr>
                        <td align="center" width="33%">
                            <span class="style2"><strong>Teacher:</strong></span>
                            <asp:Label ID="lblTeacherName" runat="server" 
                                style="font-weight: 700; font-size: large; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                        </td>
                        <td align="center" width="33%">
                            <strong><span class="style2">Designation:</span></strong>
                            <asp:Label ID="lblTeacherDesignatin" runat="server" 
                                style="font-weight: 700; font-size: large; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                        </td>
                        <td align="center">
                            <span class="style2"><strong>HBL Bank A/c No.</strong></span>&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblTeacherAcountNo" runat="server" 
                                style="font-weight: 700; font-size: large; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblBodyTable" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td width="50%">
                            <br />
                            <br />
                            <br />
                            <span class="style3">Bill verified &amp; forwarded for payment</span><br 
                                class="style3" />
                            <span class="style3">Certified that the above mentioned teacher delivered</span><br 
                                class="style3" />
                            <span class="style3">the Lecturers as mentioned against each month and duration 
                            of each</span><br class="style3" />
                            <span class="style3">lecture is 90 minute</span></td>
                        <td class="style4" valign="bottom">
                            <strong>Head of Department</strong></td>
                        <td valign="bottom" width="30%">
                            <br />
                            <span class="style4">Signature of Claimant&nbsp;&nbsp; _____________________<br /></span>
                            <br />
                            
                            <br />
                            <br />
                           <strong style="font-family: Arial, Helvetica, sans-serif"> Director Campus</strong></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    </form>
</body>
</html>
