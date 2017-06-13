using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditFacultyResearchPapers : System.Web.UI.Page
{
    TextBox txtPaperTitle = new TextBox();
    TextBox txtAbstract = new TextBox();
    TextBox txtJournalName = new TextBox();
    TextBox txtPageURL = new TextBox();
    TextBox txtCoAuthor = new TextBox();
    DropDownList ddlPaperType = new DropDownList();
    Calendar dtpDatePublish = new Calendar();
    Button btnSave = new Button();
    GridView grdResearchPapers = new GridView();
    HyperLink lnkDepartment = new HyperLink();
    HyperLink lnkFaculty = new HyperLink();

    int intFacultyID = 0;
    int intPaperID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FacultyID"] == null)
            Response.Redirect("Default.aspx");

        artEditFacultyResearchPaper.DataBind();
        artLinks.DataBind();
        foreach (Control ctrl in artEditFacultyResearchPaper.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtPaperTitle")
                    txtPaperTitle = (TextBox)ctrl;
                if (ctrl.ID == "txtAbstract")
                    txtAbstract = (TextBox)ctrl;
                if (ctrl.ID == "txtJournalName")
                    txtJournalName = (TextBox)ctrl;
                if (ctrl.ID == "txtPageURL")
                    txtPageURL = (TextBox)ctrl;
                if (ctrl.ID == "txtCoAuthor")
                    txtCoAuthor = (TextBox)ctrl;
            }

            if (ctrl is DropDownList)
                ddlPaperType = (DropDownList)ctrl;

            if (ctrl is Calendar)
                dtpDatePublish = (Calendar)ctrl;

            if (ctrl is Button)
            {
                btnSave = (Button)ctrl;
                btnSave.Click += new EventHandler(bntSave_Click);
            }

            if (ctrl is GridView)
            {
                grdResearchPapers = (GridView)ctrl;
                grdResearchPapers.RowCommand += new GridViewCommandEventHandler(grdResearchPapers_RowCommand);
                grdResearchPapers.RowDataBound += new GridViewRowEventHandler(grdResearchPapers_RowDataBound);
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
        if (Session["PaperID"] != null)
        {
            intFacultyID = Convert.ToInt32(Session["PaperID"]);
            DataTable dtResearchPaper = LogicKernal.FacultyPaper.GetPaperByFacultyID(intFacultyID);
            if (dtResearchPaper.Rows.Count > 0)
            {
                txtPaperTitle.Text = dtResearchPaper.Rows[0]["PaperTitle"].ToString();
                txtAbstract.Text = dtResearchPaper.Rows[0]["PaperAbstract"].ToString();
                txtJournalName.Text = dtResearchPaper.Rows[0]["JournalConferenceName"].ToString();
                txtPageURL.Text = dtResearchPaper.Rows[0]["PaperUrl"].ToString();
                txtCoAuthor.Text = dtResearchPaper.Rows[0]["CoAurthors"].ToString();
                dtpDatePublish.SelectedDate = Convert.ToDateTime(dtResearchPaper.Rows[0]["DatePublish"]);
                ddlPaperType.SelectedIndex = Convert.ToInt32(dtResearchPaper.Rows[0]["Journal"]);
            }
        }


        DataTable dtPapers = LogicKernal.FacultyPaper.GetPaperByFacultyID(intFacultyID);
        grdResearchPapers.DataSource = dtPapers;
        grdResearchPapers.DataBind();
    }

    private void bntSave_Click(Object sender, EventArgs e)
    {
        if (Session["FacultyID"] != null)
        {
            if (Session["PaperID"] != null)
                intPaperID = Convert.ToInt32(Session["PaperID"]);

            BusinessEntities.FacultyPaper objPaper = new BusinessEntities.FacultyPaper();
            objPaper.PaperTitle = txtPaperTitle.Text;
            objPaper.PaperAbstract = txtAbstract.Text;
            objPaper.Journal = Convert.ToBoolean(ddlPaperType.SelectedIndex);
            objPaper.JournalConferenceName = txtJournalName.Text;
            objPaper.DatePublish = dtpDatePublish.SelectedDate;
            objPaper.PaperUrl = txtPageURL.Text;
            objPaper.CoAurthors = txtCoAuthor.Text;
            objPaper.PaperID = intPaperID;
            objPaper.FacultyID = Convert.ToInt32(Session["FacultyID"]);
            if (LogicKernal.FacultyPaper.InsertUpdateFacultyPaper(objPaper) > 0)
            {
                Session.Remove("PaperID");
                Response.Redirect("EditFacultyResearchPapers.aspx");
            }
        }
    }

    private void grdResearchPapers_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        int intPaperID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Edit")
        {
            Session["PaperID"] = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("EditFacultyResearchPapers.aspx");
        }

        if (e.CommandName == "Del")
        {
            LogicKernal.FacultyPaper.DeleteFacultyPaper(intPaperID);
            Response.Redirect("EditFacultyResearchPapers.aspx");
        }
    }

    private void grdResearchPapers_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }
}