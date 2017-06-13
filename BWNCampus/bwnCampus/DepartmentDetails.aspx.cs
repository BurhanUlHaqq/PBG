using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DepartmentDetails : System.Web.UI.Page
{
    int intDepartmentID;

    protected void Page_Load(object sender, EventArgs e)
    {

        intDepartmentID = Convert.ToInt32(Request.QueryString["DeptID"]);
                
        DataTable dtDepartment = new DataTable();
        dtDepartment = LogicKernal.Department.GetDepartmentByID(intDepartmentID);
        Session["DeptID"] = intDepartmentID;

        DataTable dtFaculty = new DataTable();
        dtFaculty = LogicKernal.Faculty.GetFacultyByDepartmentID(intDepartmentID);
        lstFaculty.DataSource = dtFaculty;
        lstFaculty.DataBind();

        DataTable dtPrograms = new DataTable();
        dtPrograms = LogicKernal.Programs.GetProgramByDepartmentID(intDepartmentID);
        lstPrograms.DataSource = dtPrograms;
        lstPrograms.DataBind();
        
        lblDepartmentName.Text = dtDepartment.Rows[0]["DepartmentName"].ToString();
        lblDescription.Text = dtDepartment.Rows[0]["DepartmentDescription"].ToString();
        imgLogo.ImageUrl = dtDepartment.Rows[0]["DepartmentLogoImagePath"].ToString();
    }

    protected void lstPrograms_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ProgramDetails")
                    Response.Redirect("ProgramDetails.aspx?ProgID=" + e.CommandArgument.ToString());
    }
    protected void lstFaculty_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "FacultyDetails")
                    Response.Redirect("FacultyDetails.aspx?FacultyID=" + e.CommandArgument.ToString());
    }
}

    