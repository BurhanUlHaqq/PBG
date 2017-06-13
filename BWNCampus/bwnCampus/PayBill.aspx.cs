using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;

public partial class PayBill : System.Web.UI.Page
{
    int intFacultyID;
    DataTable dtFaculty;
    //Variables used to store data in xml file IUBFacultyRequestionForm.xml
    string strSemesterId = string.Empty;
    string teacherStatus = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlYear.Items.Count == 0)
        {
            int y = DateTime.Now.Year - 3;
            while (y <= DateTime.Now.Year)
            {
                ddlYear.Items.Add(y + "");
                y++;
                ddlYear.SelectedIndex = 3;
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
            }
        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void rbSpring_CheckedChanged(object sender, EventArgs e)
    {
        UpdateDDLAssignedCourses();
        loadAccountNoIfAvailable();
    }
    private void loadAccountNoIfAvailable()
    {
        string path = "";
        if (rbFall.Checked)
        {
            path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/" + "Fall_" + ddlYear.SelectedItem.Text + ".xml");

        }
        else if (rbSpring.Checked)
        {
            path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/" + "Spring_" + ddlYear.SelectedItem.Text + ".xml");

        }
        if (File.Exists(path))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode mainNode = doc.SelectSingleNode("//IUBFacultyPaymentBills");
            txtIncomeTaxRate.Text = mainNode.Attributes["IncomeTaxRate"].Value;
            XmlNode TeacherNode = doc.SelectSingleNode("//Teacher[@Name='" + lblTeacherName.Text + "']");
            if (TeacherNode != null)
            {
                txtAccountNo.Text = TeacherNode.Attributes["HBLBankAcountNo"].Value;
                txtRatePerLecture.Text = TeacherNode.Attributes["RatePerLecture"].Value;
                btnAccountNoSave.Visible = true;
                if (txtAccountNo.Text != "")
                {
                    btnPaymentBillCopy.Visible = true;
                }
            }
            else
            {
                txtAccountNo.Text = "";
                txtRatePerLecture.Text = "";
            }
        }
        else
        {
            txtAccountNo.Text = "";
            txtIncomeTaxRate.Text = "";
            txtRatePerLecture.Text = "";
        }
    }
    protected void rbFall_CheckedChanged(object sender, EventArgs e)
    {
        UpdateDDLAssignedCourses();
        loadAccountNoIfAvailable();
    }
    private void UpdateDDLAssignedCourses()
    {
        DataTable selectdDT = new DataTable();
        selectdDT.Columns.Add("CourseCode");
        selectdDT.Columns.Add("CourseName");
        selectdDT.Columns.Add("CourseClass");
        selectdDT.Columns.Add("CourseType");
        selectdDT.Columns.Add("CourseCreditHrs");
        selectdDT.Columns.Add("SemesterNo");
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
            XmlNode TeacherNode = doc.SelectSingleNode("//Teacher[@Name='" + lblTeacherName.Text + "']");
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
                        dr["CourseCreditHrs"] = SelectedCoursesNodes.Item(j).Attributes["CourseCreditHrs"].Value;
                        dr["SemesterNo"] = SelectedCoursesNodes.Item(j).Attributes["SemesterNo"].Value;
                        selectdDT.Rows.Add(dr);
                        j++;
                    }
                }
            }
        }
        ViewState["SelectedCourses"] = selectdDT;
        gvSelectedCourses.DataSource = selectdDT;
        gvSelectedCourses.DataBind();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateDDLAssignedCourses();
        loadAccountNoIfAvailable();
    }
    protected void btnAccountNoSave_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string year = ddlYear.SelectedValue;
        string smsterName = "";
        if (rbSpring.Checked)
        {
            smsterName = "Spring";
        }
        else if (rbFall.Checked)
        {
            smsterName = "Fall";
        }
        if (!File.Exists(path + smsterName + "_" + year + ".xml") && smsterName != "")
        {
            XmlDocument docCreate = new XmlDocument();
            XmlNode docNode = docCreate.CreateXmlDeclaration("1.0", "UTF-8", null);
            docCreate.AppendChild(docNode);
            XmlElement IUBFacultyPaymentBill = docCreate.CreateElement("IUBFacultyPaymentBills");
            IUBFacultyPaymentBill.SetAttribute("IncomeTaxRate", txtIncomeTaxRate.Text);
            docCreate.AppendChild(IUBFacultyPaymentBill);
            docCreate.Save(path + smsterName + "_" + year + ".xml");
        }
        XmlDocument doc = new XmlDocument();
        doc.Load(path + smsterName + "_" + year + ".xml");
        XmlNode MainNode = doc.SelectSingleNode("//IUBFacultyPaymentBills");
        MainNode.Attributes["IncomeTaxRate"].Value = txtIncomeTaxRate.Text;
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
            TeacherElement.SetAttribute("HBLBankAcountNo", txtAccountNo.Text);
            TeacherElement.SetAttribute("RatePerLecture", txtRatePerLecture.Text);
            MainNode.AppendChild(TeacherElement);
        }
        else
        {
            XmlNode TeacherEleme = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            TeacherEleme.Attributes["HBLBankAcountNo"].Value = txtAccountNo.Text;
            TeacherEleme.Attributes["RatePerLecture"].Value = txtRatePerLecture.Text;
        }
        lblAccountMessage.Text = "Updated Successfully!";
        doc.Save(path + smsterName + "_" + year + ".xml");
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
        XmlNode DeletedNode = doc.SelectSingleNode("//Teacher[@Name='" + lblTeacherName.Text + "']/Course[@CourseCode='" + DCourse + "']");
        if (DeletedNode != null)
        {
            DeletedNode.ParentNode.RemoveChild(DeletedNode);
        }
        doc.Save(XMLPath);
        UpdateDDLAssignedCourses();
    }
    protected void WizardBillSteps_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (WizardBillSteps.ActiveStepIndex == 0)
        {
            btnPaymentBillCopy.Visible = false;
            updateXmlDatabase();
            string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/");
            string year = ddlYear.SelectedValue;
            string smsterName = "";
            if (rbSpring.Checked)
            {
                smsterName = "Spring";
            }
            else if (rbFall.Checked)
            {
                smsterName = "Fall";
            }
            if (File.Exists(path + smsterName + "_" + year + ".xml") && smsterName != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path + smsterName + "_" + year + ".xml");
                XmlNodeList TeacherNode = doc.GetElementsByTagName("Teacher");
                int match = 0;
                int t = 0;
                while (t < TeacherNode.Count)
                {
                    string tempVal = TeacherNode.Item(t).Attributes["Name"].Value;
                    if (tempVal == lblTeacherName.Text)
                    {
                        match = t;
                        t = TeacherNode.Count;
                    }
                    t++;
                }
                XmlNode loginTeacher = TeacherNode.Item(match);
                XmlNode sem = loginTeacher.FirstChild;
                XmlNodeList courselist = sem.ChildNodes;
                int i = 0;
                DataTable dt = new DataTable();
                dt.Columns.Add("CourseCode");
                dt.Columns.Add("CourseName");
                while (i < courselist.Count)
                {
                    DataRow row = dt.NewRow();
                    row["CourseCode"] = courselist.Item(i).Attributes["CourseCode"].Value;
                    row["CourseName"] = courselist.Item(i).Attributes["TitleOfCourse"].Value;
                    dt.Rows.Add(row);
                    i++;
                }
                AttendanceList.DataSource = dt;
                AttendanceList.DataBind();
            }

        }

    }
    private void updateXmlDatabase()
    {
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string year = ddlYear.SelectedValue;
        string smsterName = "";
        if (rbSpring.Checked)
        {
            smsterName = "Spring";
        }
        else if (rbFall.Checked)
        {
            smsterName = "Fall";
        }
        if (!File.Exists(path + smsterName + "_" + year + ".xml") && smsterName != "")
        {
            XmlDocument docCreate = new XmlDocument();
            XmlNode docNode = docCreate.CreateXmlDeclaration("1.0", "UTF-8", null);
            docCreate.AppendChild(docNode);
            XmlElement IUBFacultyPaymentBill = docCreate.CreateElement("IUBFacultyPaymentBills");
            IUBFacultyPaymentBill.SetAttribute("IncomeTaxRate", txtIncomeTaxRate.Text);
            docCreate.AppendChild(IUBFacultyPaymentBill);
            docCreate.Save(path + smsterName + "_" + year + ".xml");
        }
        XmlDocument doc = new XmlDocument();
        doc.Load(path + smsterName + "_" + year + ".xml");
        XmlNode MainNode = doc.SelectSingleNode("//IUBFacultyPaymentBills");
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
            TeacherElement.SetAttribute("HBLBankAcountNo", txtAccountNo.Text);
            TeacherElement.SetAttribute("RatePerLecture", txtRatePerLecture.Text);
            XmlElement SemesterElement = doc.CreateElement("Semester");
            SemesterElement.SetAttribute("SemesterName", smsterName);
            SemesterElement.SetAttribute("Year", ddlYear.SelectedItem.Text);

            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["SelectedCourses"];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["CourseType"].ToString() != "Work Load")
                {
                    XmlElement CourseElement = doc.CreateElement("Course");
                    CourseElement.SetAttribute("TitleOfCourse", dr["CourseName"].ToString());
                    CourseElement.SetAttribute("CourseCode", dr["CourseCode"].ToString());
                    CourseElement.SetAttribute("CourseCreditHrs", dr["CourseCreditHrs"].ToString());
                    CourseElement.SetAttribute("CourseType", dr["CourseType"].ToString());
                    CourseElement.SetAttribute("SemesterNo", dr["SemesterNo"].ToString());
                    CourseElement.SetAttribute("SemesterName", (dr["CourseClass"].ToString()).Split(':')[0]);
                    SemesterElement.AppendChild(CourseElement);
                }
            }
            TeacherElement.AppendChild(SemesterElement);
            MainNode.AppendChild(TeacherElement);
        }
        else
        {
            XmlNode TeacherEleme = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            TeacherEleme.ParentNode.RemoveChild(TeacherEleme);
            doc.Save(path + smsterName + "_" + year + ".xml");
            XmlElement TeacherElement = doc.CreateElement("Teacher");
            TeacherElement.SetAttribute("Name", lblTeacherName.Text);
            TeacherElement.SetAttribute("Designation", lblDesignation.Text);
            TeacherElement.SetAttribute("Department", lblDepartmentName.Text);
            TeacherElement.SetAttribute("Status", "");
            TeacherElement.SetAttribute("HBLBankAcountNo", txtAccountNo.Text);
            TeacherElement.SetAttribute("RatePerLecture", txtRatePerLecture.Text );
            XmlElement SemesterElement = doc.CreateElement("Semester");
            SemesterElement.SetAttribute("SemesterName", smsterName);
            SemesterElement.SetAttribute("Year", ddlYear.SelectedItem.Text);

            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["SelectedCourses"];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["CourseType"].ToString() != "Work Load")
                {
                    XmlElement CourseElement = doc.CreateElement("Course");
                    CourseElement.SetAttribute("TitleOfCourse", dr["CourseName"].ToString());
                    CourseElement.SetAttribute("CourseCode", dr["CourseCode"].ToString());
                    CourseElement.SetAttribute("CourseCreditHrs", dr["CourseCreditHrs"].ToString());
                    CourseElement.SetAttribute("CourseType", dr["CourseType"].ToString());
                    CourseElement.SetAttribute("SemesterNo", dr["SemesterNo"].ToString());
                    CourseElement.SetAttribute("SemesterName", (dr["CourseClass"].ToString()).Split(':')[0]);
                    SemesterElement.AppendChild(CourseElement);
                }
            }
            TeacherElement.AppendChild(SemesterElement);
            MainNode.AppendChild(TeacherElement);
        }
        lblAccountMessage.Text = "Updated Successfully!";
        doc.Save(path + smsterName + "_" + year + ".xml");
    }
    protected void AttendanceList_CancelCommand(object source, DataListCommandEventArgs e)
    {
        AttendanceList.EditItemIndex = -1;
        CaledarDate.Visible = false;
        AttendanceDateList.Visible = false;
        lblSelectedCourse.Text = "";
    }
    protected void AttendanceList_EditCommand(object source, DataListCommandEventArgs e)
    {
        lblSelectedCourse.Text  = ((Label)e.Item.FindControl("lblCourseCode")).Text;
        AttendanceList.EditItemIndex = e.Item.ItemIndex;
        CaledarDate.Visible = true;
        AttendanceDateList.Visible = true;
    }
    protected void CaledarDate_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth || e.Day.IsWeekend)
        {
            e.Day.IsSelectable = false;
            e.Cell.Font.Strikeout = true;
        }
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/");
        string year = ddlYear.SelectedValue;
        string smsterName = "";
        if (rbSpring.Checked)
        {
            smsterName = "Spring";
        }
        else if (rbFall.Checked)
        {
            smsterName = "Fall";
        }
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNode selectedCourse = selectedSemester.SelectSingleNode("Course[@CourseCode='" + lblSelectedCourse.Text + "']");
            XmlNodeList MonthNode = selectedCourse.SelectNodes("Month");
            int m = 0;
            while (m < MonthNode.Count)
            {
                string MonthName = MonthNode.Item(m).Attributes["Name"].Value;
                int d = 0;
                XmlNodeList DateNode = MonthNode.Item(m).SelectNodes("Date");
                while (d < DateNode.Count)
                {
                    string DateName = DateNode.Item(d).InnerText;
                    string Monthdate= DateName + "/" + MonthName;
                    string selectedDate = e.Day .Date .ToShortDateString();
                    string SelDate = selectedDate.Split('/')[1];
                    string SelMonth = selectedDate.Split('/')[0];
                    if ((SelDate + "/" + SelMonth) == Monthdate)
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.Font.Strikeout = true;
                    }
                    d++;
                }
                m++;
            }
        }
    }
    protected void CaledarDate_SelectionChanged(object sender, EventArgs e)
    {
        addAttandenceToXMLFile();
        updateAttendanceDateList();
    }
    private void updateAttendanceDateList()
    {
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/");
        string year = ddlYear.SelectedValue;
        string smsterName = "";
        if (rbSpring.Checked)
        {
            smsterName = "Spring";
        }
        else if (rbFall.Checked)
        {
            smsterName = "Fall";
        }
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNode selectedCourse = selectedSemester.SelectSingleNode("Course[@CourseCode='" + lblSelectedCourse.Text + "']");
            XmlNodeList MonthNode = selectedCourse.SelectNodes("Month");
            DataTable dt = new DataTable();
            dt.Columns.Add("Attandence");
            int m = 0;
            while (m < MonthNode.Count)
            {
                string MonthName = MonthNode.Item(m).Attributes["Name"].Value;
                int d = 0;
                XmlNodeList DateNode = MonthNode.Item(m).SelectNodes("Date");
                while (d < DateNode.Count)
                {
                    string DateName = DateNode.Item(d).InnerText;
                    DataRow row = dt.NewRow();
                    row["Attandence"] = DateName + "/" + MonthName;
                    dt.Rows.Add(row);
                    d++;
                }
                m++;
            }
            AttendanceDateList.DataSource = dt;
            AttendanceDateList.DataBind();
        }
    }
    private void addAttandenceToXMLFile()
    {
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/");
        string year = ddlYear.SelectedValue;
        string smsterName = "";
        if (rbSpring.Checked)
        {
            smsterName = "Spring";
        }
        else if (rbFall.Checked)
        {
            smsterName = "Fall";
        }
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNode selectedCourse = selectedSemester.SelectSingleNode("Course[@CourseCode='" + lblSelectedCourse.Text + "']");
            string selectedDate = CaledarDate.SelectedDate.ToShortDateString();
            string SelDate = selectedDate.Split('/')[1];
            string SelMonth = selectedDate.Split('/')[0];
            XmlNode monthNode = selectedCourse.SelectSingleNode("Month[@Name='" + SelMonth + "']");
            if (monthNode == null)
            {
                XmlElement MonthElement = doc.CreateElement("Month");
                MonthElement.SetAttribute("Name", SelMonth);
                XmlElement DateElement = doc.CreateElement("Date");
                DateElement.InnerText = SelDate;
                MonthElement.AppendChild(DateElement);
                selectedCourse.AppendChild(MonthElement);
                doc.Save(path + smsterName + "_" + year + ".xml");
                lblAttandenceMessage.Text = "<b style='color:red;'>" + CaledarDate.SelectedDate.ToShortDateString() + "</b> has successfully been added in your attendance register!";
            }
            else
            {
                XmlElement DateElement = doc.CreateElement("Date");
                DateElement.InnerText = SelDate;
                monthNode.PrependChild(DateElement);
                doc.Save(path + smsterName + "_" + year + ".xml");
                lblAttandenceMessage.Text = "<b style='color:red;'>" + CaledarDate.SelectedDate.ToShortDateString() + "</b> has successfully been added in your attendance register!";
            }
        }
        else
        {
            lblAttandenceMessage.Text = "<b style='color:red;'>Database Error!</b>";
        }
    }
    protected void AttendanceDateList_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string deletDate = ((Label)e.Item.FindControl("lblAttandenceShow")).Text;
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartmentName.Text + "/");
        string year = ddlYear.SelectedValue;
        string smsterName = "";
        if (rbSpring.Checked)
        {
            smsterName = "Spring";
        }
        else if (rbFall.Checked)
        {
            smsterName = "Fall";
        }
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNode selectedCourse = selectedSemester.SelectSingleNode("Course[@CourseCode='" + lblSelectedCourse.Text + "']");
            XmlNode MonthNode = selectedCourse.SelectSingleNode("Month[@Name='" + deletDate .Split ('/')[1]+ "']");
            XmlNodeList DateNode = MonthNode.SelectNodes("Date");
            int i = 0;
            while (i < DateNode.Count)
            {
                XmlNode DeleteNode = DateNode.Item(i);
                string DeleteNodeText = DeleteNode.InnerText;
                if (DeleteNodeText == deletDate.Split('/')[0])
                {
                    DeleteNode.ParentNode.RemoveChild(DeleteNode);
                    doc.Save(path + smsterName + "_" + year + ".xml");
                    lblAttandenceMessage.Text ="<b style='color:red'>"+deletDate+"</b> has successfully been removed from attandence register!";
                    updateAttendanceDateList();
                }
                i++;
            }
        }
    }
    protected void WizardBillSteps_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        string smsterName = "";
        if (rbSpring.Checked)
        {
            smsterName = "Spring";
        }
        else if (rbFall.Checked)
        {
            smsterName = "Fall";
        }
        Session["PaymentBill"] = lblDepartmentName.Text + ":Part Time:" + smsterName + ":" + ddlYear.SelectedItem.Text + ":" + lblTeacherName.Text + ":" + lblDesignation.Text;
        Response.Write("<script>window.open('PaymentBill.aspx','_blank');</script>");
    }

    protected void btnPaymentBillCopy_Click(object sender, EventArgs e)
    {
        string smsterName = "";
        if (rbSpring.Checked)
        {
            smsterName = "Spring";
        }
        else if (rbFall.Checked)
        {
            smsterName = "Fall";
        }
        Session["PaymentBill"] = lblDepartmentName.Text + ":Part Time:" + smsterName + ":" + ddlYear.SelectedItem.Text + ":" + lblTeacherName.Text + ":" + lblDesignation.Text;
        Response.Write("<script>window.open('PaymentBill.aspx','_blank');</script>");
    }
}