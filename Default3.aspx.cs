using DataAccessHandler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

public partial class Default3 : System.Web.UI.Page
{
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        //CallApiTestSuggestToPatient();
        SuggestTestToPatient();
    }
    private void CallApiTestSuggestToPatient()
    {
        try
        {
            string gender = string.Empty;


            string _patientId, _labId, _testId, _doctorId, _pkgId;

            _patientId = "743";//db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = '" + drpBranch.Text + "' and Gender = '" + drpGender.Text + "' and orgId = '" + OrgId + "'  and age between '" + txtAge.Text + "' and '" + txtAgeto.Text + "' inner join EmployeeHealth eh on eh.orgId = ed.orgId and eh.pkgId = (select max(pkgId)from EmployeeHealth)");//db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = 'Pune' and Gender = 'Male' and age between 30 and 40 and orgId ='" + OrgId + "'");

            // _testId= db.getData("select testId from PackageTestDetails pkgTest inner join EmployeeHealth eh on pkgTest.pkgId=eh.pkgId where pkgTest.orgId = '" + OrgId + "' and pkgTest.pkgId=(select max(pkgId)from EmployeeHealth)");

            _testId = "496";//db.getData("select distinct stuff(( select ',' +cast (u.testId as char(2)) from PackageTestDetails u where u.testId = testId and pkgId=(select max(pkgId)from EmployeeHealth) order by u.testId for xml path('')),1,1,'') as userlist from PackageTestDetails group by testId");
            _labId = "3";//db.getData("select labId from PackageLabDetails pkgLab  inner join EmployeeHealth eh on pkgLab.pkgId=eh.pkgId where pkgLab.orgId = '" + OrgId + "' and pkgLab.pkgId=(select max(pkgId)from EmployeeHealth)");

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

    public void SuggestTestToPatient()
    {
        dynamic Result = new JObject();
        string _patientId, _labId, _testId, _doctorId, _pkgId;
        string JSONString = string.Empty;
        _patientId = "743";//db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = '" + drpBranch.Text + "' and Gender = '" + drpGender.Text + "' and orgId = '" + OrgId + "'  and age between '" + txtAge.Text + "' and '" + txtAgeto.Text + "' inner join EmployeeHealth eh on eh.orgId = ed.orgId and eh.pkgId = (select max(pkgId)from EmployeeHealth)");//db.getData("select sAppUserId from appUser au inner join EmployeeDetails ed on(au.EmployeeId) = cast(ed.EmployeeId as CHAR(50)) and ed.BatchName = 'Pune' and Gender = 'Male' and age between 30 and 40 and orgId ='" + OrgId + "'");

        //  _testId= db.getData("select testId from PackageTestDetails pkgTest inner join EmployeeHealth eh on pkgTest.pkgId=eh.pkgId where pkgTest.orgId = '" + OrgId + "' and pkgTest.pkgId=(select max(pkgId)from EmployeeHealth)");
        _doctorId = "783";//db.getData("SELECT sAppUserId FROM appUser where sFullName='Enterprise Doctor '");
        _testId = "496"; //db.getData("select distinct stuff(( select ',' +cast (u.testId as char(2)) from PackageTestDetails u where u.testId = testId and pkgId=(select max(pkgId)from EmployeeHealth) order by u.testId for xml path('')),1,1,'') as userlist from PackageTestDetails group by testId");
        _labId = "3";//db.getData("select labId from PackageLabDetails pkgLab  inner join EmployeeHealth eh on pkgLab.pkgId=eh.pkgId where pkgLab.orgId = '" + OrgId + "' and pkgLab.pkgId=(select max(pkgId)from EmployeeHealth)");

        int data = 0;
        SqlParameter[] param = new SqlParameter[]
                {
                            new SqlParameter("@Patientid",_patientId),
                            new SqlParameter("@DoctorId",_doctorId),
                            new SqlParameter("@RecommendedAt",""),
                            new SqlParameter("@LabId",_labId),
                            new SqlParameter("@Returnval",SqlDbType.Int)
                };
        data = DAL.ExecuteStoredProcedureRetnInt("WS_Sp_AddRecommendation", param);
        if (data >= 1)
        {
            string _testIds = "";
            string _testName = "";
            string _testPrice = "";
            int _totalAmount = 0;
            int _testCount = 0;
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

            SqlParameter[] paramName = new SqlParameter[]
                {
                            new SqlParameter("@Patientid",_patientId),
                            new SqlParameter("@DoctorId",_doctorId),
                            new SqlParameter("@LabId",_labId)
                 };
            DataTable dt = DAL.ExecuteStoredProcedureDataTable("Sp_Name", paramName);
            if (dt.Rows.Count > 0)
            {
                string _Msg = "Dr. " + dt.Rows[0]["DoctorName"].ToString() + " has suggested you a test at " + dt.Rows[0]["LabName"].ToString() + ". Kindly book the same at the earliest.";
                FCMPushNotification fcm = new FCMPushNotification();
                empHealthPackage eh = new empHealthPackage();

                //string inputJson = (new JavaScriptSerializer()).Serialize(paramName);
                //dynamic _Result = new JObject();
                //_Result.TotalAmount = _totalAmount;
                //_Result.TestCount = _testCount;
                //_Result.TestPrice = _testPrice.TrimEnd(',');
                //_Result.testId = _testIds.TrimEnd(',');
                //_Result.TestName = _testName.TrimEnd(',');
                //_Result.LabId = _labId;
                //_Result.DoctorId = 0;
                //_Result.RecomndationId = data;
                //_Result.LabLogo = dt.Rows[0]["LabLogo"].ToString();
                //_Result.LabContact = dt.Rows[0]["LabContact"].ToString();
                //_Result.LabAddress = dt.Rows[0]["LabAddress"].ToString();
                //_Result.LabName = dt.Rows[0]["LabName"].ToString();
                //_Result.LabOnlinePayment = dt.Rows[0]["LabOnlinePayment"].ToString();
                // string _payload = JsonConvert.SerializeObject(_Result);


                eh.TotalAmount = _totalAmount;
                eh.TestCount = _testCount;
                eh.TestPrice = _testPrice.TrimEnd(',');
                eh.testId = _testIds.TrimEnd(',');
                eh.TestName = _testName.TrimEnd(',');
                eh.LabId = _labId;
                eh.DoctorId = _doctorId;
                eh.RecomndationId = data;
                eh.LabLogo = dt.Rows[0]["LabLogo"].ToString();
                eh.LabContact = dt.Rows[0]["LabContact"].ToString();
                eh.LabAddress = dt.Rows[0]["LabAddress"].ToString();
                eh.LabName = dt.Rows[0]["LabName"].ToString();
                eh.LabOnlinePayment = dt.Rows[0]["LabOnlinePayment"].ToString();
                string _payload = JsonConvert.SerializeObject(eh);
                string _type = "Test";
                fcm.SendNotificationSuggestTest("Suggest Test", _Msg, dt.Rows[0]["DeviceTokan"].ToString(), _type, _testIds.TrimEnd(','), _labId.ToString(), "743",
                    data.ToString(), _testPrice.TrimEnd(','), _totalAmount, _testName.TrimEnd(','), _testCount, dt.Rows[0]["LabLogo"].ToString(), dt.Rows[0]["LabContact"].ToString(),
                    dt.Rows[0]["LabAddress"].ToString(), dt.Rows[0]["LabName"].ToString(), Convert.ToBoolean(dt.Rows[0]["LabOnlinePayment"].ToString()));
                Notification.AppNotification(_patientId.ToString(), _labId.ToString(), "Suggest Test", _Msg, _type, _payload, "0");
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
                int resVal = DAL.ExecuteStoredProcedureRetnInt("WS_Sp_AddTestRecommendation", param1);
            }
            //  Result.Status = true;  //  Status Key 
            //  Result.Msg = "Test suggested successfully.";
            //JsonConvert.SerializeObject(Result);
        }
    }
}