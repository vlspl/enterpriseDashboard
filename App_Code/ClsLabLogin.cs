using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using DataAccessHandler;
using CrossPlatformAESEncryption.Helper;
public class ClsLabLogin
{
    DataAccessLayer DAL = new DataAccessLayer();
    public ClsLabLogin()
    {
    }
    public Dictionary<string, string> aunthenticate(string username, string password)
    {
        Dictionary<string, string> returnValues = new Dictionary<string, string>();
        try
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserName",username),
                new SqlParameter("@Password",password)
            };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("Sp_LabLogin", param);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["sLabStatus"].ToString().ToLower() == "active")
                {
                    returnValues.Add("status", "active");
                    returnValues.Add("labId", dt.Rows[0]["sLabId"].ToString());
                    returnValues.Add("labCode", dt.Rows[0]["sLabCode"].ToString());
                    returnValues.Add("labUser", dt.Rows[0]["sFullName"].ToString());
                    returnValues.Add("username", dt.Rows[0]["sUserName"].ToString());
                    returnValues.Add("role", dt.Rows[0]["sRole"].ToString());
                    returnValues.Add("labUserId", dt.Rows[0]["sLabUserId"].ToString());
                    returnValues.Add("labHomeCollection", dt.Rows[0]["sColF"].ToString());
                }
                else
                {
                    returnValues.Add("status", "inactive");
                }
            }
            else
            {
                returnValues.Add("status", "null");
            }
        }
        catch (Exception)
        {
            returnValues.Add("status", "error");
        }
        return returnValues;
    }
    public Dictionary<string, string> LabUserDetails(string UserId)
    {
        Dictionary<string, string> returnValues = new Dictionary<string, string>();
        try
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId",UserId)
            };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("Sp_LabUserLoginDetails", param);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["sLabStatus"].ToString().ToLower() == "active")
                {
                    returnValues.Add("status", "active");
                    returnValues.Add("labId", dt.Rows[0]["sLabId"].ToString());
                    returnValues.Add("labCode", dt.Rows[0]["sLabCode"].ToString());
                    returnValues.Add("labUser", dt.Rows[0]["sFullName"].ToString());
                    returnValues.Add("username", dt.Rows[0]["sUserName"].ToString());
                    returnValues.Add("role", dt.Rows[0]["sRole"].ToString());
                    returnValues.Add("labUserId", dt.Rows[0]["sLabUserId"].ToString());
                    returnValues.Add("labHomeCollection", dt.Rows[0]["sColF"].ToString());
                }
                else
                {
                    returnValues.Add("status", "inactive");
                }
            }
            else
            {
                returnValues.Add("status", "null");
            }
        }
        catch (Exception)
        {
            returnValues.Add("status", "error");
        }
        return returnValues;
    }
    public DataTable EnterpriseLogin(string Username, string Password)
    {
        SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserName",Username),
                new SqlParameter("@Password",Password)
            };
        DataTable dt = DAL.ExecuteStoredProcedureDataTable("sp_EnterpriseLogin", param);
        return dt;
    }
    public DataTable EnterpriseUserLoginDetails(string UserId)//, string emailId
    {
        SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId",UserId),
                  // new SqlParameter("@emailId",emailId)
            };
        DataTable dt = DAL.ExecuteStoredProcedureDataTable("sp_EnterpriseUserLoginDetails", param);//  sp_EnterpriseUserLoginNew
        return dt;
    }
    public string mailPassword(string userName)
    {
        try
        {
            string _userName = CryptoHelper.Encrypt(userName);
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserName",_userName)
            };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("Sp_ForgotPasswordDetails", param);
            if (dt.Rows.Count > 0)
            {

                string emailId = CryptoHelper.Decrypt(dt.Rows[0]["EmailId"].ToString());
                string password = CryptoHelper.Decrypt(dt.Rows[0]["Password"].ToString());
                string UserName = dt.Rows[0]["Name"].ToString();
                string mailSent = sendmail(emailId, password, UserName);
                if (mailSent == "1")
                {
                    //if mail sent return 1
                    return "1";
                }
                else
                {
                    return "-1";
                }
            }
            else
            {
                //if username not found
                return "0";
            }

        }
        catch (Exception)
        {
            return "-1";
        }
    }
    public string sendmail(string emailId, string password, string Name)
    {
        try
        {
            MailMessage MailMsg = new MailMessage();
            MailMsg.From = new MailAddress("visionarylifesciences7@gmail.com");
            MailMsg.To.Add(emailId);
            MailMsg.Subject = "Password";

            MailMsg.Body = "<div style='padding:18px; font-family:verdana; font-size:small;  background-color:#eaf7ec;text-align:center '><img src='https://visionarylifescience.com/images/Howzulogo1092020101600.png' height='57px' width: 254px; class='img-thumbnail' /><h4>Dear " + Name + "</h4><br /><h3> Greetings!!!</h3> <br /> From <span style=' font-weight:bold'>VISIONARY LIFE SCIENCES PVT.LTD   .<br />" +
            " <br />" + " </span>Your Email Id is:<h3 style=' color: #fff; font-weight:bold'>" + emailId + "</h3>" + " <br />" + " <span>Your Password Is:<h3 style='  font-weight:bold'>" + password + "</h3></span>" +
             " <br />" +
                " Regards Team," +
                 "<br />" +
                 "Visionary Life Science Pvt.Ltd" +
                " </div>";
            MailMsg.IsBodyHtml = true;
            SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 587);
            smtpclient.UseDefaultCredentials = true;
            smtpclient.Credentials = new System.Net.NetworkCredential("visionarylifesciences7@gmail.com", "vls1234$");
            smtpclient.EnableSsl = true;

            smtpclient.Send(MailMsg);
            return "1";
        }
        catch (Exception ex)
        {
            return "0";
        }
    }
}