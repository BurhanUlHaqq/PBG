<%@ Page Language="C#" MasterPageFile="~/design/MasterPage.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Import Namespace="Artisteer" %>
<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    The Islamia University of Bahawalpur, Bahawalnagar Campus
</asp:Content>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
    <art:DefaultHeader ID="DefaultHeader" runat="server" />
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="news" runat="server" ContentPlaceHolderID="Sidebar1ContentPlaceHolder">
    <artisteer:Article ID="artDirectorMessage" Width="250px" Caption="Director Message"
        runat="server">
        <ContentTemplate>
            <table width="100%" border="0px">
                <tr>
                    <td valign="top">
                        Throughout its history, the Islamia University of Bahawalpur offered its students
                        undergraduate and post graduate education
                        <br />
                        <asp:HyperLink ID="lnkReadMore" runat="server">Read more...</asp:HyperLink>
                    </td>
                    <td width="85px" valign="top" align="center">
                        <img alt="VC" src="profileImages/vc.jpg" width="75px" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
    <artisteer:Article ID="artNews" Width="250px" Caption="Latest news" runat="server">
        <ContentTemplate>
            <asp:DataList ID="lstNews" runat="server" Width="100%" EnableViewState="true" OnItemCommand="lstNews_ItemCommand">
                <ItemTemplate>
                    <table width="100%">
                        <tr>
                            <td>
                                <b>
                                    <asp:LinkButton ID="lnknesTitle" runat="server" CommandName="ReadMore" CommandArgument='<%# Eval("NewsID") %>'
                                        Text='<%# Eval("NewsTitle") %>'>LinkButton</asp:LinkButton></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDetails" runat="server" Text='<%# Eval("NewsDetails") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lnkReadMore" runat="server" CommandName="ReadMore" CommandArgument='<%# Eval("NewsID") %>'>Read more...</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="sSeprater">
                                Date:
                                <asp:Label ID="lblDateCreated" runat="server" Text='<%# Eval("CreateDateTime") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
<asp:Content ID="SheetContent" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="artIntro" Caption="Introduction of Bahawalnagar Campus" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="3px">
                <tr>
                    <td>
                        <p>
                            Throughout its history, the Islamia University of Bahawalpur offered its students
                            undergraduate and post graduate education characterized by breadth and flexibility,
                            under pinned by academic excellence. Graduates from this University are expected
                            to display imagination, quick-thinking and intellectual discipline; qualities that
                            fit in well with the aims of National Educational Policy.
                        </p>
                        <p>
                            The University is driving the process of knowledge transfer, business development
                            & technology enhancement into the heart of the economy of Southern Punjab. The University
                            is also helping to meet the need for highly trained individuals, scholars and researchers
                            throughout the country.
                        </p>
                        <p>
                            The IUB is not an ivory tower but is fully engaged to drive the regional economy
                            and society. The talented students will not only graduate in an increasingly multi-national,
                            multi-cultural, and multi-ethnic world, but will also be enterprising, creative
                            and innovative.
                        </p>
                        <p>
                            The University is enabling students to develop and apply their subject-based skills
                            in an international arena and an exchange program is enabling students to undertake
                            work experience in highly professional institutes, giving them transferable skills.
                            Performance indicators show that 85% of graduates from the University are in employment
                            or studying further and also serving at the government-set benchmarks.
                        </p>
                        <p>
                            I am pleased to say that students of this University have enjoyed many recent accomplishments
                            and look to the future with enthusiasm and confidence.
                        </p>
                        <p>
                            So pat yourself on the back. You are now a part of this highly prestigious University
                            having focus on excellence. My most important message to you is that you should
                            have high dreams to fulfill and greater heights to search and reach.
                        </p>
                    </td>
                    <td width="100px" align="center" valign="top">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ScriptIncludePlaceHolder">
    <script type="text/javascript" src="<%= ResolveUrl("~/script.js") %>"></script>
</asp:Content>
