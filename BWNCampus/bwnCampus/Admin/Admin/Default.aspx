<%@ Page Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Import Namespace="Artisteer" %>
<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    Page title here...
</asp:Content>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
    <art:DefaultHeader ID="DefaultHeader" runat="server" />
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="SheetContent" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="Article1" Caption="Welcome" runat="server">
        <ContentTemplate>
            <img class="art-article" src="images/VS.png" alt="an image" style="float: left; border: 0;
                margin: 1em 1em 0 0;" />
            <p>
                Lorem ipsum dolor sit amet, <a href="javascript:void(0)" title="link">link</a>,
                <a class="visited" href="javascript:void(0)" title="visited link">visited link</a>,
                <a class="hover" href="javascript:void(0)" title="hovered link">hovered link</a>
                consectetuer adipiscing elit. Quisque sed felis. Aliquam sit amet felis. Mauris
                semper, velit semper laoreet dictum, quam diam dictum urna, nec placerat elit nisl
                in quam. Etiam augue pede, molestie eget, rhoncus at, convallis ut, eros.</p>
            <p>
                <span class="art-button-wrapper"><span class="l"></span><span class="r"></span><a
                    class="art-button" href="javascript:void(0)">Read more...</a> </span>
            </p>
            <table class="table" width="100%">
                <tr>
                    <td width="33%" valign="top">
                        <div class="art-Block">
                            <div class="art-Block-body">
                                <div class="art-BlockHeader">
                                    <div class="l">
                                    </div>
                                    <div class="r">
                                    </div>
                                    <div class="t">
                                        <center>
                                            Support</center>
                                    </div>
                                </div>
                                <div class="art-BlockContent">
                                    <div class="art-PostContent">
                                        <img src="images/01.png" width="55px" height="55px" alt="an image" style="margin: 0 auto;
                                            display: block; border: 0" />
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Quisque sed felis. Aliquam
                                            sit amet felis. Mauris semper, velit semper laoreet dictum, quam diam dictum urna.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td width="33%" valign="top">
                        <div class="art-Block">
                            <div class="art-Block-body">
                                <div class="art-BlockHeader">
                                    <div class="l">
                                    </div>
                                    <div class="r">
                                    </div>
                                    <div class="t">
                                        <center>
                                            Development</center>
                                    </div>
                                </div>
                                <div class="art-BlockContent">
                                    <div class="art-PostContent">
                                        <img src="images/02.png" width="55px" height="55px" alt="an image" style="margin: 0 auto;
                                            display: block; border: 0" />
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Quisque sed felis. Aliquam
                                            sit amet felis. Mauris semper, velit semper laoreet dictum, quam diam dictum urna.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td width="33%" valign="top">
                        <div class="art-Block">
                            <div class="art-Block-body">
                                <div class="art-BlockHeader">
                                    <div class="l">
                                    </div>
                                    <div class="r">
                                    </div>
                                    <div class="t">
                                        <center>
                                            Strategy</center>
                                    </div>
                                </div>
                                <div class="art-BlockContent">
                                    <div class="art-PostContent">
                                        <img src="images/03.png" width="55px" height="55px" alt="an image" style="margin: 0 auto;
                                            display: block; border: 0" />
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Quisque sed felis. Aliquam
                                            sit amet felis. Mauris semper, velit semper laoreet dictum, quam diam dictum urna.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
    <artisteer:Article ID="Article2" Caption="Text, &amp;amp;lt;a href=&amp;amp;quot;#&amp;amp;quot; rel=&amp;amp;quot;bookmark&amp;amp;quot; title=&amp;amp;quot;Permanent Link to this Post&amp;amp;quot;&amp;amp;gt;Link&amp;amp;lt;/a&amp;amp;gt;, &amp;amp;lt;a class=&amp;amp;quot;visited&amp;amp;quot; href=&amp;amp;quot;#&amp;amp;quot; rel=&amp;amp;quot;bookmark&amp;amp;quot; title=&amp;amp;quot;Visited Hyperlink&amp;amp;quot;&amp;amp;gt;Visited&amp;amp;lt;/a&amp;amp;gt;, &amp;amp;lt;a class=&amp;amp;quot;hovered&amp;amp;quot; href=&amp;amp;quot;#&amp;amp;quot; rel=&amp;amp;quot;bookmark&amp;amp;quot; title=&amp;amp;quot;Hovered Hyperlink&amp;amp;quot;&amp;amp;gt;Hovered&amp;amp;lt;/a&amp;amp;gt;"
        runat="server">
        <ContentTemplate>
            <p>
                Lorem <sup>superscript</sup> dolor <sub>subscript</sub> amet, consectetuer adipiscing
                elit, <a href="#" title="test link">test link</a>. Nullam dignissim convallis est.
                Quisque aliquam. <cite>cite</cite>. Nunc iaculis suscipit dui. Nam sit amet sem.
                Aliquam libero nisi, imperdiet at, tincidunt nec, gravida vehicula, nisl. Praesent
                mattis, massa quis luctus fermentum, turpis mi volutpat justo, eu volutpat enim
                diam eget metus. Maecenas ornare tortor. Donec sed tellus eget sapien fringilla
                nonummy. <acronym title="National Basketball Association">NBA</acronym> Mauris a
                ante. Suspendisse quam sem, consequat at, commodo vitae, feugiat in, nunc. Morbi
                imperdiet augue quis tellus.
                <abbr title="Avenue">
                    AVE</abbr></p>
            <h1>
                Heading 1</h1>
            <h2>
                Heading 2</h2>
            <h3>
                Heading 3</h3>
            <h4>
                Heading 4</h4>
            <h5>
                Heading 5</h5>
            <h6>
                Heading 6</h6>
            <blockquote>
                <p>
                    &#8220;This stylesheet is going to help so freaking much.&#8221;
                    <br />
                    -Blockquote
                </p>
            </blockquote>
            <br />
            <table class="art-article" border="0" cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <th>
                            Header
                        </th>
                        <th>
                            Header
                        </th>
                        <th>
                            Header
                        </th>
                    </tr>
                    <tr>
                        <td>
                            Data
                        </td>
                        <td>
                            Data
                        </td>
                        <td>
                            Data
                        </td>
                    </tr>
                    <tr class="even">
                        <td>
                            Data
                        </td>
                        <td>
                            Data
                        </td>
                        <td>
                            Data
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data
                        </td>
                        <td>
                            Data
                        </td>
                        <td>
                            Data
                        </td>
                    </tr>
                </tbody>
            </table>
            <p>
                <span class="art-button-wrapper"><span class="l"></span><span class="r"></span><a
                    class="art-button" href="javascript:void(0)">Join&nbsp;Now!</a> </span>
            </p>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
