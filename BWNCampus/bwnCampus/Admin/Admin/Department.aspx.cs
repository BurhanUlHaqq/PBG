using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Admin_Department : System.Web.UI.Page
{
    TextBox txtDepartmentName = new TextBox();
    TextBox txtDescription = new TextBox();
    FileUpload fulLogoImage = new FileUpload();
    Label lblMessage = new Label();
    LinkButton lnkPrograms = new LinkButton();

    protected void Page_Load(object sender, EventArgs e)
    {
        artDepartment.DataBind();

        if (Session["UserID"] == null)
            Response.Redirect("Login.aspx");
        foreach (Control ctrl in artDepartment.ContentPlaceholder.Controls[0].Controls)
        {
            if (!Page.IsPostBack)
                if (ctrl is Button)
                {
                    Button cmdSave = (Button)ctrl;
                    cmdSave.Click += new EventHandler(cmdSave_Click);
                }

            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtDepartmentName")
                    txtDepartmentName = (TextBox)ctrl;

                if (ctrl.ID == "txtDescription")
                    txtDescription = (TextBox)ctrl;
            }

            if (ctrl is FileUpload)
                fulLogoImage = (FileUpload)ctrl;

            if (ctrl is Label)
                lblMessage = (Label)ctrl;

            if (ctrl is LinkButton)
            {
                lnkPrograms = (LinkButton)ctrl;
                lnkPrograms.Click += new EventHandler(lnkPrograms_Click);
                if (Request.QueryString["DepartmentID"] == null)
                    lnkPrograms.Visible = false;

            }
        }

        artDepartment.DataBind();
        foreach (Control ctrl in artDepartment.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is GridView)
            {
                DataSet dsDepartment = new DataSet();
                DataKernal.Department objDepartment = new DataKernal.Department();
                dsDepartment = objDepartment.SelectDepartment();
                GridView grdDepartment = (GridView)ctrl;
                grdDepartment.DataSource = dsDepartment;
                grdDepartment.DataBind();
                grdDepartment.RowCommand += new GridViewCommandEventHandler(grdDepartment_RowCommand);
            }
        }

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["DepartmentID"] != null)
            {
                int intDepartment = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                DataTable dtDepartment = new DataTable();
                dtDepartment = LogicKernal.Department.GetDepartmentByID(intDepartment);
                
                if (dtDepartment.Rows.Count > 0)
                {
                    txtDepartmentName.Text = dtDepartment.Rows[0]["DepartmentName"].ToString ();
                    txtDescription.Text = dtDepartment.Rows[0]["DepartmentDescription"].ToString();
                }
            }

        }
    }

    private void lnkPrograms_Click(Object sender, EventArgs e)
    {
        int intDeptID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
        Session["DepartmentID"] = intDeptID;
        Response.Redirect("Programs.aspx");
    }

    protected void cmdSave_Click(object sender, EventArgs e)
    {
        string strLogoImageName = string.Empty;
       int intDepartmentID = 0;
        if(Request .QueryString ["DepartmentID"]!=null )
            intDepartmentID = Convert .ToInt32(Request .QueryString ["DepartmentID"]);

        strLogoImageName = fulLogoImage.FileName;
        fulLogoImage.SaveAs(Server.MapPath("../../DeptLogo/" + strLogoImageName));

        int intUserID = Convert.ToInt32(Session["UserID"]);

        BusinessEntities.Department objDepartment = new BusinessEntities.Department();
        objDepartment.DepartmentID = intDepartmentID;
        objDepartment.DepartmentName = txtDepartmentName.Text;
        objDepartment.DepartmentDescription = txtDescription.Text;
        objDepartment.DepartmentLogoImagePath = "DeptLogo/" + strLogoImageName;
        objDepartment.CreatedByUserID = intUserID;
        objDepartment.CreatedDateTime = System.DateTime.Now.Date;

        if (LogicKernal.Department.InsertUpdateDepartment(objDepartment) > 0)
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Record entered successfully";
            txtDepartmentName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "There is some problem in record entry";
        }
    }
    
    private void grdDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int intDepartmentID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Del")
            LogicKernal.Department.DeleteDepartment(intDepartmentID);
        else if(e.CommandName == "Edit")
            Response.Redirect("~/Admin/Admin/Department.aspx?DepartmentID=" + intDepartmentID.ToString());
  
    }

    protected void grdDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
