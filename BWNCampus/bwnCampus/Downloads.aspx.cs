using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Downloads : System.Web.UI.Page
{
    DataList lstDownload;
    protected void Page_Load(object sender, EventArgs e)
    {
        artDownloads.DataBind();
        foreach (Control ctrl in artDownloads.ContentPlaceholder.Controls[0].Controls)
        {
            if (ctrl is DataList)
            {
                DataTable dtDownloads = new DataTable();
                dtDownloads = LogicKernal.Download.GetAllDownload();
                lstDownload = new DataList();
                lstDownload = (DataList)ctrl;
                lstDownload.DataSource = dtDownloads;
                lstDownload.DataBind();
                lstDownload.ItemCommand += new DataListCommandEventHandler(lstDownload_ItemCommand);
            }
        }
    }

    private void lstDownload_ItemCommand(Object sender, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Redirect(e.CommandArgument.ToString());
        }
    }
}
