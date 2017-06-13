using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditFacultyProfile : System.Web.UI.Page
{
    int intFacultyID = 0;
    string strImageFilePath = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FacultyID"] == null)
            Response.Redirect("Default.aspx");

        lnkDepartment.NavigateUrl = "DepartmentDetails.aspx?DeptID=" + Session["DeptID"].ToString();
        lnkFaculty.NavigateUrl = "FacultyDetails.aspx?FacultyID=" + Session["FacultyID"].ToString();

        LoadData();
    }

    private void LoadData()
    {
        if (Session["FacultyID"] != null)
        {
            intFacultyID = Convert.ToInt32(Session["FacultyID"]);
            DataTable dtFaculty = LogicKernal.Faculty.GetFacultyByID(intFacultyID);
            DataTable dtDepartment = LogicKernal.Department.GetAllDepartment();

            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataSource = dtDepartment;
            ddlDepartment.DataBind();

            if (dtFaculty.Rows.Count > 0)
            {
                txtName.Text = dtFaculty.Rows[0]["FacultyName"].ToString();
                txtObjectives.Text = dtFaculty.Rows[0]["Objectives"].ToString();
                txtQualification.Text = dtFaculty.Rows[0]["Qualification"].ToString();
                txtSpecialization.Text = dtFaculty.Rows[0]["Specialization"].ToString();
                ViewState["FacultyUsername"] = dtFaculty.Rows[0]["FacultyUsername"].ToString();
                ViewState["FacultyPassword"] = dtFaculty.Rows[0]["FacultyPassword"].ToString();
                if (Convert.ToBoolean(dtFaculty.Rows[0]["Gender"]) == true)
                    ddlGender.SelectedIndex = 0;
                else
                    ddlGender.SelectedIndex = 1;

                ddlDepartment.SelectedValue = dtFaculty.Rows[0]["DepartmentID"].ToString();
                ddlDesignation.SelectedValue = dtFaculty.Rows[0]["DesignationID"].ToString();
                imgFaculty.ImageUrl = dtFaculty.Rows[0]["FacultyImage"].ToString();
                strImageFilePath = imgFaculty.ImageUrl;
            }
        }
    }

    private void bntSave_Click(Object sender, EventArgs e)
    {
        if (fulImage.FileName != string.Empty)
        {
            fulImage.SaveAs(Server.MapPath("profileImages/" + fulImage.FileName));
            strImageFilePath = "profileImages/" + fulImage.FileName;
        }
        if (Session["FacultyID"] != null)
            intFacultyID = Convert.ToInt32(Session["FacultyID"]);
        else
            intFacultyID = 0;

        BusinessEntities.Faculty objFaculty = new BusinessEntities.Faculty();
        objFaculty.FacultyName = txtName.Text;
        objFaculty.Objectives = txtObjectives.Text;
        objFaculty.Qualification = txtQualification.Text;
        objFaculty.Specialization = txtSpecialization.Text;
        objFaculty.FacultyUsername = ViewState["FacultyUsername"].ToString();
        objFaculty.FacultyPassword = ViewState["FacultyPassword"].ToString();
        objFaculty.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
        objFaculty.DesignationID = Convert.ToInt32(ddlDesignation.SelectedValue);
        if (ddlDesignation.SelectedIndex == 0)
            objFaculty.Gender = true;
        else
            objFaculty.Gender = false;
        objFaculty.FacultyImage = strImageFilePath;
        objFaculty.FacultyID = intFacultyID;
        if (LogicKernal.Faculty.InsertUpdateFaculty(objFaculty) == 0)
            Response.Redirect("Default.aspx");

    }
}