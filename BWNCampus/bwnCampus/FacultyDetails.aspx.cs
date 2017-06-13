using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacultyDetails : System.Web.UI.Page
{
    int intFacultyID = 0;
    DataTable dtFaculty = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            intFacultyID = Convert.ToInt32(Request.QueryString["FacultyID"]);
            dtFaculty = LogicKernal.Faculty.GetFacultyByID(intFacultyID);
            imgFaculty.ImageUrl = dtFaculty.Rows[0]["FacultyImage"].ToString();
            if (Convert.ToBoolean(dtFaculty.Rows[0]["Gender"]) == true)
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";
            lblFacultyName.Text = dtFaculty.Rows[0]["FacultyName"].ToString();
            lblDesignation.Text = dtFaculty.Rows[0]["Designation"].ToString();
            lblObjectives.Text = dtFaculty.Rows[0]["Objectives"].ToString();
            lblQualification.Text = dtFaculty.Rows[0]["Qualification"].ToString();
            lblSpecialization.Text = dtFaculty.Rows[0]["Specialization"].ToString();

            DataTable dtPaper = new DataTable();
            dtPaper = LogicKernal.FacultyPaper.GetPaperByFacultyID(intFacultyID);
            lstPapers.DataSource = dtPaper;
            lstPapers.DataBind();

            DataTable dtProjects = new DataTable();
            dtProjects = LogicKernal.Projects.GetProjectsByFacultyID(intFacultyID);
            lstProjects.DataSource = dtProjects;
            lstProjects.DataBind();

            lnkDepartment.NavigateUrl = "DepartmentDetails.aspx?DeptID=" + Session["DeptID"].ToString();
        }

        if (Session["FacultyID"] != null)
        {
            pnlProfile.Visible = true;
            pnlLogin.Visible = false;
        }
        else
        {
            pnlProfile.Visible = false;
            pnlLogin.Visible = true;
        }
    }

    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        DataTable dtFacultyLogin = new DataTable();
        dtFacultyLogin = LogicKernal.Faculty.FacultyLogin(txtUsername.Text, txtPassword.Text);
        if (dtFacultyLogin.Rows.Count > 0)
        {
            Session["FacultyID"] = dtFacultyLogin.Rows[0]["FacultyID"].ToString();
            pnlProfile.Visible = true;
            pnlLogin.Visible = false;
        }
        else
            lblMessage.Visible = true;
    }
    protected void btnLogout_Click1(object sender, EventArgs e)
    {
        Session["FacultyID"] = null;
        pnlProfile.Visible = false;
        pnlLogin.Visible = true;
    }
}