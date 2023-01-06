using DataAccessHandler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Configuration;

/// <summary>
/// Summary description for WhatsappMsg
/// </summary>
public class WhatsappMsg
{
    DataAccessLayer DAL = new DataAccessLayer();
    string _getSendWhatsappMsgAPIFrmWebConfig = "";
    public WhatsappMsg()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string sendWhatsappMsg(string mobNo, string msgName, string parameters)
    {
        string JSONString = string.Empty; // Create string object to return final output
        dynamic Result = new JObject();  //Create root JSON Object
        string Msg = "";
 	
 // New lines added by Harshada @08-09-22 for resolvinf status 0 issue
     System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        _getSendWhatsappMsgAPIFrmWebConfig = WebConfigurationManager.AppSettings["sendWhatsappMsg"];

        //var client = new RestClient("http://endpoint.visionarylifesciences.in/TestBooking/ManualReportPunching");
        var client = new RestClient(_getSendWhatsappMsgAPIFrmWebConfig);

        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
      //  request.AddHeader("Authorization", "Bearer " + user_token);
        request.AddHeader("Content-Type", "application/json");
        var body = @"{" + "\n" +
        @"  ""mobNo"": ""@mobNo""," + "\n" +
        @"  ""msgName"": ""@msgName""," + "\n" +
        @"  ""parameters"": ""@param""" + "\n" +

        @"}";

        //  DateTime dt = Convert.ToDateTime(System.DateTime.Now.ToString("MM-dd-yyyy"));
        body = body.Replace("@mobNo", mobNo);
        body = body.Replace("@msgName", msgName);
        body = body.Replace("@param", parameters);
       
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        Console.WriteLine(response.Content);
       

         return response.Content;
     

    }

}