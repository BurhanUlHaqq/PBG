using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ServiceDetails : System.Web.UI.Page
{
    Label lblServiceName = new Label();
    Label lblServiceDetail = new Label();
    Image imgImageFilePath = new Image();
    int intServiceID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            intServiceID = Convert.ToInt32(Request.QueryString["ServID"]);
        }
        artServiceDetails.DataBind();
        DataSet dsServices = new DataSet();
        DataKernal.Services objServices = new DataKernal.Services();
        dsServices = objServices.SelectServices(intServiceID);

        foreach (Control ctrl in artServiceDetails.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is Label)
            {
                if (ctrl.ID == "lblServiceName")
                    lblServiceName = (Label)ctrl;

                if (ctrl.ID == "lblServiceDetail")
                    lblServiceDetail = (Label)ctrl;
            }

            if (ctrl is Image)
                imgImageFilePath = (Image)ctrl;

        }
        lblServiceName.Text = dsServices.Tables[0].Rows[0]["ServiceName"].ToString();
        lblServiceDetail.Text = dsServices.Tables[0].Rows[0]["ServiceDetail"].ToString();
        imgImageFilePath.ImageUrl = dsServices.Tables[0].Rows[0]["ServiceImageFilePath"].ToString();
    }
    
 
}