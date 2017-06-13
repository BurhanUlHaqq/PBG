<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefaultMenu.ascx.cs" Inherits="Menu" %>

<ul class="art-menu">
    <li><a href="Default.aspx" class="<% =GetClass("Default") %>" ><span class="l"></span><span class="r"></span><span class="t">Home</span></a></li>
    <li><a href="Department.aspx" class="<% =GetClass("Department") %>"><span class="l"></span><span class="r"></span><span class="t">Department</span></a></li>
    <li><a href="Downloads.aspx" class="<% =GetClass("Download") %>" ><span class="l"></span><span class="r"></span><span class="t">Form Download</span></a></li>
    <li><a href="News.aspx" class="<% =GetClass("News") %>" ><span class="l"></span><span class="r"></span><span class="t">News</span></a></li>
    <li><a href="Contacts.aspx" class="<% =GetClass("Contacts") %>" ><span class="l"></span><span class="r"></span><span class="t">Contacts List</span></a></li>
    <li><a href="Services.aspx" class="<% =GetClass("Services") %>" ><span class="l"></span><span class="r"></span><span class="t">Services</span></a></li>
    <li><a href="Faculty.aspx" class="<% =GetClass("Faculty") %>" ><span class="l"></span><span class="r"></span><span class="t">Faculty</span></a></li>
    <li><a href="Messages.aspx" class="<% =GetClass("Messages") %>" ><span class="l"></span><span class="r"></span><span class="t">Messages</span></a></li>
</ul>
