using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_Faculty : System.Web.UI.Page
{
    TextBox txtFacultyName = new TextBox();
    TextBox txtUsername = new TextBox();
    TextBox txtPassword = new TextBox();

    DropDownList ddlDesignation = new DropDownList();
    DropDownList ddlDepartment = new DropDownList();
    FileUpload fulFacultyImage = new FileUpload();
    GridView grdFaculty = new GridView();
    Button cmdSave = new Button();
    Label lblMessage = new Label();

    protected void Page_Load(object sender, EventArgs e)
    {
        artFaculty.DataBind();
        if (Session["UserID"] == null)
            Response.Redirect("Login.aspx");

        foreach (Control ctrl in artFaculty.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is Button)
            {
                Button cmdSave = (Button)ctrl;
                cmdSave.Click += new EventHandler(cmdSave_Click);
            }

            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtFacultyName")
                    txtFacultyName = (TextBox)ctrl;
                if (ctrl.ID == "txtUsername")
                    txtUsername = (TextBox)ctrl;
                if (ctrl.ID == "txtPassword")
                    txtPassword = (TextBox)ctrl;
            }
            if (ctrl is DropDownList)
            {
                if (ctrl.ID == "ddlDesignation")
                    ddlDesignation = (DropDownList)ctrl;

                if (ctrl.ID == "ddlDepartment")
                {
                    DataTable dtDepartment = new DataTable();
                    dtDepartment = LogicKernal.Department.GetAllDepartment();
                    ddlDepartment = (DropDownList)ctrl;
                    ddlDepartment.DataValueField = "DepartmentID";
                    ddlDepartment.DataTextField = "DepartmentName";
                    ddlDepartment.DataSource = dtDepartment;
                    ddlDepartment.DataBind();
                }
            }

            if (ctrl is FileUpload)
                fulFacultyImage = (FileUpload)ctrl;

            if (ctrl is Label)
                lblMessage = (Label)ctrl;

            if (ctrl is GridView)
            {
                DataSet dsFaculty = new DataSet();
                DataKernal.Faculty objFaculty = new DataKernal.Faculty();
                dsFaculty = objFaculty.SelectFaculty();
                grdFaculty = (GridView)ctrl;
                grdFaculty.DataSource = dsFaculty;
                grdFaculty.DataBind();
            }
        }

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["FacultyID"] != null)
            {
                int intFacultID = Convert.ToInt32(Request.QueryString["FacultyID"]);
                DataTable dtFaculty = new DataTable();
                dtFaculty = LogicKernal.Faculty.GetFacultyByID(intFacultID);

                if (dtFaculty.Rows.Count > 0)
                {
                    txtFacultyName.Text = dtFaculty.Rows[0]["FacultyName"].ToString();
                    ddlDesignation.SelectedIndex = Convert.ToInt32(dtFaculty.Rows[0]["DesignationID"]);
                }
            }
        }
    }

    private void cmdSave_Click(System.Object sender, EventArgs e)
    {
        string strFacultyImage = string.Empty;
        int intFacultyID = 0;
        if (Request.QueryString["FacultyID"] != null)
            intFacultyID = Convert.ToInt32(Request.QueryString["FacultyID"]);

        strFacultyImage = fulFacultyImage.FileName;
        fulFacultyImage.SaveAs(Server.MapPath("../../profileImages/" + strFacultyImage));

        int intUserID = Convert.ToInt32(Session["UserID"]);

        BusinessEntities.Faculty objFaculty = new BusinessEntities.Faculty();
        objFaculty.FacultyID = intFacultyID;
        objFaculty.DepartmentID  = Convert.ToInt32(ddlDepartment.SelectedValue);
        objFaculty.DesignationID = ddlDesignation.SelectedIndex + 1;
        objFaculty.FacultyName = txtFacultyName.Text;
        objFaculty.FacultyUsername = txtUsername.Text;
        objFaculty.FacultyPassword = txtPassword.Text;
        objFaculty.FacultyImage = "profileImages/" + strFacultyImage;
        objFaculty.Objectives = "N/A";
        objFaculty.Qualification = "N/A";
        objFaculty.Specialization = "N/A";
        
        if (LogicKernal.Faculty.InsertUpdateFaculty(objFaculty) > 0)
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Record entered successfully";
            txtFacultyName.Text = string.Empty;
            
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "There is some problem in record entry";
        }
    }
}