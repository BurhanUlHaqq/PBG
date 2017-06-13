<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="DepartmentList.aspx.cs" Inherits="DepartmentList" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
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
<asp:Content ID="Content6" ContentPlaceHolderID="fullSheetContentPlaceHolder" runat="Server">
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
        Departments
    </h2>
    <asp:DataList ID="lstDepartmentList" runat="server" OnItemCommand="lstDepartmentList_ItemCommand">
        <ItemTemplate>
            <table width="100%" cellpadding="5px" border="0px">
                <tr>
                    <td align="center" rowspan="2" width="50px" valign="top">
                        <asp:Image ID="imgLogo" runat="server" Height="48px" ImageUrl='<%# Eval("DepartmentLogoImagePath") %>'
                            Width="48px" />
                    </td>
                    <td align="left">
                        <b>
                            <asp:LinkButton ID="lstDepartmentList" runat="server" CommandArgument='<%# Eval("DepartmentID") %>'
                                Text='<%# Eval("DepartmentName") %>' CommandName="DepartmentDetails"></asp:LinkButton></b>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblDepartmentDescription" runat="server" Text='<%# ShortDesc(Eval("DepartmentDescription")) %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <div align="center">
        <asp:LinkButton ID="btnShowVisiting" runat="server" Font-Size="Small" OnClick="btnShowVisiting_Click">Show Visiting Faculty</asp:LinkButton>
    </div>
    <asp:Panel ID="panalVisitingContainer" runat="server" Height="400px" Visible="False"
        ScrollBars="Auto">
            <asp:DataList ID="listAllVisitingFaculty" runat="server" BackColor="#E3EAEB" BorderColor="#E7E7FF"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                GridLines="Horizontal" OnEditCommand="listAllVisitingFaculty_EditCommand"
                OnCancelCommand="listAllVisitingFaculty_CancelCommand" Width="100%">
                <AlternatingItemStyle BackColor="White" />
                <EditItemTemplate>
                    <table class="style1" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Text="Name"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Gander"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" Text="CNIC"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" Text="Qualification"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" Text="Cell No"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" Text="E-Mail"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" Text="Added By"></asp:Label>
                            </td>
                            <td rowspan="2" width="60px">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Cancel">Hide Details</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblVisitingNameDetail" runat="server" Text='<%# Eval("VisitingName") %>'
                                    Font-Size="Small" ForeColor="Black" Font-Bold="True" Font-Names="Arial"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVisitingGanderDetail" runat="server" Text='<%# Eval("VisitingGander") %>'
                                    Font-Size="Small" ForeColor="Black" Font-Bold="True" Font-Names="Arial"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVisitingCNICDetail" runat="server" Text='<%# Eval("VisitingCNIC") %>'
                                    Font-Size="Small" ForeColor="Black" Font-Bold="True" Font-Names="Arial"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVisitingQualigicationDetail" runat="server" Text='<%# Eval("VisitingQualification") %>'
                                    Font-Size="Small" ForeColor="Black" Font-Bold="True" Font-Names="Arial"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVisitingCellNoDetail" runat="server" Text='<%# Eval("VisitingCellNo") %>'
                                    Font-Size="Small" ForeColor="Black" Font-Bold="True" Font-Names="Arial"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVisitingEMailDetail" runat="server" Text='<%# Eval("VisitingEmail") %>'
                                    Font-Size="Small" ForeColor="Black" Font-Bold="True" Font-Names="Arial"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVisitingAddedByDetail" runat="server" Text='<%# Eval("AddedBy") %>'
                                    Font-Size="Small" ForeColor="Black" Font-Bold="True" Font-Names="Arial"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <ItemStyle BackColor="#E3EAEB" ForeColor="#4A3C8C" />
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblVisitingName" runat="server" Text='<%# Eval("VisitingName") %>'
                                    Font-Bold="True" Font-Size="Small"></asp:Label>
                                &nbsp;-
                                <asp:Label ID="lblVisitingQualification" runat="server" Text='<%# Eval("VisitingQualification") %>'
                                    Font-Bold="True" Font-Size="Small"></asp:Label>
                            </td>
                            <td width="65px">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit">Show Details</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            </asp:DataList>
    </asp:Panel>
            <div class="cleared">
            </div>
        </div>
    </div>
    
</asp:Content>
