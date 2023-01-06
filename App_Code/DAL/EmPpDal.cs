using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmpDal
/// </summary>
public class EmPpDal
{
    EmployeeBO objempBo = new EmployeeBO();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public EmPpDal()
    {
       
    }
    
    public int AddEmplDetails(EmployeeBO ObjBO) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (Employee.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("Sp_AddEmployeeDetails", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FName", ObjBO.Fname);
            cmd.Parameters.AddWithValue("@MName", ObjBO.MName);
            cmd.Parameters.AddWithValue("@LName", ObjBO.LName);
            cmd.Parameters.AddWithValue("@SName", ObjBO.SName);
            cmd.Parameters.AddWithValue("@AtdharName", ObjBO.AtdharName);
            cmd.Parameters.AddWithValue("@DOB", ObjBO.DOB);
            cmd.Parameters.AddWithValue("@Age", ObjBO.Age);
            cmd.Parameters.AddWithValue("@Gender", ObjBO.Gender);
            cmd.Parameters.AddWithValue("@Pphoto", "");//ObjBO.Pphoto


            cmd.Parameters.AddWithValue("@PanNo", ObjBO.PanNo);
            cmd.Parameters.AddWithValue("@Email ", ObjBO.Email);
            cmd.Parameters.AddWithValue("@ContactNo", ObjBO.ContactNo);
            cmd.Parameters.AddWithValue("@AltContact", ObjBO.AltContact);
             cmd.Parameters.AddWithValue("@CAddress", ObjBO.CAddress);
            cmd.Parameters.AddWithValue("@PAddress", ObjBO.PAddress);
            cmd.Parameters.AddWithValue("@State", ObjBO.State);
            cmd.Parameters.AddWithValue("@City", ObjBO.City);
            cmd.Parameters.AddWithValue("@Pincode", ObjBO.Pincode);
            cmd.Parameters.AddWithValue("@EmpId", ObjBO.EmpId);
            cmd.Parameters.AddWithValue("@Dsgn", ObjBO.Dsgn);
            cmd.Parameters.AddWithValue("@Dept", ObjBO.Dept);
            cmd.Parameters.AddWithValue("@BatchName", ObjBO.BatchName);
            cmd.Parameters.AddWithValue("@DOJ", ObjBO.DOJ);
            cmd.Parameters.AddWithValue("@EmpStatus", ObjBO.EmpStatus);
            cmd.Parameters.AddWithValue("@Bgroup", ObjBO.Bgroup);
            cmd.Parameters.AddWithValue("@HealthID", ObjBO.HealthID);
            cmd.Parameters.AddWithValue("@Qualification", ObjBO.Qualification);
            cmd.Parameters.AddWithValue("@Pyear", ObjBO.Pyear);



            cmd.Parameters.AddWithValue("@Grade", ObjBO.Grade);
            cmd.Parameters.AddWithValue("@University", ObjBO.University);
            cmd.Parameters.AddWithValue("@CompName", ObjBO.CompName);
            cmd.Parameters.AddWithValue("@Period", ObjBO.Period);
            cmd.Parameters.AddWithValue("@frm","");
            cmd.Parameters.AddWithValue("@tto", ObjBO.tto);
            cmd.Parameters.AddWithValue("@dsgnn", ObjBO.dsgnn);
            cmd.Parameters.AddWithValue("@Documents", "");//ObjBO.Documents
            cmd.Parameters.AddWithValue("@orgId", ObjBO.OrgId);
            cmd.Parameters.AddWithValue("@branchId", ObjBO.BranchId);
            cmd.Parameters.AddWithValue("@deptId", ObjBO.DeptId);
            //cmd.Parameters.AddWithValue("@Mobilenumber", ObjBO.Mobilenumber);
            con.Open();
            int Result = cmd.ExecuteNonQuery();
            cmd = new SqlCommand("SELECT MAX(EmployeeId) FROM EmployeeDetails", con);

            int EmpId = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            if(ObjBO.OrgId=="2")
            {
                int maleCount, femaleCount;
                
                con.Open();//(age_18_25 =  CASE WHEN age between 18 and 25  THEN age_18_25 +1 WHEN age between 26 and 35 THEN age_26_35 +1 WHEN age between 36 and 45 THEN age_36_45 +1  WHEN age between 46 and 60 THEN age_46_60 +1  ELSE age_60_above +1    END
                if (ObjBO.Gender == "Male")
                    cmd = new SqlCommand("update EnterpriseData set health_counter=health_counter+1,dpt_male=dpt_male+1,age_18_25= (CASE WHEN " + ObjBO.Age+" between 18 and 25  THEN age_18_25 +1 else age_18_25 end) , age_26_35= (case WHEN "+ ObjBO.Age+ " between 26 and 35 THEN age_26_35 +1 else age_26_35 end) , age_36_45= (case WHEN " + ObjBO.Age + " between 36 and 45 THEN age_36_45 +1 else age_36_45 end), age_46_60= (case WHEN " + ObjBO.Age + " between 46 and 60 THEN age_46_60 +1 else age_46_60 end ), age_60_above= (case WHEN " + ObjBO.Age + " between 60 and 99 THEN age_60_above +1 else age_60_above end ) where country = 'India' and City_branch = '" + ObjBO.City+"' and department = '"+ObjBO.Dept+"' and gender = '"+ObjBO.Gender+"' and emp_health='Healthy'",con);
              else
                    cmd = new SqlCommand("update EnterpriseData set health_counter=health_counter+1,dpt_female=dpt_female+1,age_18_25= (CASE WHEN " + ObjBO.Age + " between 18 and 25  THEN age_18_25 +1 else age_18_25 end) , age_26_35= (case WHEN " + ObjBO.Age + " between 26 and 35 THEN age_26_35 +1 else age_26_35 end) , age_36_45= (case WHEN " + ObjBO.Age + " between 36 and 45 THEN age_36_45 +1 else age_36_45 end), age_46_60= (case WHEN " + ObjBO.Age + " between 46 and 60 THEN age_46_60 +1 else age_46_60 end ), age_60_above= (case WHEN " + ObjBO.Age + " between 60 and 99 THEN age_60_above +1 else age_60_above end ) where country = 'India' and City_branch = '" + ObjBO.City + "' and department = '" + ObjBO.Dept + "' and gender = '" + ObjBO.Gender + "' and emp_health='Healthy'", con);

                cmd.ExecuteNonQuery();
                con.Close();
            }
           

            return EmpId;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public DataTable EditEmplDetails(string editEmpId)
    {
        DataTable result = null;
        SqlCommand sql_cmnd = new SqlCommand("WS_Sp_GetEmployeedataforEdit", con);
        sql_cmnd.Parameters.Add(new SqlParameter("@EmployeeID", editEmpId));
        sql_cmnd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter adp = new SqlDataAdapter(sql_cmnd);

        adp.SelectCommand.CommandTimeout = 240000;
        DataTable DataDTTablesDT = new DataTable();
        adp.Fill(DataDTTablesDT);
        result = DataDTTablesDT;


        return result;
    }
    public DataTable AddExpDetails(DataTable dt, int EmpChieldID)
    {
        if (dt.Rows.Count > 0)
        {
            string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.ExpDetail";

                    //[OPTIONAL]: Map the DataTable columns with that of the database table
                    // sqlBulkCopy.ColumnMappings.Add("QualificationId", "QualificationId");
                    sqlBulkCopy.ColumnMappings.Add("EmpChieldID1", "EmployeeId");
                    sqlBulkCopy.ColumnMappings.Add("CompName", "CompName");
                    sqlBulkCopy.ColumnMappings.Add("Period", "Period");
                    sqlBulkCopy.ColumnMappings.Add("tto", "tto");
                    sqlBulkCopy.ColumnMappings.Add("Cdsgn", "Cdsgn");
                   


                    //    sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                    //  sqlBulkCopy.ColumnMappings.Add("Country", "Country");
                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
        }
        return dt;
    }

    public DataTable AddQulificionDetails(DataTable dt, int EmpChieldID)
    {
        if (dt.Rows.Count > 0)
        {
            string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.QulificationList";

                    //[OPTIONAL]: Map the DataTable columns with that of the database table
                    // sqlBulkCopy.ColumnMappings.Add("QualificationId", "QualificationId");
                    sqlBulkCopy.ColumnMappings.Add("EmpChieldID1", "EmployeeId");
                    sqlBulkCopy.ColumnMappings.Add("Qulification", "Qulification");
                    sqlBulkCopy.ColumnMappings.Add("Pyear", "Pyear");
                    sqlBulkCopy.ColumnMappings.Add("Grade", "Grade");
                    sqlBulkCopy.ColumnMappings.Add("University", "University");

                    //    sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                    //  sqlBulkCopy.ColumnMappings.Add("Country", "Country");
                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
        }
        return dt;
    }

    public DataTable fillData(string empId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT * FROM EmployeeDetails where EmployeeId='" + empId + "'", con);
       
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
    public DataTable fillExperience(string empId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT CompName,Period,tto,Cdsgn FROM ExpDetail where EmployeeId='" + empId + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
    public DataTable fillQualification(string empId)
    {
        //here get data by employyee id


        SqlCommand cmd = new SqlCommand("SELECT Qulification,Pyear,Grade,University  FROM QulificationList where EmployeeId='" + empId + "'", con);

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        return dt;
    }
    public void DeleteEmployeeDetails(string employeeId) // passing Bussiness object Here  
    {
        try
        {
            /* Because We will put all out values from our (Employee.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
            SqlCommand cmd = new SqlCommand("sp_DeleteEmpData", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empId", employeeId);
     
            con.Open();
            int Result = cmd.ExecuteNonQuery();
            //cmd = new SqlCommand("SELECT MAX(EmployeeId) FROM EmployeeDetails", con);

            //int EmpId = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
            //return EmpId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}