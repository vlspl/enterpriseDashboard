using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrossPlatformAESEncryption.Helper;
using DataAccessHandler;
using Newtonsoft.Json;

public partial class Branch : System.Web.UI.Page
{
    DBClass db = new DBClass();
    DataTable dtFillData;
    string userNm, OrgId;
    int branchId;
    BranchDal objdal = new BranchDal();
    BranchBO objBranchBo = new BranchBO();
    public DataSet ds_patientList;
    DataTable dt_new = new DataTable();
    DataRow dtrow;
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        OrgId = (Session["OrgId"].ToString());
	    branchId = int.Parse( Session["BranchId"].ToString());
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
      

        if (!IsPostBack)
        {
            BindGrid();
           
        }
    }
  
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
       
        BindGrid();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
    //    lblError.Visible = true;
    //    if (txtbranchName.Text == "")
    //        lblError.Text = "Please Enter Branch Name";
    //   else if (txtAddress.Text == "")
    //        lblError.Text = "Please Enter Address";
    //    else if (drpCountry.SelectedValue == "")
    //        lblError.Text = "Please Select Country";

    //    else if(drpState.SelectedValue == "")
    //        lblError.Text = "Please Select State";
    //    else if(drpCity.SelectedValue == "")
    //        lblError.Text = "Please Select City";
    //    else if (txtMobile.Text == "")
    //        lblError.Text = "Please Enter Mobile No";
    //    else if (txtEmail.Text == "")
    //        lblError.Text = "Please Enter Email";
    //    else
    //    {
    //        insert();

    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
    //        txtbranchName.Text = txtAddress.Text = txtEmail.Text = txtMobile.Text = txtZipCode.Text = string.Empty;
    //        lblError.Visible = false;
    //    }
    }

    //private void BindGrid()
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(constr))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("sp_BindBranchData", con))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.AddWithValue("orgId",OrgId);
    //         cmd.Parameters.AddWithValue("branchId",branchId);
    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.Connection = con;
    //                sda.SelectCommand = cmd;
                 
    //                DataTable dt = new DataTable();
    //                sda.Fill(dt);
                   
    //                GridBranch.DataSource = dt;
    //                GridBranch.DataBind();
                   
    //            }
    //        }
    //    }
    //}
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();
        if (branchId == 0)
        {
            //cmd = new SqlCommand(Session["branchDtls"].ToString(), con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            DataTable dt = (DataTable)Session["branchDtls"];
            GridBranch.DataSource = dt;
            GridBranch.DataBind();

        }
        else
        {
            cmd = new SqlCommand("sp_BindBranchData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("orgId", OrgId);
            cmd.Parameters.AddWithValue("branchId", branchId);
            SqlDataAdapter sda = new SqlDataAdapter();

            cmd.Connection = con;
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            sda.Fill(dt);

            GridBranch.DataSource = dt;
            GridBranch.DataBind();


        }


    }

    
    protected void GridBranch_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridBranch.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        objdal.DeleteBranchDetails(Convert.ToInt32(GridBranch.DataKeys[e.RowIndex].Value.ToString()));
        BindGrid();

    }
    protected void GridBranch_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridBranch.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GridBranch_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        

        int userid = Convert.ToInt32(GridBranch.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)GridBranch.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lblID");

        //TextBox textBranchName = (TextBox)row.Cells[2].Controls[0];
        //TextBox textStatus = (TextBox)row.Cells[3].Controls[0];
        string BranchName = (row.Cells[2].Controls[0] as TextBox).Text;
        string Status = (row.Cells[3].Controls[0] as TextBox).Text;
        //string address = (row.Cells[4].Controls[0] as TextBox).Text;
        //string country = (row.Cells[5].Controls[0] as TextBox).Text;
        //string state = (row.Cells[6].Controls[0] as TextBox).Text;
        //string city = (row.Cells[7].Controls[0] as TextBox).Text;
        //string zipCode = (row.Cells[8].Controls[0] as TextBox).Text;
        //string mobileNo = (row.Cells[9].Controls[0] as TextBox).Text;
        //string email = (row.Cells[10].Controls[0] as TextBox).Text;
        //objBranchBo.BranchName = textBranchName.Text;
        //objBranchBo.status = textStatus.Text;

        GridBranch.EditIndex = -1;
        objdal.UpdateBranchDetails(userid, BranchName, Status);

        BindGrid();
    }
    protected void GridBranch_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridBranch.EditIndex = -1;
        BindGrid();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridBranch.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void GridBranch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
           string  mobNo = (dr["Contact"].ToString());
            string emailId = (dr["Email"].ToString());
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            e.Row.Cells[3].Text = CryptoHelper.Decrypt(mobNo);
            e.Row.Cells[4].Text = CryptoHelper.Decrypt(emailId);

            if (dr["IsActive"].ToString() == "True")
                e.Row.Cells[5].Text = "Active";
            else
                e.Row.Cells[5].Text = "Deactive";
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);

        SqlCommand cmd = new SqlCommand("select * from BranchMaster where Org_Id='" + OrgId + "' and IsActive=1 order by BranchName asc", con);

        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();
        da.Fill(dt);
        GridBranch.DataSource = dt;
        GridBranch.DataBind();


    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);

        SqlCommand cmd = new SqlCommand("select * from BranchMaster where Org_Id='" + OrgId + "' and IsActive=0 order by BranchName asc", con);

        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();
        da.Fill(dt);
        GridBranch.DataSource = dt;
        GridBranch.DataBind();


    }

}