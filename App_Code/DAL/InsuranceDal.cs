using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for InsuranceDal
/// </summary>
public class InsuranceDal
{
    public InsuranceDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddInsuranceDetails(InsuranceBO insuranceBO) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddInsuranceDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@policyName", insuranceBO.PolicyName);
            cmd.Parameters.AddWithValue("@deptName", insuranceBO.DeptName);
            cmd.Parameters.AddWithValue("@branch", insuranceBO.Branch);
            cmd.Parameters.AddWithValue("@state", insuranceBO.State);
            cmd.Parameters.AddWithValue("@city", insuranceBO.City);
            cmd.Parameters.AddWithValue("@age", insuranceBO.Age);
            cmd.Parameters.AddWithValue("@gender", insuranceBO.Gender);
            cmd.Parameters.AddWithValue("@hospitalNm", insuranceBO.HospitalNm);
            cmd.Parameters.AddWithValue("@staus", insuranceBO.Status);


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

    public int DeleteInsuranceDetails(int insuranceId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_DeleteInsuranceDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@insuranceId", insuranceId);

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
    public DataTable fillData(string insuranceId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT * FROM EmployeeInsurance where insuranceId='" + insuranceId + "'", con);

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