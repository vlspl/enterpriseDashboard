using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

public partial class Dashboard : System.Web.UI.Page
{
   
    DBClass db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        dpt_line_chart();
        employeeAgeRatio();
   //     vaccination_pie_chart();
        bldGrp_Vbar_chart();
        TopVulnerability_dounutChart();
        LoadCovidVaccinated();
        Health_donut_chart();

        spanMale.InnerHtml =(db.getCount("select sum(health_counter) from EnterpriseData where gender='Male' group by gender").ToString());
        spanFemale.InnerHtml= (db.getCount("select sum(health_counter) from EnterpriseData where gender='Female' group by gender").ToString());
        //
    }

    public void dpt_line_chart()
    {


        try
        {

            DataTable dt = db.bindDataset(@" select department, sum(dpt_male) as male,sum(dpt_female) as female from EnterpriseData  group by department");

            if (dt.Rows.Count > 0)
            {
                int dtRows = dt.Rows.Count;

                string dpt = "", dpt_maleCount = "", dpt_femaleCount = "";



                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dpt += dt.Rows[i]["department"].ToString() + ",";
                    //dpt += "\""+dt.Rows[i]["department"].ToString() +"\"" +",";
                    dpt_maleCount += dt.Rows[i]["male"].ToString() + ",";
                    dpt_femaleCount += dt.Rows[i]["female"].ToString() + ",";

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
    public void employeeAgeRatio()
    {
        try
        {
            // DataTable dt = db.bindDataset("select distinct  age, sum(ageCount) as AgeCount,(gender) from EnterpriseData UNPivot (ageCount for age IN(age_18_25, age_26_35, age_36_45, age_46_60, age_60_above) ) tab group by age,gender ");

            // DataTable dt = db.bindDataset(" select age, STRING_AGG(AgeCount, ',') as AgeCount,STRING_AGG(gender, ',') as gender from( select distinct  age, sum(ageCount) as AgeCount, gender from EnterpriseData UNPivot (ageCount for age IN(age_18_25, age_26_35, age_36_45, age_46_60, age_60_above) ) tab group by age, gender ) b  group by age ");

            DataTable dt = db.bindDataset("  select gender, convert(nvarchar, sum(age_18_25)) +',' + convert(nvarchar, sum(age_26_35)) + ',' + convert(nvarchar, sum(age_36_45))  + ',' + convert(nvarchar, sum(age_46_60)) + ',' + convert(nvarchar, sum(age_60_above)) as val from EnterpriseData group by gender ");
            HAgeMale.Value = dt.Rows[0][1].ToString();
            HEmpGender.Value = dt.Rows[1][1].ToString();

            //if (dt.Rows.Count > 0)
            //{
            //    int dtRows = dt.Rows.Count;
            //    string age = "",gender="";
            //    string ageCount = "";
            //    int ageSum = 0;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {

            //        ageSum += int.Parse(dt.Rows[i]["AgeCount"].ToString());
            //        gender += dt.Rows[i]["gender"].ToString() + ",";
            //        age += dt.Rows[i]["age"].ToString() + ",";

            //        ageCount += dt.Rows[i]["AgeCount"].ToString() + ",";

            //    }




            //    HAgeMale.Value = age.TrimEnd(',');
            //// HAgeFemale.Value = ;
            //    HEmpGender.Value = gender.TrimEnd(',');
            //    //HDepartmentTotal.Value = (ageSum).ToString();
            //    //spanDepartmentTotalCount.InnerHtml = ageSum.ToString();
            // }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured');", true);
            // Response.Redirect("Error.htm",false);
        }
    }
    public void vaccination_pie_chart()
    {


        try
        {

            DataTable dt = db.bindDataset(@"select distinct  v_status, sum(v_count) as v_count from EnterpriseData UNPivot (v_count for v_status IN([not_vaccinated],[fully_vaccinated],[partially_vaccinated]) ) tab group by v_status ");

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
    protected void bldGrp_Vbar_chart()
    {

        DataTable dt = db.GetData("select distinct  UPPER(bldgName) as bldgName,sum(bloodCount) as bloodCount from EnterpriseData UNPivot (bloodCount for bldgName IN(bl_A_pv,bl_A_nv , bl_B_pv , bl_B_nv, bl_O_pv, bl_O_nv,bl_AB_pv,bl_AB_nv)) tab group by bldgName");
        Chart1.DataSource = dt;
        //Chart1.Series[0].ChartType = (SeriesChartType)int.Parse(rblChartType.SelectedItem.Value);
        Chart1.Legends[0].Enabled = true;
        Chart1.Series[0].XValueMember = "bldgName";
        Chart1.Series[0].YValueMembers = "bloodCount";
        Chart1.DataBind();
    }
    
    protected void TopVulnerability_dounutChart()
    {
        try
        {
            DataTable dt = db.bindDataset("select distinct Upper(dsName) as dsName,sum(dpcount) as diseaseCount from EnterpriseData UNPivot (dpcount for dsName IN(bp, diabetes, heart_ailment, hypertension, overwt_obesitty)) tab group by dsName; ");


            if (dt.Rows.Count > 0)
            {
                int dtRows = dt.Rows.Count;
                string DeptName = "";
                string DeptCount = "";
                int DeptSum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                     DeptSum +=int.Parse(dt.Rows[i]["diseaseCount"].ToString());
                   
                     DeptName += dt.Rows[i]["dsName"].ToString() + ",";
                    DeptCount += dt.Rows[i]["diseaseCount"].ToString() + ",";
                    
                }
                HDepartmentName.Value = DeptName.TrimEnd(',');
                HDepartmentCount.Value = DeptCount.TrimEnd(',');
                HDepartmentTotal.Value = (DeptSum).ToString();
                //spanDepartmentTotalCount.InnerHtml = DeptSum.ToString();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured');", true);
            // Response.Redirect("Error.htm",false);
        }
    }
    protected void LoadCovidVaccinated()
    {
        try
        {

           DataTable dtCovidVaccinated = db.bindDataset("select distinct  testStatus,sum(statusCount) as statusCount from EnterpriseData UNPivot ( statusCount for testStatus IN(not_vaccinated, fully_vaccinated, partially_vaccinated)) tab group by testStatus; ");
            if (dtCovidVaccinated.Rows.Count > 0)
            {
                #region Test Count Gender wise
               
                if (dtCovidVaccinated.Rows.Count > 0)
                {
                    string tsetStatus = "";
                    string TestCount = "";
                    int TotalSum = 0;

                    for (int i = 0; i < dtCovidVaccinated.Rows.Count; i++)
                    {
                        tsetStatus += dtCovidVaccinated.Rows[i]["testStatus"].ToString() + ",";
                        TestCount += dtCovidVaccinated.Rows[i]["statusCount"].ToString() + ",";
                        TotalSum += int.Parse(dtCovidVaccinated.Rows[i]["statusCount"].ToString());

                       
                    }
                    HAgegroupAmt.Value = TestCount.TrimEnd(',');
                    HGender.Value = tsetStatus.TrimEnd(',');
                    HTestCountGender.Value = TestCount.TrimEnd(',');
                    HTotalGenderTestCount.Value = TotalSum.ToString();
                   //spanTotalTestCountGenderwise.InnerHtml = (TotalSum).ToString();
                }
                #endregion
                #region Test status Wise Chart
                DataTable dtAge = dtCovidVaccinated;
                string testAmt = "";
                if (dtAge.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAge.Rows.Count; i++)
                    {
                        testAmt += dtAge.Rows[i]["statusCount"].ToString() + ",";

                        HAgegroupAmt.Value = testAmt;
                    }
                }
                #endregion
            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured');", true);
            // Response.Redirect("Error.htm",false);
        }
    }

 
    protected void Health_donut_chart()
    {
        try
        {
            DataTable dt = db.bindDataset("select emp_health,sum(health_counter)as Healthcount from EnterpriseData    group by emp_health ");


            if (dt.Rows.Count > 0)
            {
                int dtRows = dt.Rows.Count;
                string DeptName = "";
                string DeptCount = "";
                int DeptSum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DeptSum += int.Parse(dt.Rows[i]["Healthcount"].ToString());

                    DeptName += dt.Rows[i]["emp_health"].ToString() + ",";
                    DeptCount += dt.Rows[i]["Healthcount"].ToString() + ",";

                }
                HhealthName.Value = DeptName.TrimEnd(',');
                HhealthCount.Value = DeptCount.TrimEnd(',');
                HhealthTotal.Value = (DeptSum).ToString();
             //   spanHealth.InnerHtml = DeptSum.ToString();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured');", true);
            // Response.Redirect("Error.htm",false);
        }
    }

   

  
}