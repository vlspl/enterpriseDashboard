using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessHandler;

public partial class Department : System.Web.UI.Page
{
    DBClass db = new DBClass();
    DataTable dtFillData;
    DeptDal objdal = new DeptDal();
    string userNm, orgId,branchId;
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        branchId=Session["BranchId"].ToString();
        orgId=Session["OrgId"].ToString();
//orgId = (db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
       
       
            if (!IsPostBack)
            {

                BindGrid();
                if (Request.QueryString["deptId"] != null)
                {
                    btnSave.Text = "Update";
                    dtFillData = objdal.fillData(Request.QueryString["deptId"]);
                    foreach (DataRow row in dtFillData.Rows)
                    {
                        // basic Info
                        txtdeptName.Text = row["deptName"].ToString();
                        drpStatus.Text = row["status"].ToString();
                    }
                }
            }
        
    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SP_bindDept", con))//sp_BindDeptData
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orgId", orgId);
                //cmd.Parameters.AddWithValue("@parentbranchId", branchId);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridDept.DataSource = dt;
                        GridDept.DataBind();
                    }
                }
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        
            lblError.Visible = true;
        if (txtdeptName.Text == "")
            lblError.Text = "Please Enter Department";
        else if (drpStatus.SelectedValue == "--Select--")
            lblError.Text = "Please Select  Status";
        else
        {
            if (Request.QueryString["deptId"] == null)
                insert();
            else
            {
                objdal.UpdateDeptDetails(int.Parse(Request.QueryString["deptId"].ToString()), txtdeptName.Text, drpStatus.Text);
                Response.Redirect("Department.aspx");
                // Request.QueryString.Clear();
              //  Request.QueryString.Remove("deptId");
            }
            txtdeptName.Text = "";
            drpStatus.Text = "--Select--";
            btnSave.Text = "Save";
            BindGrid();
        }
        
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        lblError.Visible = true;
        if (txtdeptName.Text == "")
            lblError.Text = "Please Enter Department";
        else if (drpStatus.SelectedValue == "--Select--")
            lblError.Text = "Please Select  Status";
        else
        {
            insert();
            BindGrid();


        }
    }
    private void insert()
    {
        try
        {

            SqlParameter[] paramDept = new SqlParameter[]
                       {
                              new SqlParameter("@DeptName",txtdeptName.Text),
                              new SqlParameter("@staus",drpStatus.Text),
                              new SqlParameter("@orgId",orgId),
                              new SqlParameter("@branchId",branchId),
                            new SqlParameter("@Returnval",SqlDbType.Int)
                       };
            int result = DAL.ExecuteStoredProcedureRetnInt("Sp_AddDepartmentDetails", paramDept);
            if (result == -2)
                lblError.Text = "Department Already Exists.";
            else if (result > 1)
            {
                lblError.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
            }
            //string Output = string.Empty;
            //DepartmentBO objDeptBo = new DepartmentBO();


            //objDeptBo.deptName = txtdeptName.Text;
            //objDeptBo.status = drpStatus.Text;


            //DeptDal objdal = new DeptDal();

            //int j = objdal.AddDeptDetails(objDeptBo, orgId, branchId);
            txtdeptName.Text = string.Empty;
            drpStatus.Text = "--Select--";




        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridDept_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridDept.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        objdal.DeleteDeptDetails(Convert.ToInt32(GridDept.DataKeys[e.RowIndex].Value.ToString()));
        BindGrid();
       
    }
    protected void GridDept_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridDept.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GridDept_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //DropDownList ddl = (DropDownList)GridDept.Rows[e.RowIndex].FindControl("ddlId");
        //string selectedvalue = ddl.SelectedValue;

        int userid = Convert.ToInt32(GridDept.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)GridDept.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lblID");

        //TextBox textBranchName = (TextBox)row.Cells[2].Controls[0];
        //TextBox textStatus = (TextBox)row.Cells[3].Controls[0];
        string DeptName = (row.Cells[1].Controls[0] as TextBox).Text;
       
        string Status = (row.Cells[2].Controls[0] as TextBox).Text;
        //objBranchBo.BranchName = textBranchName.Text;
        //objBranchBo.status = textStatus.Text;

        GridDept.EditIndex = -1;
        objdal.UpdateDeptDetails(userid, DeptName,  Status);

        BindGrid();
      
    }
    protected void GridDept_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridDept.EditIndex = -1;
        BindGrid();
    }
   
}