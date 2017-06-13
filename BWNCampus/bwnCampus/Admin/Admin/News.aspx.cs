using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Admin_News : System.Web.UI.Page
{
    TextBox txtNewsTitle = new TextBox();
    TextBox txtDetails = new TextBox();
    TextBox txtImageTitle1 = new TextBox();
    FileUpload imgImageUpload1 = new FileUpload();
    TextBox txtImageTitle2 = new TextBox();
    FileUpload imgImageUpload2 = new FileUpload();
    TextBox txtImageTitle3 = new TextBox();
    FileUpload imgImageUpload3 = new FileUpload();
    TextBox txtImageTitle4 = new TextBox();
    FileUpload imgImageUpload4 = new FileUpload();
    TextBox txtImageTitle5 = new TextBox();
    FileUpload imgImageUpload5 = new FileUpload();
    Button cmdSave = new Button();
    Label lblMessage = new Label();

    private BusinessEntities.Images objNewsImage;

    protected void Page_Load(object sender, EventArgs e)
    {
        artNews.DataBind();

        if (Session["UserID"] == null)
            Response.Redirect("Login.aspx");
        foreach (Control ctrl in artNews.ContentPlaceholder.Controls[0].Controls)
        {
            if (!Page.IsPostBack)
            {
                if (ctrl is Button)
                {
                    Button cmdSave = (Button)ctrl;
                    cmdSave.Click += new EventHandler(cmdSave_Click);
                }//ctrl button
            }
            if (ctrl is TextBox)
            {

                if (ctrl.ID == "txtNewsTitle")
                    txtNewsTitle = (TextBox)ctrl;

                if (ctrl.ID == "txtDetails")
                    txtDetails = (TextBox)ctrl;

                if (ctrl.ID == "txtImageTitle1")
                    txtImageTitle1 = (TextBox)ctrl;

                if (ctrl.ID == "txtImageTitle2")
                    txtImageTitle2 = (TextBox)ctrl;

                if (ctrl.ID == "txtImageTitle3")
                    txtImageTitle3 = (TextBox)ctrl;

                if (ctrl.ID == "txtImageTitle4")
                    txtImageTitle4 = (TextBox)ctrl;

                if (ctrl.ID == "txtImageTitle5")
                    txtImageTitle5 = (TextBox)ctrl;
            }//ctrl is textbox

            if (ctrl is FileUpload)
            {

                if (ctrl.ID == "imgImageUpload1")
                    imgImageUpload1 = (FileUpload)ctrl;

                if (ctrl.ID == "imgImageUpload2")
                    imgImageUpload2 = (FileUpload)ctrl;

                if (ctrl.ID == "imgImageUpload3")
                    imgImageUpload3 = (FileUpload)ctrl;

                if (ctrl.ID == "imgImageUpload4")
                    imgImageUpload4 = (FileUpload)ctrl;

                if (ctrl.ID == "imgImageUpload5")
                    imgImageUpload5 = (FileUpload)ctrl;
            }//ctrl file upload

            if (ctrl is Label)
                lblMessage = (Label)ctrl;
        }//end for each

        GridView grdNews = new GridView();

        artNews.DataBind();
        foreach (Control ctrl in artNews.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is GridView)
            {
                DataSet dsNews = new DataSet();
                DataKernal.News objNews = new DataKernal.News();
                dsNews = objNews.SelectNews();
                GridView News = (GridView)ctrl;
                News.DataSource = dsNews;
                News.DataBind();
                News.RowCommand += new GridViewCommandEventHandler(News_RowCommand);
            }
        }
        if(!Page.IsPostBack)
        {
           if(Request.QueryString["NewsID"] != null )
           {
               int intNews = Convert.ToInt32(Request.QueryString["NewsID"]);
               DataTable dtNews = new DataTable();
               dtNews = LogicKernal.News.GetNewsByID(intNews);
               if (dtNews.Rows.Count > 0)
               {
                   txtNewsTitle.Text = dtNews.Rows[0]["NewsTitle"].ToString();
                   txtDetails.Text = dtNews.Rows[0]["NewsDetails"].ToString();
               }

           }
        }
    }//
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        int intNewsID = 0;
        if(Request.QueryString["NewsID"]!=null)

        intNewsID= Convert .ToInt32(Request.QueryString["NewsID"]);

        int intUserID = Convert.ToInt32(Session["UserID"]);

        BusinessEntities.News objNews = new BusinessEntities.News();
        objNews.NewsID = intNewsID;
        objNews.NewsTitle = txtNewsTitle.Text;
        objNews.NewsDetails = txtDetails.Text;
        objNews.CreatedByUserID = intUserID;
        objNews.CreateDateTime = System.DateTime.Now.Date;

        intNewsID = LogicKernal.News.InsertUpdateNews(objNews);
        if (intNewsID > 0)
        {
            if (imgImageUpload1.FileName != string.Empty)
            {
                if (System.IO.File.Exists(Server.MapPath("../../newsImages/" + imgImageUpload1.FileName)))
                {
                    System.IO.File.Delete(Server.MapPath("../../newsImages/" + imgImageUpload1.FileName));
                }
                imgImageUpload1.SaveAs(Server.MapPath("../../newsImages/" + imgImageUpload1.FileName));
                string strFileName1 = "newsImages/" + imgImageUpload1.FileName;
                BusinessEntities.Images objNewsImage1 = new BusinessEntities.Images();
                objNewsImage1.ImagesTitle = txtImageTitle1.Text;
                objNewsImage1.ImageFilePath = strFileName1;
                objNewsImage1.ImagesDetails = "";
                objNewsImage1.ImagesCreatedByUserID = intUserID;
                objNewsImage1.ImagesCreateDateTime = System.DateTime.Now.Date;
                objNewsImage1.ImagesNewsID = intNewsID;

                int intNewsImageID = LogicKernal.Images.InsertUpdateImages(objNewsImage1);
            }
            if (imgImageUpload2.FileName != string.Empty)
            {
                imgImageUpload2.SaveAs(Server.MapPath("../../newsImages/" + imgImageUpload2.FileName));
                string strFileName2 = "newsImages/" + imgImageUpload2.FileName;
                BusinessEntities.Images objNewsImage2 = new BusinessEntities.Images();
                objNewsImage2.ImagesTitle = txtImageTitle2.Text;
                objNewsImage2.ImageFilePath = strFileName2;
                objNewsImage2.ImagesDetails = "";
                objNewsImage2.ImagesCreatedByUserID = intUserID;
                objNewsImage2.ImagesCreateDateTime = System.DateTime.Now.Date;
                objNewsImage2.ImagesNewsID = intNewsID;
                int intNewsImageID = LogicKernal.Images.InsertUpdateImages(objNewsImage2);
            }

            if (imgImageUpload3.FileName != string.Empty)
            {
                imgImageUpload3.SaveAs(Server.MapPath("../../newsImages/" + imgImageUpload3.FileName));
                string strFileName3 = "newsImages/" + imgImageUpload3.FileName;
                BusinessEntities.Images objNewsImage3 = new BusinessEntities.Images();
                objNewsImage3.ImagesTitle = txtImageTitle3.Text;
                objNewsImage3.ImageFilePath = strFileName3;
                objNewsImage3.ImagesDetails = "";
                objNewsImage3.ImagesCreatedByUserID = intUserID;
                objNewsImage3.ImagesCreateDateTime = System.DateTime.Now.Date;
                objNewsImage3.ImagesNewsID = intNewsID;
                int intNewsImageID = LogicKernal.Images.InsertUpdateImages(objNewsImage3);
            }

            if (imgImageUpload4.FileName != string.Empty)
            {
                imgImageUpload4.SaveAs(Server.MapPath("../../newsImages/" + imgImageUpload4.FileName));
                string strFileName4 = "newsImages/" + imgImageUpload4.FileName;
                BusinessEntities.Images objNewsImage4 = new BusinessEntities.Images();
                objNewsImage4.ImagesTitle = txtImageTitle4.Text;
                objNewsImage4.ImageFilePath = strFileName4;
                objNewsImage4.ImagesDetails = "";
                objNewsImage4.ImagesCreatedByUserID = intUserID;
                objNewsImage4.ImagesCreateDateTime = System.DateTime.Now.Date;
                objNewsImage4.ImagesNewsID = intNewsID;
                int intNewsImageID = LogicKernal.Images.InsertUpdateImages(objNewsImage4);
            }

            if (imgImageUpload5.FileName != string.Empty)
            {
                imgImageUpload5.SaveAs(Server.MapPath("../../newsImages/" + imgImageUpload5.FileName));
                string strFileName5 = "newsImages/" + imgImageUpload5.FileName;
                BusinessEntities.Images objNewsImage5 = new BusinessEntities.Images();
                objNewsImage5.ImagesTitle = txtImageTitle5.Text;
                objNewsImage5.ImageFilePath = strFileName5;
                objNewsImage5.ImagesDetails = "";
                objNewsImage5.ImagesCreatedByUserID = intUserID;
                objNewsImage5.ImagesCreateDateTime = System.DateTime.Now.Date;
                objNewsImage5.ImagesNewsID = intNewsID;
                int intNewsImageID = LogicKernal.Images.InsertUpdateImages(objNewsImage5);
            }

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Record entered successfully";
            txtNewsTitle.Text = string.Empty;
            txtDetails.Text = string.Empty;
            txtImageTitle1.Text = string.Empty;
            txtImageTitle2.Text = string.Empty;
            txtImageTitle3.Text = string.Empty;
            txtImageTitle4.Text = string.Empty;
            txtImageTitle5.Text = string.Empty;
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "There is some problem in record entry";
        }
    }

    private void News_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int intNewsID = Convert.ToInt32(e .CommandArgument);

        if(e.CommandName  == "Del")
             LogicKernal .News.DeleteNews(intNewsID);
         else if(e.CommandName  == "Edit")
            Response .Redirect ("~/Admin/Admin/News.aspx?NewsID=" + intNewsID.ToString());
    }
}
