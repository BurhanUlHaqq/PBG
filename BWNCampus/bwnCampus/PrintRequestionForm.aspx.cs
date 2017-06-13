using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PrintRequestionForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        string user=Request .QueryString ["tr"];
        if (Session[user + "Rsaifoia000F"] != null)
        {
            int checkTotalCourses = 1;
            table = (DataTable)Session[user + "Rsaifoia000F"];
            lblTeacherName.Text = table.Rows[0]["TitleOfCourse"].ToString();
            lblDesignation.Text = table.Rows[0]["CourseCode"].ToString();
            lblDepartment.Text = table.Rows[0]["CourseCreditHrs"].ToString();
            lblSemester.Text = table.Rows[0]["CourseType"].ToString();

            DataTable WorkLoadTable = new DataTable();
            WorkLoadTable.Columns.Add("SrNo");
            WorkLoadTable.Columns.Add("CourseName");
            WorkLoadTable.Columns.Add("CourseCode");
            WorkLoadTable.Columns.Add("CourseCredit");
            DataRow headerRow = WorkLoadTable.NewRow();
            headerRow["SrNo"] = "I";
            headerRow["CourseName"] = "Regular Course(s)";
            WorkLoadTable.Rows.Add(headerRow);
            int i = 1;
            while (i < table.Rows.Count)
            {
                if (table.Rows[i]["CourseType"].ToString() == "Work Load")
                {
                    DataRow row = WorkLoadTable.NewRow();
                    row["SrNo"] = i.ToString();
                    row["CourseName"] = table.Rows[i]["TitleOfCourse"].ToString();
                    row["CourseCode"] = table.Rows[i]["CourseCode"].ToString();
                    row["CourseCredit"] = table.Rows[i]["CourseCreditHrs"].ToString();
                    WorkLoadTable.Rows.Add(row);
                    checkTotalCourses++;
                }
                i++;
            }
            if (checkTotalCourses == 1)
            {
                DataRow row = WorkLoadTable.NewRow();
                row["SrNo"] = checkTotalCourses.ToString();
                row["CourseName"] = "";
                row["CourseCode"] = "";
                row["CourseCredit"] = "";
                WorkLoadTable.Rows.Add(row);
            }
            DataRow headerRow2 = WorkLoadTable.NewRow();
            headerRow2["SrNo"] = "II";
            headerRow2["CourseName"] = "Part Time Course(s)";
            WorkLoadTable.Rows.Add(headerRow2);
            int j = 1;
            checkTotalCourses = 1;
            while (j < table.Rows.Count)
            {
                if (table.Rows[j]["CourseType"].ToString() == "Part Time")
                {
                    DataRow row = WorkLoadTable.NewRow();
                    row["SrNo"] = j.ToString();
                    row["CourseName"] = table.Rows[j]["TitleOfCourse"].ToString();
                    row["CourseCode"] = table.Rows[j]["CourseCode"].ToString();
                    row["CourseCredit"] = table.Rows[j]["CourseCreditHrs"].ToString();
                    WorkLoadTable.Rows.Add(row);
                    checkTotalCourses++;
                }
                j++;
            }
            if (checkTotalCourses == 1)
            {
                DataRow row = WorkLoadTable.NewRow();
                row["SrNo"] = checkTotalCourses.ToString();
                row["CourseName"] = "";
                row["CourseCode"] = "";
                row["CourseCredit"] = "";
                WorkLoadTable.Rows.Add(row);
            }
            gvWorkLoad.DataSource = WorkLoadTable;
            gvWorkLoad.DataBind();

            int z= 1;
            checkTotalCourses = 1;
            DataTable VisitersTable = new DataTable();
            VisitersTable.Columns.Add("SrNo");
            VisitersTable.Columns.Add("CourseName");
            VisitersTable.Columns.Add("CourseCode");
            VisitersTable.Columns.Add("CourseCredit");
            while (z < table.Rows.Count)
            {
                if (table.Rows[z]["CourseType"].ToString() == "Visiting")
                {
                    DataRow row = VisitersTable.NewRow();
                    row["SrNo"] = z.ToString();
                    row["CourseName"] = table.Rows[z]["TitleOfCourse"].ToString();
                    row["CourseCode"] = table.Rows[z]["CourseCode"].ToString();
                    row["CourseCredit"] = table.Rows[z]["CourseCreditHrs"].ToString();
                    VisitersTable.Rows.Add(row);
                    checkTotalCourses++;
                }
                z++;
            }
            if (checkTotalCourses == 1)
            {
                DataRow row = VisitersTable.NewRow();
                row["SrNo"] = checkTotalCourses.ToString();
                row["CourseName"] = " ";
                row["CourseCode"] = " ";
                row["CourseCredit"] = " ";
                VisitersTable.Rows.Add(row);
            }
            gvVisiters.DataSource = VisitersTable;
            gvVisiters.DataBind();
        }
        else
        {
            Response.Write("<script>notLoginUser()</script");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "My", "notLoginUser()",true);
        }
    }
    protected void gvWorkLoad_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.Cells[0].Text == "I" || e.Row.Cells[0].Text == "II")
        //    {
        //        e.Row.Cells[1].ColumnSpan = 5;
        //        e.Row.Cells.RemoveAt(4);
        //    }
        //}
    }
}