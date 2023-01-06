using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for TestDal
/// </summary>
public class TestDal
{
    public TestDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddTestDetails(TestBO testBO) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddTestDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TestName", testBO.testName);
            cmd.Parameters.AddWithValue("@range", testBO.range);
            cmd.Parameters.AddWithValue("@staus", testBO.status);


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
    public int UpdateTestDetails(int testId, string testName,string range,string status) // passing Bussiness object Here  
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
    public DataTable fillData(string testId)
    {
        //here get data by employyee id


        //   SqlCommand cmd = new SqlCommand("SELECT  test.sTestId,test.sTestCode, test.sTestName, testProfile.sProfileName, analyte.sAnalyteName,section.sSectionName FROM  test INNER JOIN testAnalyte ON test.sTestId = testAnalyte.sTestId INNER JOIN testProfile ON test.sTestProfileId = testProfile.sTestProfileId INNER JOIN    analyte ON testAnalyte.sAnalyteId = analyte.sAnalyteId INNER JOIN section ON testProfile.sSectionId = section.sSectionId where  test.sTestId='" + testId + "'", con);
        SqlCommand cmd = new SqlCommand(@"SELECT       distinct test.sTestId, test.sTestCode, test.sTestName, testProfile.sProfileName, analyte.sAnalyteName, section.sSectionName,
                    tar.ReferenceType, tar.Grade, tar.Unit, tar.UpperLimit, tar.LowerLimit, tasm.sResultType
                        , method.sMethodName, specimen.sSampleType, specimen.sQuantity, specimen.sTimePeriod
                           FROM            test INNER JOIN
                         testAnalyte ON test.sTestId = testAnalyte.sTestId INNER JOIN
                         testProfile ON test.sTestProfileId = testProfile.sTestProfileId  INNER JOIN
                         analyte ON testAnalyte.sAnalyteId = analyte.sAnalyteId INNER JOIN
                         section ON testProfile.sSectionId = section.sSectionId INNER JOIN
                         testAnalyteSpecimenMethod AS tasm ON testAnalyte.sTestAnalyteId = tasm.sTestAnalyteId INNER JOIN
                         TestAnalyteReferenceRange AS tar ON tar.TASMId = tasm.sTASMId INNER JOIN
                         specimen ON tasm.sSpecimenId = specimen.sSpecimenId INNER JOIN
                         method ON tasm.sMethodId = method.sMethodId
                        WHERE(test.sTestId = '" + testId + "')",con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
}