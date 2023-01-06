using CrossPlatformAESEncryption.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LabMaster : System.Web.UI.Page
{
    hospitalDAL objdal = new hospitalDAL();
    DataTable dtFillData;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            if (Request.QueryString["sLabId"] != null)
            {
                dtFillData = objdal.fillData(Request.QueryString["sLabId"]);
                foreach (DataRow row in dtFillData.Rows)
                {
                    // basic Info
                    txtLabNm.Text = row["sLabName"].ToString();
                    txtAddress.Text = row["sLabAddress"].ToString();
                    txtEmail.Text = CryptoHelper.Decrypt(row["sLabEmailId"].ToString());
                
                    txtContact.Text = CryptoHelper.Decrypt(row["sLabContact"].ToString());
                    txtOwner.Text = row["sLabManager"].ToString();
                   txtLongiLatitude.Text=row["sLabLocation"].ToString();
            }
            }
        //}
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hospital_LabMaster.aspx");
    }
}