using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FacultyID"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void cmdSave_Click(object sender, EventArgs e)
    {
        DataTable dtFaculty = LogicKernal.Faculty.FacultyLogin(txtUsername.Text, txtOldPassword.Text);
        if (dtFaculty.Rows.Count > 0)
        {
            BusinessEntities.Faculty objFaculty = new BusinessEntities.Faculty();
            objFaculty.FacultyID = Convert.ToInt32(Session["FacultyID"]);
            objFaculty.FacultyImage = dtFaculty.Rows[0]["FacultyImage"].ToString();
            objFaculty.FacultyName = dtFaculty.Rows[0]["FacultyName"].ToString();
            objFaculty.FacultyPassword = txtNewPassword.Text;
            objFaculty.FacultyUsername = txtUsername.Text;
            objFaculty.Gender = Convert.ToBoolean(dtFaculty.Rows[0]["Gender"]);
            objFaculty.Objectives = dtFaculty.Rows[0]["Objectives"].ToString();
            objFaculty.Qualification = dtFaculty.Rows[0]["Qualification"].ToString();
            objFaculty.Specialization = dtFaculty.Rows[0]["Specialization"].ToString();
            objFaculty.DepartmentID = Convert.ToInt32(dtFaculty.Rows[0]["DepartmentID"]);
            objFaculty.DesignationID = Convert.ToInt32(dtFaculty.Rows[0]["DesignationID"]);
            if (LogicKernal.Faculty.InsertUpdateFaculty(objFaculty) > 0)
                Response.Redirect("FacultyDetails.aspx?FacultyID=" + Convert.ToInt32(Session["FacultyID"]));
            else
            {
                lblMessage.Text = "There is some problem in record saving";
                lblMessage.Visible = true;
            }
        }
        else
        {
            lblMessage.Text = "Invalid Username or Old Password";
            lblMessage.Visible = true;
        }
    }
}