<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Admin_Admin_News" %>

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
<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <script type="text/jscript" ss="custom"></script>
    <artisteer:Article ID="artNews" runat="server" Caption="News">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%" border="0px">
                            <tr>
                                <td align="right">
                                    <strong>News Title:</strong><asp:RequiredFieldValidator ID="NewsTitle" runat="server" ControlToValidate="txtNewsTitle"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtNewsTitle" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" style="font-weight: 700">
                                    Details:<asp:RequiredFieldValidator ID="Details" runat="server" ControlToValidate="txtDetails"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" Width="300px" Height="300px"></asp:TextBox>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtImageTitle1" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="right">
                                    <asp:FileUpload ID="imgImageUpload1" runat="server" Width="306px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtImageTitle2" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:FileUpload ID="imgImageUpload2" runat="server" Width="306px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtImageTitle3" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:FileUpload ID="imgImageUpload3" runat="server" Width="306px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtImageTitle4" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:FileUpload ID="imgImageUpload4" runat="server" Width="306px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtImageTitle5" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:FileUpload ID="imgImageUpload5" runat="server" Width="306px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdSave" runat="server" CssClass="art-button" OnClick="cmdSave_Click"
                                            Text="Save" />
                                    </span>
                                </td>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:GridView ID="grdNews" runat="server" AutoGenerateRows="False" CellPadding="4"
                                        EnableModelValidation="True" ForeColor="#333333" Width="100%" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <%--<asp:ImageField ControlStyle-Width="50px" DataImageUrlField="ImageFilePath" HeaderText="News Image">
                                                <ControlStyle Width="50px" />
                                            </asp:ImageField>--%>
                                            <asp:BoundField DataField="NewsTitle" HeaderText="News Title" />
                                            <asp:BoundField DataField="CreateDateTime" HeaderText="Create Date Time" />
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <table class="style1">
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                                                    CommandArgument='<%# Eval("NewsID") %>' Height="24px" Width="24px" CausesValidation="False"
                                                                    ImageUrl="~/Admin/Admin/images/file_edit.png" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Delete" CommandName="Del"
                                                                    OnClientClick="return confirm('Sure To Delete');" CommandArgument='<%# Eval("NewsID") %>'
                                                                    CausesValidation="False" Height="24px" ImageUrl="~/Admin/Admin/images/dd.png"
                                                                    Width="24px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
