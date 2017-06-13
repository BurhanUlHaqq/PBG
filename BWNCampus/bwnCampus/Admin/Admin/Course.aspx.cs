using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_Course : System.Web.UI.Page
{
    TextBox txtCourseName = new TextBox();
    TextBox txtCourseCode = new TextBox();
    TextBox txtSemester = new TextBox();
    TextBox txtCreditHours = new TextBox();
    TextBox txtDescription = new TextBox();
    Button btnSave = new Button();
    GridView grdCourse = new GridView();
    Label lblMessage = new Label();
    DataTable dtCourse = new DataTable();
    Label lblProgramName = new Label();

    int intCourseID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("Login.aspx");
        artCourse.DataBind();
        foreach (Control ctrl in artCourse.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtCourseName")
                    txtCourseName = (TextBox)ctrl;
                if (ctrl.ID == "txtCourseCode")
                    txtCourseCode = (TextBox)ctrl;
                if (ctrl.ID == "txtCreditHours")
                    txtCreditHours = (TextBox)ctrl;
                if (ctrl.ID == "txtSemester")
                    txtSemester = (TextBox)ctrl;
                if (ctrl.ID == "txtDescription")
                    txtDescription = (TextBox)ctrl;
            }

            if (ctrl is Button)
            {
                btnSave = (Button)ctrl;
                btnSave.Click += new EventHandler(btnSave_Click);
            }

            if (ctrl is GridView)
            {
                grdCourse = (GridView)ctrl;
                grdCourse.RowCommand += new GridViewCommandEventHandler(grdCourse_RowCommand);
            }

            if (ctrl is Label)
            {
                if (ctrl.ID == "lblProgramName")
                    lblProgramName = (Label)ctrl;
                if (ctrl.ID == "lblMessage")
                    lblMessage = (Label)ctrl;
            }
        }

        LoadData();
    }

    private void LoadData()
    {
        if (Session["ProgramID"] != null)
        {
            if (Session["CourseID"] != null)
            {
                dtCourse = LogicKernal.Course.GetCourseByID(Convert.ToInt32(Session["CourseID"]));
                if (dtCourse.Rows.Count > 0)
                {
                    txtCourseName.Text = dtCourse.Rows[0]["CourseName"].ToString();
                    txtCourseCode.Text = dtCourse.Rows[0]["CourseCode"].ToString();
                    txtCreditHours.Text = dtCourse.Rows[0]["CreditHours"].ToString();
                    txtSemester.Text = dtCourse.Rows[0]["SemesterNO"].ToString();
                    txtDescription.Text = dtCourse.Rows[0]["CourseDescription"].ToString();
                }
            }
            lblProgramName.Text = Session["ProgramName"].ToString();
            dtCourse = LogicKernal.Course.GetAllCourse();
            grdCourse.DataSource = dtCourse;
            grdCourse.DataBind();
        }   
    }

    private void btnSave_Click(Object sender, EventArgs e)
    {
        BusinessEntities.Course objCourse = new BusinessEntities.Course();
        objCourse.CourseID = intCourseID;
        objCourse.CourseName = txtCourseName.Text;
        objCourse.CourseCode = txtCourseCode.Text;
        objCourse.CreditHours = txtCreditHours.Text;
        objCourse.SemesterNO = Convert.ToInt32(txtSemester.Text);
        objCourse.CourseDescription = txtDescription.Text;
        objCourse.ProgramID = Convert.ToInt32(Session["ProgramID"]);
        objCourse.CreatedUserID = Convert.ToInt32(Session["UserID"]);
        objCourse.CreatedDateTime = System.DateTime.Now;
        if (LogicKernal.Course.InsertUpdateCourse(objCourse) > 0)
        {
            Session.Remove("CourseID");
            Response.Redirect("Course.aspx");
        }
        else
        {
            lblMessage.Visible = true;
        }
    }

    private void grdCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Session["CourseID"] = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Course.aspx");
        }
        
        if (e.CommandName == "Del")
        {
            LogicKernal.Course.DeleteCourse(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("Course.aspx");
        }
    }
}