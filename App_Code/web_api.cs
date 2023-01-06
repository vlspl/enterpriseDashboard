using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Net.Http;
//using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using DataAccessHandler;
using CrossPlatformAESEncryption.Helper;
using System.Web.Configuration;

namespace WebApplication4
{
    public class web_api
    {
        DataAccessLayer DAL = new DataAccessLayer();
        int get_bookingId = 0, get_bookLabTestId=0;
        string obj_get_Json_data=string.Empty;
        string ReportId, TestId, AnalyteName, SubAnalyteName, Specimen, MethodName, ResultType, ReferenceType, AgeGroup;
        string MaleRange, FemaleRange, Grade, Unit, Interpretation, LowerLimit, UpperLimit, Value, Result, BookingId,labName;
        string _getManualPuchAPIFrmWebConfig, _getReportUpdatedFrmWebConfig;
        public string ManualReportPunching(string user_token,string labNm,string testid)
        {

            _getManualPuchAPIFrmWebConfig = WebConfigurationManager.AppSettings["API_ManualReportPunch"];

            //var client = new RestClient("http://endpoint.visionarylifesciences.in/TestBooking/ManualReportPunching");
            var client = new RestClient(_getManualPuchAPIFrmWebConfig);

            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer "+user_token);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"  ""LabName"": ""@labNm""," + "\n" +
            @"  ""DoctorId"": ""0""," + "\n" +
            @"  ""TestId"": ""@testid""," + "\n" +
            @"  ""TestDate"": ""@date""," + "\n" +
           
            @"}";

          //  DateTime dt = Convert.ToDateTime(System.DateTime.Now.ToString("MM-dd-yyyy"));
            body = body.Replace("@labNm",labNm);
            body = body.Replace("@testid", testid);
            body = body.Replace("@date", System.DateTime.Now.ToString("dd/MM/yyyy")).Replace('-', '/');
          //  body = System.DateTime.Now.ToString("dd/MM/yyyy").Replace('-','/');

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

             // getting booking Id from response
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            dynamic get_Json_data = JObject.Parse(jsonResponse);

            // grab the values and do your assertions :-)
            var bookingId = get_Json_data["BookingId"];
            get_bookingId = Convert.ToInt32(bookingId);

            //getting BookLabTestId
            var bookLabTestId = get_Json_data["ReportId"];
            get_bookLabTestId = Convert.ToInt32(bookLabTestId);

            return response.Content;

            // Response body

            //{ "Status":true,"BookingId":4388,"ReportId":6564,"Msg":"Appointment booked successfully."}

        }
        public string GetReportValuesUpdated(string user_token,string _getTestId)
        {
            _getReportUpdatedFrmWebConfig = WebConfigurationManager.AppSettings["API_GetReportUpdated"];
            //var client = new RestClient("http://endpoint.visionarylifesciences.in/TestBooking/GetReportValuesUpdated?BookingId=" + get_bookingId);

          //  var client = new RestClient(_getReportUpdatedFrmWebConfig + get_bookingId);
            var client = new RestClient(_getReportUpdatedFrmWebConfig + _getTestId);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + user_token);
            request.AddHeader("Content-Type", "application/json");
          
            request.AddParameter("application/json", _getTestId, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.Content != "")
            {
                // getting values from response
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                dynamic get_Json_data = JObject.Parse(jsonResponse);
                obj_get_Json_data = Convert.ToString(get_Json_data);
                gettingDataFromJson();
            }
            return response.Content;
        }

       
        public void gettingDataFromJson()
        {
             
            string json = obj_get_Json_data;//"{'results':[{'SwiftCode':'','City':'','BankName':'Deutsche    Bank','Bankkey':'10020030','Bankcountry':'DE'},{'SwiftCode':'','City':'10891    Berlin','BankName':'Commerzbank Berlin (West)','Bankkey':'10040000','Bankcountry':'DE'}]}";//

            var resultObjects = AllChildren(JObject.Parse(json))
                .First(c => c.Type == JTokenType.Array && c.Path.Contains("AnalyteList"))
                .Children<JObject>();

            foreach (JObject result in resultObjects)
            {
                foreach (JProperty property in result.Properties())
                {
                   
                    AnalyteName = result["AnalyteName"].ToString();
                    SubAnalyteName = result["SubAnalyteName"].ToString();
                    Specimen = result["Specimen"].ToString();
                    MethodName = result["MethodName"].ToString();
                    ResultType = result["ResultType"].ToString();
                    ReferenceType = result["ReferenceType"].ToString();
                    AgeGroup = result["AgeGroup"].ToString();
                    MaleRange = result["MaleRange"].ToString();
                    FemaleRange = result["FemaleRange"].ToString();
                     Grade = result["Grade"].ToString();
                    Unit = result["Unit"].ToString();
                    MaleRange = result["MaleRange"].ToString();
                    FemaleRange = result["FemaleRange"].ToString();
                    Interpretation = result["Interpretation"].ToString();
                    LowerLimit = result["LowerLimit"].ToString();
                    UpperLimit = result["UpperLimit"].ToString();
                   
                }
            }
        }

        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
        int i = 0;
        public string AddReport(string testId,string userId,string value,string getResult)
        {
            //var UserId = User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase)).Value;
            string JSONString = string.Empty; // Create string object to return final output
            dynamic Result = new JObject();  //Create root JSON Object
            string Msg = "";
            try
            {
                i = 0;
                string json = obj_get_Json_data;//"{'results':[{'SwiftCode':'','City':'','BankName':'Deutsche    Bank','Bankkey':'10020030','Bankcountry':'DE'},{'SwiftCode':'','City':'10891    Berlin','BankName':'Commerzbank Berlin (West)','Bankkey':'10040000','Bankcountry':'DE'}]}";//

                var resultObjects = AllChildren(JObject.Parse(json))
                    .First(c => c.Type == JTokenType.Array && c.Path.Contains("AnalyteList"))
                    .Children<JObject>();

              //  value = value + ',' + '-';  //- added for if there is only one analyte
                string[] splitTestColSpec = new string[500];
                string getColSpec = value.ToString().TrimEnd(',');

                splitTestColSpec = getColSpec.Split(',');


                //foreach (string colSpec in splitTestColSpec)
                //{
                //    if (colSpec != "-")
                //    {
                foreach (JObject result in resultObjects)
                {
                    //foreach (JProperty property in result.Properties())
                    //{

                    AnalyteName = result["AnalyteName"].ToString();
                    SubAnalyteName = result["SubAnalyteName"].ToString();
                    Specimen = result["Specimen"].ToString();
                    MethodName = result["MethodName"].ToString();
                    ResultType = result["ResultType"].ToString();
                    ReferenceType = result["ReferenceType"].ToString();
                    AgeGroup = result["AgeGroup"].ToString();
                    MaleRange = result["MaleRange"].ToString();
                    FemaleRange = result["FemaleRange"].ToString();
                    Grade = result["Grade"].ToString();
                    Unit = result["Unit"].ToString();
                    MaleRange = result["MaleRange"].ToString();
                    FemaleRange = result["FemaleRange"].ToString();
                    Interpretation = result["Interpretation"].ToString();
                    LowerLimit = result["LowerLimit"].ToString();
                    UpperLimit = result["UpperLimit"].ToString();

                    Value = splitTestColSpec[i];// value; //colSpec;//
                    i++;
                    Result = getResult;
                            // }

                            //_createReport = _analyteList[i];

                            string _value = Value != "" ? CryptoHelper.Encrypt(Value) : "";
                            string _result = Result != "" ? CryptoHelper.Encrypt(Result) : "";
                            int data = 0;
                            SqlParameter[] param = new SqlParameter[]
                            {
                            new SqlParameter("@sBookLabTestId",get_bookLabTestId),
                            new SqlParameter("@sTestId",testId),
                            new SqlParameter("@sAnalyte",AnalyteName),
                            new SqlParameter("@sSubAnalyte",SubAnalyteName),
                            new SqlParameter("@sSpecimen",Specimen),
                            new SqlParameter("@sMethod",MethodName),
                            new SqlParameter("@sResultType",ResultType),
                            new SqlParameter("@sReferenceType",ReferenceType),
                            new SqlParameter("@sAge",AgeGroup),
                            new SqlParameter("@sMale",MaleRange),
                            new SqlParameter("@sFemale",FemaleRange),
                            new SqlParameter("@sGrade",Grade),
                            new SqlParameter("@sUnits",Unit),
                            new SqlParameter("@sInterpretation",Interpretation),
                            new SqlParameter("@sLowerLimit",LowerLimit),
                            new SqlParameter("@sUpperLimit",UpperLimit),

                            new SqlParameter("@sValue",_value),
                            new SqlParameter("@sResult",_result),
                            new SqlParameter("@returnval",SqlDbType.Int)
                            };
                            data = DAL.ExecuteStoredProcedureRetnInt("Sp_AddTestReport", param);

                            if (data == 1)
                            {
                                SqlParameter[] param1 = new SqlParameter[]
                                    {
                                     new SqlParameter("@ReportCreatedBy",userId),
                                     new SqlParameter("@BookLabTestId",get_bookLabTestId),
                                     new SqlParameter("@Notes",""),
                                     new SqlParameter("@returnval",SqlDbType.Int)
                                    };
                                int retrnval = DAL.ExecuteStoredProcedureRetnInt("WS_Sp_CreateReportUpdated", param1);
                                //  Result.Status = true;  //  Status Key 
                                // Result.Msg = "Report added successfully.";
                                // JSONString = JsonConvert.SerializeObject(Result);
                            }
                            else
                            {
                                Result.Status = false;  //  Status Key 
                                Result.Msg = "Something went wrong,Please try again.";
                                JSONString = JsonConvert.SerializeObject(Result);
                            }


                            SqlParameter[] param2 = new SqlParameter[]
                                          {
                                     new SqlParameter("@EmpId",userId),
                                     new SqlParameter("@ReportPath",""),
                                     new SqlParameter("@Status","In Progress"),
                                     new SqlParameter("@BookingId",get_bookingId.ToString()),//
                                     new SqlParameter("@Returnval",SqlDbType.Int)
                                          };
                            int retrnva1 = DAL.ExecuteStoredProcedureRetnInt("WS_Sp_AddEmployeeReport", param2);
                       }
                //    }
                //}
            }
            catch (Exception ex)
            {
                
             //   Result.Status = false;  //  Status Key
                //Result.Msg = ex;
                //JSONString = JsonConvert.SerializeObject(Result);
                LogError.LoggerCatch(ex);
            }
            return JSONString;
        
        }
    }
}