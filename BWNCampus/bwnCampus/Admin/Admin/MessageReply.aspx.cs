using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Xml;
using System.Messaging;
using System.Web.Services.Description;


public partial class Admin_Admin_MessageReply : System.Web.UI.Page
{
  
    TextBox txtEmail = new TextBox();
    TextBox txtSubject = new TextBox();
    TextBox txtMessage = new TextBox();
    Button cmdSend = new Button();
    Label lblMessage = new Label();
    protected void Page_Load(object sender, EventArgs e)
    {
        artMessageReply.DataBind();
        foreach (Control ctrl in artMessageReply.ContentPlaceholder.Controls[0].Controls)
        {
            if (!Page.IsPostBack)
                if (ctrl is Button)
                {
                    Button cmdSend = (Button)ctrl;
                    cmdSend.Click += new EventHandler(cmdSend_Click);
                }

            if (ctrl is TextBox)
            {
                if (ctrl.ID == "txtEmail")
                    txtEmail = (TextBox)ctrl;

                if (ctrl.ID == "txtSubject")
                    txtSubject = (TextBox)ctrl;

                if (ctrl.ID == "txtMessage")
                    txtMessage = (TextBox)ctrl;
            }

            if (ctrl is Label)
                lblMessage = (Label)ctrl;
        }
       
        string strMessageEmail;
        
        strMessageEmail = (Request.QueryString["MessageSenderEmail"]);
        txtEmail.Text = strMessageEmail;

    }
    protected void cmdSend_Click(object sender, EventArgs e)
    {
        // Create an XmlWriter object, to write XML to a StringWriter.
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        StringWriter sw = new StringWriter();
        XmlWriter w = XmlWriter.Create(sw, settings);

        // Write the following XML data to the string:
        //    <FaultReport UserName="..." UserEmail="...">
        //        fault description text
        //    </FaultReport>
        w.WriteStartDocument();
        w.WriteStartElement("txtSubject");
       
        w.WriteAttributeString("UserEmail", txtEmail.Text);
        w.WriteString(txtMessage.Text);
        w.WriteEndElement();
        w.WriteEndDocument();
        w.Close();
        string timestamp = DateTime.Now.ToString();
        System.Messaging.Message msg = new System.Messaging.Message(sw.ToString(), new ActiveXMessageFormatter());
        MessageQueue queue = new MessageQueue(@".\Private$\FaultReportQueue");
        queue.Send(msg, "Fault[" + timestamp + "]");


        //{
        //    lblMessage.ForeColor = System.Drawing.Color.Green;
        //    lblMessage.Text = "Message Sent Successfully";
        //    txtEmail.Text = string.Empty;
        //    txtSubject.Text = string.Empty;
        //    txtMessage.Text = string.Empty;
        //}
        //else
        //{
        //    lblMessage.ForeColor = System.Drawing.Color.Red;
        //    lblMessage.Text = "There is some problem in Message Sending";
        //}

       
    }
}

