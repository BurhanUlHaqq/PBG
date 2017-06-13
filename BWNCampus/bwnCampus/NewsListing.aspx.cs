using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsListing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        artNewsList.DataBind();
        DataList lstNews = (DataList)artNewsList.ContentPlaceholder.Controls[0].Controls[1];
        DataTable dtNews = new DataTable();
        dtNews = LogicKernal.News.GetAllNews();
        lstNews.DataSource = dtNews;
        lstNews.DataBind();
        lstNews.ItemCommand += new DataListCommandEventHandler(lstNews_ItemCommand);
    }

    private void lstNews_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        if (e.CommandName == "NewsDetails")
            Response.Redirect("NewsDetails.aspx?NewsID=" + e.CommandArgument.ToString());
    }
}
