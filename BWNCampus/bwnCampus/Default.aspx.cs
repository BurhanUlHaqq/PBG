using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        artNews.DataBind();
        DataList lstNews = (DataList)artNews.ContentPlaceholder.Controls[0].Controls[1];
        DataTable dtNews = new DataTable();
        dtNews = LogicKernal.News.GetTopNews(5);
        lstNews.DataSource = dtNews;
        lstNews.DataBind();
        lstNews.ItemCommand += new DataListCommandEventHandler(lstNews_ItemCommand);
        
    }

    protected void lstNews_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ReadMore")
            Response.Redirect("NewsDetails.aspx?NewsID=" + e.CommandArgument.ToString());
    }
}
