using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
/// Summary description for DBClass
/// </summary>
public class DBClass
{
	SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

	public DBClass()
	{
      
    }
    public void cnopen()
    {
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        cn.Open();
    }

    public void cnclose()
    {
        if (cn.State != ConnectionState.Closed)
        {
            cn.Close();
        }
    }

    public DataTable bindDataset(string qry)
    {
        cnopen();
        SqlCommand cmd = new SqlCommand(qry, cn);
        SqlDataAdapter sd = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        DataTable dt = new DataTable();
        sd.Fill(dt);
        cn.Close();
        return dt;
    }
    public int getCount(string qry)
    {
        int count = 0;
        //
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(qry, cn);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
           // if (rd.Read())
                count = int.Parse(rd[0].ToString());
            cn.Close();
            return count;
        }
        catch(Exception ex)
        {
            return 0;
        }
       
    }
    public string getData(string qry)
    {
        string getData = "0";
        //

        cn.Open();
        SqlCommand cmd = new SqlCommand(qry, cn);
        SqlDataReader rd = cmd.ExecuteReader();
        rd.Read();

        getData = (rd[0].ToString());
        cn.Close();
        cmd.Dispose();
        return getData;
    }
    public void insert(string qry)
    {
       
        cn.Open();
        SqlCommand cmd = new SqlCommand(qry, cn);
        //SqlDataReader rd = cmd.ExecuteReader();
        cmd.ExecuteNonQuery();
      
        cn.Close();
      
    }
    public  DataTable GetData(string query)
    {

        cn.Open();
        SqlCommand cmd = new SqlCommand(query);
            
                DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(query, cn);
                    sda.Fill(dt);
        cn.Close();   
                return dt;
            
       
    }

    public void bindDrp(string qry, DropDownList drp, string name, string value)
    {
        //try
        //{
        cn.Close();
            SqlDataAdapter adpt = new SqlDataAdapter(qry, cn);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            drp.DataSource = dt;
            drp.DataBind();
            drp.DataTextField = name;
            drp.DataValueField = value;
            drp.DataBind();
            cn.Close();
        //}

        //catch (Exception ex)
        //{
        //    ex.ToString();
        //}
        //finally
        //{
        //    cn.Close();
        //    cn.Dispose();//Do not call this if you want to reuse the connection
        //}

    }
    public void reset(Page p)
    {
        foreach (Control txt in p.Controls)
        {

            // MessageBox.Show(txt.Name.ToString());
            if (txt is TextBox)
            {
                TextBox txtbox = (TextBox)txt;
                txtbox.Text = "";
            }

           

        }
    }
    public bool chkDBValue(string query )
    {
        cn.Open();
        SqlCommand cmd = new SqlCommand(query,cn);

        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.HasRows)
            return true;
        else
            return false;
        cn.Close();
       
    }
}