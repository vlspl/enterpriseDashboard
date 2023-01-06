using CrossPlatformAESEncryption.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hospital_LabMaster : System.Web.UI.Page
{
    DBClass db = new DBClass();
    DataTable dtFillData;
    string userNm ;
    string  OrgId, branchId;
    hospitalDAL objdal = new hospitalDAL();
    hospitalLabBO objhospitalBo = new hospitalLabBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        branchId = Session["BranchId"].ToString();
        OrgId = Session["OrgId"].ToString();
     //   OrgId = int.Parse(db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());

        if (!IsPostBack)
        {
            BindGrid();

        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        insert();
        BindGrid();
    }
    private void insert()
    {
        try
        {
            string Output = string.Empty;
            hospitalLabBO objHospitalBo = new hospitalLabBO();

            //objHospitalBo.HospitalName = txtHospital.Text;
            //objHospitalBo.State = drpState.Text;
            //objHospitalBo.City = drpCity.Text;
            //objHospitalBo.address = txtAddress.Text;
            //objHospitalBo.Status = drpStatus.Text;
            hospitalDAL objdal = new hospitalDAL();

            int j = objdal.AddHospitalDetails(objHospitalBo);


            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
            //txtHospital.Text = txtAddress.Text= string.Empty;
          
            //drpStatus.Text = drpState.Text = drpCity.Text="--Select--";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("sp_BindHospitalData", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("orgId", OrgId);
               // cmd.Parameters.AddWithValue("branchId", branchId);

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridHospital.DataSource = dt;
                        GridHospital.DataBind();
                    }
                }
            }
        }
    }

    protected void GridHospital_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridHospital.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        objdal.DeleteHospitalDetails(Convert.ToInt32(GridHospital.DataKeys[e.RowIndex].Value.ToString()));
        BindGrid();

    }
    protected void GridHospital_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridHospital.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GridHospital_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        int userid = Convert.ToInt32(GridHospital.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)GridHospital.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lblID");

        //TextBox textBranchName = (TextBox)row.Cells[2].Controls[0];
        //TextBox textStatus = (TextBox)row.Cells[3].Controls[0];
        string HospName = (row.Cells[2].Controls[0] as TextBox).Text;
        string state = (row.Cells[3].Controls[0] as TextBox).Text;
        string city = (row.Cells[4].Controls[0] as TextBox).Text;
        string address = (row.Cells[5].Controls[0] as TextBox).Text;
        string Status = (row.Cells[6].Controls[0] as TextBox).Text;
        //objBranchBo.BranchName = textBranchName.Text;
        //objBranchBo.status = textStatus.Text;

        GridHospital.EditIndex = -1;
        objdal.UpdateHospitalDetails(userid, HospName,state,city,address, Status);

        BindGrid();
    }
    protected void GridHospital_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridHospital.EditIndex = -1;
        BindGrid();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text == "" || e.Row.Cells[6].Text== "&nbsp;")
                e.Row.Cells[6].Text = (e.Row.Cells[6].Text);
            else
                e.Row.Cells[6].Text = CryptoHelper.Decrypt(e.Row.Cells[6].Text);
        }
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridHospital.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}