using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_Programs : System.Web.UI.Page
{
    TextBox txtTitle = new TextBox();
    TextBox txtYear = new TextBox();
    TextBox txtSemester = new TextBox();
    TextBox txtCriteria = new TextBox();
    TextBox txtFee = new TextBox();
    TextBox txtDescription = new TextBox();
    DropDownList ddlDepartment = new DropDownList();
    Button btnSave = new Button();
    GridView grdPrograms = new GridView();
    Label lblMessage = new Label();
    LinkButton lnkAddEditCourse = new LinkButton();

    int intDepartmentID = 0;
    int intProgramID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        artPrograms.DataBind();

        foreach (Control ctrl in artPrograms.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtTitle")
                    txtTitle = (TextBox)ctrl;
                if (ctrl.ID == "txtYear")
                    txtYear = (TextBox)ctrl;
                if (ctrl.ID == "txtSemester")
                    txtSemester = (TextBox)ctrl;
                if (ctrl.ID == "txtCriteria")
                    txtCriteria = (TextBox)ctrl;
                if (ctrl.ID == "txtFee")
                    txtFee = (TextBox)ctrl;
                if (ctrl.ID == "txtDescription")
                    txtDescription = (TextBox)ctrl;
            }
            if (ctrl is DropDownList)
                ddlDepartment = (DropDownList)ctrl;
            if (ctrl is Button)
            {
                btnSave = (Button)ctrl;
                btnSave.Click += new EventHandler(btnSave_Click);
            }

            if (ctrl is GridView)
            {
                grdPrograms = (GridView)ctrl;
                grdPrograms.RowCommand += new GridViewCommandEventHandler(grdPrograms_RowCommand);
            }

            if (ctrl is LinkButton)
            {
                lnkAddEditCourse = (LinkButton)ctrl;
                lnkAddEditCourse.Click += new EventHandler(lnkAddEditCourse_Click);
            }
        }

        LoadData();
    }

    private void lnkAddEditCourse_Click(Object sender, EventArgs e)
    {
        Response.Redirect("Course.aspx");
    }

    private void LoadData()
    {
        if (Session["DepartmentID"] != null)
            intDepartmentID = Convert.ToInt32(Session["DepartmentID"]);

        DataTable dtDepartment = LogicKernal.Department.GetAllDepartment();
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataValueField = "DepartmentID";
        ddlDepartment.DataSource = dtDepartment;
        ddlDepartment.DataBind();

        if (Session["ProgramID"] != null)
        {
            DataTable dtProgram = new DataTable();
            intProgramID = Convert.ToInt32(Session["ProgramID"]);
            dtProgram = LogicKernal.Programs.GetProgramsByID(intProgramID);
            if (dtProgram.Rows.Count > 0)
            {
                Session["ProgramName"] = dtProgram.Rows[0]["ProgramName"].ToString();
                txtTitle.Text = dtProgram.Rows[0]["ProgramName"].ToString();
                SetDuration(dtProgram.Rows[0]["Duration"].ToString());
                txtCriteria.Text = dtProgram.Rows[0]["Criteria"].ToString();
                txtFee.Text = dtProgram.Rows[0]["Fee"].ToString();
                txtDescription.Text = dtProgram.Rows[0]["ProgramDescription"].ToString();
                ddlDepartment.SelectedValue = dtProgram.Rows[0]["DepartmentID"].ToString();
                lnkAddEditCourse.Visible = true;
            }

            lnkAddEditCourse.Visible = true;
        }
        DataTable dtPrograms = LogicKernal.Programs.GetProgramByDepartmentID(intDepartmentID);
        if (dtPrograms.Rows.Count > 0)
        {
            grdPrograms.DataSource = dtPrograms;
            grdPrograms.DataBind();
        }

    }

    private void SetDuration(string strDuration)
    {
        string strYear, strSemester;
        strYear = strDuration.Split("-".ToCharArray())[0];
        strSemester = strDuration.Split("-".ToCharArray())[1];
        txtYear.Text = strYear.Split(":".ToCharArray())[1];
        txtSemester.Text = strSemester.Split(":".ToCharArray())[1];
    }

    private void btnSave_Click(Object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            BusinessEntities.Programs objPrograms = new BusinessEntities.Programs();
            objPrograms.ProgramName = txtTitle.Text;
            objPrograms.Duration = "Years:" + txtYear.Text + "-Semester:" + txtSemester.Text;
            objPrograms.Criteria = txtCriteria.Text;
            objPrograms.ProgramDescription = txtDescription.Text;
            objPrograms.ProgramID = intProgramID;
            objPrograms.Fee = Convert.ToInt32(txtFee.Text); 
            objPrograms.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
            objPrograms.CreatedByUserID = Convert.ToInt32(Session["UserID"]);
            if (LogicKernal.Programs.InsertUpdatePrograms(objPrograms) > 0)
            {
                Response.Redirect("Programs.aspx");
            }
            else
            {
                lblMessage.Visible = true;
            }
        }
    }

    private void grdPrograms_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        Session["ProgramID"] = e.CommandArgument;
        if (e.CommandName == "Edit")           
            Response.Redirect("Programs.aspx");
        if (e.CommandName == "Del")
        {
            LogicKernal.Programs.DeletePrograms(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("Programs.aspx");
        }
    }
}