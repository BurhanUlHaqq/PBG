<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefaultMenu.ascx.cs" Inherits="Menu" %>
<ul class="art-menu">
    <li><a href="Default.aspx" class="<% =GetClass("Default") %>"><span class="l"></span><span class="r"></span><span class="t">Home</span></a></li>
    <li><a href="DepartmentList.aspx" class="<% =GetClass("DepartmentList") %>"><span class="l"></span><span class="r"></span><span class="t">Department</span></a></li>
    <li><a href="Downloads.aspx" class="<% =GetClass("Downloads") %>"><span class="l"></span><span class="r"></span><span class="t">Download</span></a></li>
    <li><a href="NewsListing.aspx" class="<% =GetClass("NewsListing") %>"><span class="l"></span><span class="r"></span><span class="t">News</span></a></li>
    <li><a href="Contacts.aspx" class="<% =GetClass("Contacts") %>"><span class="l"></span><span class="r"></span><span class="t">Contacts</span></a></li>
    <li><a href="Services.aspx" class="<% =GetClass("Services") %>"><span class="l"></span><span class="r"></span><span class="t">Services</span></a></li>
    <li><a href="ContactUs.aspx" class="<% =GetClass("ContactUs") %>"><span class="l"></span><span class="r"></span><span class="t">Contact Us</span></a></li>
    <%--<li><a href="AboutUs.aspx" class="<% =GetClass("AboutUs") %>"><span class="l"></span><span class="r"></span><span class="t">About Us</span></a></li>--%>
</ul>
