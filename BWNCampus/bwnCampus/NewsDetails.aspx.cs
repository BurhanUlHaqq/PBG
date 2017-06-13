using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        artNewsDetails.DataBind();
        int intNewsID = Convert.ToInt32(Request.QueryString["NewsID"]);
        DataList lstNewsImages = (DataList)artNewsDetails.ContentPlaceholder.Controls[0].Controls[5];
        DataTable dtNews = new DataTable();
        dtNews = LogicKernal.Images.GetImagesByNewsID(intNewsID);
        lstNewsImages.DataSource = dtNews;
        lstNewsImages.DataBind();
        Label lblNewsTitle = (Label)artNewsDetails.ContentPlaceholder.Controls[0].Controls[1];
        Literal ltrNewsDetails = (Literal)artNewsDetails.ContentPlaceholder.Controls[0].Controls[3];
        dtNews = new DataTable();
        dtNews = LogicKernal.News.GetNewsByID(intNewsID);
        lblNewsTitle.Text = dtNews.Rows[0]["NewsTitle"].ToString();
        ltrNewsDetails.Text = dtNews.Rows[0]["NewsDetails"].ToString();
    }    
}
