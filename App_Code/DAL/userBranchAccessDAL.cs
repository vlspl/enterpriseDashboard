using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for userBranchAccessDAL
/// </summary>
public class userBranchAccessDAL
{
    public userBranchAccessDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    private object userId;

    public int userBranchAssignDetails(userBranchAssignBO userBranchAssignBO, int orgId,int branchId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("[Sp_userBranchAssign]", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userName", userBranchAssignBO.UserName);
            cmd.Parameters.AddWithValue("@branchName", userBranchAssignBO.BranchName);
            cmd.Parameters.AddWithValue("@status", userBranchAssignBO.Status);
            cmd.Parameters.AddWithValue("@userId", 0);
            cmd.Parameters.AddWithValue("@orgId", orgId);
            cmd.Parameters.AddWithValue("@createdBy", userBranchAssignBO.CreatedBy);
            cmd.Parameters.AddWithValue("@createdDate", userBranchAssignBO.CreatedDate);
            cmd.Parameters.AddWithValue("@editedBy", userBranchAssignBO.EditedBy);
            cmd.Parameters.AddWithValue("@editedDate", userBranchAssignBO.EditedDate);
            cmd.Parameters.AddWithValue("@deletedBy", userBranchAssignBO.DeletedBy);
            cmd.Parameters.AddWithValue("@deletedDate", userBranchAssignBO.DeletedDate);
            cmd.Parameters.AddWithValue("@branchId", branchId);
            cmd.Parameters.AddWithValue("@returnval", SqlDbType.Int);


            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            return Result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public int OnRowUpdating(string UserName, string branchName, string status) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("[Sp_UpdateDepartmentDetails]", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userName", UserName);
            cmd.Parameters.AddWithValue("@BranchName", branchName);
            cmd.Parameters.AddWithValue("@status", status);
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



    public int delete(int userBranchId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("[Sp_DeleteuserBranchAssign]", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userBranchId", userBranchId);

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
    public DataTable fillData(string userId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT * FROM userBranchAssign where userId='" + userId + "'", con);
     

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }


    
}
