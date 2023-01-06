using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class EnterpriseMasterPage : System.Web.UI.MasterPage
{
    string script, userNm;
    string orgId,getImagePath="",branchId, _getImgPath,userId;
    DBClass db = new DBClass();
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            userNm = Session["userName"].ToString();
            branchId = Session["BranchId"].ToString();
            orgId = Session["OrgId"].ToString();
         userId= Session["HRId"].ToString();
            //DataTable dt_getValues = DAL.GetDataTable("SELECT  OrganizationMaster.Name as OrgName,OrganizationUsers.Name as UserNm,BranchName FROM OrganizationMaster INNER JOIN  BranchMaster ON OrganizationMaster.ID = BranchMaster.Org_Id INNER JOIN  OrganizationUsers ON OrganizationMaster.ID = OrganizationUsers.Org_Id AND BranchMaster.ID = OrganizationUsers.Branch_ID WHERE(OrganizationMaster.ID = '" + orgId + "') and BranchMaster.Email ='" + userNm + "'");
            DataTable dt_getValues = DAL.GetDataTable("SELECT  OrganizationMaster.Name as OrgName,OrganizationUsers.Name as UserNm from  OrganizationUsers inner join OrganizationMaster  ON OrganizationMaster.ID = OrganizationUsers.Org_Id  WHERE(OrganizationUsers.Org_Id = '" + orgId + "') and Branch_ID='" + branchId + "'  and  OrganizationUsers.Id='"+userId+"'");
            if (dt_getValues.Rows.Count>0)
            {
                lblCmpnyNm.Text = dt_getValues.Rows[0]["OrgName"].ToString();
               lblUsernm.Text= dt_getValues.Rows[0]["UserNm"].ToString();
               // lblBranchnm.Text= dt_getValues.Rows[0]["BranchName"].ToString();
            }
            // lblUsernm.Text = db.getData("SELECT Name FROM OrganizationUsers WHERE Org_Id = '" + orgId + "' and Branch_ID='" + branchId + "'").ToString();

            DataTable dtForBranchNm = DAL.GetDataTable("select BranchName from BranchMaster bm inner join SubBranchDetails sd on bm.Org_Id=sd.orgId and bm.ID=sd.branchId where Org_Id = '" + orgId + "' and sd.branchId = '" + branchId + "' ");
            if (dtForBranchNm.Rows.Count == 0)
                lblBranchnm.Text = "Main Branch";
            else
                lblBranchnm.Text = dtForBranchNm.Rows[0]["BranchName"].ToString();

            getImagePath = db.getData("select Org_Logo FROM OrganizationMaster where ID='" + orgId + "'");
         // if (File.Exists(getImagePath))
          //  {
		  string str = getImagePath.Replace("../", "");

         //   Label1.Text = "https://www.visionarylifescience.com/" + str;
            Image1.ImageUrl = "https://www.visionarylifescience.com/" + str;
            Image1.Visible = true;
		//}
		//else
            //{
             //   Image1.ImageUrl = "images//howzuLogo.png";

            //}
        }
    }
  
    public string GetSliderPath()
    {
        string JSONString = string.Empty; // Create string object to return final output
        dynamic Result = new JObject();  //Createroot JSON Object
        Result.MyDetails = new JArray() as dynamic;

        try
        {
            SqlParameter[] param = new SqlParameter[]
                {
                          new SqlParameter("@SearchingText","")
                };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("WS_Sp_GetSliderPath", param);
            if (dt.Rows.Count > 0)
            {
                dynamic ObjImageDetail = new JObject();
                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    ObjImageDetail.ImageTitle = dt.Rows[j]["ImageTitle"];
                    ObjImageDetail.ImagePath = dt.Rows[j]["ImagePath"];
                    // Get's No of Rows Count 
                    Result.MyDetails.Add(ObjImageDetail); //Add  details to array
                    Result.Status = true;  //  Status Key 
                }
            }
            else
            {
                Result.Status = false;  //  Status Key
                Result.Msg = "No Record Found";
            }
            JSONString = JsonConvert.SerializeObject(Result);

            // getting booking Id from response
            dynamic jsonResponse = JsonConvert.DeserializeObject(Result.Content);
            dynamic get_Json_data = JObject.Parse(jsonResponse);

            // grab the values and do your assertions :-)
            var getPath = get_Json_data["ImagePath"];
            _getImgPath = Convert.ToInt32(getPath);
        }
        catch (Exception e)
        {
            Result.Status = false;  //  Status Key
            Result.Msg = "Something went wrong,Please try again.";
            JSONString = JsonConvert.SerializeObject(Result);
        }
        return JSONString;
    }

}
