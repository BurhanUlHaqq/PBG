using System;
 	using System.Data;
 	using System.Collections.Generic;
 	using System.Web;
 	using System.Web.UI;
 	using System.Web.UI.WebControls;
 	using System.Xml;
 	using System.Xml.Serialization;
 	using System.IO;

public partial class CourseAssignmentForm : System.Web.UI.Page
{
    int intFacultyID;
    DataTable dtFaculty;
    DataTable dtClasses;
    //Variables used to store data in xml file IUBFacultyRequestionForm.xml
    string strSemesterId = string.Empty;
    string teacherStatus = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (txtYear.Items.Count == 0)
        {
            int y = DateTime.Now.Year - 3;
            while (y <= DateTime.Now.Year)
            {
                txtYear.Items.Add(y + "");
                y++;
                txtYear.SelectedIndex = 3;
            }
        }
        if (Session["FacultyID"] != null)
        {
            intFacultyID = Convert.ToInt16(Session["FacultyID"]);
            dtFaculty = new DataTable();
            dtFaculty = LogicKernal.Faculty.GetFacultyByID(intFacultyID);
            if (dtFaculty.Rows.Count > 0)
            {
                lblTeacherName.Text = dtFaculty.Rows[0]["FacultyName"].ToString();
                lblDesignation.Text = dtFaculty.Rows[0]["Designation"].ToString();
                lblDepartmentID.Text = dtFaculty.Rows[0]["DepartmentID"].ToString();
                lblDepartmentName.Text = LogicKernal.Department.GetDepartmentByID(Convert.ToInt16(lblDepartmentID.Text)).Rows[0]["DepartmentName"].ToString();
                ucCourse.okButtonClickedEvent += new okButtonClickedEventHandler(ucCourse_okButtonClickedEvent);
            }
        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void rdbSpring_CheckedChanged(object sender, EventArgs e)
    {
        ddlClasses.Visible = true;
        dtClasses = new DataTable();
        dtClasses = LogicKernal.Department.GenerateClassesList("Spring", Convert.ToInt16(lblDepartmentID.Text));
        ddlClasses.DataSource = dtClasses;
        ddlClasses.DataTextField = "ClassName";
        ddlClasses.DataValueField = "ClassID";
        ddlClasses.DataBind();
        //rdbFall.Enabled = false;
        //rdbSummer.Enabled = false;
    }
    protected void rdbFall_CheckedChanged(object sender, EventArgs e)
    {
        ddlClasses.Visible = true;
        dtClasses = new DataTable();
        dtClasses = LogicKernal.Department.GenerateClassesList("Fall", Convert.ToInt16(lblDepartmentID.Text));
        ddlClasses.DataSource = dtClasses;
        ddlClasses.DataTextField = "ClassName";
        ddlClasses.DataValueField = "ClassID";
        ddlClasses.DataBind();
        //rdbSummer.Enabled = false;
        //rdbSpring.Enabled = false;
    }

    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtPrograms = new DataTable();
        dtPrograms = LogicKernal.Programs.GetProgramByDepartmentID(Convert.ToInt32(lblDepartmentID.Text));
        string strProgramID = string.Empty;
        string strProgramName = string.Empty;
        for (int i = 0; i < dtPrograms.Rows.Count; i++)
        {
            strProgramID = dtPrograms.Rows[i]["ProgramID"].ToString();
            strProgramName = dtPrograms.Rows[i]["ProgramName"].ToString();
            if (strProgramName == ddlClasses.SelectedItem.Text.Split(':')[0])
            {
                i = dtPrograms.Rows.Count;
            }
        }
        strSemesterId = ddlClasses.SelectedItem.Text.Split(':')[1];
        ucCourse.Semester = Convert.ToInt32(strSemesterId);
        ucCourse.Program = Convert.ToInt32(strProgramID);
        ucCourse.Teacher = lblTeacherName.Text;
        ucCourse.Designation = lblDesignation.Text;
        ucCourse.DepartmentName = lblDepartmentName.Text;
        ucCourse.Year = txtYear.SelectedValue;
        if (rdbSpring .Checked)
        {
            ucCourse.XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Spring_" + txtYear.SelectedValue + ".xml");
            ucCourse.ProgramName = "Spring-" + txtYear .Text;
        }
        else
        {
            ucCourse.XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Fall_" + txtYear.SelectedValue + ".xml");
            ucCourse.ProgramName = "Fall-" + txtYear.Text;
        }
        ucCourse.loadData(true);
        ucCourse.Visible = true;
        btnAllCourses.Visible = true;
    }
    protected void ddlClasses_DataBound(object sender, EventArgs e)
    {
        DataTable dtPrograms = new DataTable();
        dtPrograms = LogicKernal.Programs.GetProgramByDepartmentID(Convert.ToInt32(lblDepartmentID.Text));
        string strProgramID = string.Empty;
        string strProgramName = string.Empty;
        for (int i = 0; i < dtPrograms.Rows.Count; i++)
        {
            strProgramID = dtPrograms.Rows[i]["ProgramID"].ToString();
            strProgramName = dtPrograms.Rows[i]["ProgramName"].ToString();
            if (strProgramName == ddlClasses.SelectedItem.Text.Split(':')[0])
            {
                i = dtPrograms.Rows.Count;
            }
        }
        strSemesterId = ddlClasses.SelectedItem.Text.Split(':')[1];
        ucCourse.Semester = Convert.ToInt32(strSemesterId);
        ucCourse.Program = Convert.ToInt32(strProgramID);
        ucCourse.Teacher = lblTeacherName.Text;
        ucCourse.Designation = lblDesignation.Text;
        ucCourse.DepartmentName = lblDepartmentName.Text;
        ucCourse.Year = txtYear.SelectedValue;
        if (rdbSpring .Checked)
        {
            ucCourse.XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Spring_" + txtYear.SelectedValue + ".xml");
            ucCourse.ProgramName = "Spring-" + txtYear.Text;
        }
        else
        {
            ucCourse.XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Fall_" + txtYear.SelectedValue + ".xml");
            ucCourse.ProgramName = "Fall-" + txtYear.Text;
        }
        ucCourse.loadData(true);
        ucCourse.Visible = true;
        btnAllCourses.Visible = true;
    }
    protected void ucCourse_okButtonClickedEvent(object sender, okButtonClickedEventArgs e)
    {
        string path = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string year = txtYear.SelectedValue;
        string smsterName;
        if (rdbSpring .Checked )
        {
            smsterName = "Spring";
        }
        else
        {
            smsterName = "Fall";
        }
        if (!File.Exists(path + smsterName +"_"+ year + ".xml"))
        {
            XmlDocument docCreate = new XmlDocument();
            XmlNode docNode = docCreate.CreateXmlDeclaration("1.0", "UTF-8", null);
            docCreate.AppendChild(docNode);
            XmlElement IUBFacultyRequestionForm = docCreate.CreateElement("IUBFacultyRequestionForm");
            docCreate.AppendChild(IUBFacultyRequestionForm);
            docCreate.Save(path + smsterName +"_"+ year + ".xml");
        }
        XmlDocument doc = new XmlDocument();
        doc.Load(path + smsterName +"_"+ year + ".xml");
        DataTable SelectedCourse = ucCourse.SelectedCourse;
        XmlNode MainNode = doc.SelectSingleNode("//IUBFacultyRequestionForm");
        XmlNodeList TeacherNode = doc.GetElementsByTagName("Teacher");
        int match = 0;
        int i = 0;
        while (i < TeacherNode.Count)
        {
            string tempVal = TeacherNode.Item(i).Attributes["Name"].Value;
            if (tempVal == lblTeacherName.Text)
            {
                match = 1;
                i = TeacherNode.Count;
            }
            i++;
        }
        if (MainNode.ChildNodes.Count == 0 || match == 0)
        {
            XmlElement TeacherElement = doc.CreateElement("Teacher");
            TeacherElement.SetAttribute("Name", lblTeacherName.Text);
            TeacherElement.SetAttribute("Designation", lblDesignation.Text);
            TeacherElement.SetAttribute("Department", lblDepartmentName.Text);
            TeacherElement.SetAttribute("Status", "");
            foreach (DataRow dr in SelectedCourse.Rows)
            {
                string CourseCode = dr["CourseCode"].ToString();
                string CourseName = dr["CourseName"].ToString();
                string CourseCreditHours = dr["CourseCreditHours"].ToString();
                XmlElement Course = doc.CreateElement("Course");
                Course.SetAttribute("TitleOfCourse", CourseName);
                Course.SetAttribute("CourseCode", CourseCode);
                Course.SetAttribute("CourseCreditHrs", CourseCreditHours);
                Course.SetAttribute("CourseType", ucCourse.CourseType);
                Course.SetAttribute("SemesterNo", ddlClasses.SelectedItem.Text.Split(':')[1]);
                Course.SetAttribute("SemesterName", ddlClasses.SelectedItem.Text.Split(':')[0]);
                Course.SetAttribute("Year", txtYear.SelectedValue);
                TeacherElement.AppendChild(Course);
            }
            MainNode.AppendChild(TeacherElement);
        }
        else
        {
            XmlNode TeacherEleme = doc.SelectSingleNode("IUBFacultyRequestionForm/Teacher[@Name='" + lblTeacherName.Text + "']");
            foreach (DataRow dr in SelectedCourse.Rows)
            {
                string CourseCode = dr["CourseCode"].ToString();
                string CourseName = dr["CourseName"].ToString();
                string CourseCreditHours = dr["CourseCreditHours"].ToString();
                XmlElement Course = doc.CreateElement("Course");
                Course.SetAttribute("TitleOfCourse", CourseName);
                Course.SetAttribute("CourseCode", CourseCode);
                Course.SetAttribute("CourseCreditHrs", CourseCreditHours);
                Course.SetAttribute("CourseType", ucCourse.CourseType);
                Course.SetAttribute("SemesterNo", ddlClasses.SelectedItem.Text.Split(':')[1]);
                Course.SetAttribute("SemesterName", ddlClasses.SelectedItem.Text.Split(':')[0]);
                Course.SetAttribute("Year", txtYear.SelectedValue);
                TeacherEleme.AppendChild(Course);
            }
        }
        doc.Save(path + smsterName + "_"+year + ".xml");
        ucCourse.loadData(false);
        btnAllCourses.Visible = true;
        panalAllCourse.Visible = false;
        iBtnExit.Visible = false;
        headerTxt.Visible = false;
    }
    protected void txtYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucCourse.Visible = false;
        rdbFall.Enabled = true;
        rdbSpring.Enabled = true;
        rdbFall.Checked = false;
        rdbSpring.Checked = false;
        ddlClasses.Visible = false;
        btnAllCourses.Visible = false;
        panalAllCourse.Visible = false;
        iBtnExit.Visible = false;
        headerTxt.Visible = false;
    }
    protected void btnAllCourses_Click(object sender, EventArgs e)
    {
        panalAllCourse.Visible = true;
        headerTxt.Visible = true;
        btnAllCourses.Visible = false;
        iBtnExit.Visible = true;
        if (rdbSpring.Checked)
        {
            controlViewAllCourses.XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Spring_" + txtYear.SelectedValue + ".xml");
            controlViewAllCourses.loadData();
        }
        else
        {
            controlViewAllCourses.XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Fall_" + txtYear.SelectedValue + ".xml");
            controlViewAllCourses.loadData();
        }
    }
    protected void iBtnExit_Click(object sender, ImageClickEventArgs e)
    {
        panalAllCourse.Visible = false;
        headerTxt.Visible = false;
        btnAllCourses.Visible = true;
        iBtnExit.Visible = false;
    }
}