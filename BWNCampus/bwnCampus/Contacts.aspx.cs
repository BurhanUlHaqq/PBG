using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contacts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        artContacts.DataBind();
        DataTable dtContacts = new DataTable();
        GridView grdContacts = (GridView)artContacts.ContentPlaceholder.Controls[0].Controls[1];
        dtContacts = LogicKernal.Contacts.GetAllContacts();
        grdContacts.DataSource = dtContacts;
        grdContacts.DataBind();
    }
}
