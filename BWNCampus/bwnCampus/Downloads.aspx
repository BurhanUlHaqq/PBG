<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeFile="Downloads.aspx.cs" Inherits="Downloads" %>

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
    <artisteer:Article ID="artDownloads" Caption="Downloads" runat="server">
        <ContentTemplate>
            <div>
                <asp:DataList ID="lstDownloads" runat="server" Width="100%">
                    <ItemTemplate>
                        <table width="100%" cellpadding="5px" border="0px">
                            <tr>
                                <td align="center" rowspan= "2" width ="50px" valign= "middle" >
                                    <asp:Image ID="imgIcon" runat="server" Height="48px" ImageUrl='<%# Eval("DownloadIconPath") %>'
                                        Width="48px" />
                                </td>
                                <td align ="left" ><b>
                                    <asp:LinkButton ID="lstDownloads" runat="server"
                                    CommandArgument='<%# Eval("DownloadFilePath") %>' 
                                    Text='<%# Eval("DownloadTitle") %>' CommandName ="Download"></asp:LinkButton></b>
                                </td>
                            </tr>
                            <tr>
                                <td align ="left" >
                                   <asp:Label ID="lblDescription" runat="server" 
                                    Text='<%# Eval("DownloadDetail") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
