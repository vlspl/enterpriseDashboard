using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mailTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void sendMail()
    {
        string to = "sagar@howzu.co.in"; //To address    
        string from = "sutar.harshada2@gmail.com"; //From address    
        MailMessage message = new MailMessage(from, to);

        string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
        message.Subject = "Sending Email Using Asp.Net & C#";
        message.Body = mailbody;
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("sutar.harshada2@gmail.com", "Anvit@2019");
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        //System.Net.NetworkCredential basicCredential1 = new
        //System.Net.NetworkCredential("sutar.harshada2@gmail.com", "Anvit@2019");
       
        
       
        try
        {
            client.Send(message);
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        sendMail();
    }
}