using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_VisitingFaculty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dlVisitingList.DataSource = LogicKernal.VisitingFaculty.GetAllFaculty();
            dlVisitingList.DataBind();
        }
    }
    protected void dlVisitingList_EditCommand(object source, DataListCommandEventArgs e)
    {
        dlVisitingList.DataSource = LogicKernal.VisitingFaculty.GetAllFaculty();
        //string gander=((Label)e.Item .FindControl("lblGanderStatus")).Text;
        dlVisitingList.EditItemIndex = e.Item.ItemIndex;
        dlVisitingList.DataBind();
        
       // ((DropDownList)e.Item.FindControl("UpdateGander")).SelectedIndex = ((DropDownList)e.Item.FindControl("UpdateGander")).Items.IndexOf(((DropDownList)e.Item.FindControl("UpdateGander")).Items.FindByText(gander));
    }
    protected void dlVisitingList_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        Label lbl =(Label) e.Item.FindControl("UpdateID");
        int DeleteId=Convert .ToInt32  (lbl.Text );
        LogicKernal.VisitingFaculty.DeleteFacultyByID(DeleteId);
        dlVisitingList.DataSource = LogicKernal.VisitingFaculty.GetAllFaculty();
        dlVisitingList.DataBind();
    }
    protected void dlVisitingList_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        BusinessEntities.VisitingFaculty UpdateFaculty = new BusinessEntities.VisitingFaculty();
        UpdateFaculty.ID = Convert.ToInt32(((Label)e.Item.FindControl("UpdateID")).Text);
        UpdateFaculty.Name = ((TextBox)e.Item.FindControl("UpdateName")).Text;
        UpdateFaculty.Gander = ((DropDownList)e.Item.FindControl("UpdateGander")).SelectedValue;
        UpdateFaculty.CNIC = ((TextBox)e.Item.FindControl("UpdateCNIC")).Text;
        UpdateFaculty.Qualification = ((TextBox)e.Item.FindControl("UpdateQualification")).Text;
        UpdateFaculty.CellNo = ((TextBox)e.Item.FindControl("UpdateCellNo")).Text;
        UpdateFaculty.Email = ((TextBox)e.Item.FindControl("UpdateEmail")).Text;
        UpdateFaculty.AddedBy = ((TextBox)e.Item.FindControl("UpdateAddedBy")).Text;
        LogicKernal.VisitingFaculty.InsertUpdateFaculty(UpdateFaculty);
        dlVisitingList.EditItemIndex = -1;
        dlVisitingList.DataSource = LogicKernal.VisitingFaculty.GetAllFaculty();
        dlVisitingList.DataBind();
    }
    protected void dlVisitingList_CancelCommand(object source, DataListCommandEventArgs e)
    {
        dlVisitingList.EditItemIndex = -1;
        dlVisitingList.DataSource = LogicKernal.VisitingFaculty.GetAllFaculty();
        dlVisitingList.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BusinessEntities.VisitingFaculty newFaculty = new BusinessEntities.VisitingFaculty();
        newFaculty.Name = newName.Text;
        newFaculty.Gander = newGander.SelectedValue;
        newFaculty.CNIC = newCNIC.Text;
        newFaculty.Qualification = newQualification.Text;
        newFaculty.CellNo = newCellNo.Text;
        newFaculty.Email = newEmail.Text;
        newFaculty.AddedBy = newAddedBy.Text;
        int status=LogicKernal.VisitingFaculty.InsertUpdateFaculty(newFaculty);
        if (status == 1)
        {
            dlVisitingList.DataSource = LogicKernal.VisitingFaculty.GetAllFaculty();
            dlVisitingList.DataBind();
            newName.Text = newCNIC.Text = newCellNo.Text = newAddedBy.Text = newQualification.Text = newEmail.Text = "";
            newGander.SelectedIndex = 0;
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Successfuly Added This Record";
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Error in Database";
        }
    }
}