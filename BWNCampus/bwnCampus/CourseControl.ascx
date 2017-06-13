<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CourseControl.ascx.cs"
    ClassName="CourseListing" Inherits="CourseControl" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<table>
    <tr>
        <td>
            <asp:Label ID="lblSelectedCourses" runat="server" 
                Text="Selected Courses By You:"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table width="600px">
                <tr>
                    <td align="left">
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
                        <table class="style1">
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnGenrateRF" runat="server" Text="Genrate Requistion Form" 
                                        Width="156px" onclick="btnGenrateRF_Click" />
                                    </td>
                            </tr>
                        </table>
                        <asp:Label ID="LabelSemester" runat="server" Text="Semester:"></asp:Label>
                        &nbsp;<asp:Label ID="labSemesterNo" runat="server"></asp:Label>
                        <asp:DataList ID="lstCourses" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                            <AlternatingItemStyle BackColor="#F7F7F7" />
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <ItemStyle BackColor="#E2E9E3" ForeColor="#4A3C8C" />
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td width="10%">
                                            <asp:CheckBox ID="chkCourse" runat="server" Text='<%# Eval("CourseID") %>'></asp:CheckBox>
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblCourseCode" runat="server" Text='<%# Eval("CourseCode") %>'></asp:Label>
                                        </td>
                                        <td width="60%">
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
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <table class="style1">
                            <tr>
                                <td align="right" width="80%">
                                    <asp:DropDownList ID="lstCourseType" runat="server" OnLoad="lstCourseType_Load" OnSelectedIndexChanged="lstCourseType_SelectedIndexChanged">
                                        <asp:ListItem>Work Load</asp:ListItem>
                                        <asp:ListItem>Part Time</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Button ID="BtnOk" runat="server" Text="Ok" Width="66px" OnClick="BtnOk_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
