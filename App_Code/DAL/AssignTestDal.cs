using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AssignTestDal
/// </summary>
public class AssignTestDal
{
    public AssignTestDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddAssignTestDetails(AssignTestBO testBO) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddAssignTestDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptName", testBO.DeptName);
            cmd.Parameters.AddWithValue("@branch", testBO.Branch);
            cmd.Parameters.AddWithValue("@age", testBO.Age);
            cmd.Parameters.AddWithValue("@employee", testBO.Employee);
            cmd.Parameters.AddWithValue("@test", testBO.Test);
            cmd.Parameters.AddWithValue("@period", testBO.Period);

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
    public int UpdateTestDetails(int testId, string testName, string range, string status) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_UpdateTest", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@testId", testId);
            cmd.Parameters.AddWithValue("@testName", testName);
            cmd.Parameters.AddWithValue("@range", range);
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
    public int DeleteTesthDetails(int testId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_DeleteTestDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@testId", testId);

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
    public DataTable fillData(string assignTestID)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT * FROM AssignTest where assignTestId='" + assignTestID + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }

    public void bindDrp(string qry, DropDownList drp, string name, string value)
    {

      
        SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        drp.DataSource = dt;
        drp.DataBind();
        drp.DataTextField = name;
        drp.DataValueField = value;
        drp.DataBind();
       

    }
}