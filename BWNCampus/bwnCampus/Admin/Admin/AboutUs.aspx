<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin/design/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Admin_Admin_AboutUs" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MenuContentPlaceHolder" Runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" Runat="Server">
    <artisteer:Article ID="artAboutUs" runat="server" Caption="About Us">
        <ContentTemplate>

       
        <table class="style2">
            <tr>
                <td><p>
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
            </tr>
        </table>
         </ContentTemplate>
    </artisteer:Article>
</asp:Content>

