using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrossPlatformAESEncryption.Helper;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using iTextSharp.tool.xml;
public partial class EmployeeDetails : System.Web.UI.Page
{
    EmPpDal objdal = new EmPpDal();
    string userNm, orgId,branchId;
    DBClass db = new DBClass();   
 DataTable dtSession;

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
       

        userNm = Session["userName"].ToString();
       // orgId = (db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
        branchId = Session["BranchId"].ToString();
        orgId = Session["OrgId"].ToString();
        if (userNm == "")
            Response.Redirect("Login.aspx");
        else
        {
            if (!this.IsPostBack)
            {

                this.BindGrid();

            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridEmp.EditIndex)
        {
            if (e.Row.DataItem != null)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string mobNo = (dr["sMobile"].ToString());
                string emailId = (dr["sEmailId"].ToString());
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();

                if (emailId != "")
                    e.Row.Cells[2].Text = CryptoHelper.Decrypt(emailId);
                else
                    e.Row.Cells[2].Text = (emailId);
                if (mobNo != "")
                    e.Row.Cells[3].Text = CryptoHelper.Decrypt(mobNo);
                else
                    e.Row.Cells[3].Text = (mobNo);


            }
        }
    }
    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridEmp.Rows[e.RowIndex];
        int EmpID = Convert.ToInt32(GridEmp.DataKeys[e.RowIndex].Values[0]);


        string Email = (row.Cells[2].Controls[0] as TextBox).Text;
        string ContactNo = (row.Cells[4].Controls[0] as TextBox).Text;
        string Name = (row.Cells[3].Controls[0] as TextBox).Text;
        string Dept = (row.Cells[5].Controls[0] as TextBox).Text;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE EmployeeDetails SET Email = @Email, ContactNo = @ContactNo,Fname=@Fname,Dept=@Dept WHERE EmployeeId = @EmployeeId"))
            {
                cmd.Parameters.AddWithValue("@EmployeeId", EmpID);
                cmd.Parameters.AddWithValue("@FName", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
                cmd.Parameters.AddWithValue("@Dept", Dept);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        GridEmp.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridEmp.EditIndex = -1;
        this.BindGrid();
    }
   
    protected void GridEmp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridEmp.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        objdal.DeleteEmployeeDetails(GridEmp.DataKeys[e.RowIndex].Value.ToString());
BindGrid();
 foreach (DataRow dr in dtSession.Rows)
        {
            if (dr["EmployeeId"].ToString() == GridEmp.DataKeys[e.RowIndex].Value.ToString())
                dr.Delete();
        }
           dtSession.AcceptChanges();
        GridEmp.DataSource = dtSession;
        GridEmp.DataBind();
       

    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridEmp.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    private void BindGrid()
    {
      
        if (branchId == "0")
        {
            //cmd = new SqlCommand(Session["EmpDtls"].ToString(),con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
           dtSession = (DataTable)Session["EmpDtls"];
            GridEmp.DataSource = dtSession;//Session["EmpDtls"].ToString();
            GridEmp.DataBind();

        }
        else
        {
            cmd = new SqlCommand("sp_BindEmpData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("orgId", this.orgId);
            cmd.Parameters.AddWithValue("branchId", this.branchId);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridEmp.DataSource = dt;
            GridEmp.DataBind();

        }

    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridEmp.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void GridEmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string mobNo = (dr["sMobile"].ToString());
            string emailId = (dr["sEmailId"].ToString());
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();

            if (emailId != "" )
                e.Row.Cells[2].Text = CryptoHelper.Decrypt(emailId);
            else
                e.Row.Cells[2].Text = (emailId);
            if(mobNo!="")
                e.Row.Cells[3].Text = CryptoHelper.Decrypt(mobNo);
            else
                e.Row.Cells[3].Text = (mobNo);


        }
    }
}