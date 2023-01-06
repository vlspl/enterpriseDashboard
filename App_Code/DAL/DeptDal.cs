using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeptDal
/// </summary>
public class DeptDal
{
  
    public DeptDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddDeptDetails(DepartmentBO deptBO,string orgId,string branchId) // passing Bussiness object Here  
    {

        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddDepartmentDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeptName", deptBO.deptName);
            cmd.Parameters.AddWithValue("@staus", deptBO.status);
            cmd.Parameters.AddWithValue("@orgId", orgId);
            cmd.Parameters.AddWithValue("@branchId", branchId);
            cmd.Parameters.AddWithValue("@Returnval", SqlDbType.Int);
            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            //con.Open();
            //cmd = new SqlCommand("update EnterpriseData set dpt_male=dpt_male+1,dpt_female=dpt_male+1 where orgId='"+ orgId + "' and department='"+ deptBO.deptName + "'", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            return Result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateDeptDetails(int deptId,string deptName, string status) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_UpdateDepartmentDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptId", deptId);
            cmd.Parameters.AddWithValue("@deptName", deptName);
            cmd.Parameters.AddWithValue("@status",status);
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
   

    public int DeleteDeptDetails(int deptId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_DeleteDeptDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptId", deptId);

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
    public DataTable fillData(string deptId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT * FROM AddDepartment where DeptId='" + deptId + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
}