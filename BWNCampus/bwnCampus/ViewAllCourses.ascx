<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewAllCourses.ascx.cs" Inherits="ViewAllCourses" %>
    <asp:GridView ID="gvShowCourses" runat="server" AutoGenerateColumns="False" 
        BackColor="#DEE8E6" CellPadding="4" EnableModelValidation="True" 
        ForeColor="#333333" GridLines="None" Width="100%" 
    EmptyDataText="Nothing is Selected for this Program in this Department">
        <AlternatingRowStyle BackColor="#F7F7F7" BorderStyle="None" />
        <Columns>
            <asp:BoundField DataField="CourseCode" HeaderText="Course Code">
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="CourseName" HeaderText="Subject Title" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="CourseClass" HeaderText="Class" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="CourseTeacher" HeaderText="Teacher" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#82ACB3" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#DEE8E6" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#DEE8E6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#DEE8E6" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>

    


