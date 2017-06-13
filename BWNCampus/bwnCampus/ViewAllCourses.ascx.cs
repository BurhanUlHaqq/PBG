using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;

public partial class ViewAllCourses : System.Web.UI.UserControl
{
    protected string strPath;
    public string XMLPath
    {
        get
        {
            return strPath;
        }
        set
        {
            strPath = value;
        }
    }
    public void loadData()
    {
        DataTable tblSelectedCourses = new DataTable();
        tblSelectedCourses.Columns.Add("CourseCode");
        tblSelectedCourses.Columns.Add("CourseName");
        tblSelectedCourses.Columns.Add("CourseClass");
        tblSelectedCourses.Columns.Add("CourseTeacher");
        if (System.IO.File.Exists(strPath))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(strPath);
            XmlNodeList teacherList = doc.SelectNodes("//IUBFacultyRequestionForm/Teacher");
            int i = 0;
            while (i < teacherList.Count)
            {
                XmlNodeList courseList = doc.SelectNodes("IUBFacultyRequestionForm/Teacher[@Name='" + teacherList.Item(i).Attributes["Name"].Value + "']/Course");
                int j = 0;
                while (j < courseList.Count)
                {
                    DataRow row = tblSelectedCourses.NewRow();
                    row["CourseCode"] = courseList.Item(j).Attributes["CourseCode"].Value;
                    row["CourseName"] = courseList.Item(j).Attributes["TitleOfCourse"].Value;
                    row["CourseClass"] = courseList.Item(j).Attributes["SemesterName"].Value +":"+ courseList.Item(j).Attributes["SemesterNo"].Value;
                    row["CourseTeacher"] = teacherList.Item(i).Attributes["Name"].Value;
                    tblSelectedCourses.Rows.Add(row);
                    j++;
                }
                i++;
            } 
        }
        gvShowCourses.DataSource = tblSelectedCourses;
        gvShowCourses.DataBind();
    }
    protected void gvShowCourses_Sorting(object sender, GridViewSortEventArgs e)
    {
        String newOrder = "CourseCode";
        e.SortExpression = newOrder;
        e.SortDirection =  SortDirection .Ascending ;
    }
}