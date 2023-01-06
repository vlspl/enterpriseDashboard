using DataAccessHandler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class EmployeeMasterPage : System.Web.UI.MasterPage
{
    string getColor = "", userNm, branchId,userId;
    string OrgId, getImagePath;
    DBClass db = new DBClass();
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        if (!IsPostBack)
        {
            // OrgId = int.Parse(db.getData("SELECT OrganizationMaster.ID FROM  OrganizationMaster INNER JOIN BranchMaster ON OrganizationMaster.ID = BranchMaster.Org_Id INNER JOIN UserLoginMaster ON BranchMaster.ID = UserLoginMaster.UserId WHERE        (UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
            branchId = Session["BranchId"].ToString();
            OrgId = Session["OrgId"].ToString();
            userId= Session["HRId"].ToString();

            //  lblCmpnyNm.Text = db.getData("SELECT OrganizationMaster.Name FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString();

            //DataTable dt_getValues = DAL.GetDataTable("SELECT  OrganizationMaster.Name as OrgName,OrganizationUsers.Name as UserNm,BranchName FROM OrganizationMaster INNER JOIN  BranchMaster ON OrganizationMaster.ID = BranchMaster.Org_Id INNER JOIN  OrganizationUsers ON OrganizationMaster.ID = OrganizationUsers.Org_Id AND BranchMaster.ID = OrganizationUsers.Branch_ID WHERE(OrganizationMaster.ID = '" + OrgId + "') and BranchMaster.Email ='" + userNm + "'");
            DataTable dt_getValues = DAL.GetDataTable("SELECT  OrganizationMaster.Name as OrgName,OrganizationUsers.Name as UserNm from  OrganizationUsers inner join OrganizationMaster  ON OrganizationMaster.ID = OrganizationUsers.Org_Id  WHERE(OrganizationUsers.Org_Id = '" + OrgId + "') and Branch_ID='" + branchId + "'  and  OrganizationUsers.Id='"+userId+"'");
            if (dt_getValues.Rows.Count > 0)
            {
                lblCmpnyNm.Text = dt_getValues.Rows[0]["OrgName"].ToString();
                lblUsernm.Text = dt_getValues.Rows[0]["UserNm"].ToString();
               // lblBranchnm.Text = dt_getValues.Rows[0]["BranchName"].ToString();
            }
            DataTable dtForBranchNm = DAL.GetDataTable("select BranchName from BranchMaster bm inner join SubBranchDetails sd on bm.Org_Id=sd.orgId and bm.ID=sd.branchId where Org_Id = '" + OrgId + "' and sd.branchId = '" + branchId + "' ");
            if (dtForBranchNm.Rows.Count == 0)
                lblBranchnm.Text = "Main Branch";
            else
                lblBranchnm.Text = dtForBranchNm.Rows[0]["BranchName"].ToString();


            //  lblUsernm.Text = db.getData("SELECT Name FROM OrganizationUsers WHERE Org_Id = '" + OrgId + "' and Branch_ID='" + branchId + "'").ToString();
            getImagePath = db.getData("select Org_Logo FROM OrganizationMaster where ID='" + OrgId + "'");
           

		//if (File.Exists(getImagePath))
           // {
		  string str = getImagePath.Replace("../", "");

         //   Label1.Text = "https://www.visionarylifescience.com/" + str;
            Image1.ImageUrl = "https://www.visionarylifescience.com/" + str;
            Image1.Visible = true;
		//}
		//else
          //  {
            //    Image1.ImageUrl = "images//howzuLogo.png";

           // }
        }
    }

  
}
        
    