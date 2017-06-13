<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="VisitingFaculty.aspx.cs" Inherits="Admin_Admin_VisitingFaculty" %>

<%@ Register src="DefaultMenu.ascx" tagname="DefaultMenu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
<uc1:DefaultMenu ID="DefaultMenu1" 
                    runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <table align="center" cellpadding="0" cellspacing="0" 
        style="font-size: small; font-weight: 700">
        <tr>
            <td align="center" class="style2" colspan="2">
                <strong>Insert New Visiting Faculty</strong>
            </td>
        </tr>
        <tr>
            <td align="right">
                Name:</td>
            <td>
                <asp:TextBox ID="newName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="newName" ErrorMessage="*" 
                    ValidationGroup="NewRecordGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Gander</td>
            <td>
                <asp:DropDownList ID="newGander" runat="server" Height="16px" Width="108px">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                CNIC:</td>
            <td>
                <asp:TextBox ID="newCNIC" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="newCNIC" ErrorMessage="*" 
                    ValidationGroup="NewRecordGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="newCNIC" ErrorMessage="Like This('xxxxx-xxxxxxx-x')" 
                    ValidationExpression="\d{5}-\d{7}-\d{1}" ValidationGroup="NewRecordGroup"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Qualification:</td>
            <td>
                <asp:TextBox ID="newQualification" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="newQualification" ErrorMessage="*" 
                    ValidationGroup="NewRecordGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Cell No:</td>
            <td>
                <asp:TextBox ID="newCellNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="newCellNo" ErrorMessage="*" 
                    ValidationGroup="NewRecordGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Email:</td>
            <td>
                <asp:TextBox ID="newEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="newEmail" ErrorMessage="*" 
                    ValidationGroup="NewRecordGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="newEmail" ErrorMessage="Invalid E-Mail" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="NewRecordGroup"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Added By:</td>
            <td>
                <asp:TextBox ID="newAddedBy" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="newAddedBy" ErrorMessage="*" 
                    ValidationGroup="NewRecordGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                    ValidationGroup="NewRecordGroup" />
&nbsp;
                <input id="Reset1" type="reset" value="reset" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    &nbsp;<strong><span class="style2">Available Visiting Faculty:</span></strong><br />
    <asp:DataList ID="dlVisitingList" runat="server" OnEditCommand="dlVisitingList_EditCommand"
        BackColor="Silver" Width="100%" OnCancelCommand="dlVisitingList_CancelCommand"
        OnDeleteCommand="dlVisitingList_DeleteCommand" 
        OnUpdateCommand="dlVisitingList_UpdateCommand">
        <AlternatingItemStyle BackColor="White" />
        <EditItemTemplate>
            <table class="style1" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text="ID" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="Small" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGander" runat="server" Font-Bold="True" Font-Size="Small" Text="Gander"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCNIC" runat="server" Font-Bold="True" Font-Size="Small" Text="CNIC"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblQualification" runat="server" Font-Bold="True" Font-Size="Small" Text="Qualification"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCellNo" runat="server" Font-Bold="True" Font-Size="Small" Text="Cell No"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Font-Size="Small" Text="E-Mail"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAddedBy" runat="server" Font-Bold="True" Font-Size="Small" Text="Added By"></asp:Label>
                    </td>
                    <td rowspan="2" width="100px" align="right">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" ForeColor="#0066FF">Update</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" OnClientClick ="return confirm('Do you realy want to delete this record?')" runat="server" CommandName="Delete" ForeColor="#CC0000">Delete</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Cancel" ForeColor="#003300">Cancel</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="UpdateID" runat="server" Text='<%# Eval("VisitingId") %>' 
                            Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="UpdateName" runat="server" Text='<%# Eval("VisitingName") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblGanderStatus" runat="server" Text='<%# Eval("VisitingGander") %>'></asp:Label>
                        <asp:DropDownList ID="UpdateGander" runat="server">
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="UpdateCNIC" runat="server" Text='<%# Eval("VisitingCNIC") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="UpdateQualification" runat="server" 
                            Text='<%# Eval("VisitingQualification") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="UpdateCellNo" runat="server" 
                            Text='<%# Eval("VisitingCellNo") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="UpdateEmail" runat="server" 
                            Text='<%# Eval("VisitingEmail") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="UpdateAddedBy" runat="server" Text='<%# Eval("AddedBy") %>'></asp:TextBox>
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
        <ItemTemplate>
            <table class="style1">
                <tr>
                    <td>
                        <asp:Label ID="Name" runat="server" Font-Size="Small" Text='<%# Eval("VisitingName") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Qualification" runat="server" Font-Size="Small" Text='<%# Eval("VisitingQualification") %>'></asp:Label>
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="lbEdit" runat="server" CommandName="edit">Edit</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    </asp:Content>
