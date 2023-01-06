using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeHealthDetails : System.Web.UI.Page
{
    HealthDal objdal = new HealthDal();
    HealthBO bo = new HealthBO();
    int pkgId;
    string userNm,orgId,branchId;
    DBClass db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        branchId = Session["BranchId"].ToString();
        orgId = Session["OrgId"].ToString();
       // orgId = (db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
        
            if (!this.IsPostBack)
            {

                this.BindGrid();

            }
       
    }


    protected void GridEmpHealth_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridEmpHealth.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        objdal.DeleteHealthDetails(Convert.ToInt32(GridEmpHealth.DataKeys[e.RowIndex].Value.ToString()));
        BindGrid();

    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridEmpHealth.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            
            using (SqlCommand cmd = new SqlCommand("sp_BindEmployeeHealthPackageData", con))//sp_BindEmpHealthData
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("orgId",orgId);
                //   cmd.Parameters.AddWithValue("pkgId",);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridEmpHealth.DataSource = dt;
                        GridEmpHealth.DataBind();
                    }
                }
            }
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridEmpHealth.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}