using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Admin_Services : System.Web.UI.Page
{
    TextBox txtServiceName = new TextBox();
    TextBox txtServiceDetails = new TextBox();
    FileUpload fulServiceImage = new FileUpload();
    Button cmdSave = new Button();
    Label lblMessage = new Label();

    protected void Page_Load(object sender, EventArgs e)
    {

        artServices.DataBind();

        if (Session["UserID"] == null)
            Response.Redirect("Login.aspx");
        foreach (Control ctrl in artServices.ContentPlaceholder.Controls[0].Controls)
        {
            if (!Page.IsPostBack)
                if (ctrl is Button)
                {
                    Button cmdSave = (Button)ctrl;
                    cmdSave.Click += new EventHandler(cmdSave_Click);
                }

            if (ctrl is TextBox)
            {

                if (ctrl.ID == "txtServiceName")
                    txtServiceName = (TextBox)ctrl;

                if (ctrl.ID == "txtServiceDetails")
                    txtServiceDetails = (TextBox)ctrl;
            }

            if (ctrl is FileUpload)
                fulServiceImage = (FileUpload)ctrl;

            if (ctrl is Label)
                lblMessage = (Label)ctrl;
        }

        artServices.DataBind();
        foreach (Control ctrl in artServices.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is GridView)
            {
                DataSet dsServices = new DataSet();
                DataKernal.Services objService = new DataKernal.Services();
                dsServices = objService.SelectServices();
                GridView grdServices = (GridView)ctrl;
                grdServices.DataSource = dsServices;
                grdServices.DataBind();
                grdServices.RowCommand += new GridViewCommandEventHandler(grdServices_RowCommand);

            }
        }

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ServiceID"] != null)
            {
                int intService = Convert.ToInt32(Request.QueryString["ServiceID"]);
                DataTable dtServices = new DataTable();
                dtServices = LogicKernal.Services.GetServicesByID(intService);

                if (dtServices.Rows.Count > 0)
                {
                    txtServiceName.Text = dtServices.Rows[0]["ServiceName"].ToString();
                    txtServiceDetails.Text = dtServices.Rows[0]["ServiceDetail"].ToString();
                }
            }
           
        }
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {

        string strLogoImageName = string.Empty;
        int intServiceID = 0;

        if (Request.QueryString["ServiceID"] != null)
            intServiceID = Convert.ToInt32(Request.QueryString["ServiceID"]);

        strLogoImageName = fulServiceImage.FileName;
        fulServiceImage.SaveAs(Server.MapPath("~/Services/" + strLogoImageName));

        int intUserID = Convert.ToInt32(Session["UserID"]);

        BusinessEntities.Services objServices = new BusinessEntities.Services();
        objServices.ServiceID = intServiceID;
        objServices.ServiceName = txtServiceName.Text;
        objServices.ServiceDetails = txtServiceDetails.Text;
        objServices.ServiceImagePath = "~/Services/" + strLogoImageName;
        objServices.ServiceCreatedByUserID = intUserID;
        objServices.ServiceCreatedByDateTime = System.DateTime.Now.Date;
       

        if (LogicKernal.Services.InsertUpdateServices(objServices) > 0)
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Record entered successfully";
            txtServiceName.Text = string.Empty;
            txtServiceDetails.Text = string.Empty;
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "There is some problem in record entry";
        }
    }

    private void grdServices_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int intServiceID = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Del")
            LogicKernal.Services.DeleteServices(intServiceID);
         else if(e .CommandName == "Edit")
            Response.Redirect("~/Admin/Admin/Services.aspx?ServiceID=" + intServiceID.ToString());
    }
}


