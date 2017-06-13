<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="Contacts.aspx.cs" Inherits="Contacts" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

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
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="fullSheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artContacts" runat="server" Caption="Contacts" meta:resourcekey="artContactsResource1">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:GridView ID="grdContacts" runat="server" meta:resourcekey="grdContactsResource1"
                            Width="60%" AutoGenerateColumns="False" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="ContactTitle" HeaderText="Name">
                                    <ItemStyle Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Telephone" HeaderText="Phone">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
