using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditFacultyProjects : System.Web.UI.Page
{
    TextBox txtTitle = new TextBox();
    TextBox txtDetails = new TextBox();
    TextBox txtRole = new TextBox();
    TextBox txtURL = new TextBox();
    Button btnSave = new Button();
    GridView grdProjects = new GridView();
    int intProjectID = 0;
    int intFacultyID = 0;
    HyperLink lnkDepartment = new HyperLink();
    HyperLink lnkFaculty = new HyperLink();
    protected void Page_Load(object sender, EventArgs e)
    {
        artEditFacultyProject.DataBind();
        artLinks.DataBind();
        foreach (Control ctrl in artEditFacultyProject.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtTitle")
                    txtTitle = (TextBox)ctrl;
                if (ctrl.ID == "txtDetails")
                    txtDetails = (TextBox)ctrl;
                if (ctrl.ID == "txtRole")
                    txtRole = (TextBox)ctrl;
                if (ctrl.ID == "txtURL")
                    txtURL = (TextBox)ctrl;
            }

            if (ctrl is Button)
            {
                btnSave = (Button)ctrl;
                btnSave.Click += new EventHandler(btnSave_Click);
            }

            if (ctrl is GridView)
            {
                grdProjects = (GridView)ctrl;
                grdProjects.RowCommand += new GridViewCommandEventHandler(grdProjects_RowCommand);
            }
        }

        foreach (Control ctrl in artLinks.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is HyperLink)
            {
                if (ctrl.ID == "lnkDepartment")
                {
                    lnkDepartment = (HyperLink)ctrl;
                    lnkDepartment.NavigateUrl = "DepartmentDetails.aspx?DeptID=" + Session["DeptID"].ToString();
                }

                if (ctrl.ID == "lnkFaculty")
                {
                    lnkFaculty = (HyperLink)ctrl;
                    lnkFaculty.NavigateUrl = "FacultyDetails.aspx?FacultyID=" + Session["FacultyID"].ToString();
                }
            }
        }

        LoadData();
    }

    private void LoadData()
    {
        intFacultyID = Convert.ToInt32(Session["FacultyID"]);
        if (Session["ProjectID"] != null)
        {
            intProjectID = Convert.ToInt32(Session["ProjectID"]);
            DataTable dtProjects = LogicKernal.Projects.GetProjectsByID(intProjectID);
            if (dtProjects.Rows.Count > 0)
            {
                txtTitle.Text = dtProjects.Rows[0]["ProjectTitle"].ToString();
                txtDetails.Text = dtProjects.Rows[0]["ProjectDetails"].ToString();
                txtRole.Text = dtProjects.Rows[0]["RollInProject"].ToString();
                txtURL.Text = dtProjects.Rows[0]["ProjectUrl"].ToString();
            }
        }

        DataTable dtProject = LogicKernal.Projects.GetProjectsByFacultyID(intFacultyID);
        grdProjects.DataSource = dtProject;
        grdProjects.DataBind();
    }

    private void btnSave_Click(Object sender, EventArgs e)
    {
        intProjectID = Convert.ToInt32(Session["ProjectID"]);
        intFacultyID = Convert.ToInt32(Session["FacultyID"]);

        BusinessEntities.Projects objProject = new BusinessEntities.Projects();
        objProject.ProjectID = intProjectID;
        objProject.ProjectTitle = txtTitle.Text;
        objProject.ProjectDetails = txtDetails.Text;
        objProject.RollInProject = txtRole.Text;
        objProject.ProjectUrl = txtURL.Text;
        objProject.FacultyID = intFacultyID;

        if (LogicKernal.Projects.InsertUpdateProjects(objProject) > 0)
        {
            Session.Remove("PaperID");
            Response.Redirect("EditFacultyProjects.aspx");
        }
    }

    private void grdProjects_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            intProjectID = Convert.ToInt32(e.CommandArgument);
            Session["ProjectID"] = intProjectID;
            Response.Redirect("EditFacultyProjects.aspx");
        }

        if (e.CommandName == "Del")
        {
            intProjectID = Convert.ToInt32(e.CommandArgument);
            LogicKernal.Projects.DeleteProjects(intProjectID);
            Response.Redirect("EditFacultyProjects.aspx");
        }
    }
}