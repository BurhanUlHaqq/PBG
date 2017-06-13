<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefaultSidebar1.ascx.cs" Inherits="DefaultSidebar1" %>
<%@ Import Namespace="Artisteer" %>
<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<artisteer:Block ID="NewsBlock" Caption="Latest News" runat="server">
    <ContentTemplate>
    </ContentTemplate>
</artisteer:Block>
<artisteer:Block ID="HighlightsBlock" Caption="Highlights" runat="server">
    <ContentTemplate>
        <asp:DataList ID="lstNews" runat="server" Width="100%">
            <ItemTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblNewsTitle" runat="server" Text='<%# Eval("NewsTitle") %>'></asp:Label>
                            <asp:Label ID="lblNewsID" runat="server" Text='<%# Eval("NewsID") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDetails" runat="server" Text='<%# Eval("NewsDetails") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:LinkButton ID="lnkReadMore" runat="server" CommandArgument='<%# Eval("NewsID") %>'>Read more...</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date:
                            <asp:Label ID="lblDateCreated" runat="server" Text='<%# Eval("CreateDateTime") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </ContentTemplate>
</artisteer:Block>
<artisteer:Block ID="ContactInformationBlock" Caption="Contact Info" runat="server">
    <ContentTemplate>
        <div>
            <img src="images/contact.jpg" alt="an image" style="margin: 0 auto; display: block;
                width: 95%" />
            <br />
            <b>Company Co.</b>
            <br />
            Las Vegas, NV 12345<br />
            Email: <a href="mailto:info@company.com">info@company.com</a><br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Phone: (123) 456-7890
            <br />
            Fax: (123) 456-7890
        </div>
    </ContentTemplate>
</artisteer:Block>
