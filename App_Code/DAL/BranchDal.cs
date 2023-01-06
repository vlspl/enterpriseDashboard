using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BranchDal
/// </summary>
public class BranchDal
{
    public BranchDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddBranchDetails(BranchBO branchBO,string orgId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddBranchDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
        

            cmd.Parameters.AddWithValue("@parentbranch", branchBO.ParentBranch);
            cmd.Parameters.AddWithValue("@usernamebranch", branchBO.UserNameBranch);
            cmd.Parameters.AddWithValue("@designation", branchBO.Designation);
            cmd.Parameters.AddWithValue("@branchName", branchBO.BranchName);
            cmd.Parameters.AddWithValue("@staus", branchBO.Status);
            cmd.Parameters.AddWithValue("@address", branchBO.Address);
            cmd.Parameters.AddWithValue("@country", branchBO.Country);
            cmd.Parameters.AddWithValue("@state", branchBO.State);
            cmd.Parameters.AddWithValue("@city", branchBO.City);
            cmd.Parameters.AddWithValue("@zipCode", branchBO.ZipCode);
            cmd.Parameters.AddWithValue("@mobileNo", branchBO.MobileNo);
            cmd.Parameters.AddWithValue("@emailId", branchBO.Email);
            cmd.Parameters.AddWithValue("@orgId", orgId);

            cmd.Parameters.AddWithValue("@returnval",  SqlDbType.Int);


            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            //con.Open();
            //cmd = new SqlCommand("update EnterpriseData set dpt_male=dpt_male+1,dpt_female=dpt_male+1 where orgId='" + orgId + "' and City_branch='" + branchBO.BranchName + "'", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            return Result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int UpdateBranchDetails(int branchId, string BranchName,string status ) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_UpdateBranchDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branchId", branchId);
            cmd.Parameters.AddWithValue("@branchName", BranchName);
            cmd.Parameters.AddWithValue("@status", status);
            //cmd.Parameters.AddWithValue("@address", address);
            //cmd.Parameters.AddWithValue("@country", country);
            //cmd.Parameters.AddWithValue("@state", state);
            //cmd.Parameters.AddWithValue("@city", city);
            //cmd.Parameters.AddWithValue("@zipCode",zipCode);
            //cmd.Parameters.AddWithValue("@mobileNo", mobileNo);
            //cmd.Parameters.AddWithValue("@emailId", email);
            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return Result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DeleteBranchDetails(int branchId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_DeleteBranchDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branchId", branchId);
           
            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return Result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable fillData(string branchId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT * FROM BranchMaster bm inner join OrganizationUsers ou on ou.Branch_ID = bm.ID and ou.Org_Id = bm.Org_Id inner join UserLoginMaster ulm on  ulm.UserId = ou.ID where bm.ID  ='" + branchId + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }


}