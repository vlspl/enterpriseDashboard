using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Natification
/// </summary>
public class Notification
{
    public Notification()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void AppNotification(string UserId, string LabID, string Title, string Message, string Type, string Payload, string CreatedBy)
    {
        DataAccessLayer DAL = new DataAccessLayer();
        try
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sUserAppid", UserId),
                new SqlParameter("@sTitle", Title),
                new SqlParameter("@sMessage", Message),
                new SqlParameter("@Type", Type),
                new SqlParameter("@Payload", Payload),
                new SqlParameter("@CreatedBy", CreatedBy),
                new SqlParameter("@returnval", SqlDbType.Int)
            };
            int result = DAL.ExecuteStoredProcedureRetnInt("Sp_AddAppNotificationUpdated", param);
        }
        catch (Exception ex)
        {

        }
    }
}