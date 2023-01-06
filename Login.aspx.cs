using CrossPlatformAESEncryption.Helper;
using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rmtest : System.Web.UI.Page
{
    loginDal dal = new loginDal();
    ClsLabLogin objLogin = new ClsLabLogin();
    LoginBO BO = new LoginBO();
    DBClass db = new DBClass();
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        login();


    }
    void login()
    {
        int j = dal.login(txtUserName.Text, txtpassword.Text);
        string userNmWithEncode = HttpUtility.UrlEncode(CryptoHelper.Encrypt(txtUserName.Text));//this method for passing special char like + % to querystring
        string userNm = CryptoHelper.Encrypt(txtUserName.Text);
        string pwd = (CryptoHelper.Encrypt(txtpassword.Text));
        SqlParameter[] param = new SqlParameter[]
         {
                new SqlParameter("@UserName",userNm),
                new SqlParameter("@Password",pwd)
         };
        DataTable dt = DAL.ExecuteStoredProcedureDataTable("sp_LoginMaster", param); //userLoginMaster
        if (dt.Rows.Count > 0)
        {
            DataTable Empdt = objLogin.EnterpriseUserLoginDetails(dt.Rows[0]["UserId"].ToString()); //OrganizationUsers 
            if (Empdt.Rows.Count > 0)
            {
                if (Empdt.Rows[0]["IsActive"].ToString().ToLower() == "true")
                {
                    Session["loggedIn"] = "true";
                    Session["OrgId"] = Empdt.Rows[0]["Org_Id"].ToString();
                    Session["BranchId"] = Empdt.Rows[0]["Branch_ID"].ToString();
                    Session["HRId"] = Empdt.Rows[0]["ID"].ToString();

                    Response.Cookies["loggedIn"].Value = "true";
                    Response.Cookies["OrgId"].Value = Empdt.Rows[0]["Org_Id"].ToString();
                    Response.Cookies["BranchId"].Value = Empdt.Rows[0]["Branch_ID"].ToString();
                    Response.Cookies["HRId"].Value = Empdt.Rows[0]["ID"].ToString();

                    Session["userName"] = txtUserName.Text;

                    //ViewState["OrgId"] = Empdt.Rows[0]["Org_Id"].ToString();
                    //string id = ViewState["OrgId"].ToString();
                }
            }

            //  HttpUtility.UrlEncode(userNm);  this for passing special character in querystring
            Response.Redirect(String.Format("Default.aspx"));
        }
        else
        {
            // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Invalid UserName Or Password ')", true);
            lblMsg.Text = "Invalid UserName Or Password!!";
        }
    }

    protected void txtpassword_TextChanged(object sender, EventArgs e)
    {
        login();
    }
}