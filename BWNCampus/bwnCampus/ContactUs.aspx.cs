using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : System.Web.UI.Page
{
    TextBox txtMessageTitle = new TextBox();
    TextBox txtMessagesDetails = new TextBox();
    TextBox txtMessageSenderName = new TextBox();
    TextBox txtMessageSenderEmail = new TextBox();
    TextBox txtMessageSenderPhone = new TextBox();
    Button cmdSend = new Button();
    Label lblMessage = new Label();
    private BusinessEntities.Messages objMessages;

    protected void Page_Load(object sender, EventArgs e)
    {
        artContactUs.DataBind();

  
        foreach (Control ctrl in artContactUs.ContentPlaceholder.Controls[0].Controls)
        {
            if (!Page.IsPostBack)
            {
                if (ctrl is Button)
                {
                    Button cmdSend = (Button)ctrl;
                    cmdSend.Click += new EventHandler(cmdSend_Click);
                }//ctrl button
            }
            if (ctrl is TextBox)
            {

                if (ctrl.ID == "txtMessageTitle")
                    txtMessageTitle = (TextBox)ctrl;

                if (ctrl.ID == "txtMessagesDetails")
                    txtMessagesDetails = (TextBox)ctrl;

                if (ctrl.ID == "txtMessageSenderName")
                    txtMessageSenderName = (TextBox)ctrl;

                if (ctrl.ID == "txtMessageSenderEmail")
                    txtMessageSenderEmail = (TextBox)ctrl;

                if (ctrl.ID == "txtMessageSenderPhone")
                    txtMessageSenderPhone = (TextBox)ctrl;
            }//ctrl is textbox
                
            if (ctrl is Label)
                    lblMessage = (Label)ctrl;
            
        }//end for each
    }//end page load
   
    protected void cmdSend_Click(object sender, EventArgs e)
    {
        int intUserID = Convert.ToInt32(Session["UserID"]);

        BusinessEntities.Messages objMessages = new BusinessEntities.Messages();
        objMessages.MessageTitle = txtMessageTitle.Text;
        objMessages.MessagesDetails = txtMessagesDetails.Text;
        objMessages.MessageSenderName = txtMessageSenderName.Text;
        objMessages.MessageSenderEmail = txtMessageSenderEmail.Text;
        objMessages.MessageSenderPhone = txtMessageSenderPhone.Text;
        objMessages.CreatedDate = System.DateTime.Now.Date;
        objMessages.IsRead = true;
        objMessages.ReplierID = intUserID;
        objMessages.MessagesID = 0;

        if (LogicKernal.Messages.InsertUpdateMessages(objMessages) > 0)
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Message Sent Successfully";
            txtMessageTitle.Text = string.Empty;
            txtMessagesDetails.Text = string.Empty;
            txtMessageSenderName.Text = string.Empty;
            txtMessageSenderEmail.Text = string.Empty;
            txtMessageSenderPhone.Text = string.Empty;
        }
        else  
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "There is some problem in Message Sending";
        }
       }
    protected void txtMessageSenderEmail_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtMessageSenderPhone_TextChanged(object sender, EventArgs e)
    {

    }
}//end class
