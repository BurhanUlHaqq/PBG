using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_Messages : System.Web.UI.Page
{
    DataList lstMessages = new DataList();
    protected void Page_Load(object sender, EventArgs e)
    {
        artMessagesList.DataBind();
        lstMessages = (DataList)artMessagesList.ContentPlaceholder.Controls[0].Controls[1];
        DataTable dtMessages = new DataTable();
        dtMessages = LogicKernal.Messages.GetAllMessages();
        lstMessages.ItemCommand += new DataListCommandEventHandler(lstMessagesDetails_ItemCommand);
        lstMessages.DataSource = dtMessages;
        lstMessages.DataBind();
    }   

    protected void lstMessagesDetails_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Reply")
          //  Response.Redirect("MessageReply.aspx?MessageID=" + e.CommandArgument.ToString());
        Response.Redirect("MessageReply.aspx?MessageSenderEmail=" + e.CommandArgument.ToString());

    }
}
