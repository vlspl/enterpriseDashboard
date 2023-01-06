using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessHandler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class EmployeeHealthPackage : System.Web.UI.Page
{
    public int EmpChieldID, testId, labId, OrgId;
    public string labCode, testCode, userNm, branchId;
    HealthDal objdal = new HealthDal();
    DataTable dtFillData;
    DBClass db = new DBClass();
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        branchId = Session["BranchId"].ToString();
        OrgId = int.Parse(Session["OrgId"].ToString());
        // OrgId = int.Parse(db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
        if (userNm == "")
            Response.Redirect("Login.aspx");
        else
        {
            if (!this.IsPostBack)
            {

                objdal.bindDrp("select deptName from AddDepartment where orgId='" + OrgId + "' order by deptName", drpDept, "deptName", "deptName");//
                drpDept.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"

                objdal.bindDrp("select BranchName from BranchMaster where Org_Id='" + OrgId + "' order by BranchName", drpBranch, "branchName", "branchName");
                drpBranch.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"


                //objdal.bindDrp("select sFullName from appUser ", drpEmp, "sFullName", "sFullName");
                //drpEmp.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"

                objdal.bindDrp("SELECT labMaster.sLabName FROM OrganizationTieupLab INNER JOIN  OrganizationMaster ON OrganizationTieupLab.Org_ID = OrganizationMaster.ID INNER JOIN labMaster ON OrganizationTieupLab.Lab_Id = labMaster.sLabId  where OrganizationMaster.ID = '" + OrgId + "' order by sLabName", drpLab, "sLabName", "sLabName");
                drpLab.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"

                //objdal.bindDrp("select Name from OrganizationMaster ", drpOrganization, "Name", "Name");
                //drpOrganization.Items.Insert(0, new ListItem("Select", "Select")); //updated code to set first value "All"
                empCount();
                if (Request.QueryString["pkgId"] != null)
                {
                    dtFillData = objdal.fillData(Request.QueryString["pkgId"]);
                    foreach (DataRow row in dtFillData.Rows)
                    {
                        // basic Info
                        txtPackage.Text = row["packageName"].ToString();
                        drpDept.Text = row["department"].ToString();
                        drpBranch.Text = row["branch"].ToString();
                        string age = row["age"].ToString();

                        string[] ageFrm = age.Split('-');
                        txtAge.Text = ageFrm[0];
                        txtAgeto.Text = ageFrm[1];

                        drpGender.Text = row["gender"].ToString();
                        //drpTest.Text = row["test"].ToString();
                        drpTest.Text = row["status"].ToString();


                    }
                    BtnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    txtPackage.ReadOnly = true;
                    drpDept.Enabled = false;
                    drpBranch.Enabled = false;
                    txtAge.ReadOnly = true;
                    txtAgeto.ReadOnly = true;
                    drpGender.Enabled = false;
                    drpTest.Enabled = false;
                    drpLab.Enabled = false;
                    GridView1.Enabled = false;
                    GridView2.Enabled = false;
                }

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("testId"), new DataColumn("testName"), new DataColumn("testCode"), new DataColumn("orgId") });
                ViewState["test"] = dt;

                if (Request.QueryString["pkgId"] != null)
                {

                    dt = objdal.fillTest(Request.QueryString["pkgId"]);
                    this.BindGrid();

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                DataTable dtLab = new DataTable();
                dtLab.Columns.AddRange(new DataColumn[4] { new DataColumn("labId"), new DataColumn("labName"), new DataColumn("labCode"), new DataColumn("orgId") });
                ViewState["Lab"] = dtLab;

                if (Request.QueryString["pkgId"] != null)
                {

                    dt = objdal.fillLab(Request.QueryString["pkgId"]);
                    this.BindGrid_Lab();

                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }

            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        SaveData();

        saveTest();
        saveLab();
        //call api here for assign package to user
        SuggestTestToPatient();
        //  CallApiTestSuggestToPatient();
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
        Response.Redirect("EmployeeHealthDetails.aspx");
    }
    public void empCount()
    {
        string qry = "Select count(*) from EmployeeDetails where orgId='" + OrgId + "' and ";
        int flag = 0;

        if (drpBranch.SelectedValue != "All")
        {
            if (flag != 0)
                qry += " and ";

            qry += "BatchName='" + drpBranch.Text + "'";

            flag++;
        }
        if (drpDept.SelectedValue != "All")
        {
            if (flag != 0)
                qry += " and ";
            qry += "Dept='" + drpDept.Text + "'";

            flag++;
        }
        if (drpGender.SelectedValue != "All")
        {
            if (flag != 0)
                qry += " and ";
            qry += "Gender='" + drpGender.Text + "'";

            flag++;
        }
        if (txtAge.Text != "" && txtAgeto.Text != "")
        {
            if (flag != 0)
                qry += " and ";
            qry += "Age between '" + txtAge.Text + "' and '" + txtAgeto.Text + "'";

            flag++;
        }
        if (flag == 0)
            qry = "Select count(*) from EmployeeDetails where orgId='" + OrgId + "'";
        lblEmCount.Text = db.getData(qry);

    }
    protected void drpBranch_TextChanged(object sender, EventArgs e)
    {
        empCount();

    }
    protected void drpDept_TextChanged(object sender, EventArgs e)
    {
        empCount();

    }
    protected void drpGender_TextChanged(object sender, EventArgs e)
    {
        empCount();

    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {
        empCount();

    }
    protected void txtAgeto_TextChanged(object sender, EventArgs e)
    {
        empCount();

    }
    public void SuggestTestToPatient()
    {
        dynamic Result = new JObject();
        string _patientId, _labId, _testId, _doctorId, _pkgId;
        string JSONString = string.Empty;
        if (drpGender.Text != "All")
            _patientId = db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = '" + drpBranch.Text + "' and Gender = '" + drpGender.Text + "' and orgId = '" + OrgId + "'  and age between '" + txtAge.Text + "' and '" + txtAgeto.Text + "' inner join EmployeeHealth eh on eh.orgId = ed.orgId and eh.pkgId = (select max(pkgId)from EmployeeHealth)");//db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = 'Pune' and Gender = 'Male' and age between 30 and 40 and orgId ='" + OrgId + "'");
        else
            _patientId = db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = '" + drpBranch.Text + "'  and orgId = '" + OrgId + "'  and age between '" + txtAge.Text + "' and '" + txtAgeto.Text + "' inner join EmployeeHealth eh on eh.orgId = ed.orgId and eh.pkgId = (select max(pkgId)from EmployeeHealth)");//db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = 'Pune' and Gender = 'Male' and age between 30 and 40 and orgId ='" + OrgId + "'");

        //  _testId= db.getData("select testId from PackageTestDetails pkgTest inner join EmployeeHealth eh on pkgTest.pkgId=eh.pkgId where pkgTest.orgId = '" + OrgId + "' and pkgTest.pkgId=(select max(pkgId)from EmployeeHealth)");
        _doctorId = db.getData("SELECT sAppUserId FROM appUser where sFullName='Enterprise Doctor '");
        _testId = db.getData("select distinct stuff(( select ',' +cast (u.testId as char(10)) from PackageTestDetails u where u.testId = testId and pkgId=(select max(pkgId)from EmployeeHealth) order by u.testId for xml path('')),1,1,'') as userlist from PackageTestDetails group by testId");
        _labId = db.getData("select labId from PackageLabDetails pkgLab  inner join EmployeeHealth eh on pkgLab.pkgId=eh.pkgId where pkgLab.orgId = '" + OrgId + "' and pkgLab.pkgId=(select max(pkgId)from EmployeeHealth)");

        int data = 0;
        SqlParameter[] param = new SqlParameter[]
                {
                            new SqlParameter("@Patientid",_patientId),
                            new SqlParameter("@DoctorId",_doctorId),
                            new SqlParameter("@RecommendedAt",""),
                            new SqlParameter("@LabId",_labId),
                            new SqlParameter("@Returnval",SqlDbType.Int)
                };
        data = DAL.ExecuteStoredProcedureRetnInt("WS_Sp_AddRecommendation", param); //insrt into recommdation
        if (data >= 1)
        {
            string _testIds = "";
            string _testName = "";
            string _testPrice = "";
            int _totalAmount = 0;
            int _testCount = 0;
            if (testId != '*')
            {
                SqlParameter[] paramTest = new SqlParameter[]
                {
                          new SqlParameter("@TestList",_testId),
                          new SqlParameter("@LabId",_labId)
                };
                DataTable dtTest = DAL.ExecuteStoredProcedureDataTable("WS_Sp_GetTestPricebyLabIdAndTestlist", paramTest);
                if (dtTest.Rows.Count > 0)
                {
                    foreach (DataRow row in dtTest.Rows)
                    {
                        _testName += row["sTestName"] + ",";
                        _testIds += row["sTestId"] + ",";
                        _testPrice += row["sPrice"] + ",";
                        _totalAmount += Convert.ToInt32(row["sPrice"] != "" ? row["sPrice"] : "0");
                        _testCount = _testCount + 1;
                    }
                }



                _testId = _testId.TrimEnd(',');
                string[] splitTest = _testId.Split(',');

                foreach (string TestId in splitTest)
                {
                    SqlParameter[] param1 = new SqlParameter[]
                             {
                                new SqlParameter("@RecommendationId",data),
                                new SqlParameter("@TestId",TestId),
                                new SqlParameter("@LabId",_labId),
                                new SqlParameter("@Returnval",SqlDbType.Int)
                    };
                    int resVal = DAL.ExecuteStoredProcedureRetnInt("WS_Sp_AddTestRecommendation", param1);  // insert into testRecoomended
                                                                                                            
                    //insert into testReportValues table
                         //get values related to test
                    SqlParameter[] paramTestvalues = new SqlParameter[]
                       {
                          new SqlParameter("@testId",TestId),
                          new SqlParameter("@LabId",_labId)
                       };
                    DataTable dtTestvalues = DAL.ExecuteStoredProcedureDataTable("Sp_GetTestValues", paramTestvalues);
                    db.insert("insert into tempDebug values('" + dtTestvalues.Rows.Count + "')");

                    if (dtTestvalues.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtTestvalues.Rows)
                        {

                            SqlParameter[] paramtestDtl = new SqlParameter[]
                         {
                        new SqlParameter("@sBookLabTestId",0),
                        new SqlParameter("@sTestId",TestId),
                        new SqlParameter("@sAnalyte",row["sAnalyteName"].ToString()),
                        new SqlParameter("@sSubAnalyte",row["sSubAnalyteName"].ToString()),
                        new SqlParameter("@sSpecimen",row["sSampleType"].ToString()),
                        new SqlParameter("@sMethod",row["sMethodName"].ToString()),
                        new SqlParameter("@sResultType",row["sResultType"].ToString()),
                        new SqlParameter("@sReferenceType",row["ReferenceType"].ToString()),
                        new SqlParameter("@sAge",row[""].ToString()), //MaleFromAge
                        new SqlParameter("@sMale",row["MaleRange"].ToString()),
                        new SqlParameter("@sFemale",row["FemaleRange"].ToString()),
                        new SqlParameter("@sGrade",row["Grade"].ToString()),
                        new SqlParameter("@sUnits",row["Unit"].ToString()),
                        new SqlParameter("@sInterpretation",row["Interpretation"].ToString()),
                        new SqlParameter("@sLowerLimit",row["LowerLimit"].ToString()),
                        new SqlParameter("@sUpperLimit",row["UpperLimit"].ToString()),
                        new SqlParameter("@sValue","0"),
                        new SqlParameter("@sResult","0"),
                        new SqlParameter("@returnval",SqlDbType.Int)
                         };
                            int result = DAL.ExecuteStoredProcedureRetnInt("Sp_AddTestReport", paramtestDtl);
                            db.insert("insert into tempDebug values('" + result + "')");

                        }
                    }
                }

            }
            // insert into medicationMaster and details
            db.insert("insert into MedicationReminderMaster (UserId,MedName,MedFor,MedSdate,MedDoseDuration,DoseInterval)values('" + _patientId + "','" + _doctorId + ',' + _labId + "','Test Suggest','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "','0','0')");
            //  int masterId = int.Parse(db.getData("select max(RemidermId) from MedicationReminderMaster").ToString());

            db.insert("insert into MedicationReminderDetails values((select max(RemidermId) from MedicationReminderMaster),'','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "','" + System.DateTime.Now.ToString("hh:mm tt") + "','','N')");


     
        }
    }
        private void CallApiTestSuggestToPatient()
        {
            try
            {
                string gender = string.Empty;


                string _patientId, _labId, _testId, _doctorId, _pkgId;

                _patientId = db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = '" + drpBranch.Text + "' and Gender = '" + drpGender.Text + "' and orgId = '" + OrgId + "'  and age between '" + txtAge.Text + "' and '" + txtAgeto.Text + "' inner join EmployeeHealth eh on eh.orgId = ed.orgId and eh.pkgId = (select max(pkgId)from EmployeeHealth)");//db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = 'Pune' and Gender = 'Male' and age between 30 and 40 and orgId ='" + OrgId + "'");

                // _testId= db.getData("select testId from PackageTestDetails pkgTest inner join EmployeeHealth eh on pkgTest.pkgId=eh.pkgId where pkgTest.orgId = '" + OrgId + "' and pkgTest.pkgId=(select max(pkgId)from EmployeeHealth)");

                _testId = db.getData("select distinct stuff(( select ',' +cast (u.testId as char(2)) from PackageTestDetails u where u.testId = testId and pkgId=(select max(pkgId)from EmployeeHealth) order by u.testId for xml path('')),1,1,'') as userlist from PackageTestDetails group by testId");
                _labId = db.getData("select labId from PackageLabDetails pkgLab  inner join EmployeeHealth eh on pkgLab.pkgId=eh.pkgId where pkgLab.orgId = '" + OrgId + "' and pkgLab.pkgId=(select max(pkgId)from EmployeeHealth)");

                string apiUrl = "http://endpoint.visionarylifescience.com/Doctor";
                object input = new
                {
                    _patientId,
                    _labId,
                    _testId,
                    _doctorId = 0,


                };
                string inputJson = (new JavaScriptSerializer()).Serialize(input);
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string jsonUserMessage = client.UploadString(apiUrl + "/TestSuggestToPatient", inputJson);

                var parts = jsonUserMessage.Split(new string[] { "}{" }, StringSplitOptions.RemoveEmptyEntries)
                                                               .Select(s => s.Trim('{', '}'))
                                                               .Select(s => s.Split(':'))
                                                               .ToDictionary(s => s[0], s => s[1]);




                string key = parts.Keys.FirstOrDefault();
                string values = parts.Values.FirstOrDefault();



                const string oneitem = "((?<item>)|\"(?<item>.*?)\"|(?<item>[^\"][^,]*))";
                CaptureCollection captures = Regex.Match(values, "^" + oneitem + "(?:," + oneitem + ")*$").Groups["item"].Captures;
                IEnumerable<string> split = from Capture capture in captures
                                            select capture.Value;


                if (split != null)
                {
                    foreach (var element in split)
                    {
                        if (element == "false")
                        {

                            dynamic data = JObject.Parse(jsonUserMessage);
                            string UserMessage = data.Msg;
                            CustomValidator val = new CustomValidator();
                            val.ErrorMessage = UserMessage;
                            val.IsValid = false;
                            val.ValidationGroup = "RegisterCheck";
                            this.Page.Validators.Add(val);
                            break;


                        }
                        if (element != "false")
                        {


                            dynamic data = JObject.Parse(jsonUserMessage);
                            string UserMessage = data.Msg;

                            CustomValidator val = new CustomValidator();
                            val.ErrorMessage = UserMessage;

                            val.IsValid = true;
                            val.ValidationGroup = "RegisterCheck";
                            this.Page.Validators.Add(val);


                            break;
                        }

                    }


                }

            }

            catch (Exception ex)
            {

                throw ex;
            }


        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            //HealthDal empHealth = new HealthDal();
            //empHealth.DeleteHealthDetails(int.Parse(Request.QueryString["healthId"]));

            //SaveData();

            //BtnSave.Visible = true;
            //btnUpdate.Visible = false;
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Updated Successfully!\");", true);
            Response.Redirect("EmployeeHealthDetails.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            //HealthDal empHealth = new HealthDal();
            //empHealth.DeleteHealthDetails(int.Parse(Request.QueryString["healthId"]));

            //SaveData();

            BtnSave.Visible = true;
            btnDelete.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Deleted Successfully!\");", true);
            Response.Redirect("EmployeeHealthDetails.aspx");
        }
        private void SaveData()
        {
            string Output = string.Empty;


            HealthBO objempHealthBo = new HealthBO();

            objempHealthBo.PackageName = txtPackage.Text;
            objempHealthBo.DeptName = drpDept.Text;
            objempHealthBo.Branch = drpBranch.Text;
            objempHealthBo.Age = txtAge.Text + " - " + txtAgeto.Text;
            objempHealthBo.CreatedDate = System.DateTime.Now.ToString("MM/dd/yyyy");
            //objempBo.SName = txtLName.Text;
            objempHealthBo.Gender = drpGender.Text;
            objempHealthBo.Test = "";
            objempHealthBo.Status = "Active";
            objempHealthBo.organization = "";// drpOrganization.Text;

            //OrgId= objdal.getOrgId();        //OrgId= objdal.getOrgId();
            EmpChieldID = objdal.AddHealthDetails(objempHealthBo, OrgId);


        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[1].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt;
            int index = Convert.ToInt32(e.RowIndex);

            dt = ViewState["test"] as DataTable;

            dt.Rows[index].Delete();
            ViewState["dt"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //BindGrid();
        }
        protected void OnRowDeletingLab(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt;
            int index = Convert.ToInt32(e.RowIndex);

            dt = ViewState["Lab"] as DataTable;

            dt.Rows[index].Delete();
            ViewState["dt"] = dt;
            GridView2.DataSource = dt;
            GridView2.DataBind();
            Button1.Enabled = true;
            lblWarning.Visible = false;
            //BindGrid();
        }

        protected void BindGrid()
        {

            GridView1.DataSource = (DataTable)ViewState["test"];
            GridView1.DataBind();

        }


        protected void BindGrid_Lab()
        {

            GridView2.DataSource = (DataTable)ViewState["Lab"];
            GridView2.DataBind();

        }

        private void saveTest()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("_testId", typeof(int)), new DataColumn("testName", typeof(string)), new DataColumn("testCode", typeof(string)), new DataColumn("orgId", typeof(int)) });
            foreach (GridViewRow row in GridView1.Rows)
            {


                dt.Rows.Clear();
                // string EmpChieldID1 =int.Parse(txtEmpid.Text).ToString();
                string testName = row.Cells[1].Text;

                string testCode = row.Cells[2].Text;
                int orgId = OrgId;
                //string University = row.Cells[3].Text;

                dt.Rows.Add(EmpChieldID, testName, testCode, orgId);
                HealthDal objdal = new HealthDal();
                DataTable j = objdal.AddTestDetails(dt, EmpChieldID);

            }
        }

        private void saveLab()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("_labId", typeof(int)), new DataColumn("labName", typeof(string)), new DataColumn("labCode", typeof(string)), new DataColumn("orgId", typeof(int)) });
            foreach (GridViewRow row in GridView2.Rows)
            {
                dt.Rows.Clear();
                // string EmpChieldID1 =int.Parse(txtEmpid.Text).ToString();
                string labName = row.Cells[1].Text;
                string labCode = row.Cells[2].Text;
                // string orgId = row.Cells[3].Text;
                //string Grade = row.Cells[2].Text;
                //string University = row.Cells[3].Text;

                dt.Rows.Add(EmpChieldID, labName, labCode, OrgId);
                HealthDal objdal = new HealthDal();
                DataTable j = objdal.AddLabDetails(dt, EmpChieldID);

            }
        }
        protected void InsertLab(object sender, EventArgs e)
        {

            DataTable dtLab;
            //dt.Rows.Clear();
            if (Request.QueryString["pkgId"] != null)
            {
                dtLab = objdal.fillLab(Request.QueryString["pkgId"]);
                this.BindGrid_Lab();
            }
            else
                dtLab = (DataTable)ViewState["Lab"];

            //OrgId = objdal.getOrgId(drpOrganization.Text);
            labCode = objdal.getLabCode(drpLab.Text);
            dtLab.Rows.Add("", drpLab.SelectedValue.Trim(), labCode, OrgId);
            ViewState["Lab"] = dtLab;
            this.BindGrid_Lab();
            //drpCity.Text ="";
            //drpCountry.Text = "";
            Button1.Enabled = false;
            lblWarning.Visible = true;
            lblWarning.Text = "You can Add Only One Lab";
        }
        protected void Insert(object sender, EventArgs e)
        {

            DataTable dt;
            //dt.Rows.Clear();
            if (Request.QueryString["pkgId"] != null)
            {
                dt = objdal.fillTest(Request.QueryString["pkgId"]);
                this.BindGrid();
            }
            else
                dt = (DataTable)ViewState["test"];

            //OrgId = objdal.getOrgId(drpOrganization.Text);
            testCode = objdal.getTestCode(drpTest.Text);
            //if (GridView1.Rows.Count >= 1)
            //{
            // foreach (GridViewRow row in GridView1.Rows)
            bool entryFound = false;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                if (GridView1.Rows[i].Cells[1].Text == drpTest.Text)
                {
                    lblWarningTest.Visible = true;
                    lblWarningTest.Text = "Test Already Exists.";
                    entryFound = true;
                    break;
                }

            }
            if (!entryFound)
            {
                lblWarningTest.Visible = false;
                dt.Rows.Add("", drpTest.SelectedValue.Trim(), testCode, OrgId);
                ViewState["test"] = dt;
                this.BindGrid();
            }
            //}
            //else
            //{
            //    lblWarningTest.Visible = false;
            //    dt.Rows.Add("", drpTest.SelectedValue.Trim(), testCode, OrgId);
            //    ViewState["test"] = dt;
            //    this.BindGrid();
            //}
            //drpCity.Text ="";
            //drpCountry.Text = "";


        }

    protected void drpLab_SelectedIndexChanged(object sender, EventArgs e)
    {
        objdal.bindDrp("SELECT distinct test.sTestName FROM  test INNER JOIN   testLab ON test.sTestId = testLab.sTestId INNER JOIN  labMaster ON testLab.sLabId = labMaster.sLabId  WHERE        (labMaster.sLabName = '" + drpLab.Text + "') order by sTestName asc", drpTest, "sTestName", "sTestName");
        drpTest.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"

    }
}
