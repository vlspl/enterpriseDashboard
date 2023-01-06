using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
//using System.DirectoryServices;
using System.Web;



namespace MedicationReminder
{
    class ErrorLog
    {
        string LogDirectory;
        public bool WriteErrorLog(string LogMessage)
        {
            bool Status = false;
            string LogDirectory = "~\\MedicationReminderServiceLog\\"; //ConfigurationManager.AppSettings["LogDirectory"].ToString();
           
            DateTime CurrentDateTime = DateTime.Now;
            string CurrentDateTimeString = CurrentDateTime.ToString();
            CheckCreateLogDirectory(LogDirectory);
            string logLine = BuildLogLine(CurrentDateTime, LogMessage);
            LogDirectory = (LogDirectory + "Log_" + LogFileName(DateTime.Now) + ".txt");

            lock (typeof(ErrorLog))
            {
                StreamWriter oStreamWriter = null;
                try
                {
                    oStreamWriter = new StreamWriter(LogDirectory, true);
                    oStreamWriter.WriteLine(logLine);
                    Status = true;
                }
                catch
                {

                }
                finally
                {
                    if (oStreamWriter != null)
                    {
                        oStreamWriter.Close();
                    }
                }

                //oStreamWriter.WriteLine("Data Time:" + DateTime.Now);

                //oStreamWriter.WriteLine("Exception Name:" + );

                //oStreamWriter.WriteLine("Event Name:" + sEventName);

                //oStreamWriter.WriteLine("Control Name:" + sControlName);

                //oStreamWriter.WriteLine("Error Line No.:" + nErrorLineNo);

                //oStreamWriter.WriteLine("Form Name:" + sFormName);

                //// Close the stream:

                //oStreamWriter.Close();
            }
            return Status;
        }


        private bool CheckCreateLogDirectory(string LogPath)
        {
            bool loggingDirectoryExists = false;
            DirectoryInfo oDirectoryInfo = new DirectoryInfo(LogPath);
            if (oDirectoryInfo.Exists)
            {
                loggingDirectoryExists = true;
            }
            else
            {
                try
                {
                  System.IO.Directory.CreateDirectory(LogPath);
                   
                 
                    loggingDirectoryExists = true;
                }
                catch
                {
                    // Logging failure
                }
            }
            return loggingDirectoryExists;
        }


        private string BuildLogLine(DateTime CurrentDateTime, string LogMessage)
        {
            StringBuilder loglineStringBuilder = new StringBuilder();
            loglineStringBuilder.Append(LogFileEntryDateTime(CurrentDateTime));
            loglineStringBuilder.Append(" \t");
            loglineStringBuilder.Append(LogMessage);
            return loglineStringBuilder.ToString();
        }


        public string LogFileEntryDateTime(DateTime CurrentDateTime)
        {
            return CurrentDateTime.ToString("dd-MM-yyyy HH:mm:ss");
        }


        private string LogFileName(DateTime CurrentDateTime)
        {
            return CurrentDateTime.ToString("dd_MM_yyyy");
        }
        public void deleteOldLogFiles()
        {
            int deleteFileDaysCount = int.Parse(System.Configuration.ConfigurationManager.AppSettings["deleteFileDays"].ToString());

            //delete old file 

            string[] files = Directory.GetFiles(LogDirectory);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-deleteFileDaysCount))
                    fi.Delete();
            }
        }

        
    }
}
