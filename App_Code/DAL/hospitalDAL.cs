using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for hospitalDAL
/// </summary>
public class hospitalDAL
{
    public hospitalDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public int AddHospitalDetails(hospitalLabBO hospitalBO) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddHospitalDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@hospitalName", hospitalBO.HospitalName);
            cmd.Parameters.AddWithValue("@state", hospitalBO.State);
            cmd.Parameters.AddWithValue("@city", hospitalBO.City);
            cmd.Parameters.AddWithValue("@address", hospitalBO.address);
            cmd.Parameters.AddWithValue("@staus", hospitalBO.Status);


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

    public int DeleteHospitalDetails(int hospitalId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_DeleteHospitalDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@hospitalId", hospitalId);

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
    public int UpdateHospitalDetails(int hospitalId, string hospitalNm, string state, string city, string address, string status) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_UpdateHospital", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@hospitalId", hospitalId);
            cmd.Parameters.AddWithValue("@hospitalName", hospitalNm);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@address", address);
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
    public DataTable fillData(string labId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT labMaster.sLabId,labMaster.sLabName, labMaster.sLabAddress, labMaster.sLabManager, labMaster.sLabStatus, labMaster.sLabContact,labMaster.sLabEmailId ,labMaster.sLabLocation FROM OrganizationTieupLab INNER JOIN OrganizationMaster ON OrganizationTieupLab.Org_ID = OrganizationMaster.ID INNER JOIN labMaster ON OrganizationTieupLab.Lab_Id = labMaster.sLabId where labMaster.sLabId ='" + labId + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }

}