using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logo : System.Web.UI.Page
{
    string getImagePath;
    DBClass db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {

        getImagePath = db.getData("select Org_Logo FROM OrganizationMaster where ID='2'");
string str=getImagePath.Replace("../","");
        Label1.Text = "https://www.visionarylifescience.com/"+ str;
Image1.ImageUrl =  "https://www.visionarylifescience.com/"+ str;
        Image1.Visible = true;
       // Label1.Text = Server.MapPath("images/" + getImagePath);
 			
    }
}