using System;
using System.Data.SqlClient;
using System.Data;
using DataAccessHandler;
/// <summary>
/// Summary description for ClsAppNotification
/// </summary>
public class ClsAppNotification
{
	public ClsAppNotification()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int AppNotification(string UserId, string Title, string Message, string Type, string Payload, string CreatedBy)
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
            return result;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}