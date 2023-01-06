using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for userCreationDal
/// </summary>
public class userCreationDal
{
    DBClass db = new DBClass();
    public userCreationDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddUser(UserCreationBO userBO) // passing Bussiness object Here  
    {
        try
        {
           

            // Insert into Access control master

            SqlCommand cmd = new SqlCommand("Sp_AcessControlMaster", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", userBO.Name);
            cmd.Parameters.AddWithValue("@designation", userBO.Designation);
            cmd.Parameters.AddWithValue("@mobile", userBO.MobileNo);
            cmd.Parameters.AddWithValue("@emailId", userBO.Email);
           
            cmd.Parameters.AddWithValue("@department", userBO.Department);
            cmd.Parameters.AddWithValue("@password", userBO.Password);
            cmd.Parameters.AddWithValue("@remark", userBO.Remark);
            cmd.Parameters.AddWithValue("@orgId", userBO.OrgId);
            cmd.Parameters.AddWithValue("@createdBy", userBO.CreatedBy);
            cmd.Parameters.AddWithValue("@createdDate", userBO.CreatedDate);
            cmd.Parameters.AddWithValue("@editedBy", userBO.EditedBy);
            cmd.Parameters.AddWithValue("@editedDate", userBO.EditedDate);
            cmd.Parameters.AddWithValue("@deletedBy", userBO.DeletedBy);
            cmd.Parameters.AddWithValue("@deletedDate", userBO.DeletedDate);
            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd.Dispose();

            // Insert into Access control Details
          // int masterId= int.Parse(db.getData("select max(masterid) from accessControlMaster")+1);
           
            cmd = new SqlCommand("SELECT MAX(masterid) FROM accessControlMaster", con);

            int EmpId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            return EmpId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateDeptDetails(int deptId, string deptName, string status) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_UpdateDepartmentDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptId", deptId);
            cmd.Parameters.AddWithValue("@deptName", deptName);
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


    public int DeleteUserDetails(int masterId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_DeleteUserDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masterid", masterId);

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

    public DataTable AddCountryCityDetails(DataTable dt, int masterId)
    {
        if (dt.Rows.Count > 0)
        {
            string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.acessControlDetails";

                    //[OPTIONAL]: Map the DataTable columns with that of the database table
                    //sqlBulkCopy.ColumnMappings.Add("id", "masterId");
                    sqlBulkCopy.ColumnMappings.Add("accessCntrlmasterid", "masterid");
                    sqlBulkCopy.ColumnMappings.Add("country", "country");
                    sqlBulkCopy.ColumnMappings.Add("city_branch", "city_branch");
                  

                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
        }
        return dt;
    }
}