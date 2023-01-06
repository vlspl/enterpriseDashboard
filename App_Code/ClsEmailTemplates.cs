using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Configuration;
using System.IO;
using MedicationReminder;

/// <summary>
/// Summary description for ClsEmailTemplates
/// 
/// </summary>
public class ClsEmailTemplates
{
    ErrorLog log = new ErrorLog();
    string mailFrom, mailFrom_password;

    public object Request { get; private set; }

   
    public string sendmail(string emailId, string password, string Name, string Username)
    {
        try
        {
            MailMessage MailMsg = new MailMessage();
           
            mailFrom = WebConfigurationManager.AppSettings["from_EmailID"];
            mailFrom_password = WebConfigurationManager.AppSettings["from_PassWord"];
          
            MailMsg.From = new MailAddress(mailFrom);//"visionarylifesciences7@gmail.com"
            MailMsg.To.Add(emailId);
            MailMsg.Subject = "HowzU Connect – Thank you for your registration. Sign in today.";

            MailMsg.Body = " <div style='padding: 18px; font-family: verdana; font-size: small; background-color: #eaf7ec;text-align: center'>" +
                            "<img src='https://visionarylifescience.com/images/Howzulogo1092020101600.png' height='57px' width: 254px; class='img-thumbnail' /><h4>" +
                            "Dear " + Name + "</h4><h3>Congratulations!!!</h3>" +
                            "<span style='font-weight: bold'>You've successfully signed up for HowzU!<br /><br />" +
                            "</span>Please find your login details below.<br />" +
                            "<span>Your UserName is:<h4 style='font-weight: bold'>" + Username + "</h4></span>" +
                            "<span>Your Password is:<h4 style='font-weight: bold'>" + password + "</h4></span>" +
                            "<p><b>Click here: </b>For iphone Users :https://apps.apple.com/in/app/howzu/id1481816983 </p>" +
                            "For Android Users :https://play.google.com/store/apps/details?id=com.howzu </ p > <br/>" +
                            "Regards Team,<br />" +
                            "Visionary Life Science Pvt. Ltd." +
                            "</div>";

            //string mailBodyPath = WebConfigurationManager.AppSettings["mailBodyPath"];

            //string text = File.ReadAllText(mailBodyPath);


            //if (text.Contains("@name"))
            //    text.Replace("@name", "Name");
            //if (text.Contains("@userNm"))
            //    text.Replace("@userNm", "Username");
            //if (text.Contains("@pwd"))
            //    text.Replace("@pwd", "password");

            //MailMsg.Body = text;


            MailMsg.IsBodyHtml = true;
          //  SmtpClient client = new SmtpClient("relay-hosting.secureserver.in", 25); //relay-hosting.secureserver.net
            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25); //relay-hosting.secureserver.net
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(mailFrom, mailFrom_password); //from address credential
            client.EnableSsl = false;
            //Send the msgs  
            client.Send(MailMsg);
           // log.WriteErrorLog("Error: in Mail Send -----on time :" + System.DateTime.Now.ToString("HH:mm") + "   - > " + ex.ToString());

            return "1";
        }
        catch (Exception ex)
        {
            
            throw ex;
            log.WriteErrorLog("Error: in Mail Send -----on time :" + System.DateTime.Now.ToString("HH:mm") + "   - > " + ex.ToString());

            // return "0";
        }
    }


    public string sendmailForEnterprise(string emailId, string password,  string Username)
    {
        try
        {
            MailMessage MailMsg = new MailMessage();

            mailFrom = WebConfigurationManager.AppSettings["from_EmailID"];
            mailFrom_password = WebConfigurationManager.AppSettings["from_PassWord"];

            MailMsg.From = new MailAddress(mailFrom);//"visionarylifesciences7@gmail.com"
            MailMsg.To.Add(emailId);
            MailMsg.Subject = "HowzU Connect – Thank you for your registration. Sign in today.";

            MailMsg.Body = " <div style='padding: 18px; font-family: verdana; font-size: small; background-color: #eaf7ec;text-align: center'>" +
                            "<img src='https://visionarylifescience.com/images/Howzulogo1092020101600.png' height='57px' width: 254px; class='img-thumbnail' />" +
                            "<h3>Hey there,</h3>" +
                            "<span style='font-weight: bold'>You're invited to join Enterprise!<br /><br />" +
                            "</span>Please find your login details below.<br />" +
                            "<span>Your UserName is:<h4 style='font-weight: bold'>" + Username + "</h4></span>" +
                            "<span>Your Password is:<h4 style='font-weight: bold'>" + password + "</h4></span>" +
                           
                            "Regards Team,<br />" +
                            "Visionary Life Science Pvt. Ltd." +
                            "</div>";

        
            MailMsg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(mailFrom, mailFrom_password); //from address credential
            client.EnableSsl = false;
            //Send the msgs  
            client.Send(MailMsg);
            // log.WriteErrorLog("Error: in Mail Send -----on time :" + System.DateTime.Now.ToString("HH:mm") + "   - > " + ex.ToString());

            return "1";
        }
        catch (Exception ex)
        {

            throw ex;
            log.WriteErrorLog("Error: in Mail Send -----on time :" + System.DateTime.Now.ToString("HH:mm") + "   - > " + ex.ToString());

            // return "0";
        }
    }
   
    public string sendmail(string emailId, string password, string Name, string Username,string body,string subject)
    {
        try
        {
            MailMessage MailMsg = new MailMessage();

            mailFrom = WebConfigurationManager.AppSettings["from_EmailID"];
            mailFrom_password = WebConfigurationManager.AppSettings["from_PassWord"];

            MailMsg.From = new MailAddress(mailFrom);//"visionarylifesciences7@gmail.com"
            MailMsg.To.Add(emailId);
            // MailMsg.Subject = "HowzU Connect – Thank you for your registration. Sign in today.";
            MailMsg.Subject = subject;
            MailMsg.Body = body;

            MailMsg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(mailFrom, mailFrom_password); //from address credential
            client.EnableSsl = false;
            //Send the msgs  
            client.Send(MailMsg);
            // log.WriteErrorLog("Error: in Mail Send -----on time :" + System.DateTime.Now.ToString("HH:mm") + "   - > " + ex.ToString());

            return "1";
        }
        catch (Exception ex)
        {

            throw ex;
            log.WriteErrorLog("Error: in Mail Send -----on time :" + System.DateTime.Now.ToString("HH:mm") + "   - > " + ex.ToString());

            // return "0";
        }
    }
}