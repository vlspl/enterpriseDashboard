using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessHandler;
using System.Data;
using System.Data.SqlClient;
using Validation;
using BitsBizLogic;
//using Org.BouncyCastle.Asn1.Ocsp;
using CrossPlatformAESEncryption.Helper;

/// <summary>
/// Summary description for ClsAddEmployee
/// </summary>
public class ClsAddEmployee
{
    DataAccessLayer DAL = new DataAccessLayer();
    InputValidation Ival = new InputValidation();
    public ClsAddEmployee()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string AddEmployee(string Name, string Mobile, string EmailId, string Gender, string Birthdate, string Address,
         string State, string city, string Pincode, string EmployeeId, string AadharCard, string OrgId, string Branchid, string CreatedBy, string password)
    {
        string Msg = "";
        string _password = CryptoHelper.Encrypt(password);
        string _EmailId = CryptoHelper.Encrypt(EmailId.ToLower());
        string _Mobile = CryptoHelper.Encrypt(Mobile);
        string _aadhar = CryptoHelper.Encrypt(AadharCard);
        if (Ival.IsTextBoxEmpty(Name))
        {
            Msg += "● Please Enter Valid Name<br>";
        }
        if (!Ival.IsCharOnly(Name))
        {
            Msg = "● Please Enter Valid Employee Name <br>";
        }
        //if (Ival.IsTextBoxEmpty(Address))
        //{
        //    Msg += "● Please Enter Valid Adress<br>";
        //}
        if (Ival.PhoneMobileValidation(Mobile))
        {
            Msg += "● Please Enter Valid Mobile Number<br>";
        }
        if (!Ival.IsValidEmailAddress(EmailId))
        {
            Msg += "● Please Enter Valid Email Address <br>";
        }
        else
        {
            ClsEmailTemplates emailTemp = new ClsEmailTemplates();
            string subject = "HowzU Connect – Thank you for your registration. Sign in today.";

            string mailbody = mailbody = "Greetings of the day! <br />" +

                "<h3>Congratulations! You have successfully registered for Howzu App. </h3><br />" +

                "Now it’s time to update your health details to have your personalised digital health Valet for you and your family members." +

                 "<br />Follow the steps below for the further process now :<br /><br />" +
                 "<b>1 . Download the App :</b><br /><br />" +
                "<b>iOS User</b> : https://apps.apple.com/in/app/howzu/id1481816983 <br />" +
                "<b>Android User</b> : https://play.google.com/store/apps/details?id=com.howzu <br /><br />" +
                "<b>2 . Kindly use following credentials to Sign in,</b><br /><br />" +
                        "<b>User Name : " + Mobile + "</b><br />" +
                        "<b>PassCode : " + password + "</b><br /><br />" +

                "Along with tracking your health report, HowzU will also help you to find best path labs and manage each of your family members' health data at your fingertips.<br />" +

                "We are delighted to welcome you to the Howzu family, and are looking for a long and endeavoring business Relationship.<br /><br />" +

                "<b>Regards,</b><br />" +
                "<b>Howzu Team. </b> ";
            string mailSent = emailTemp.sendmail(EmailId, password, Name, Mobile,mailbody,subject);
        }
        if (Ival.IsValidAadharCard(AadharCard))
        {
            Msg += "● Please Enter Valid Aadhar Number <br>";
        }
        if (!Ival.IsDecimal(Pincode))
        {
            Msg += "● Please Enter Valid Pincode Number <br>";
        }
        if (Msg.Length > 0)
        {
            return Msg;
        }
        else
        {
           
           
           
                SqlParameter[] param = new SqlParameter[]
                    {
                      new SqlParameter("@sFullName",Name),
                      new SqlParameter("@sMobile",_Mobile),
                      new SqlParameter("@sEmailId",_EmailId),
                      new SqlParameter("@sGender",Gender),
                      new SqlParameter("@sBirthDate",Birthdate),
                      new SqlParameter("@sAddress",Address),
                      new SqlParameter("@sRole","Employee"),
                      new SqlParameter("@sCountry","India"),
                      new SqlParameter("@sState",State),
                      new SqlParameter("@sCity",city),
                      new SqlParameter("@sPincode",Pincode),
                      new SqlParameter("@EmployeeId",EmployeeId),
                      new SqlParameter("@AadharCard",_aadhar),
                      new SqlParameter("@Returnval",SqlDbType.Int)
                    };
                int Result = DAL.ExecuteStoredProcedureRetnInt("Sp_AddEmployee", param);//Insert into App User

                if (Result >= 1)
                {
                    SqlParameter[] param1 = new SqlParameter[]
                    {
                      new SqlParameter("@EmpId",Result),
                      new SqlParameter("@OrgId",OrgId),
                      new SqlParameter("@BranchId",Branchid),
                      new SqlParameter("@CreatedBy",CreatedBy),
                      new SqlParameter("@Returnval",SqlDbType.Int)
                    };
                    int ResultVal = DAL.ExecuteStoredProcedureRetnInt("Sp_AddOrgEmployee", param1);// Insert into Organization Employee Details
                    
                //insert into new table UserOrgAsign
                SqlParameter[] paramEmpOrg = new SqlParameter[]
                    {
                      new SqlParameter("@branchId",Branchid),
                      new SqlParameter("@orgId",OrgId),
                      new SqlParameter("@userId",Result),
                      new SqlParameter("@createdBy",CreatedBy),
                      new SqlParameter("@createdDate",System.DateTime.Now),
                      new SqlParameter("@Returnval",SqlDbType.Int)
                    };
                int ResultValEmpOrg = DAL.ExecuteStoredProcedureRetnInt("SP_AddUserOrgAssign", paramEmpOrg);
              
                if (ResultVal == 1)
                    {
                        SqlParameter[] param2 = new SqlParameter[]
                      {
                      new SqlParameter("@UserId",Result),
                      new SqlParameter("@Mobile",_Mobile),
                      new SqlParameter("@EmailId",_EmailId),
                      new SqlParameter("@Role","Employee"),
                      new SqlParameter("@Password",_password),
                      new SqlParameter("@UserName",""),
                     // new SqlParameter("@loginStatus","A"),
                       new SqlParameter("@orgId",OrgId),
                      new SqlParameter("@Returnval",SqlDbType.Int)

                       };
                        int ResultVal1 = DAL.ExecuteStoredProcedureRetnInt("Sp_AddUserLoginCredentialsEnterprise", param2); //Insert into User Login Master Details
                        Msg = "1";
                    }
                    else if (ResultVal == -2)
                    {
                        Msg = "-2";
                    }
                    else
                    {
                        Msg = "● Something Went Wrong, Please Try Again After Some Time!";
                    }
                }

                else
                {
                    Msg = Result.ToString();
                }
           
        }
        return Msg;
    }




    public DataTable GetEmployee(string Org_Id, string Branch_Id)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlParameter[] param = new SqlParameter[]
            {
               new SqlParameter("@OrgId",Org_Id),
               new SqlParameter("@BranchId",Branch_Id)
            };
            dt = DAL.ExecuteStoredProcedureDataTable("Sp_GetEmployeeList ", param);
            return dt;
        }
        catch (Exception)
        {
            dt = null;
            return dt;
        }
    }
    public DataTable GetEmployeeHealthReportList(string Org_Id, string Branch_Id)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlParameter[] param = new SqlParameter[]
            {
               new SqlParameter("@OrgId",Org_Id),
               new SqlParameter("@BranchId",Branch_Id)
            };
            dt = DAL.ExecuteStoredProcedureDataTable("Sp_GetEmployeehealthReport ", param);
            return dt;
        }
        catch (Exception)
        {
            dt = null;
            return dt;
        }
    }
    public DataTable GetEmployeeReport(string Org_Id, string Branch_Id)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlParameter[] param = new SqlParameter[]
            {
               new SqlParameter("@OrgId",Org_Id),
               new SqlParameter("@BranchId",Branch_Id)
            };
            dt = DAL.ExecuteStoredProcedureDataTable("Sp_GetEmployeeUploadedReport ", param);
            return dt;
        }
        catch (Exception)
        {
            dt = null;
            return dt;
        }
    }
    public DataTable GetEmployeehealthReport(string EmpId, string Gender)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlParameter[] param = new SqlParameter[]
            {
               new SqlParameter("@PatientId",EmpId),
               new SqlParameter("@Gender",Gender.Trim())
            };
            dt = DAL.ExecuteStoredProcedureDataTable("Sp_GetTestReportByPatientId ", param);
            return dt;
        }
        catch (Exception)
        {
            dt = null;
            return dt;
        }
    }

}