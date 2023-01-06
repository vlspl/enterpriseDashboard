using CrossPlatformAESEncryption.Helper;
using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    ClsAdminLogin objLogData = new ClsAdminLogin();
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnForgotPwd_Click(object sender, EventArgs e)
    {
        string user = CryptoHelper.Encrypt(txtemail.Text);
        string password = CreateRandomPassword();
        //  string mailPassword = objLogData.mailPassword(user,password);  // hide by sagar

        // update password in Login master Table

        int data = 0;
        SqlParameter[] param = new SqlParameter[]
                {
                            new SqlParameter("@Password",CryptoHelper.Encrypt(password)),
                            new SqlParameter("@UserName",user),
                            //new SqlParameter("@RecommendedAt",""),
                            //new SqlParameter("@LabId",_labId),
                            new SqlParameter("@Returnval",SqlDbType.Int)
                };
        data = DAL.ExecuteStoredProcedureRetnInt("sp_ForgotPassword", param);
        if (data >= 1)
        {

            string mailPassword = objLogData.sendmail_new(txtemail.Text, password, user);

            lbl_msg.Text = mailPassword;
        }
        else
        {
            lbl_msg.Text = "Something went wrong..Please try again later..";

        }

        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occurred  " + mailPassword + "'  )", true);

    }

    private string CreateRandomPassword()
    {
        // Create a string of characters, numbers, special characters that allowed in the password  
        string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
        Random random = new Random();

        // Select one random character at a time from the string  
        // and create an array of chars  
        char[] chars = new char[6];
        for (int i = 0; i < 6; i++)
        {
            chars[i] = validChars[random.Next(0, validChars.Length)];
        }
        return new string(chars);
    }
}