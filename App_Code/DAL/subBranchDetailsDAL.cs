using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for subBranchDetailsDAL
/// </summary>
public class subBranchDetailsDAL
{
    public subBranchDetailsDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    private object branch_subBranchId;

    public int subBranchDetails(subBranchDetailsBO subBranchBO, int orgId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("[Sp_subBranchDetails]", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parentBranchId", subBranchBO.ParentBranch);
            cmd.Parameters.AddWithValue("@branchId", subBranchBO.subBranch);
            cmd.Parameters.AddWithValue("@orgId", orgId);
            cmd.Parameters.AddWithValue("@status", subBranchBO.Status);
           // cmd.Parameters.AddWithValue("@userId", 0);
            //cmd.Parameters.AddWithValue("@orgId", orgId);
            cmd.Parameters.AddWithValue("@createdBy", subBranchBO.CreatedBy);
            cmd.Parameters.AddWithValue("@createdDate", subBranchBO.CreatedDate);
            cmd.Parameters.AddWithValue("@editedBy", subBranchBO.EditedBy);
            cmd.Parameters.AddWithValue("@editedDate", subBranchBO.EditedDate);
            cmd.Parameters.AddWithValue("@deletedBy", subBranchBO.DeletedBy);
            cmd.Parameters.AddWithValue("@deletedDate", subBranchBO.DeletedDate);



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

    public int OnRowUpdating(string ParentBranch, string BranchName, string status) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("[sp_updatesubBranchDetails]", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parentBranch", ParentBranch);
            cmd.Parameters.AddWithValue("@subBranch", BranchName);
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

    public int GridView1_RowDeleting(int userId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("[Sp_DeletesubBranchDetails1]", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branchsubBranchId", branch_subBranchId);

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


        SqlCommand cmd = new SqlCommand("SELECT * FROM subBranchDetails where branchsubBranchId='" + branch_subBranchId + "'", con);


        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
}