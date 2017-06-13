using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Menu : System.Web.UI.UserControl
{
    public string GetClass(string page)
    {
        if (this.Request.Url.ToString().ToLower().Contains(page.ToLower()))
            return "active";
        else
            return "link";
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
