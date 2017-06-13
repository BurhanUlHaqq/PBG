using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Admin_Downloads : System.Web.UI.Page
{
    TextBox txtDownlaodTitle = new TextBox();
    TextBox txtDownloadDetails = new TextBox();
    FileUpload fulDownloadFile = new FileUpload();
    Button cmdSave = new Button();
    Label lblMessage = new Label();

    protected void Page_Load(object sender, EventArgs e)
    {
        artDownloads.DataBind();

        if (Session["UserID"] == null)
            Response.Redirect("Login.aspx");
        foreach (Control ctrl in artDownloads.ContentPlaceholder.Controls[0].Controls)
        {
            if (!Page.IsPostBack)
                if (ctrl is Button)
                {
                    Button cmdSave = (Button)ctrl;
                    cmdSave.Click += new EventHandler(cmdSave_Click);
                }

            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtDownlaodTitle")
                    txtDownlaodTitle = (TextBox)ctrl;

                if (ctrl.ID == "txtDownloadDetails")
                    txtDownloadDetails = (TextBox)ctrl;
            }

            if (ctrl is FileUpload)
                fulDownloadFile = (FileUpload)ctrl;

            if (ctrl is Label)
                lblMessage = (Label)ctrl;
        }

        GridView grdDownload = new GridView();
       
        artDownloads.DataBind();

        foreach (Control ctrl in artDownloads.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is GridView)
            {
                DataSet dsDownloads= new DataSet();
                DataKernal.Download objDownload = new DataKernal.Download();
                dsDownloads= objDownload.SelectDownload();
                GridView Download = (GridView)ctrl;
                Download.DataSource = dsDownloads;
                Download.DataBind();
                Download.RowCommand += new GridViewCommandEventHandler(Download_RowCommand);
            }
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["DownloadID"] != null)
            {
                int intDownload = Convert.ToInt32(Request.QueryString["DownloadID"]);
                DataTable dtDownload = new DataTable();
                dtDownload = LogicKernal.Download.GetDownloadByID(intDownload);

                if (dtDownload.Rows.Count > 0)
                {
                    txtDownlaodTitle.Text = dtDownload.Rows[0]["DownloadTitle"].ToString();
                    txtDownloadDetails.Text = dtDownload.Rows[0]["DownloadDetail"].ToString();
                }
            }
        }

    }

    protected void cmdSave_Click(object sender, EventArgs e)
    {
        
        string strLogoImageName = string.Empty;
        int intDownloadID = 0;
        if (Request.QueryString["DownloadID"] != null)
            intDownloadID = Convert.ToInt32(Request.QueryString["DownloadID"]);

        strLogoImageName = fulDownloadFile.FileName;
        fulDownloadFile.SaveAs(Server.MapPath("../../downloads/" + strLogoImageName));

        int intUserID = Convert.ToInt32(Session["UserID"]);

        BusinessEntities.Download  objDownloads = new BusinessEntities.Download();
        objDownloads.DownloadID = intDownloadID;
        objDownloads.DownloadTitle = txtDownlaodTitle.Text;
        objDownloads.DownloadDetail = txtDownloadDetails.Text;
        objDownloads.DownloadFilePath = "downloads/" + strLogoImageName;
        objDownloads.DownloadCreateByUserID = intUserID;
        objDownloads.DownloadCreateDateTime = System.DateTime.Now.Date;

        if (LogicKernal.Download.InsertUpdateDownload(objDownloads) > 0)
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Record entered successfully";
            txtDownlaodTitle.Text = string.Empty;
            txtDownloadDetails.Text = string.Empty;
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "There is some problem in record entry";
        }
    }
   
    private void Download_RowCommand(object sender, GridViewCommandEventArgs  e)
    {
        int intDownloadID = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Del")
            LogicKernal.Download.DeleteDownload(intDownloadID);
        else if (e.CommandName == "Edit")
            Response .Redirect ("~/Admin/Admin/Downloads.aspx?DownloadID=" + intDownloadID .ToString());
    }
}
