using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for LogError
/// </summary>
public class LogError
{
	public LogError()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void LoggerCatch(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = System.Web.Hosting.HostingEnvironment.MapPath("~/ErrorLog/CatchErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }
   public static void Log(String error)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.Web.Hosting.HostingEnvironment.MapPath("~/ErrorLog/logger.txt"), true))
        {
            file.WriteLine(DateTime.Now + ":\t" + error);
            file.Close();
        }
    }
}