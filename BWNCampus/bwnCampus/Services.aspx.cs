using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Services : System.Web.UI.Page

{
    DataList lstServices = new DataList();

    protected void Page_Load(object sender, EventArgs e)
    {
        artlstServices.DataBind();

        foreach (Control ctrl in artlstServices.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is DataList)
            {
                DataSet dsServices = new DataSet();
                DataKernal.Services objServices = new DataKernal.Services();
                dsServices = objServices.SelectServices();
               DataList lstServices = (DataList)ctrl;
                lstServices.DataSource = dsServices;
                lstServices.DataBind();
                lstServices.ItemCommand += new DataListCommandEventHandler(lstServices_ItemCommand);
            }
        }
    }
    private void lstServices_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ServiceDetails")
        {
            Response.Redirect("ServiceDetails.aspx?ServID=" + e.CommandArgument.ToString());
        }
    }
}

