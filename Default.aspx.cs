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
using DataAccessHandler;

public partial class Dashboard : System.Web.UI.Page
{

    DBClass db = new DBClass();
    bool flagMale = false, flagMFemale = false, flagHealthy = false, flagunealthy = false;
    string[] cartArray = new string[50];
    // List<int> cartArray = new List<string>(Enumerable.Range());
    SqlConnection cn;
    int getZone = 0, OrgId;
    string getColor = "",userName,branchId,userId;
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        // OrganizationId = int.Parse( Session["OrgId"].ToString());
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        userName = Session["userName"].ToString();
        branchId = Session["BranchId"].ToString();
        OrgId = int.Parse(Session["OrgId"].ToString());
 userId= Session["HRId"].ToString();
        //  bindNivoSlider();
        //  lblOrg.Text = OrgId.ToString();
        if (!IsPostBack)
        {

            if (Request.QueryString["zoneId"] != null)
            {
                getZone = int.Parse(Request.QueryString["zoneId"]);
                switch (getZone)
                {
                    case 1:
                        lblDesignation.Text = "CEO";
                        break;

                    case 2:
                        lblDesignation.Text = "Country Head";
                        break;
                    case 3:
                        lblDesignation.Text = "Branch HR";
                        break;
                }
                // lblUsernm.Text = db.getData("SELECT  OrganizationUsers.Name FROM   OrganizationMaster INNER JOIN BranchMaster ON OrganizationMaster.ID = BranchMaster.Org_Id INNER JOIN OrganizationUsers ON OrganizationMaster.ID = OrganizationUsers.Org_Id AND BranchMaster.ID = OrganizationUsers.Branch_ID WHERE(BranchMaster.Email = '" + userName + "')").ToString();
            }
            lblUsernm.Text = db.getData("SELECT Name FROM OrganizationUsers WHERE Org_Id = '" + OrgId + "' and Branch_ID='" + branchId + "' and  Id='"+userId+"'").ToString();

            db.cnopen();

            bindAllDrp();

            bindAllCounterAndChart();

            // LoadHealth("");


            // PopulateChartForTestGrp("");
            db.cnclose();


        }

    }
    public void bindNivoSlider()
    {

        //====== Getting connection string defined in the web.config file. Pointed to the database we want to use.
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        //======= Select Query.
        string cmdText = "select '..'+ImagePath as ImagePath ,IsActive from Dashboardslider order by 1 desc";

        //====== Providning information to SQL command object about which query to 
        //====== execute and from where to get database connection information.
        SqlCommand cmd = new SqlCommand(cmdText, con);

        //===== To check current state of the connection object. If it is closed open the connection
        //===== to execute the insert query.
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        //===== Execute Query and bind data to Datalist.
        //repeaterNivoSlider.DataSource = cmd.ExecuteReader();
        //repeaterNivoSlider.DataBind();
    }
  
    void adv()
    {
        for (int i = 0; i < 5; i++)
        {
            //txtCart.Text += cartArray[i] + ",";
        }

    }
   
    #region Bind All dropdown
    public void bindAllDrp()
    {
        //For Bind Branch 
        SqlParameter[] paramBranchBind = new SqlParameter[]
             {
                             new SqlParameter("@orgId",OrgId),
                             new SqlParameter("@parentbranchId",branchId)
              };
        DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_bindBranch", paramBranchBind);
        drpcountry.DataSource = dt;

        drpcountry.DataTextField = "BranchName";
        drpcountry.DataValueField = "ID";
        drpcountry.DataBind();
        drpcountry.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"

        db.bindDrp("select distinct deptName from AddDepartment where orgId='" + OrgId + "'", drpDept, "deptName", "deptName");
        drpDept.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"

        ////For Bind Dept 
        //SqlParameter[] paramDeptBind = new SqlParameter[]
        //     {
        //                     new SqlParameter("@orgId",OrgId),
        //                     new SqlParameter("@parentbranchId",branchId)

        //      };
        //DataTable dtDept = DAL.ExecuteStoredProcedureDataTable("SP_bindDept", paramDeptBind);
        //drpDept.DataSource = dtDept;
        //drpDept.DataTextField = "deptName";
        //drpDept.DataValueField ="deptId";

        //drpDept.DataBind();
        //// drpDept.DataBind();
        //drpDept.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"

    }
    #endregion
    #region AllCharts
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
    #region Department Line Chart
    public void dpt_line_chart()
    {
        try
        {
            if (drpcountry.SelectedItem.Text != "All")
                branchId = drpcountry.SelectedItem.Value;
            else
                branchId = Session["branchId"].ToString();

          
            SqlParameter[] param = new SqlParameter[]
{
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

};
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_departmentLineChart", param);

            if (dt.Rows.Count > 0)
            {
                int dtRows = dt.Rows.Count;

                string dpt = "", dpt_maleCount = "", dpt_femaleCount = "", dept = "";

                DataRow[] foundRows;

                DataTable distinctDT = SelectDistinct(dt, "Department");
                for (int i = 0; i < distinctDT.Rows.Count; i++)
                {

                    dpt += distinctDT.Rows[i]["department"].ToString() + ",";
                    dept = distinctDT.Rows[i]["department"].ToString();

                    // Use the Select method to find all rows matching the filter.
                    foundRows = dt.Select("department='" + dept + "'");
                    if (foundRows.Length > 1)
                    {
                        // Print column 0 of each returned row.
                        //for (int j = 0; j < foundRows.Length; j++)
                        //{
                        dpt_femaleCount += foundRows[0]["gcounter"].ToString() + ",";
                        dpt_maleCount += foundRows[1]["gcounter"].ToString() + ",";

                        // }
                    }
                    else
                    {
                        if (foundRows[0]["Gender"].ToString() == "Male")
                        {
                            dpt_maleCount += foundRows[0]["gcounter"].ToString() + ",";
                            dpt_femaleCount += "0,";
                        }
                        else
                        {
                            dpt_femaleCount += foundRows[0]["gcounter"].ToString() + ",";
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
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured in line chart');", true);
            // Response.Redirect("Error.htm",false);
        }


    }
    #endregion

    #region Employee Age Ratio Bar Chart
    public void employeeAgeRatio()
    {
        try
        {
            if (drpcountry.SelectedItem.Text != "All")
                branchId = drpcountry.SelectedItem.Value;
            else
                branchId = Session["branchId"].ToString();

           

            SqlParameter[] param = new SqlParameter[]
{
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

};
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_EmpAgeRatioChart", param);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    HAgeMale.Value = dt.Rows[1][1].ToString();

                    HEmpGender.Value = dt.Rows[0][1].ToString();
                }
                else if (drpGender.SelectedValue == "Male")
                {
                    HEmpGender.Value = "0,0,0,0,0";
                    HAgeMale.Value = dt.Rows[0][1].ToString();
                }
                else if (drpGender.SelectedValue == "Female")
                {
                    HAgeMale.Value = "0,0,0,0,0";
                    HEmpGender.Value = dt.Rows[0][1].ToString();

                }
                else if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0].ToString() == "Male")
                    {
                        HEmpGender.Value = "0,0,0,0,0";
                        HAgeMale.Value = dt.Rows[0][1].ToString();
                    }
                    else
                    {
                        HAgeMale.Value = "0,0,0,0,0";
                        HEmpGender.Value = dt.Rows[0][1].ToString();
                    }
                }
                else
                {
                    HEmpGender.Value = "0";
                    HAgeMale.Value = "0";
                }
            }
            else
            {
                HEmpGender.Value = "0";
                HAgeMale.Value = "0";
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured in age chart');", true);
            // Response.Redirect("Error.htm",false);
        }
    }
    #endregion

    #region Blood group ratio Vertical Bar Chart
    protected void PopulateChartForBloodGrp()
    {
        if (drpcountry.SelectedItem.Text != "All")
            branchId = drpcountry.SelectedItem.Value;
        else
            branchId = Session["branchId"].ToString();

      

        SqlParameter[] param = new SqlParameter[]
      {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

      };
        DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_EmpBloodRatioChart", param);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows.Count > 1)
            {

                hbldgrpCount.Value = dt.Rows[0][1].ToString();

                hBGgender.Value = dt.Rows[1][1].ToString();

            }
            else if (drpGender.SelectedValue == "Male")
            {
                if (dt.Rows.Count > 0)
                    hBGgender.Value = dt.Rows[0][1].ToString();
                hbldgrpCount.Value = "0";
            }
            else if (drpGender.SelectedValue == "Female")
            {
                hBGgender.Value = "0";
                if (dt.Rows.Count > 0)
                    hbldgrpCount.Value = dt.Rows[0][1].ToString();

            }
            else if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][0].ToString() == "Male")
                {
                    hbldgrpCount.Value = "0,0,0,0,0,0,0,0";
                    hBGgender.Value = dt.Rows[0][1].ToString();
                }
                else
                {
                    hBGgender.Value = "0,0,0,0,0,0,0,0";
                    hbldgrpCount.Value = dt.Rows[0][1].ToString();
                }
            }
            else
            {
                hBGgender.Value = "0";
                hbldgrpCount.Value = "0";
            }
        }
        else
        {
            hBGgender.Value = "0";
            hbldgrpCount.Value = "0";
        }

    }
    #endregion

    #region Top Vulnerability Donut chart
    protected void LoadTopVulnerability()
    {
        try
        {
            if (drpcountry.SelectedItem.Text != "All")
                branchId = drpcountry.SelectedItem.Value;
            else
                branchId = Session["branchId"].ToString();

            SqlParameter[] param = new SqlParameter[]
{
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

};
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_TopVulnerabilityChart", param);
            if (dt.Rows.Count > 0)
            {
                int dtRows = dt.Rows.Count;
                string DeptName = "";
                string DeptCount = "";
                int DeptSum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DeptSum += int.Parse(dt.Rows[i]["diseaseCount"].ToString());

                    DeptName += dt.Rows[i]["dsName"].ToString() + ",";
                    DeptCount += dt.Rows[i]["diseaseCount"].ToString() + ",";

                }
                HDepartmentName.Value = DeptName.TrimEnd(',');
                HDepartmentCount.Value = DeptCount.TrimEnd(',');
                HDepartmentTotal.Value = (DeptSum).ToString();
                //spanDepartmentTotalCount.InnerHtml = DeptSum.ToString();

            }
 else
            {
                HDepartmentName.Value = "";
                HDepartmentCount.Value = "";
                HDepartmentTotal.Value = "";
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured in tp 5 chart');", true);
            // Response.Redirect("Error.htm",false);
        }
    }
    #endregion

    #region Covid Vaccinated Pie Chart
    protected void LoadCovidVaccinated()
    {
        try
        {
            if (drpcountry.SelectedItem.Text != "All")
                branchId = drpcountry.SelectedItem.Value;
            else
                branchId = Session["branchId"].ToString();

            SqlParameter[] param = new SqlParameter[]
      {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text)

      };

            DataTable dtCovidVaccinated = DAL.ExecuteStoredProcedureDataTable("sp_CovidChart", param);

            if (dtCovidVaccinated.Rows.Count >0)
            {
                foreach (DataRow row in dtCovidVaccinated.Rows)
                {

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

                            h_v_status.Value = tsetStatus.TrimEnd(',');
                            h_v_count.Value = TestCount.TrimEnd(',');
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
            }
            else
            {
                HAgegroupAmt.Value = "0,0,0";
                HGender.Value = "0,0,0";
                HTestCountGender.Value = "0,0,0";
                HTotalGenderTestCount.Value = "0,0,0";

                h_v_status.Value = "0,0,0";
                h_v_count.Value = "0,0,0";
            }
                

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured in covid chart');", true);
            // Response.Redirect("Error.htm",false);
        }
    }
    #endregion

    #region Employee Health Donut Chart
    protected void LoadHealth()
    {
        try
        {
            if (drpcountry.SelectedItem.Text != "All")
                branchId = drpcountry.SelectedItem.Value;
            else
                branchId = Session["branchId"].ToString();

            SqlParameter[] param = new SqlParameter[]
    {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

    };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("sp_HealthCounterForChart", param);

            if (dt.Rows.Count > 0)
            {
              //  int dtRows = dt.Rows.Count;
                string Emphealth = "";
                string healthCount = "";
                int healthSum = 0;

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0]["emp_health"].ToString() == "Healthy")
                    {
                        Emphealth += dt.Rows[0]["emp_health"].ToString() + ",";
                        healthCount += dt.Rows[0]["Healthcount"].ToString() + ",";
                        healthSum += int.Parse(dt.Rows[0]["Healthcount"].ToString());

                        Emphealth += "Unhealthy" + ",";
                        healthCount += "0" + ",";
                    }
                    else
                    {
                        Emphealth += "Healthy" + ",";
                        healthCount += "0" + ",";

                        Emphealth += dt.Rows[0]["emp_health"].ToString() + ",";
                        healthCount += dt.Rows[0]["Healthcount"].ToString() + ",";
                        healthSum += int.Parse(dt.Rows[0]["Healthcount"].ToString());

                      
                    }


                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        healthSum += int.Parse(dt.Rows[i]["Healthcount"].ToString());

                        Emphealth += dt.Rows[i]["emp_health"].ToString() + ",";
                        healthCount += dt.Rows[i]["Healthcount"].ToString() + ",";
                    }
                }


           


          
                HhealthName.Value = Emphealth.TrimEnd(',');
                HhealthCount.Value = healthCount.TrimEnd(',');
                HhealthTotal.Value = (healthSum).ToString();
                //spanHealth.InnerHtml = DeptSum.ToString();

            }
            else
            {
                HhealthName.Value = "0,0";
                HhealthCount.Value = "0,0";
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideModal", "alert('Error occured in health chart');", true);
            // Response.Redirect("Error.htm",false);
        }
    }

    #endregion

    #region test group ratio
    protected void PopulateChartForTestGrp()
    {
        if (drpcountry.SelectedItem.Text != "All")
            branchId = drpcountry.SelectedItem.Value;
        else
            branchId = Session["branchId"].ToString();

        SqlParameter[] paramTest = new SqlParameter[]
      {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

      };
        DataTable dt = DAL.ExecuteStoredProcedureDataTable("sp_TestChart", paramTest);

        if (dt.Rows.Count > 0)
        {
            int dtRows = dt.Rows.Count;

            string t_status = "", t_count = "";
                t_status= "Test Completed,Test Pending";
                t_count = dt.Rows[0][0].ToString() +","+ dt.Rows[0][1].ToString();

            htestStatus.Value = t_status;
            htestCount.Value = t_count;

            // here counter for health camp
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@orgId",OrgId) ,
                new SqlParameter("@returnval",SqlDbType.Int)
            };
            int Testcount = DAL.ExecuteStoredProcedureRetnInt("SP_getTestCount", param);
            if (Testcount != 0)
            {
                lbltestPendingCounter.Text = ((int.Parse(lblEmpCounter.Text) * Testcount) - (int.Parse(lbltestCompletedCounter.Text))).ToString();

                t_status = "Test Completed,Test Pending";
                t_count = dt.Rows[0][0].ToString() + "," + lbltestPendingCounter.Text;

                htestStatus.Value = t_status;
                htestCount.Value = t_count;
            }


        }
        else
        {
            htestStatus.Value = "0,0,0";
            htestCount.Value = "0,0,0";
        }

    }
    #endregion
    #endregion
    #region All Counters
    #region BranchCounter
    void branchCounterChart()
    {
        if (drpcountry.SelectedItem.Text != "All")
            branchId = drpcountry.SelectedItem.Value;
        else
            branchId = Session["branchId"].ToString();

        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
             new SqlParameter("@orgId",OrgId),
         };
        DataTable dtBranch = DAL.ExecuteStoredProcedureDataTable("SP_BranchCounter", param);
        foreach (DataRow row in dtBranch.Rows)
        {
            lblBranchCounter.Text = row["count"].ToString();
        }

        //for display branch details list
        SqlParameter[] paramBranchList = new SqlParameter[]
      {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),

      };
        DataTable dt_getBranchDtls = DAL.ExecuteStoredProcedureDataTable("SP_BranchDetailsList", paramBranchList);
        Session["branchDtls"] = dt_getBranchDtls;

    }
    #endregion
    #region EmployeeCounter
    void employeeCounterChart()
    {
       
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

        };
        DataTable dtEmp = DAL.ExecuteStoredProcedureDataTable("SP_EmpCounterByMultipleCriteria", param);
        foreach (DataRow row in dtEmp.Rows)
        {

            lblEmpCounter.Text = row["count"].ToString();
        }
        //for display employee details list
        SqlParameter[] paramEmpList = new SqlParameter[]
      {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

      };
        DataTable dt_getEmpDtls = DAL.ExecuteStoredProcedureDataTable("SP_EmpDetails", paramEmpList);
        Session["EmpDtls"] = dt_getEmpDtls; //qryForEmpList+ " order by 1 desc ";
    }
    #endregion
    #region HealthCounter
    void healthCounterChart()
    {
        lblHealthyCounter.Text = "0";
        lblUnhealthyCounter.Text = "0";
        if (drpcountry.SelectedItem.Text != "All")
            branchId = drpcountry.SelectedItem.Value;
        else
            branchId = Session["branchId"].ToString();

        SqlParameter[] param = new SqlParameter[]
      {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

      };
        //DataTable dtEmpHealth = DAL.GetDataTable(qry + grpBy);
        DataTable dtEmpHealth = DAL.ExecuteStoredProcedureDataTable("sp_GetHealthCounter", param);
        if (dtEmpHealth.Rows.Count > 0)
        {
            foreach (DataRow row in dtEmpHealth.Rows)
            {
                if (row["EmpHealth"].ToString() == "Healthy")
                {


                    lblHealthyCounter.Text = row["Healthcount"].ToString();
                }
                if (row["EmpHealth"].ToString() == "Unhealthy")
                {

                    lblUnhealthyCounter.Text = row["Healthcount"].ToString();

                }


            }
        }
        else
        {
            lblHealthyCounter.Text = "0";
            lblUnhealthyCounter.Text = "0";
        }
        //if (drphealth.Text == "Healthy")
        //    lblUnhealthyCounter.Text = "0";
        //if (drphealth.Text == "Unhealthy")
        //    lblHealthyCounter.Text = "0";
    }
    #endregion
    #region TestCounter
    void TestCounterChart()
    {
        if (drpcountry.SelectedItem.Text != "All")
            branchId = drpcountry.SelectedItem.Value;
        else
            branchId = Session["branchId"].ToString();
       
        SqlParameter[] paramTest = new SqlParameter[]
   {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

   };
        DataTable dtTest = DAL.ExecuteStoredProcedureDataTable("sp_GetTestCounter", paramTest);
        if (dtTest.Rows.Count > 0)
        {
            foreach (DataRow row in dtTest.Rows)
            {

                lbltestCompletedCounter.Text = row["Completed"].ToString();
                //if (row["testStatus"].ToString() == "Test Pending")
                lbltestPendingCounter.Text = row["Pending"].ToString();
            }
        }
        else
        {
            lbltestCompletedCounter.Text = "0";
            lbltestPendingCounter.Text = "0";
        }
        // here counter for health camp
        SqlParameter[] param = new SqlParameter[]
        {
                new SqlParameter("@orgId",OrgId) ,
                new SqlParameter("@returnval",SqlDbType.Int) 
        };
        int Testcount = DAL.ExecuteStoredProcedureRetnInt("SP_getTestCount", param);
        if (Testcount != 0 && int.Parse(lbltestCompletedCounter.Text).ToString()!="")
            lbltestPendingCounter.Text = ((int.Parse(lblEmpCounter.Text) * Testcount) - (int.Parse(lbltestCompletedCounter.Text))).ToString();

    }
    #endregion
    #region VaccineCounter
    void vaccineCounterChart()
    {
        lblFullvaccineCounter.Text = "0";
        if (drpcountry.SelectedItem.Text != "All")
            branchId = drpcountry.SelectedItem.Value;
        else
            branchId = Session["branchId"].ToString();
      
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),
        };

        DataTable dtvaccine = DAL.ExecuteStoredProcedureDataTable("sp_GetVaccineCounter", param);
        if (dtvaccine.Rows.Count > 0)
        {
            foreach (DataRow row in dtvaccine.Rows)
            {
                if (row["testStatus"].ToString() == "Fully")
                    lblFullvaccineCounter.Text = row["statusCount"].ToString();
            }
        }
        else
        {
            lblFullvaccineCounter.Text = "0";
        }

    }
    #endregion
    #region GenderCounter
    void GenderCounterChart()
    {
        spanMale.InnerText = "0";
        spanFemale.InnerText = "0";
        if (drpcountry.SelectedItem.Text != "All")
            branchId = drpcountry.SelectedItem.Value;
        else
            branchId = Session["branchId"].ToString();
       

        SqlParameter[] param = new SqlParameter[]
{
            new SqlParameter("@branchNm",drpcountry.SelectedItem.Text),
            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",OrgId),
            new SqlParameter("@gender",drpGender.SelectedItem.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),

};
        DataTable dtGender = DAL.ExecuteStoredProcedureDataTable("SP_GenderCounter", param);
       // DataTable dtGender = DAL.GetDataTable(qry + groupBy);
        if (dtGender.Rows.Count > 0)
        {
            foreach (DataRow row in dtGender.Rows)
            {
                if (dtGender.Rows.Count > 1)
                {
                    spanMale.InnerText = dtGender.Rows[0][1].ToString();
                    spanFemale.InnerText = dtGender.Rows[1][1].ToString();

                }
                else if (dtGender.Rows[0][0].ToString() == "Male")
                {
                    spanMale.InnerText = dtGender.Rows[0][1].ToString();
                    spanFemale.InnerText = "0";
                }
                else if (dtGender.Rows[0][0].ToString() == "Female")
                {
                    spanMale.InnerText = "0";
                    spanFemale.InnerText = dtGender.Rows[0][1].ToString();
                }
                else
                {
                    spanMale.InnerText = "0";
                    spanFemale.InnerText = "0";
                }

            }
        }
        else
        {
            spanMale.InnerText = "0";
            spanFemale.InnerText = "0";
        }

    }
    #endregion
    #region DeptCounter
    void DeptCounterChart()
    {
        SqlParameter[] param = new SqlParameter[]
       {
            new SqlParameter("@orgId",OrgId),
             new SqlParameter("@dept",drpDept.SelectedItem.Text)

       };
        DataTable dtDept = DAL.ExecuteStoredProcedureDataTable("SP_DeptCounter", param);
       // DataTable dtDept = DAL.GetDataTable(qry);
        foreach (DataRow row in dtDept.Rows)
        {

            lblDeptCounter.Text = row["count"].ToString();
        }

    }
    #endregion
    #endregion
    public void bindAllCounterAndChart()
    {
        //Counters
        branchCounterChart();
        employeeCounterChart();
        healthCounterChart();
        TestCounterChart();
        vaccineCounterChart();
        GenderCounterChart();
        DeptCounterChart();

        // charts
        LoadCovidVaccinated();
        LoadTopVulnerability();
        LoadHealth();
        dpt_line_chart();
        employeeAgeRatio();
        // vaccination_pie_chart();
        PopulateChartForBloodGrp();
        PopulateChartForTestGrp();
    }


    protected void drpDept_TextChanged(object sender, EventArgs e)
    {
        bindAllCounterAndChart();
        if (drpDept.Text == "All")
        {
            branchId = Session["BranchId"].ToString();
            
        }
        else
            lblDeptCounter.Text = "1";

       
    }
    protected void drpcountry_TextChanged(object sender, EventArgs e)
    {
        if (drpcountry.Text == "All")
        {
            branchId = Session["BranchId"].ToString();
           
        }
        //else
        //{
        //    branchId = drpcountry.SelectedValue;
        //    lblBranchCounter.Text = "1";
        //}
        bindAllCounterAndChart();

    }

    protected void drpState_TextChanged(object sender, EventArgs e)
    {
        bindAllCounterAndChart();

    }

    protected void drpbranch_TextChanged(object sender, EventArgs e)
    {
        bindAllCounterAndChart();

    }

    protected void drphealth_TextChanged(object sender, EventArgs e)
    {
        //if (drphealth.SelectedValue == "Healthy")
        //{
        //    flagHealthy = true;
        //    flagunealthy = false;
        //}
        //else
        //{
        //    flagunealthy = true;
        //    flagHealthy = false;
        //}
        bindAllCounterAndChart();

    }

    protected void drpGender_TextChanged(object sender, EventArgs e)
    {
        bindAllCounterAndChart();

    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("UserProfile.aspx?userNm="+ lblUsernm.Text + "&designation=" + lblDesignation.Text));
       
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeDetails.aspx");
    }
}