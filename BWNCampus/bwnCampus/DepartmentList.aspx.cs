using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DepartmentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet dsDepartment = new DataSet();
            DataKernal.Department objDepartment = new DataKernal.Department();
            dsDepartment = objDepartment.SelectDepartment();
            lstDepartmentList.DataSource = dsDepartment;
            lstDepartmentList.DataBind();
            
        }
        listAllVisitingFaculty.DataSource = LogicKernal.VisitingFaculty.GetAllFaculty();
        listAllVisitingFaculty.DataBind();
    }

   public string ShortDesc(object objDesc)
    {
        int intLength = 300;
        string strShortDesc;
        string strFullDesc;
        strFullDesc = Convert.ToString(objDesc);
        if (strFullDesc.Length < intLength)
            return strFullDesc;
        strShortDesc = strFullDesc.Substring(0, intLength) + "...";
        return strShortDesc;
    }

    protected void lstDepartmentList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DepartmentDetails")
        {
            Response.Redirect("DepartmentDetails.aspx?DeptID=" + e.CommandArgument.ToString());
        }
    }
    protected void listAllVisitingFaculty_EditCommand(object source, DataListCommandEventArgs e)
    {
        listAllVisitingFaculty.EditItemIndex = e.Item.ItemIndex;
        listAllVisitingFaculty.DataBind();
    }
    protected void listAllVisitingFaculty_CancelCommand(object source, DataListCommandEventArgs e)
    {
        listAllVisitingFaculty.EditItemIndex = -1;
        listAllVisitingFaculty.DataBind();
    }
    protected void btnShowVisiting_Click(object sender, EventArgs e)
    {
        if (panalVisitingContainer.Visible == false)
        {
            panalVisitingContainer.Visible = true;
            btnShowVisiting.Text = "Hide Visiting Faculty";
        }
        else
        {
            panalVisitingContainer.Visible = false;
            btnShowVisiting.Text = "Show Visiting Faculty";
        }
    }
}
