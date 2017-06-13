<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="Services.aspx.cs" Inherits="Services" %>

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
<asp:Content ID="Content5" ContentPlaceHolderID="fullSheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artlstServices" runat="server" Caption="Services">
        <ContentTemplate>
        <asp:DataList ID="lstServicesList" runat="server">
        <ItemTemplate>
            <table width="100%" cellpadding="5Px" border="0px">
                <tr>
                    <td align="center" rowspan="2" width="48px" valign="middle">
                        <asp:Image ID="imgServiceImageFilePath" runat="server"
                         Width="48px" hight="48px" ImageUrl='<%# Eval("ServiceImageFilePath") %>' />
                    </td>
                    <td align="left">
                        <asp:LinkButton ID="ServiceName" runat="server"
                         CommandArgument='<%#Eval("ServiceID") %>'
                            Text='<%# Eval("ServiceName") %>' CommanName ="ServiceDetails"></asp:LinkButton>
                    </td>
                     </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblServiceDetails" runat="server" Text='<%# Eval("ServiceDetail") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    </ContentTemplate>
    </artisteer:Article>
    </asp:Content>

