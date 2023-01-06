using CrossPlatformAESEncryption.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.Configuration;

public partial class LabMaster : System.Web.UI.Page
{
    DBClass db = new DBClass();
    DataTable dtFillData;
    string userNm, labCode;
    int OrgId;
    string  branchId;
    LabDal objdal = new LabDal();
    LabBO objlabBo = new LabBO();
    CryptoHelper cypher = new CryptoHelper();
string mailFrom, mailFrom_password;
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        branchId = Session["BranchId"].ToString();
        OrgId =int.Parse(Session["OrgId"].ToString());
        btnClose.Visible = false ;
        btnregister.Visible = true;
        // OrgId = int.Parse(db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
        if (Request.QueryString["sLabId"] != null)
        {
            dtFillData = objdal.fillData(Request.QueryString["sLabId"]);
            foreach (DataRow row in dtFillData.Rows)
            {
                // basic Info
                txtLName.Text = row["sLabName"].ToString();
                txtLOwner.Text = row["sLabManager"].ToString();
                txtemailId.Text =CryptoHelper.Decrypt(row["sLabEmailId"].ToString());
                txtcontactNo.Text = CryptoHelper.Decrypt(row["sLabContact"].ToString());
             
                txtaddress.Text = row["sLabAddress"].ToString();
               /// txtlatitude.Text = row["sLabContact"].ToString();

                txtUaerName.Text = row["sUserName"].ToString();
              
                txtpassword.Text = row["sPassword"].ToString();
                txtConpassword.Text = row["sPassword"].ToString();

                btnClose.Visible = true;
                btnregister.Visible = false;
            }
        }
        }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        insert();
        // BindGrid();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hospital_LabMaster.aspx");
    }
    private void insert()
    {
        try
        {
            string Output = string.Empty;
            LabBO objLabBo = new LabBO();


            LabDal objdal = new LabDal();
            objLabBo.LabName = txtLName.Text;
            objLabBo.LabOwner = txtLOwner.Text;
            objLabBo.EmailId = txtemailId.Text;
            objLabBo.contactNo =CryptoHelper.Encrypt( txtcontactNo.Text);
            objLabBo.address = txtaddress.Text;
            objLabBo.userName = (txtUaerName.Text);
            objLabBo.password = txtpassword.Text;
            objLabBo.Confirmpassword = txtConpassword.Text;
            objLabBo.Location = txtaddress.Text;
            objLabBo.Status = "Pending Approval";// drpStatus.Text;
            objLabBo.CreatedBy =(userNm);
            objLabBo.CreatedAt = DateTime.Now.ToString("MM/dd/yyyy");
           // objLabBo.bran = txtLName.Text;
            //objLabBo.contactNo = txtSName.Text;
            //  labCode = db.getData("SELECT   sLabCode FROM   labMaster where sLabName== '" + txtLName.Text + "') ");

            string brname = "aa"; //= db.getData("SELECT BranchName FROM   BranchMaster where Org_Id= '" + OrgId + "' and ID='"+branchId+"' ");
            string oc = db.getData("SELECT Contact FROM   OrganizationMaster where ID= '" + OrgId + "' ");
            string oe = db.getData("SELECT Email FROM   OrganizationMaster where ID= '" + OrgId + "' ");
            string orgName= db.getData("SELECT Name FROM   OrganizationMaster where ID= '" + OrgId + "' ");
		string orgcontact=CryptoHelper.Decrypt(oc);
		string orgemail=CryptoHelper.Decrypt(oe);
            int j = objdal.AddLabDetails(objLabBo, OrgId,int.Parse(branchId));
           
          
        sendmail(txtLName.Text,txtcontactNo.Text, txtLOwner.Text, txtemailId.Text,brname,orgcontact,orgemail,orgName);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "insertSuccess", "alert('Save successfully');location.href='Hospital_LabMaster.aspx';", true);
            txtLName.Text = txtLOwner.Text = txtemailId.Text = txtcontactNo.Text = txtaddress.Text = txtUaerName.Text = txtpassword.Text = txtConpassword.Text = txtlatitude.Text = string.Empty;
            //txtHospital.Text = txtAddress.Text= string.Empty;

            //drpStatus.Text = drpState.Text = drpCity.Text="--Select--";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
public string sendmail(string labName, string ownerName, string emailId, string contactNo, string brname, string orgcontact, string orgemail, string orgName)
    {
        try
        {
            MailMessage MailMsg = new MailMessage();

            mailFrom = WebConfigurationManager.AppSettings["from_EmailID"];
            mailFrom_password = WebConfigurationManager.AppSettings["from_PassWord"];
          
            MailMsg.From = new MailAddress(mailFrom);//"visionarylifesciences7@gmail.com"
            MailMsg.To.Add("support@howzu.co.in");
            MailMsg.Subject = "Request Sending for HowzU Enterprise Lab Approval.";
            MailMsg.Body =

                "Greetings of the day! <br />" +

                "<h3>Dear Howzu Team </h3><br />" +

	
                "Please Approved <b>" + labName + "</b><br /><br /> " +

               "<b>Requested Details -</b><br /><br />" +
                        "<b>Lab Name : " + labName + "</b><br />" +
                         "<b>Contact No : " + orgcontact + "</b><br />" +
                          "<b>Email ID : " + orgemail + "</b><br />" +
                        "<b>For Branch : " + brname + "</b><br />" +
                         "<b>Organization Name : " + orgName + "</b><br /><br />" +
                "<b>Requested By -</b><br /><br />" +
                            "<b>Name : " + ownerName + "</b><br />" +
                         "<b>Contact No : " + contactNo + "</b><br />" +
                          "<b>Email ID : " + emailId + "</b><br />" +
                        "<b>Requested Date : " + System.DateTime.Now.ToString("dd/MM/yyyy") + "</b><br /><br />" +

                "<b>Yours sincerely ,</b><br />";
               
          

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
		   ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(ex);", true);
            throw ex;
            // log.WriteErrorLog("Error: in Mail Send -----on time :" + System.DateTime.Now.ToString("HH:mm") + "   - > " + ex.ToString());

            return "0";
        }
    }
}
   