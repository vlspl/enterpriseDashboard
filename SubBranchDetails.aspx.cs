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

public partial class subBranchDetails : System.Web.UI.Page
{

    string userNm, branchId;
    string OrgId;
    public int EmpChieldID;
    DBClass db = new DBClass();
    private object dtFillData;
    userBranchAccessDAL objDAL = new userBranchAccessDAL();
    subBranchDetailsDAL objDal = new subBranchDetailsDAL();

    DataAccessLayer DAL = new DataAccessLayer();
    SqlConnection cn;

    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        branchId = Session["BranchId"].ToString();
        OrgId = Session["OrgId"].ToString();

        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        if (!this.IsPostBack)
            {
            
            cn.Open();
            SqlCommand cmd = new SqlCommand("select BranchName,ID from BranchMaster where Org_Id='" + OrgId + "' order by BranchName asc", cn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            drpParentBranch.DataSource = dt;
            
            drpParentBranch.DataTextField = "BranchName";
            drpParentBranch.DataValueField = "ID";
            drpParentBranch.DataBind();

            drpSubBranch.DataSource = dt;//dt.Select("BranchName,ID <> " + drpParentBranch.SelectedValue);


            drpSubBranch.DataTextField = "BranchName";
            drpSubBranch.DataValueField = "ID";
            drpSubBranch.DataBind();
            cn.Close();


           BindGrid();



            }

        
    }

    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
        protected void BtnSave_Click(object sender, EventArgs e)
    {
        lblError.Visible = true;
        if (drpParentBranch.SelectedValue == "")
            lblError.Text = "Please Enter Parent Branch ";
        else if (drpSubBranch.SelectedValue == "")
            lblError.Text = "Please Enter Sub Branch";
      else if (drpParentBranch.SelectedValue == drpSubBranch.SelectedValue)
            lblError.Text = "You cant't select Same Parent Branch and Sub Branch ";
        else if (db.chkDBValue("select * from SubBranchDetails where branchId='" + drpParentBranch.SelectedValue + "' and parentBranchId='" + drpSubBranch.SelectedValue + "'"))
            lblError.Text = "You cant't Use this Criteria.Because Same sub Branch is used as Parent";

        else
        {
            insert();
          
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
            //drpParentBranch.Text = drpStatus.Text  = string.Empty;
            //ViewState["Branch"] = "";
            BindGrid();

            lblError.Visible = false;
        }
    }

 

    private void BindGrid()
    {
        //GridView1.DataSource = DAL.GetDataTable("Sp_GetsubBranchDetails" );
        //GridView1.DataBind();
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("[Sp_GetsubBranchDetails]", con))

            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgId", OrgId);

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }

    int parentBranchId, subbranchId;
    private void insert()
    {
        try
        {
            string Output = string.Empty;
            subBranchDetailsBO  objsubBranchBO = new subBranchDetailsBO();

          

                // here get id's from dropdown selectd value

                //parentBranchId = int.Parse(DAL.ExecuteScalar("select ID from BranchMaster where BranchName='" + drpParentBranch.Text + "'"));
                //subbranchId = int.Parse(DAL.ExecuteScalar("select ID from BranchMaster where BranchName='" + drpSubBranch.Text + "'"));


                objsubBranchBO.ParentBranch = drpParentBranch.SelectedValue;
                objsubBranchBO.subBranch = drpSubBranch.SelectedValue;
                objsubBranchBO.Status = drpStatus.SelectedValue;
                objsubBranchBO.CreatedBy = "";
                objsubBranchBO.CreatedDate = System.DateTime.Now;
                objsubBranchBO.DeletedBy = "";
                objsubBranchBO.DeletedDate = System.DateTime.Now;
                objsubBranchBO.EditedBy = "";
                objsubBranchBO.EditedDate = System.DateTime.Now;

                subBranchDetailsDAL objDal = new subBranchDetailsDAL();

                int j = objDal.subBranchDetails(objsubBranchBO, int.Parse(OrgId.ToString()));
          
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


   

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        objDAL.delete(id);
        BindGrid();

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        

        int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lblID");

       
        string Status = (row.Cells[3].Controls[0] as TextBox).Text;
        cn.Open();
        SqlCommand cmd = new SqlCommand("Update SubBranchDetails set Status='" + Status + "' where branch_subBranchId='" + userid + "'",cn);
        cmd.ExecuteNonQuery();
        GridView1.EditIndex = -1;

        cn.Close();
       

        BindGrid();

    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[4].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete ?')){ return false; };";
                }
            }
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGrid();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void txtsearch_TextChanged(object sender, EventArgs e)
    {

    }
}