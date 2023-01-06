using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for HealthDal
/// </summary>
public class HealthDal
{
    int orgId,testId,labId;
    string testCode, labCode;
    public HealthDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddHealthDetails(HealthBO healthBO,int OrgId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddHealthDetails", con);

         
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@packageName", healthBO.PackageName);
            cmd.Parameters.AddWithValue("@department", healthBO.DeptName);
            cmd.Parameters.AddWithValue("@branch", healthBO.Branch);
            cmd.Parameters.AddWithValue("@age", healthBO.Age);
            cmd.Parameters.AddWithValue("@gender", healthBO.Gender); 
            cmd.Parameters.AddWithValue("@createdDate", healthBO.CreatedDate);
            cmd.Parameters.AddWithValue("@staus", healthBO.Status);
           // orgId = getOrgId(healthBO.organization);
            cmd.Parameters.AddWithValue("@orgId", OrgId);
           
            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd = new SqlCommand("SELECT MAX(pkgId) FROM EmployeeHealth", con);

            int EmpId = Convert.ToInt32(cmd.ExecuteScalar());

          
            cmd.Dispose();
            return EmpId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int getOrgId(string orgName)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select ID from OrganizationMaster where Name='"+ orgName + "'",con);
         orgId = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Dispose();
        con.Close();
        return orgId;
    }
    public string getTestCode(string testNam)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT   sTestCode FROM  test  where sTestName='" + testNam + "'", con);
        testCode = Convert.ToString(cmd.ExecuteScalar());
        cmd.Dispose();
        con.Close();
        return testCode;
    }
    public string getLabCode(string labName)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT  sLabCode FROM labMaster where sLabName = '" + labName + "'", con);
        labCode =Convert.ToString(cmd.ExecuteScalar());
        cmd.Dispose();
        con.Close();
        return labCode;
    }
    public int DeleteHealthDetails(int healthId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_DeleteHealthDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pkgId", healthId);

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
    public DataTable fillData(string healthId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT * FROM EmployeeHealth where pkgId='" + healthId + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
    public DataTable fillTest(string healthId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT pkgId,testName,   testCode ,orgId FROM  PackageTestDetails where pkgId='" + healthId + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
    public DataTable fillLab(string healthId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT   pkgId,labName,  labCode,orgId  FROM  PackageLabDetails where pkgId='" + healthId + "'", con);

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

    public int getTestId(string testName)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select sTestId from test where sTestName = '" + testName + "'", con);
        testId = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Dispose();
        con.Close();
        return testId;
    }
    public int getLabId(string labName)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT  sLabId FROM labMaster where sLabName = '" + labName + "'", con);
        labId = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Dispose();
        con.Close();
        return labId;
    }
    public DataTable AddTestDetails(DataTable dt, int testId)
    {

        if (dt.Rows.Count > 0)
        {
            string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.PackageTestDetails";

                   
                    sqlBulkCopy.ColumnMappings.Add("testName", "testName");
                    sqlBulkCopy.ColumnMappings.Add("_testId", "pkgId");
                    sqlBulkCopy.ColumnMappings.Add("orgId", "orgId");
                    sqlBulkCopy.ColumnMappings.Add("testCode", "testCode");

                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
            testId = this.getTestId(dt.Rows[0]["testName"].ToString());
            using (SqlConnection con = new SqlConnection(consString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update PackageTestDetails set testId='" + testId + "' where testName='"+ dt.Rows[0]["testName"].ToString() + "'",con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        return dt;
    }

    public DataTable AddLabDetails(DataTable dt, int labId)
    {
        if (dt.Rows.Count > 0)
        {
            string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.PackageLabDetails";

                 
                    sqlBulkCopy.ColumnMappings.Add("_labId", "pkgId");
                    sqlBulkCopy.ColumnMappings.Add("labName", "labName");
                    sqlBulkCopy.ColumnMappings.Add("orgId", "orgId");
                    sqlBulkCopy.ColumnMappings.Add("labCode", "labCode");

                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }

            labId = this.getLabId(dt.Rows[0]["labName"].ToString());
            using (SqlConnection con = new SqlConnection(consString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update PackageLabDetails set labId='" + labId + "' where labName='" + dt.Rows[0]["labName"].ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        return dt;
    }
}