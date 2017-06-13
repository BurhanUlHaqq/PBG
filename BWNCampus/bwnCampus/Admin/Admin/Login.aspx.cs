using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_Login : System.Web.UI.Page
{
    TextBox txtUsername = new TextBox();
    TextBox txtPassword = new TextBox();
    Button cmdLogin = new Button();
    Label lblMessage = new Label();

    protected void Page_Load(object sender, EventArgs e)
    {
        artLogin.DataBind();

        foreach (Control ctrl in artLogin.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtUsername")
                    txtUsername = (TextBox)ctrl;
                if (ctrl.ID == "txtPassword")
                    txtPassword = (TextBox)ctrl;
            }

            if (ctrl is Button)
            {
                cmdLogin = (Button)ctrl;
                cmdLogin.Click += new EventHandler(cmdLogin_Click);
            }

            if (ctrl is Label)
            {
                lblMessage = (Label)ctrl;
            }
        }
    }
    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        DataTable dtUsers = new DataTable();
        dtUsers = LogicKernal.Users.GetByUsernamePassword(txtUsername.Text, txtPassword.Text);
        if (dtUsers.Rows.Count > 0)
        {
            Session["UserID"] = dtUsers.Rows[0]["UsersID"];
            Response.Redirect("Default.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Invalid Username or Password";
        }
    }
}
