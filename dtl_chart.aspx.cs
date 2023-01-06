using DataAccessHandler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dtl_chart : System.Web.UI.Page
{
    DataAccessLayer DAL = new DataAccessLayer();
    DBClass db = new DBClass();
    ClsFCMNotification ObjFCM = new ClsFCMNotification();
    ClsAppNotification objAppNotify = new ClsAppNotification();
    private SqlConnection con;
    private SqlCommand com;
     string constr, query, branchId, OrgId;
    private void connection()
    {
       
        constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
        con = new SqlConnection(constr);
        con.Open();
      
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        branchId = Session["BranchId"].ToString();
        OrgId = (Session["OrgId"].ToString());
        if (!IsPostBack)
        {
            db.bindDrp("select distinct centerName from vaccinationDetails where orgId='" + OrgId + "'", drpcenterName, "centerName", "centerName");
            drpcenterName.Items.Insert(0, new ListItem("All", "All"));
            employeeGenderRatio();
            vaccination_pie_chart("");
            employeeAgeRatio_Linechart();
            viewcounter();

            vaccinationDetails();
        }
      
    }

    protected void vaccinationDetails()
    {
        try
        {
            connection();
            com = new SqlCommand("GetdsvaccinationDetails", con);
            com.Parameters.AddWithValue("@orgId", OrgId);
            com.Parameters.AddWithValue("@branchId", branchId);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gridvacDetails.DataSource = dt;
            gridvacDetails.DataBind();
            lblcount.Text = (gridvacDetails.Rows.Count).ToString();
        }
        catch (Exception ex)
        {

        }
    }
    public void employeeGenderRatio()
    {
        try
        {
            //db.cnOpen();
            // DataTable dt = db.bindDataset("select gender, convert(nvarchar, sum(age_18_25)) +',' + convert(nvarchar, sum(age_26_35)) + ',' + convert(nvarchar, sum(age_36_45))  + ',' + convert(nvarchar, sum(age_46_60)) + ',' + convert(nvarchar, sum(age_60_above)) as val from EnterpriseData " + whr + "  group by gender ");

            SqlParameter[] paramEmgAgeRatio = new SqlParameter[]
     {
                             new SqlParameter("@orgId",OrgId),
                             new SqlParameter("@parentbranchId",branchId)

      };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_EmpGenderChartForCovid", paramEmgAgeRatio);

            if (dt.Rows.Count > 1)
            {
                HAgeMale.Value = dt.Rows[0][1].ToString();

                HEmpGender.Value = dt.Rows[1][1].ToString();
            }
            else if (dt.Rows[0][0].ToString() == "Male")
            {
                HAgeMale.Value = "0";
                HEmpGender.Value = dt.Rows[0][1].ToString();
              
            }
            else if (dt.Rows[0][0].ToString() == "Female")
            {
                HEmpGender.Value = "0";
                HAgeMale.Value = dt.Rows[0][1].ToString();

            }
            else
            {
                HEmpGender.Value = "0";
                HAgeMale.Value = "0";
            }
            string genderValue="", count="";
            //if (dt.Rows.Count> 0 )
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        genderValue += dt.Rows[i]["gender"].ToString() + ",";
            //        count += dt.Rows[i]["count"].ToString() + ",";
            //    }
            //    //    HAgeMale.Value = dt.Rows[0]["gender"].ToString();

            //    //HEmpGender.Value = dt.Rows[0]["count"].ToString();
            //}

            //  HAgeMale.Value = genderValue.TrimEnd(','); 

            //        HEmpGender.Value = count.TrimEnd(','); 




        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured in age chart');", true);
            // Response.Redirect("Error.htm",false);
        }
    }
    public void employeeAgeRatio_Linechart()
    {
        try
        {

            SqlParameter[] paramDeptLineChart = new SqlParameter[]
                {
                             new SqlParameter("@orgId",OrgId),
                             new SqlParameter("@parentbranchId",branchId)

                 };
            DataTable dtLine = DAL.ExecuteStoredProcedureDataTable("SP_LineChart_Agegrpwise", paramDeptLineChart);

            if (dtLine.Rows.Count > 0)
            {
                int dtRows = dtLine.Rows.Count;

                string dpt = "", dpt_maleCount = "", dpt_femaleCount = "";

                for (int i = 0; i < dtLine.Rows.Count; i++)
                {
                    if (!dpt.Contains(dtLine.Rows[i]["BranchName"].ToString()))
                        dpt += dtLine.Rows[i]["BranchName"].ToString() + ",";
                    //dpt += "\""+dt.Rows[i]["department"].ToString() +"\"" +",";
                    if (dtLine.Rows[i]["Gender"].ToString() == "Male")
                        dpt_maleCount += dtLine.Rows[i]["counter"].ToString() + ",";
                    else
                        dpt_femaleCount += dtLine.Rows[i]["counter"].ToString() + ",";

                }

                h_dept.Value = dpt.TrimEnd(',');
                h_male_count.Value = dpt_maleCount.TrimEnd(',');
                h_female_count.Value = dpt_femaleCount.TrimEnd(',');
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured');", true);
            // Response.Redirect("Error.htm",false);
        }
    }
    public void viewcounter()
    {
        if (branchId == "0")
        {
            lblfull.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails  where  status='Fully' and orgId='" + OrgId + "' ").ToString();
            lblpartial.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails  where  status='Partially' and orgId='" + OrgId + "' ").ToString();
            lblnot.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails where  status='Not' and orgId='" + OrgId + "' ").ToString();
            lblbooster.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails where  status='Booster' and orgId='" + OrgId + "'").ToString();
            lbltotal.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails WHERE orgId='" + OrgId + "' ").ToString();
        }
        else
        {
            lblfull.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails  where  status='Fully' and orgId='" + OrgId + "' and branchId='" + branchId + "'").ToString();
            lblpartial.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails  where  status='Partially' and orgId='" + OrgId + "' and branchId='" + branchId + "'").ToString();
            lblnot.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails where  status='Not' and orgId='" + OrgId + "' and branchId='" + branchId + "'").ToString();
            lblbooster.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails where  status='Booster' and orgId='" + OrgId + "' and branchId='" + branchId + "'").ToString();
            lbltotal.Text = db.getCount("select count(vaccinationDetailsId) from vaccinationDetails WHERE orgId='" + OrgId + "' and branchId='" + branchId + "'").ToString();
        }
    }
    public void vaccination_pie_chart(string whr)
    {
        try
        {

            DataTable dt = db.bindDataset(@"select distinct status as v_status, count(vaccinationDetailsId) as v_count from vaccinationDetails   group by status");

            if (dt.Rows.Count > 0)
            {
                int dtRows = dt.Rows.Count;

                string v_status = "", v_count = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    v_status += dt.Rows[i]["v_status"].ToString() + ",";
                    v_count += dt.Rows[i]["v_count"].ToString() + ",";

                }

                h_v_status.Value = v_status.TrimEnd(',');
                h_v_count.Value = v_count.TrimEnd(',');

            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured');", true);
            // Response.Redirect("Error.htm",false);
        }

    }

    protected void gridvacDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridvacDetails.PageIndex = e.NewPageIndex;
        vaccinationDetails();
    }

   

    protected void btnsendNotification_Click(object sender, EventArgs e)
    {
       
            connection();
            com = new SqlCommand("GetdsvaccinationDetails_deviceToken", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@orgId", OrgId);
            com.Parameters.AddWithValue("@parentbranchId", branchId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds_AppUserDetails = new DataTable();
            da.Fill(ds_AppUserDetails);

            string Type = "Covid Vaccinated";
            dynamic _Result = new JObject();
            //_Result.BookingId = bookLabId;
            string _payload = JsonConvert.SerializeObject(_Result);
            if (ds_AppUserDetails.Rows.Count != 0)
            {
                foreach (DataRow row in ds_AppUserDetails.Rows)
                {
                    string deviceToken = row["sdeviceToken"].ToString();
                    if (deviceToken != "null")
                    {
                        string appUserId = row["sAppUserId"].ToString();
                        string Message = txtpushMessage.Text;
                       // string msg = "Your Push Notification at "+ Message + " " + ds_AppUserDetails.Rows[0]["Name"].ToString() + " has been created and Send successfully for covid vaccinated.";
                        ObjFCM.SendNotification("Push Notification Status", Message, deviceToken, Type, appUserId.ToString());
                        int _result = objAppNotify.AppNotification(appUserId, "Push Notification Status", Message, Type, _payload, appUserId.ToString());

                       
                        string script = "{ sendnotification('" + deviceToken + "', '" + Message + "'); };";
                        //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "popup", script, true);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", script, true);
                    }
                }
                txtpushMessage.Text = string.Empty;
            }
       
       
    }

  
    public DataTable GetBranchDetails(string type, string vname, string gender, string cname)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = DAL.GetDataTable("Sp_VacDetails_statuswise " + "'" + type + "','"+ vname + "','"+gender+"','"+cname+ "' ,'" + OrgId + "' ,'" + branchId + "' ");
            return dt;
        }
        catch (Exception ex)
        {
            dt = null;
            return dt;
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if(drpfdmType.Text!= "- Select Status -")
        {
            if(drpvacName.Text!= "- Select Vaccination -")
            {
                if (drpgender.Text != "- Select Gender -")
                {
                    if (drpcenterName.Text != "- Select Center -")
                    {
                        string type = drpfdmType.Text;
                        string vname = drpvacName.Text;
                        string gender = drpgender.Text;
                        string cname = drpcenterName.Text;
                        gridvacDetails.DataSource = GetBranchDetails(type, vname, gender, cname);
                        gridvacDetails.DataBind();
                        lblcount.Text = (gridvacDetails.Rows.Count).ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Select Center\");", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Select Gender\");", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Select Vaccination\");", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Select Status\");", true);
        }
    }
}