using System.Xml;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class CourseControl : System.Web.UI.UserControl
{
    private int intSemesterId;
    private int intProgramId;
    private string strXMLPath;
    private string strTeacherUsingControl;
    private string strCourseType;
    private string strYear;
    private DataTable dtSelectedCourse;
    private string strDesignation;
    private string strDepartment;
    private string strProgram;
    public string ProgramName
    {
        get
        {
            return strProgram;
        }
        set
        {
            strProgram = value;
        }
    }
    public string DepartmentName
    {
        get
        {
            return strDepartment;
        }
        set
        {
            strDepartment = value;
        }
    }
    public string Designation
    {
        get
        {
            return strDesignation;
        }
        set
        {
            strDesignation = value;
        }
    }
    public int Semester
    {
        get
        {
            return intSemesterId;
        }
        set
        {
            intSemesterId = value;
        }
    }
    public string CourseType
    {
        get
        {
            return strCourseType;
        }
        set
        {
            strCourseType = value;
        }
    }
    public string Teacher
    {
        get
        {
            return strTeacherUsingControl;
        }
        set
        {
            strTeacherUsingControl = value;
        }
    }
    public string XMLPath
    {
        get
        {
            return strXMLPath;
        }
        set
        {
            strXMLPath = value;
        }
    }
    public string Year
    {
        get
        {
            return strYear;
        }
        set
        {
            strYear = value;
        }
    }
    public int Program
    {
        get
        {
            return intProgramId;
        }
        set
        {
            intProgramId = value;
        }
    }
    public DataTable SelectedCourse
    {
        get
        {
            return dtSelectedCourse;
        }
        set
        {
            dtSelectedCourse = value;
        }
    }

    public event okButtonClickedEventHandler okButtonClickedEvent;

    protected void BtnOk_Click(object sender, EventArgs e)
    {
        getSelectedData();
        okButtonClickedEventArgs okButtonClickedData = new okButtonClickedEventArgs(true);
        onOkButtonClickedEvent(okButtonClickedData);
    }
    public virtual void onOkButtonClickedEvent(okButtonClickedEventArgs e)
    {
        if (okButtonClickedEvent != null)
        {
            okButtonClickedEvent(this, e);
        }
    }
    public void loadData(Boolean UpdateValues)
    {
        if (UpdateValues == true)
        {
            ViewState["xmlPath"] = strXMLPath;
            ViewState["Teacher"] = strTeacherUsingControl;
            ViewState["Semester"] = intSemesterId;
            ViewState["Program"] = intProgramId;
            ViewState["year"] = strYear;
            ViewState["Depatrment"] = strDepartment;
            ViewState["Designation"] = strDesignation;
            ViewState["ProgramName"] = strProgram;
        }
        loadInSelectedArea();
        DataTable dtCourse = new DataTable();
        dtCourse = LogicKernal.Course.GetCourseBySemesterNoProgramID(Convert.ToInt32(ViewState["Semester"]), Convert.ToInt32(ViewState["Program"]));
        labSemesterNo.Text = Convert.ToString(Convert.ToInt32(ViewState["Semester"]));
        lstCourses.DataSource = dtCourse;
        lstCourses.DataBind();
        XmlDocument doc = new XmlDocument();
        if (System.IO.File.Exists(ViewState["xmlPath"].ToString()))
        {
            doc.Load(ViewState["xmlPath"].ToString());
            XmlNodeList SelectedCoursesNodes = doc.SelectNodes("IUBFacultyRequestionForm/Teacher/Course");
            if (SelectedCoursesNodes.Count != 0)
            {
                int j = 0;
                while (j < SelectedCoursesNodes.Count)
                {
                    string strCourseCode = SelectedCoursesNodes.Item(j).Attributes["CourseCode"].Value;
                    int i = 0;
                    while (i < lstCourses.Items.Count)
                    {
                        DataListItem dl = lstCourses.Items[i];
                        CheckBox CourseCheck = ((CheckBox)dl.FindControl("chkCourse"));
                        String CourseCode = ((Label)dl.FindControl("lblCourseCode")).Text;

                        if (CourseCode == strCourseCode)
                        {
                            CourseCheck.Enabled = false;
                        }
                        i++;
                    }
                    j++;
                }

            }
        }
    }
    private void getSelectedData()
    {
        int i = 0;
        DataTable dt = new DataTable();
        dt.Columns.Add("CourseCode");
        dt.Columns.Add("CourseName");
        dt.Columns.Add("CourseCreditHours");
        while (i < lstCourses.Items.Count)
        {
            DataListItem dl = lstCourses.Items[i];
            CheckBox CourseCheck = ((CheckBox)dl.FindControl("chkCourse"));
            if (CourseCheck.Checked == true)
            {
                String CourseCode = ((Label)dl.FindControl("lblCourseCode")).Text;
                String CourseName = ((Label)dl.FindControl("lblCourseName")).Text;
                String CourseCreditHours = ((Label)dl.FindControl("lblCreditHours")).Text;
                DataRow dr = dt.NewRow();
                dr["CourseCode"] = CourseCode;
                dr["CourseName"] = CourseName;
                dr["CourseCreditHours"] = CourseCreditHours;
                dt.Rows.Add(dr);
            }
            i++;
        }
        dtSelectedCourse = dt;
    }
    private void loadInSelectedArea()
    {
        DataTable selectdDT = new DataTable();
        selectdDT.Columns.Add("CourseCode");
        selectdDT.Columns.Add("CourseName");
        selectdDT.Columns.Add("CourseClass");
        selectdDT.Columns.Add("CourseType");
        XmlDocument doc = new XmlDocument();
        if (System.IO.File.Exists(ViewState["xmlPath"].ToString()))
        {
            doc.Load(ViewState["xmlPath"].ToString());
            XmlNode TeacherNode = doc.SelectSingleNode("//Teacher[@Name='" + ViewState["Teacher"].ToString() + "']");
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
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void lstCourseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        strCourseType = lstCourseType.SelectedValue;
    }
    protected void lstCourseType_Load(object sender, EventArgs e)
    {
        strCourseType = lstCourseType.SelectedValue;
    }
    protected void gvSelectedCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string DCourse = gvSelectedCourses.Rows[e.RowIndex].Cells[0].Text;
        XmlDocument doc = new XmlDocument();
        doc.Load(ViewState["xmlPath"].ToString());
        XmlNode DeletedNode = doc.SelectSingleNode("//Teacher[@Name='" + ViewState["Teacher"] + "']/Course[@CourseCode='" + DCourse + "']");
        if (DeletedNode != null)
        {
            DeletedNode.ParentNode.RemoveChild(DeletedNode);
        }
        doc.Save(ViewState["xmlPath"].ToString());
        loadData(false);
    }
    protected void btnGenrateRF_Click(object sender, EventArgs e)
    {
        DataTable RequestinData = new DataTable();
        RequestinData.Columns.Add("TitleOfCourse");
        RequestinData.Columns.Add("CourseCode");
        RequestinData.Columns.Add("CourseCreditHrs");
        RequestinData.Columns.Add("CourseType");

        DataRow row = RequestinData.NewRow();
        row["TitleOfCourse"] = ViewState["Teacher"];//set the teacher name
        row["CourseCode"] = ViewState["Designation"];//set the taecher Desegnation
        row["CourseCreditHrs"] = ViewState["Depatrment"];//set the teacher Department
        row["CourseType"] = ViewState["ProgramName"];//set the semester/session
        RequestinData.Rows.Add(row);
        XmlDocument doc = new XmlDocument();
        if (System.IO.File.Exists(ViewState["xmlPath"].ToString()))
        {
            doc.Load(ViewState["xmlPath"].ToString());
            XmlNode TeacherNode = doc.SelectSingleNode("//Teacher[@Name='" + ViewState["Teacher"].ToString() + "']");
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
        Session[ViewState["Teacher"].ToString() + "Rsaifoia000F"] = RequestinData;
        Response.Write("<script>window.open('PrintRequestionForm.aspx?tr=" + ViewState["Teacher"] + "','_blank');</script>");
    }
}
public class okButtonClickedEventArgs : EventArgs
{
    private bool isClicked;
    public bool IsBtnClicked
    {
        get
        {
            return isClicked;
        }
    }
    public okButtonClickedEventArgs(bool _isClicked)
    {
        this.isClicked = _isClicked;
    }
}
public delegate void okButtonClickedEventHandler(object sender, okButtonClickedEventArgs e);