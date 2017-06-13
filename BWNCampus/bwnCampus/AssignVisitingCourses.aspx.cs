using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;

public partial class AssignVisitingCourses : System.Web.UI.Page
{
    int intFacultyID;
    DataTable dtFaculty;
    DataTable dtPrograms;
    DataTable SelectedCourses;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FacultyID"] != null)
        {
            if (!IsPostBack)
            {
                int y = DateTime.Now.Year - 3;
                while (y <= DateTime.Now.Year)
                {
                    ddlYear.Items.Add(y + "");
                    y++;
                    ddlYear.SelectedIndex = 3;
                }
            }
            intFacultyID = Convert.ToInt16(Session["FacultyID"]);
            dtFaculty = new DataTable();
            dtFaculty = LogicKernal.Faculty.GetFacultyByID(intFacultyID);
            if (dtFaculty.Rows.Count > 0)
            {
                lblDepartmentID.Text = dtFaculty.Rows[0]["DepartmentID"].ToString();
                lblDepartmentName.Text = LogicKernal.Department.GetDepartmentByID(Convert.ToInt16(lblDepartmentID.Text)).Rows[0]["DepartmentName"].ToString();
                if (!IsPostBack)
                {
                    loadDDLTeacherName();
                }
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

        
    }

    private void loadDDLTeacherName()
    {
        ddlTeacherName.DataValueField = "VisitingId";
        ddlTeacherName.DataTextField = "VisitingName";
        ddlTeacherName.DataSource = LogicKernal.VisitingFaculty.GetAllFaculty();
        ddlTeacherName.DataBind();
    }
    protected void rbSpring_CheckedChanged(object sender, EventArgs e)
    {
        dtPrograms = new DataTable();
        dtPrograms = LogicKernal.Department.GenerateClassesList("Spring", Convert.ToInt16(lblDepartmentID.Text));
        ddlPrograms.DataSource = dtPrograms;
        ddlPrograms.DataTextField = "ClassName";
        ddlPrograms.DataValueField = "ClassID";
        ddlPrograms.DataBind();
        loadInSelectedArea();
    }
    protected void rbFall_CheckedChanged(object sender, EventArgs e)
    {
        dtPrograms = new DataTable();
        dtPrograms = LogicKernal.Department.GenerateClassesList("Fall", Convert.ToInt16(lblDepartmentID.Text));
        ddlPrograms.DataSource = dtPrograms;
        ddlPrograms.DataTextField = "ClassName";
        ddlPrograms.DataValueField = "ClassID";
        ddlPrograms.DataBind();
        loadInSelectedArea();
    }
    protected void ddlPrograms_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDDLCourses();
    }
    protected void ddlPrograms_DataBound(object sender, EventArgs e)
    {
        loadDDLCourses();
    }
    private void loadDDLCourses()
    {
        DataTable dtPrograms = new DataTable();
        dtPrograms = LogicKernal.Programs.GetProgramByDepartmentID(Convert.ToInt32(lblDepartmentID.Text));
        string strProgramID = string.Empty;
        string strProgramName = string.Empty;
        for (int i = 0; i < dtPrograms.Rows.Count; i++)
        {
            strProgramID = dtPrograms.Rows[i]["ProgramID"].ToString();
            strProgramName = dtPrograms.Rows[i]["ProgramName"].ToString();
            if (strProgramName == ddlPrograms.SelectedItem.Text.Split(':')[0])
            {
                i = dtPrograms.Rows.Count;
            }
        }
        ///// Finding All Selected Courses
        string strSemesterId = ddlPrograms.SelectedItem.Text.Split(':')[1];
        DataTable tblSelectedCourses = new DataTable();
        tblSelectedCourses.Columns.Add("CourseCode");
        tblSelectedCourses.Columns.Add("SemesterNo");
        tblSelectedCourses.Columns.Add("SemesterName");
        string XMLPath=string .Empty;
        if (rbFall.Checked)
        {
            XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Fall_" + ddlYear.SelectedValue + ".xml");
        }
        else if (rbSpring.Checked)
        {
            XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Spring_" + ddlYear.SelectedValue + ".xml");
        }
        if (System.IO.File.Exists(XMLPath))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLPath);
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
                    row["SemesterNo"] = courseList.Item(j).Attributes["SemesterNo"].Value;
                    row["SemesterName"] = courseList.Item(j).Attributes["SemesterName"].Value;
                    tblSelectedCourses.Rows.Add(row);
                    j++;
                }
                i++;
            }
        }
        ////////////////////////////////////////////
        //   Finding All Courses That Are availabel in Specific Semester And Program
        DataTable dtCourse = new DataTable();
        dtCourse = LogicKernal.Course.GetCourseBySemesterNoProgramID(Convert.ToInt32(strSemesterId), Convert.ToInt32(strProgramID));
        ///////////////////////////////////////////
        ddlCourses.DataTextField = "CourseName";
        ddlCourses.DataValueField = "CourseCode";
        ddlCourses.DataSource = dtCourse;
        ddlCourses.DataBind();
        //  Finding Avilable Courses That Are Available to Select for Visiter
        DataTable AvailabelCoursesList = new DataTable();
        AvailabelCoursesList.Columns.Add("CourseCode");
        AvailabelCoursesList.Columns.Add("CourseName");
        AvailabelCoursesList.Columns.Add("CourseCreditHours");
        int x = 0;
        while (x < tblSelectedCourses.Rows.Count)
        {
            string selCourse = tblSelectedCourses.Rows[x]["CourseCode"].ToString();
            int y=0;
            while (y < dtCourse.Rows.Count)
            {
                string semCourse = dtCourse.Rows[y]["CourseCode"].ToString();
                if (selCourse == semCourse )
                {
                    ddlCourses.Items[y].Enabled = false;  
                }
                y++;
            }
            x++;
        }
        ////////////////////////////////////////////////////////////////////
    }

    protected void btnAddCourse_Click(object sender, EventArgs e)
    {
        if (ddlCourses.Items.Count > 0 && ddlCourses .SelectedItem .Enabled != false )
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CourseCode");
            dt.Columns.Add("CourseName");
            dt.Columns.Add("CourseCreditHours");

            String CourseC = ddlCourses.SelectedValue;
            String CourseN = ddlCourses.SelectedItem.Text;
            String CourseCreditH = lblCreditHrs.Text;
            DataRow row = dt.NewRow();
            row["CourseCode"] = CourseC;
            row["CourseName"] = CourseN;
            row["CourseCreditHours"] = CourseCreditH;
            dt.Rows.Add(row);

            SelectedCourses = dt;


            string path = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string year = ddlYear.SelectedValue;
            string smsterName;
            if (rbSpring.Checked)
            {
                smsterName = "Spring";
            }
            else
            {
                smsterName = "Fall";
            }
            if (!File.Exists(path + smsterName + "_" + year + ".xml"))
            {
                XmlDocument docCreate = new XmlDocument();
                XmlNode docNode = docCreate.CreateXmlDeclaration("1.0", "UTF-8", null);
                docCreate.AppendChild(docNode);
                XmlElement IUBFacultyRequestionForm = docCreate.CreateElement("IUBFacultyRequestionForm");
                docCreate.AppendChild(IUBFacultyRequestionForm);
                docCreate.Save(path + smsterName + "_" + year + ".xml");
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            DataTable SelectedCourse = SelectedCourses;
            XmlNode MainNode = doc.SelectSingleNode("//IUBFacultyRequestionForm");
            XmlNodeList TeacherNode = doc.GetElementsByTagName("Teacher");
            int match = 0;
            int i = 0;
            while (i < TeacherNode.Count)
            {
                string tempVal = TeacherNode.Item(i).Attributes["Name"].Value;
                if (tempVal == ddlTeacherName.SelectedItem.Text)
                {
                    match = 1;
                    i = TeacherNode.Count;
                }
                i++;
            }
            if (MainNode.ChildNodes.Count == 0 || match == 0)
            {
                XmlElement TeacherElement = doc.CreateElement("Teacher");
                TeacherElement.SetAttribute("Name", ddlTeacherName.SelectedItem.Text);
                TeacherElement.SetAttribute("Designation", "Lecturer");
                TeacherElement.SetAttribute("Department", lblDepartmentName.Text);
                TeacherElement.SetAttribute("Status", "Visiting");
                foreach (DataRow dr in SelectedCourse.Rows)
                {
                    string CourseCode = dr["CourseCode"].ToString();
                    string CourseName = dr["CourseName"].ToString();
                    string CourseCreditHours = dr["CourseCreditHours"].ToString();
                    XmlElement Course = doc.CreateElement("Course");
                    Course.SetAttribute("TitleOfCourse", CourseName);
                    Course.SetAttribute("CourseCode", CourseCode);
                    Course.SetAttribute("CourseCreditHrs", CourseCreditHours);
                    Course.SetAttribute("CourseType", "Visiting");
                    Course.SetAttribute("SemesterNo", ddlPrograms.SelectedItem.Text.Split(':')[1]);
                    Course.SetAttribute("SemesterName", ddlPrograms.SelectedItem.Text.Split(':')[0]);
                    Course.SetAttribute("Year", ddlYear.SelectedValue);
                    TeacherElement.AppendChild(Course);
                }
                MainNode.AppendChild(TeacherElement);
            }
            else
            {
                XmlNode TeacherEleme = doc.SelectSingleNode("IUBFacultyRequestionForm/Teacher[@Name='" + ddlTeacherName.SelectedItem.Text + "']");
                foreach (DataRow dr in SelectedCourse.Rows)
                {
                    string CourseCode = dr["CourseCode"].ToString();
                    string CourseName = dr["CourseName"].ToString();
                    string CourseCreditHours = dr["CourseCreditHours"].ToString();
                    XmlElement Course = doc.CreateElement("Course");
                    Course.SetAttribute("TitleOfCourse", CourseName);
                    Course.SetAttribute("CourseCode", CourseCode);
                    Course.SetAttribute("CourseCreditHrs", CourseCreditHours);
                    Course.SetAttribute("CourseType", "Visiting");
                    Course.SetAttribute("SemesterNo", ddlPrograms.SelectedItem.Text.Split(':')[1]);
                    Course.SetAttribute("SemesterName", ddlPrograms.SelectedItem.Text.Split(':')[0]);
                    Course.SetAttribute("Year", ddlYear.SelectedValue);
                    TeacherEleme.AppendChild(Course);
                }
            }
            doc.Save(path + smsterName + "_" + year + ".xml");
            lblSaveMessage.ForeColor = System.Drawing.Color.Green;
            lblSaveMessage.Text = "Course Has Successfully Been Assigned!";
            loadDDLCourses();
            loadInSelectedArea();
        }
        else
        {
            lblSaveMessage.ForeColor = System.Drawing.Color.Red ;
            lblSaveMessage.Text = "Course Is Not Available To Assign!";
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDDLCourses();
        loadInSelectedArea();
    }
    protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        updateLblCouresCreditHrs();
        lblSaveMessage.Text = "";
    }

    private void updateLblCouresCreditHrs()
    {
        string strSemesterId = ddlPrograms.SelectedItem.Text.Split(':')[1];
        DataTable dtPrograms = new DataTable();
        dtPrograms = LogicKernal.Programs.GetProgramByDepartmentID(Convert.ToInt32(lblDepartmentID.Text));
        string strProgramID = string.Empty;
        string strProgramName = string.Empty;
        for (int i = 0; i < dtPrograms.Rows.Count; i++)
        {
            strProgramID = dtPrograms.Rows[i]["ProgramID"].ToString();
            strProgramName = dtPrograms.Rows[i]["ProgramName"].ToString();
            if (strProgramName == ddlPrograms.SelectedItem.Text.Split(':')[0])
            {
                i = dtPrograms.Rows.Count;
            }
        }
        DataTable dtCourse = new DataTable();
        dtCourse = LogicKernal.Course.GetCourseBySemesterNoProgramID(Convert.ToInt32(strSemesterId), Convert.ToInt32(strProgramID));
        int z = 0;
        while (z < dtCourse.Rows.Count)
        {
            string courseName = dtCourse.Rows[z]["CourseName"].ToString();
            if (courseName == ddlCourses.SelectedItem.Text)
            {
                lblCreditHrs.Text = dtCourse.Rows[z]["CreditHours"].ToString();
            }
            z++;
        }
    }
    protected void ddlCourses_DataBound(object sender, EventArgs e)
    {
        updateLblCouresCreditHrs();
        if (rbFall.Checked)
        {
            ShowAllCoursesControl.XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Fall_" + ddlYear.SelectedValue + ".xml");
        }
        else if (rbSpring.Checked)
        {
            ShowAllCoursesControl. XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Spring_" + ddlYear.SelectedValue + ".xml");
        }
        ShowAllCoursesControl.loadData();
        ShowAllCoursesControl.Visible = true;
    }
    protected void btnGenrateRF_Click(object sender, EventArgs e)
    {
        DataTable RequestinData = new DataTable();
        RequestinData.Columns.Add("TitleOfCourse");
        RequestinData.Columns.Add("CourseCode");
        RequestinData.Columns.Add("CourseCreditHrs");
        RequestinData.Columns.Add("CourseType");

        DataRow row = RequestinData.NewRow();
        row["TitleOfCourse"] = ddlTeacherName.SelectedItem .Text;//set the teacher name
        row["CourseCode"] = "Lecturer";//set the taecher Desegnation
        row["CourseCreditHrs"] = lblDepartmentName.Text;//set the teacher Department
        string XMLPath=string .Empty;
        if (rbFall.Checked)
        {
            XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Fall_" + ddlYear.SelectedItem .Text  + ".xml");
            row["CourseType"] = "Fall-" + ddlYear.SelectedItem.Text;//set the semester/session
        }
        else if (rbSpring.Checked)
        {
            XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Spring_" + ddlYear.SelectedItem.Text + ".xml");

            row["CourseType"] = "Spring-" + ddlYear.SelectedItem.Text;//set the semester/session
        }
    //    row["CourseType"] = "Spring-2014";//set the semester/session
        RequestinData.Rows.Add(row);
        XmlDocument doc = new XmlDocument();
        if (System.IO.File.Exists(XMLPath))
        {
            doc.Load(XMLPath);
            XmlNode TeacherNode = doc.SelectSingleNode("//Teacher[@Name='" + ddlTeacherName.SelectedItem.Text + "']");
            if (TeacherNode != null)
            {
                XmlNodeList SelectedCoursesNodes = TeacherNode.ChildNodes;
                if (SelectedCoursesNodes.Count != 0)
                {
                    int j = 0;
                    while (j < SelectedCoursesNodes.Count)
                    {
                        DataRow dr = RequestinData.NewRow();
                        dr["CourseCode"] = SelectedCoursesNodes.Item(j).Attributes["CourseCode"].Value;
                        dr["TitleOfCourse"] = SelectedCoursesNodes.Item(j).Attributes["TitleOfCourse"].Value;
                        dr["CourseCreditHrs"] = SelectedCoursesNodes.Item(j).Attributes["CourseCreditHrs"].Value;
                        dr["CourseType"] = SelectedCoursesNodes.Item(j).Attributes["CourseType"].Value;
                        RequestinData.Rows.Add(dr);
                        j++;
                    }
                }
            }
        }
        Session[ddlTeacherName .SelectedItem .Text  + "Rsaifoia000F"] = RequestinData;
        Response.Write("<script>window.open('PrintRequestionForm.aspx?tr=" + ddlTeacherName.SelectedItem.Text + "','_blank');</script>");
    }

    private void loadInSelectedArea()
    {
        DataTable selectdDT = new DataTable();
        selectdDT.Columns.Add("CourseCode");
        selectdDT.Columns.Add("CourseName");
        selectdDT.Columns.Add("CourseClass");
        selectdDT.Columns.Add("CourseType");
        XmlDocument doc = new XmlDocument();
        string XMLPath = string.Empty;
        if (rbFall.Checked)
        {
            XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Fall_" + ddlYear.SelectedItem.Text + ".xml");
            
        }
        else if (rbSpring.Checked)
        {
            XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Spring_" + ddlYear.SelectedItem.Text + ".xml");

        }
        if (System.IO.File.Exists(XMLPath))
        {
            doc.Load(XMLPath);
            XmlNode TeacherNode = doc.SelectSingleNode("//Teacher[@Name='" + ddlTeacherName .SelectedItem .Text  + "']");
            if (TeacherNode != null)
            {
                XmlNodeList SelectedCoursesNodes = TeacherNode.ChildNodes;
                if (SelectedCoursesNodes.Count != 0)
                {
                    int j = 0;
                    while (j < SelectedCoursesNodes.Count)
                    {
                        DataRow dr = selectdDT.NewRow();
                        dr["CourseCode"] = SelectedCoursesNodes.Item(j).Attributes["CourseCode"].Value;
                        dr["CourseName"] = SelectedCoursesNodes.Item(j).Attributes["TitleOfCourse"].Value;
                        dr["CourseClass"] = SelectedCoursesNodes.Item(j).Attributes["SemesterName"].Value + ":" + SelectedCoursesNodes.Item(j).Attributes["SemesterNo"].Value;
                        dr["CourseType"] = SelectedCoursesNodes.Item(j).Attributes["CourseType"].Value;
                        selectdDT.Rows.Add(dr);
                        j++;
                    }
                }
            }
        }
        gvSelectedCourses.DataSource = selectdDT;
        gvSelectedCourses.DataBind();
    }
    protected void ddlTeacherName_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadInSelectedArea();
    }
    protected void gvSelectedCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string DCourse = gvSelectedCourses.Rows[e.RowIndex].Cells[0].Text;
        XmlDocument doc = new XmlDocument();
        string XMLPath = string.Empty;
        if (rbFall.Checked)
        {
            XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Fall_" + ddlYear.SelectedItem.Text + ".xml");

        }
        else if (rbSpring.Checked)
        {
            XMLPath = Server.MapPath("XMLStorage/IUBFacultyRequestionForm/" + lblDepartmentName.Text + "/" + "Spring_" + ddlYear.SelectedItem.Text + ".xml");

        }
        doc.Load(XMLPath);
        XmlNode DeletedNode = doc.SelectSingleNode("//Teacher[@Name='" + ddlTeacherName .SelectedItem .Text  + "']/Course[@CourseCode='" + DCourse + "']");
        if (DeletedNode != null)
        {
            DeletedNode.ParentNode.RemoveChild(DeletedNode);
        }
        doc.Save(XMLPath);
        loadInSelectedArea();
        ShowAllCoursesControl.XMLPath = XMLPath;
        ShowAllCoursesControl.loadData();
        loadDDLCourses();
    }
}