<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master"
    AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Admin_Admin_Services" %>

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
    <script type="text/jscript" src="custom.js"></script>
    <artisteer:Article ID="artServices" runat="server" Caption="Services">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%">
                            <tr>
                                <td align="right">
                                    <strong>Service Name:</strong><asp:RequiredFieldValidator ID="ServiceName" runat="server" ControlToValidate="txtServiceName"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtServiceName" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <strong>Description:</strong>
                                    <asp:RequiredFieldValidator ID="Description" runat="server" ControlToValidate="txtServiceDetails"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtServiceDetails" runat="server" TextMode="MultiLine" Width="300px"
                                        Height="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Image:</strong><asp:RequiredFieldValidator ID="ServiceImage" runat="server" ControlToValidate="fulServiceImage"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    <asp:FileUpload ID="fulServiceImage" Width="306px" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                                        <asp:Button ID="cmdSave" CssClass="art-button" runat="server" Text="Save" OnClick="cmdSave_Click" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:GridView ID="grdServices" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                        CellPadding="4" ForeColor="#333333">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="ServiceName" HeaderText="ServiceName" />
                                            <asp:BoundField DataField="ServiceCreateDateTime" HeaderText="Created Date Time" />
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnEdit" runat="server" AlternateText="Edit" Height="24px" Width="24px"
                                                                    CommandArgument='<%# Eval("ServiceID") %>'  CommandName="Edit"
                                                                    ImageUrl="~/Admin/Admin/images/file_edit.png" CausesValidation="False" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="Delete" Height="24px" CommandName="Del"
                                                                    Width="24px" CommandArgument='<%# Eval("ServiceID") %>' OnClientClick="return confirm('Sure to delete');"
                                                                    ImageUrl="~/Admin/Admin/images/dd.png" CausesValidation="False" />
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
