using CrossPlatformAESEncryption.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LabDal
/// </summary>
public class LabDal
{
    
    public LabDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddLabDetails(LabBO labBO,int orgId,int branchId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddTempLabDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@org_Id", orgId);
            cmd.Parameters.AddWithValue("@sLabCode","");
            cmd.Parameters.AddWithValue("@sLabName", labBO.LabName);
            cmd.Parameters.AddWithValue("@sLabManager", labBO.LabOwner);
            cmd.Parameters.AddWithValue("@sLabEmailId", labBO.EmailId);
            cmd.Parameters.AddWithValue("@sLabStatus", labBO.Status);
            cmd.Parameters.AddWithValue("@sLabContact", labBO.contactNo);
            cmd.Parameters.AddWithValue("@sLabAddress", labBO.address);
            cmd.Parameters.AddWithValue("@sUserName", labBO.userName); 
            cmd.Parameters.AddWithValue("@sPassword", labBO.password);
            cmd.Parameters.AddWithValue("@sLabLocation", labBO.Location);
            cmd.Parameters.AddWithValue("@CreatedAt", labBO.CreatedAt);
            cmd.Parameters.AddWithValue("@CreatedBy", labBO.CreatedBy);
            cmd.Parameters.AddWithValue("@branchId", branchId);

            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return Result;
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable fillData(string labId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT * FROM labMaster where sLabId='" + labId + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
}