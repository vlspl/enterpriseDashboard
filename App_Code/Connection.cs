using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.UI;

public class Connection
{
    public void getConnect()
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        conn.Open();
    }
}