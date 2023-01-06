using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class EmployeeInsuranceDetails : System.Web.UI.Page
{
    InsuranceDal objdal = new InsuranceDal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();

        }
    }
    protected void GridEmpInsurance_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridEmpInsurance.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        objdal.DeleteInsuranceDetails(Convert.ToInt32(GridEmpInsurance.DataKeys[e.RowIndex].Value.ToString()));
        BindGrid();

    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridEmpInsurance.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("sp_BindEmpInsuranceData", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridEmpInsurance.DataSource = dt;
                        GridEmpInsurance.DataBind();
                    }
                }
            }
        }
    }
}