using CrossPlatformAESEncryption.Helper;
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

public partial class empHealth : System.Web.UI.Page
{
    DataAccessLayer DAL = new DataAccessLayer();
    DBClass db = new DBClass();
    ClsFCMNotification ObjFCM = new ClsFCMNotification();
    ClsAppNotification objAppNotify = new ClsAppNotification();
    private SqlConnection con;
    private SqlCommand com;
    string constr, query, branchId, OrgId, healthGrp;
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
        healthGrp = Request.QueryString["g_dtls"];

        if (!IsPostBack)
        {
            db.bindDrp("select distinct BranchName from BranchMaster where Org_Id='" + OrgId + "'", drpbranch, "BranchName", "BranchName");
            drpbranch.Items.Insert(0, new ListItem("All", "All"));
            db.bindDrp("select distinct deptName from AddDepartment where orgId='" + OrgId + "'", drpdepartment, "deptName", "deptName");
            drpdepartment.Items.Insert(0, new ListItem("All", "All"));
           
            



            employeeGenderRatio();
            employeeAgeRatio_stackbarchart();
            viewcounter();

           HealthDetails();
        }
      
    }

    protected void HealthDetails()
    {
        try
        {
            connection();
            com = new SqlCommand("[GetHealthDetails]", con);//GettopVDetails
            com.Parameters.AddWithValue("@orgId", OrgId);
            com.Parameters.AddWithValue("@parentbranchId", branchId);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gridtopV.DataSource = dt;
            gridtopV.DataBind();
            lblcount.Text = (gridtopV.DataSource as DataTable).Rows.Count.ToString();
            
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
                             new SqlParameter("@parentbranchId",branchId),
                             // new SqlParameter("@gender","All"),
                             //new SqlParameter("@dept","All"),
                             //    new SqlParameter("@branchNm","All"),

      };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_EmpGenderChartForHealth", paramEmgAgeRatio);

            if (dt.Rows.Count > 1)
            {
                HAgeMale.Value = dt.Rows[0][1].ToString();

                HEmpGender.Value = dt.Rows[1][1].ToString();
            }
            else if (dt.Rows[0][0].ToString() == "Male")
            {
                HEmpGender.Value = "0";
                HAgeMale.Value = dt.Rows[0][1].ToString();
            }
            else if (dt.Rows[0][0].ToString() == "Female")
            {
                HAgeMale.Value = "0";
                HEmpGender.Value = dt.Rows[0][1].ToString();

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
    public void employeeAgeRatio_stackbarchart()
    {
        try
        {

            SqlParameter[] paramDeptLineChart = new SqlParameter[]
                {
                             new SqlParameter("@orgId",OrgId),
                             new SqlParameter("@parentbranchId",branchId)

                 };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_stackChart_Agegrpwise", paramDeptLineChart);
            if (dt.Rows.Count > 0)
            {
                int dtRows = dt.Rows.Count;

                string dpt = "", dpt_maleCount = "", dpt_femaleCount = "", dept = "";

                DataRow[] foundRows;

                DataTable distinctDT = SelectDistinct(dt, "BranchName");
                for (int i = 0; i < distinctDT.Rows.Count; i++)
                {

                    dpt += distinctDT.Rows[i]["BranchName"].ToString() + ",";
                    dept = distinctDT.Rows[i]["BranchName"].ToString();

                    // Use the Select method to find all rows matching the filter.
                    foundRows = dt.Select("BranchName='" + dept + "'");
                    if (foundRows.Length > 1)
                    {
                        // Print column 0 of each returned row.
                        //for (int j = 0; j < foundRows.Length; j++)
                        //{
                        dpt_femaleCount += foundRows[0]["counter"].ToString() + ",";
                        dpt_maleCount += foundRows[1]["counter"].ToString() + ",";

                        // }
                    }
                    else
                    {
                        if (foundRows[0]["Gender"].ToString() == "Male")
                        {
                            dpt_maleCount += foundRows[0]["counter"].ToString() + ",";
                            dpt_femaleCount += "0,";
                        }
                        else
                        {
                            dpt_femaleCount += foundRows[0]["counter"].ToString() + ",";
                            dpt_maleCount += "0,";
                        }
                    }

                }


                h_dept.Value = dpt.TrimEnd(',');
                h_male_count.Value = dpt_maleCount.TrimEnd(',');
                h_female_count.Value = dpt_femaleCount.TrimEnd(',');
            }
            else
            {
                h_dept.Value = "";
                h_male_count.Value = "";
                h_female_count.Value = "";
            }
            //if (dtLine.Rows.Count > 0)
            //{
            //    int dtRows = dtLine.Rows.Count;

            //    string dpt = "", dpt_maleCount = "", dpt_femaleCount = "";

            //    for (int i = 0; i < dtLine.Rows.Count; i++)
            //    {

            //        dpt += dtLine.Rows[i]["age"].ToString() + ",";
            //        //dpt += "\""+dt.Rows[i]["department"].ToString() +"\"" +",";
            //        if (dtLine.Rows[i]["gender"].ToString() == "Male")
            //            dpt_maleCount += dtLine.Rows[i]["gcounter"].ToString() + ",";
            //        else
            //            dpt_femaleCount += dtLine.Rows[i]["gcounter"].ToString() + ",";

            //    }

            //    h_dept.Value = dpt.TrimEnd(',');
            //    h_male_count.Value = dpt_maleCount.TrimEnd(',');
            //    h_female_count.Value = dpt_femaleCount.TrimEnd(',');
            //}
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured');", true);
            // Response.Redirect("Error.htm",false);
        }
    }
    public DataTable SelectDistinct(DataTable SourceTable, string FieldName)
    {
        // Create a Datatable – datatype same as FieldName  
        DataTable dt = new DataTable(SourceTable.TableName);
        dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
        // Loop each row & compare each value with one another  
        // Add it to datatable if the values are mismatch  
        object LastValue = null;
        foreach (DataRow dr in SourceTable.Select("", FieldName))
        {
            if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
            {
                LastValue = dr[FieldName];
                dt.Rows.Add(new object[] { LastValue });
            }
        }
        return dt;
    }
    private bool ColumnEqual(object A, object B)
    {
        // Compares two values to see if they are equal. Also compares DBNULL.Value.             
        if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value  
            return true;
        if (A == DBNull.Value || B == DBNull.Value) //  only one is BNull.Value  
            return false;
        return (A.Equals(B)); // value type standard comparison  
    }

    public void viewcounter()
    {
        int total = 0;
        SqlParameter[] param_count = new SqlParameter[]
                {
                             new SqlParameter("@orgId",OrgId),
                             new SqlParameter("@parentbranchId",branchId),
                              new SqlParameter("@branchNm","All"),
                       new SqlParameter("@gender","All"),
                    new SqlParameter("@dept","All"), 

                 };
        DataTable dt_counter = DAL.ExecuteStoredProcedureDataTable("sp_HealthCounterForChart", param_count);
        foreach (DataRow row_count in dt_counter.Rows)
        {
            total += int.Parse(row_count["Healthcount"].ToString());
            if (row_count["emp_health"].ToString() == "Healthy")
                lblhealthy.Text = row_count["Healthcount"].ToString();
            if (row_count["emp_health"].ToString() == "Unhealthy")
                lblunhealthy.Text = row_count["Healthcount"].ToString();
          
        }
        lbltotal.Text = total.ToString();
        if (healthGrp != null)
        {
            if (healthGrp == "Healthy")
                lblunhealthy.Text = "0";
            else
                lblhealthy.Text = "0";
            lbltotal.Text = (int.Parse(lblhealthy.Text) + int.Parse(lblunhealthy.Text)).ToString();
        }
    }

    protected void gridtopV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridtopV.PageIndex = e.NewPageIndex;
        HealthDetails();
    }

   

    protected void btnsendNotification_Click(object sender, EventArgs e)
    {
       
            connection();
            com = new SqlCommand("GetdsHealthDetails_deviceToken", con);
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

  
    public DataTable GetBranchDetails(string branch, string dept, string gender,string age, string topv, string orgId)
    {
        DataTable dt = new DataTable();
        try
        {
            if (healthGrp == "Healthy")
                topv = "Healthy";
            else if (healthGrp == "Unhealthy")
                topv = "Unhealthy";
            dt = DAL.GetDataTable("sp_empHealth_Filter " + "'" + branch + "','"+ dept + "','"+gender+"','"+age+"','"+ topv + "','"+ orgId + "','" + branchId + "'");
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
        
                        string branch = drpbranch.Text;
                        string dept = drpdepartment.Text;
                        string gender = drpgender.Text;
                        string age = drpagegroup.Text;
                        string hRatio = drphratio.Text;
                        string orgId = OrgId.ToString();
                        gridtopV.DataSource = GetBranchDetails(branch, dept, gender,age, hRatio, orgId);
                        gridtopV.DataBind();
                        lblcount.Text = (gridtopV.DataSource as DataTable).Rows.Count.ToString();
//   
//    
//}
    }
    protected void gridtopV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string result = (dr["sResult"].ToString());
           
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            e.Row.Cells[5].Text = CryptoHelper.Decrypt(result);
            if (e.Row.Cells[5].Text == "Normal")
                e.Row.Cells[5].Text = "Healthy";
            else
                e.Row.Cells[5].Text = "Unhealthy";
        }
    }
}