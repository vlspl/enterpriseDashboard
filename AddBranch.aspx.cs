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
using DataAccessHandler;
public partial class AddBranch : System.Web.UI.Page
{
    public int branchId;
    public int AddBranchDetails;
    public int EmpChieldID;
    DataTable dt = new DataTable();
    DBClass db = new DBClass();
    DataTable dtFillData;
    string userNm, OrgId;
    BranchDal objdal = new BranchDal();
    BranchBO objBranchBo = new BranchBO();
    DataAccessLayer DAL = new DataAccessLayer();


    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        OrgId= (Session["OrgId"].ToString());
        branchId = int.Parse( Session["BranchId"].ToString());

        txtbranchName.ReadOnly = false;
        if (!IsPostBack)
        {
            txtpwd.Attributes["type"] = "password";
            txtConpwd.Attributes["type"] = "password";
           // db.bindDrp("select distinct country from EnterpriseData", drpCountry, "country", "country");

            // drpCountry.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"
            //   db.bindDrp("select branchName from BranchMaster where Org_Id='" + OrgId + "' and ID='"+branchId+"' ", drpParentBranch, "branchName", "branchName");

            // db.bindDrp("select distinct City_branch from EnterpriseData", drpCity, "City_branch", "City_branch");

            //  db.bindDrp("select distinct Name from accessControlMaster where orgId='" + OrgId + "'", txtUserNameBranch, "Name", "Name");

            if (Request.QueryString["ID"] != null)
            {
              //  BindGrid();
                dtFillData = objdal.fillData(Request.QueryString["ID"]);
                foreach (DataRow row in dtFillData.Rows)
                {
                   // drpParentBranch.Text = row["parentBranch"].ToString();
                    txtbranchName.Text = row["branchName"].ToString();
                   
                    txtAddress.Text = row["BranchAddress"].ToString();
                    txtEmail.Text =CryptoHelper.Decrypt(row["Email"].ToString());
                    txtMobile.Text = CryptoHelper.Decrypt(row["Contact"].ToString());
                    txthr.Text = row["Name"].ToString();
                    txtpwd.Text = row["Password"].ToString();
                    txtConpwd.Text = row["Password"].ToString();
                    txtpwd.Attributes["value"] = row["Password"].ToString();
                    txtConpwd.Attributes["value"] = row["Password"].ToString();
                    btnUpdate.Visible = true;
                    BtnSave.Visible = false;

                    txtbranchName.ReadOnly = true;
                    txtAddress.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtMobile.ReadOnly = true;
                    txthr.ReadOnly = true;
                    txtpwd.ReadOnly = true;
                    txtConpwd.ReadOnly = true;
                   
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("UserNameBranch"), new DataColumn("Designation") });

            ViewState["Branch"] = dt;

        }
    }

   
    protected void Insert(object sender, EventArgs e)
    {
        //dt = (DataTable)ViewState["Branch"];
        //dt.Rows.Add(txtUserNameBranch.Text, txtDesignation.Text);
        //GridView1.DataSource = dt;
        //GridView1.DataBind();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["Branch"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["dt"] = dt;
        //GridView1.DataSource = dt;
        //GridView1.DataBind();
    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        lblError.Visible = true;
        if (txtbranchName.Text == "")
            lblError.Text = "Please Enter Branch Name";
        else if(db.chkDBValue("SELECT branchId FROM AddBranch  WHERE  [branchName]= '"+ txtbranchName .Text+ "'  and orgId='"+OrgId+"'"))
            lblError.Text = "Branch Already Exist";

        else if (txtAddress.Text == "")
            lblError.Text = "Please Enter Address";
       
        else if (txtMobile.Text == "")
            lblError.Text = "Please Enter Mobile No";
        else if (txtEmail.Text == "")
            lblError.Text = "Please Enter Email";
        else if (txthr.Text == "")
            lblError.Text = "Please Enter HR Name";
        else
        {
            saveDetails();

            ClsEmailTemplates emailTemp = new ClsEmailTemplates();
            string subject = "HowzU Connect – Thank you for your registration. Sign in today.";
            string mailbody= mailbody = "Greetings of the day! <br />" +

                "<h3>Dear " + txthr.Text + ", </h3><br />" +

                "Welcome to Howzu. <br/><br/>" +
                "We take this opportunity to welcome you and your team to our best-in-class and state of the art healthcare solution. We have our presence PAN India with HQ based out of Pune. <br/>" +
                "We are pleased that your Organisation decided to be part of our young and dynamic family.<br/><br/>"+

                "Our comprehensive health dashboards enable an Organization to streamline its employees’ health records on different levels ranging from departments,offices,cities etc.<br/> " +
                "and analyze their health in statistical representation for effortless understanding. <br/><br/>"+

                "It also permits HR or any head of the department to authorize its employees to undergo specific tests from specific labs in special situations and update reports in the software. <br/><br/>" +
               "Get Started to be the change,<br/>"+
                "<br />Follow the steps below for the further process now :<br /><br />" +
                 "<b>1. Click on the below link to login: :</b><br /><br />" +
                "<b> : https://enterprise.visionarylifesciences.in/ </b><br />" +
                
                "<b>2 . Kindly use following credentials to Sign in,</b><br /><br />" +
                        "<b>User Name : " + txtEmail.Text + "</b><br />" +
                        "<b>PassCode : " + txtpwd.Text + "</b><br /><br />" +

                "Enjoy the Health journey with us and we are looking for a long and endeavoring business Relationship. <br /><br/>" +


                "<b>Yours sincerely ,</b><br />" +
                "<b>Howzu Team. </b> <br />" +
                "support@howzu.co.in";
            string mailSent = emailTemp.sendmail(txtEmail.Text, txtpwd.Text, txthr.Text, txtMobile.Text, mailbody, subject);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "insertSuccess", "alert('Save successfully');location.href='Branch.aspx';", true);

            //SaveData();
            txtbranchName.Text = txtAddress.Text = txtEmail.Text = txtMobile.Text =    string.Empty;
            //ViewState["Branch"] = "";

            lblError.Visible = false;
            txtbranchName.Text = txtAddress.Text = txtEmail.Text = txthr.Text = txtMobile.Text = txtpwd.Text = txtConpwd.Text = string.Empty;
        }
    }

    private void saveDetails()
    {
        try
        {
            LogError _log = new LogError();
            string Output = string.Empty;
            BranchBO objBranchBO = new BranchBO();

            objBranchBO.ParentBranch = "0";
            objBranchBO.BranchName = txtbranchName.Text;
            objBranchBO.Status = "Active";
            objBranchBO.Address = txtAddress.Text;
            objBranchBO.Country = "";
            objBranchBO.State = "";
            objBranchBO.City = "";
            objBranchBO.ZipCode ="";
            objBranchBO.MobileNo = txtMobile.Text;
            objBranchBO.Email = txtEmail.Text;
            objBranchBO.UserNameBranch = txtpwd.Text;
            objBranchBO.Designation = txtConpwd.Text;

            BranchDal objdal = new BranchDal();

            int _branchId = objdal.AddBranchDetails(objBranchBO, OrgId);

            ///Submit Data To Database
            string _password = CryptoHelper.Encrypt(txtpwd.Text);
            string _EmailId = txtEmail.Text != "" ? CryptoHelper.Encrypt(txtEmail.Text) : "";
            string _Mobile = txtMobile.Text != "" ? CryptoHelper.Encrypt(txtMobile.Text) : "";
          //  string _parentBranchId = DAL.ExecuteScalar("select ID from BranchMaster where Org_Id='"+OrgId+"' ");


            //Insert into branch master
            SqlParameter[] param = new SqlParameter[]
                         {
                             new SqlParameter("@Org_Id",OrgId),
                             new SqlParameter("@BranchName",txtbranchName.Text),
                             new SqlParameter("@BranchAddress",txtAddress.Text),
                             new SqlParameter("@Contact",_Mobile),
                             new SqlParameter("@Email",_EmailId),
                             new SqlParameter("@BranchDetails",""),
                             // new SqlParameter("@parentBranchId",_parentBranchId),
                              // new SqlParameter("@branchType","Sub"),
                             new SqlParameter("@returnval",SqlDbType.Int)
                          };
            int Result = DAL.ExecuteStoredProcedureRetnInt("Sp_AddOrgnizationBranch", param);

            //Insert into BranchSub Assign Table
            SqlParameter[] paramSubBranch = new SqlParameter[]
                         {
                             new SqlParameter("@parentBranchId",branchId),
                             new SqlParameter("@branchId",Result),
                             new SqlParameter("@orgId",OrgId),

                             new SqlParameter("@status","Active"),
                              new SqlParameter("@createdBy",System.DateTime.Now),
                             new SqlParameter("@createdDate",System.DateTime.Now),
                             new SqlParameter("@editedBy",""),
                             new SqlParameter("@editedDate",System.DateTime.Now),
                             new SqlParameter("@deletedBy",""),
                             new SqlParameter("@deletedDate",System.DateTime.Now),

                             new SqlParameter("@returnval",SqlDbType.Int)
                          };
            int ResultSubBranch = DAL.ExecuteStoredProcedureRetnInt("Sp_subBranchDetails", paramSubBranch);

            //Insert into organization user
            if (Result >= 1)
            {
                SqlParameter[] param1 = new SqlParameter[]
                         {
                             new SqlParameter("@Name",txthr.Text),
                             new SqlParameter("@Org_Id",OrgId),
                             new SqlParameter("@Branch_ID",Result),
                             new SqlParameter("@Contact",_Mobile),
                             new SqlParameter("@Email",_EmailId),
                             new SqlParameter("@Role","Enterprise"),
                             new SqlParameter("@Password",""),
                             new SqlParameter("@returnval",SqlDbType.Int)
                          };
                int Resultval = DAL.ExecuteStoredProcedureRetnInt("Sp_AddOrgnizationUser", param1);

                //Insert into user login master
                if (Resultval > 1)
                {
                    SqlParameter[] paramlab = new SqlParameter[]
                                             {
                                                new SqlParameter("@UserId",Resultval),
                                                new SqlParameter("@Mobile",_Mobile),
                                                new SqlParameter("@EmailId",_EmailId),
                                                new SqlParameter("@Role","Enterprise"),
                                                new SqlParameter("@Password",_password),
                                                new SqlParameter("@UserName",""),
                                                new SqlParameter("@Returnval",SqlDbType.Int)
                                             };
                    int ResultVal1 = DAL.ExecuteStoredProcedureRetnInt("Sp_AddUserLoginCredentials", paramlab); 
                    //  litErrorMessage.Text = ApplicationLogic.SuccessMessage("● Saved Suceessfully.");


                }
                else if (Result == -2)
                {
                    lblError.Text = ("● User Already Exist!");
                }
            }
            else if (Result == -2)
            {
                lblError.Text = ("● Already Exist!");
            }
            else
            {
                lblError.Text = ("● Something Went Wrong, Please try Again!");
            }
            //BindGrid();
            txtbranchName.Text = string.Empty;
          //  drpStatus.Text = "--Select--";
        }
        catch (Exception ex)
        {
            throw ex;
          // LoggerCatch(ex);
        }
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("sp_BindBranchData", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("orgId", OrgId);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        //GridView1.DataSource = dt;
                        //GridView1.DataBind();
                    }
                }
            }
        }
    }

    private void saveDetails12()
    {
        DataTable dt = new DataTable();
        //dt.Columns.AddRange(new DataColumn[] { new DataColumn("ParentBranch", typeof(int)), new DataColumn("BranchName", typeof(string)), new DataColumn("Status", typeof(string)), new DataColumn("Address", typeof(string)), new DataColumn("Country", typeof(string)), new DataColumn("State", typeof(string)), new DataColumn ("City", typeof(string)), new DataColumn ("Zipcode", typeof(string)), new DataColumn ("MobileNo", typeof(string)), new DataColumn ("Email", typeof(string)), new DataColumn ("UserNameBranch", typeof(string)), new DataColumn ("Designation", typeof(string)) });
        dt.Columns.AddRange(new DataColumn[] { new DataColumn("UserNameBranch", typeof(string)), new DataColumn("Designation", typeof(string)) });
        //foreach (GridViewRow row in GridView1.Rows)
        //{
        //    dt.Rows.Clear();
        //    // string EmpChieldID1 =int.Parse(txtEmpid.Text).ToString();
        //    //string ParentBranch = row.Cells[0].Text;
        //    //string branchId = row.Cells[1].Text;
        //    //string BranchName = row.Cells[1].Text;
        //    //string Status = row.Cells[2].Text;
        //    //string Address = row.Cells[3].Text;
        //    //string Country = row.Cells[4].Text;
        //    //string State = row.Cells[5].Text;
        //    //string City = row.Cells[6].Text;
        //    //string Zipcode = row.Cells[7].Text;
        //    //string MobileNo = row.Cells[8].Text;
        //    //string Email = row.Cells[9].Text;

        //    string UserNameBranch = row.Cells[0].Text;
        //    string Designation = row.Cells[1].Text;

        //    //dt.Rows.Add(ParentBranch, BranchName, Status, Address, Country, State, City, Zipcode, MobileNo, Email, UserNameBranch, Designation);
        //    dt.Rows.Add(UserNameBranch, Designation);
        //    //EmPpDal objbal = new EmPpDal();
        //    BranchBO objBranchBO = new BranchBO();
        //    //DataTable j = objdal.AddBranchDetails(dt, branchId);
        //    int j = objdal.AddBranchDetails(objBranchBo, OrgId);

        //}
    }




    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Branch.aspx");
    }
}
