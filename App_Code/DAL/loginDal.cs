using CrossPlatformAESEncryption.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for loginDal
/// </summary>
public class loginDal
{
    string _userNm, _password;
    public loginDal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

    public int login(string userName,string password)
    {
         _userNm=  CryptoHelper.Encrypt(userName);

        _password = CryptoHelper.Encrypt(password);

        SqlCommand cmd = new SqlCommand("Sp_LoginDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@userName", _userNm);
        cmd.Parameters.AddWithValue("@password", _password);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
       
    }
}