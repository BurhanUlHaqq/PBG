using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramDetails : System.Web.UI.Page
{
    int intProgramID = 0;
    DataTable dtProgram;
    protected void Page_Load()
    {
        if (Request.QueryString["ProgID"] != null)
        {
            intProgramID = Convert.ToInt32(Request.QueryString["ProgID"]);
            dtProgram = LogicKernal.Programs.GetProgramsByID(intProgramID);
            lblCaption.Text = dtProgram.Rows[0]["ProgramName"].ToString();
            lblDuration.Text = dtProgram.Rows[0]["Duration"].ToString();
            lblCriteria.Text = dtProgram.Rows[0]["Criteria"].ToString();
            lblFee.Text = dtProgram.Rows[0]["Fee"].ToString();
            lblDescription.Text = dtProgram.Rows[0]["ProgramDescription"].ToString();
            LoadData();
            lnkDepartment.NavigateUrl = "DepartmentDetails.aspx?DeptID=" + Session["DeptID"].ToString();
        }
    }

    private void LoadData()
    {
        DataTable dtSemester = new DataTable();
        dtSemester.Columns.Add("SemesterName", typeof(string));
        dtSemester.Columns.Add("SemesterNo", typeof(int));
        int intSemesters = Convert.ToInt32(lblDuration.Text.Split("-".ToCharArray())[1].Split(":".ToCharArray())[1]);
        for (int i = 0; i < intSemesters; i++)
        {
            DataRow dr = dtSemester.NewRow();
            dr["SemesterName"] = "<b>Semester: " + (i + 1) + "</b>";
            dr["SemesterNo"] = i + 1;
            dtSemester.Rows.Add(dr);
        }

        lstSemesterList.DataSource = dtSemester;
        lstSemesterList.DataBind();
    }
    
    protected void lstSemesterList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label lblSemesterNo = (Label)e.Item.FindControl("lblSemesterNo");
        DataList lstCourses = (DataList)e.Item.FindControl("lstCourses");
        DataTable dtCourse = LogicKernal.Course.GetCourseBySemesterNoProgramID(Convert.ToInt32(lblSemesterNo.Text), Convert.ToInt32(Request.QueryString["ProgID"]));
        if (dtCourse.Rows.Count > 0)
        {
            lstCourses.DataSource = dtCourse;
            lstCourses.DataBind();
        }
    }
}