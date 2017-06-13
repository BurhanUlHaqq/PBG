using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Admin_Contacts : System.Web.UI.Page
{
    TextBox txtContacts = new TextBox();
    TextBox txtTelephone = new TextBox();
    TextBox txtEmail = new TextBox();
    Button cmdSave = new Button();
    Label lblMessage = new Label();

    protected void Page_Load(object sender, EventArgs e)
    {
        artContacts.DataBind();

        if (Session["UserID"] == null)
            Response.Redirect("Login.aspx");
        foreach (Control ctrl in artContacts.ContentPlaceholder.Controls[0].Controls)
        {
            if (!Page.IsPostBack)
                if (ctrl is Button)
                {
                    Button cmdSave = (Button)ctrl;
                    cmdSave.Click += new EventHandler(cmdSave_Click);
                }

            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtContactTitle")
                    txtContacts = (TextBox)ctrl;

                if (ctrl.ID == "txtTelephone")
                    txtTelephone = (TextBox)ctrl;

                if (ctrl.ID == "txtEmail")
                    txtEmail = (TextBox)ctrl;
            }

            if (ctrl is Label)
                lblMessage = (Label)ctrl;
        }

        GridView grdContacts = new GridView();

        artContacts.DataBind();

        foreach (Control ctrl in artContacts.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is GridView)
            {
                DataSet dsContacts = new DataSet();
                DataKernal.Contacts objContacts = new DataKernal.Contacts();
                dsContacts = objContacts.SelectContacts();
                GridView Contacts = (GridView)ctrl;
                Contacts.DataSource = dsContacts;
                Contacts.DataBind();
                Contacts.RowCommand += new GridViewCommandEventHandler(Contacts_RowCommand);
            }
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactID"] != null)
            {
                int intContacts = Convert.ToInt32(Request.QueryString["ContactID"]);
                DataTable dtContacts = new DataTable();
                dtContacts = LogicKernal.Contacts.GetContactsByID(intContacts);

                if (dtContacts.Rows.Count > 0)
                {
                    txtContacts.Text = dtContacts.Rows[0]["ContactTitle"].ToString();
                    txtTelephone.Text = dtContacts.Rows[0]["Telephone"].ToString();
                    txtEmail.Text = dtContacts.Rows[0]["Email"].ToString();
                }
            }
        }
    }


    protected void cmdSave_Click(object sender, EventArgs e)
    {
        int intContactID = 0;
        if (Request.QueryString["ContactID"] != null)
            intContactID = Convert.ToInt32(Request.QueryString["ContactID"]);

        int intUserID = Convert.ToInt32(Session["UserID"]);

        BusinessEntities.Contacts objContacts = new BusinessEntities.Contacts();
        objContacts.ContactID = intContactID;
        objContacts.ContactTitle = txtContacts.Text;
        objContacts.Telephone = txtTelephone.Text;
        objContacts.Email = txtEmail.Text;

        if (LogicKernal.Contacts.InsertUpdateContacts(objContacts) > 0)
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Record entered successfully";
            txtContacts.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "There is some problem in record entry";
        }
    }
    private void Contacts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int intContactID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Del")
            LogicKernal.Contacts.DeleteContacts(intContactID);
            else if(e.CommandName == "Edit")
            Response.Redirect("~/Admin/Admin/Contacts.aspx?ContactID=" + intContactID.ToString());
    }
   
}