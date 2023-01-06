using CrossPlatformAESEncryption.Helper;
using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validation;
using System.Data.OleDb;
using System.Configuration;
using System.IO;

public partial class Default4 : System.Web.UI.Page
{
    ClsAddEmployee ObjAddEmp = new ClsAddEmployee();
    DataAccessLayer DAL = new DataAccessLayer();
    InputValidation Ival = new InputValidation();
    string gender, userNm;
    OleDbConnection Econ;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Upload(object sender, EventArgs e)
    {
        //Upload and save the file.
        string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(file_upload.PostedFile.FileName);
        file_upload.SaveAs(csvPath);

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id", typeof(int)),
            new DataColumn("Name", typeof(string))
           });

        //dt.Columns.AddRange(new DataColumn[21] { new DataColumn("EmployeeId", typeof(int)),
        //    new DataColumn("FName", typeof(string)),
        //    new DataColumn("AtdharName",typeof(string)),
        // new DataColumn("DOB", typeof(string)),
        //    new DataColumn("Age",typeof(string)),
        //     new DataColumn("Gender", typeof(string)),
        //    new DataColumn("PanNo",typeof(string)),
        //     new DataColumn("Email", typeof(string)),
        //    new DataColumn("ContactNo",typeof(string)),
        //     new DataColumn("CAdress", typeof(string)),
        //    new DataColumn("State",typeof(string)),
        //       new DataColumn("City", typeof(string)),
        //    new DataColumn("Pincode",typeof(string)),
        //     new DataColumn("EmpId", typeof(string)),
        //    new DataColumn("Dsgn",typeof(string)),
        //     new DataColumn("Dept", typeof(string)),
        //    new DataColumn("BatchName",typeof(string)),
        //     new DataColumn("EmpStatus",typeof(string)),
        //     new DataColumn("Bgroup", typeof(string)),
        //    new DataColumn("HealthID",typeof(string)),
        //       new DataColumn("OrgId",typeof(int)),

        //});


        string csvData = File.ReadAllText(csvPath);
        foreach (string row in csvData.Split('\n'))
        {
            if (!string.IsNullOrEmpty(row))
            {
                dt.Rows.Add();
                int i = 0;
                foreach (string cell in row.Split(','))
                {
                    dt.Rows[dt.Rows.Count - 1][i] = cell;
                    i++;
                }
            }
        }

        string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(consString))
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set the database table name.
                sqlBulkCopy.DestinationTableName = "dbo.EmployeeDetails";
                con.Open();
                sqlBulkCopy.WriteToServer(dt);
                con.Close();
            }
        }
    }
    private void ExcelConn(string FilePath)
    {

        //string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.10.0;Data Source={0};Extended Properties=""Excel 10.0 Xml;HDR=YES;""", FilePath);//
        // cn = new SqlConnection(constr);

        string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0 Xml;HDR=YES;""", FilePath);
        Econ = new OleDbConnection(constr);

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {

        string Msg = "";
        //  btnUpload.Enabled = false;
        if (file_upload.PostedFile != null)
        {
            try
            {
                string filename = file_upload.FileName;
                if (file_upload.HasFile)
                {
                    String fileextension = System.IO.Path.GetExtension(file_upload.FileName);
                    if (fileextension.ToLower() != ".xls" && fileextension.ToLower() != ".xlsx")
                    {
                        lblError.Text = "Please Upload only .xls,.xlsx files only. ";
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        string path = string.Concat(Server.MapPath("~/" + file_upload.FileName));
                        file_upload.SaveAs(path);

                        // Connection String to Excel Workbook  
                        // string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                        string constr  = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", path);
                        Econ = new OleDbConnection(constr);
                        // ExcelConn(path);

                        string Query = string.Format("Select * FROM [{0}]", "Sheet1$");
                        OleDbCommand Ecom = new OleDbCommand(Query, Econ);
                        Econ.Open();

                        DataSet ds = new DataSet();
                        OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
                        Econ.Close();
                        oda.Fill(ds);
                        DataTable Exceldt = ds.Tables[0];
                        int rowCount = Convert.ToInt32(Exceldt.Rows.Count);
                        if (Exceldt.Rows.Count > 0)
                        {
                            int count = 1;
                            foreach (DataRow row in Exceldt.Rows)
                            {
                                string Password = CreateRandomPassword();
                                //if (Ival.IsValidEmailAddress(row["Email Id"].ToString()))
                                //{
                                //    ClsEmailTemplates emailTemp = new ClsEmailTemplates();
                                //    string mailSent = emailTemp.sendmail(row["Email Id"].ToString(), Password, row["Full Name"].ToString(), row["Mobile No"].ToString());
                                //}
                                string _password = CryptoHelper.Encrypt(Password);
                                string _EmailId = CryptoHelper.Encrypt(row["Email Id"].ToString());
                                string _Mobile = CryptoHelper.Encrypt(row["Mobile No"].ToString());
                                string _HealthId = CryptoHelper.Encrypt(row["Health ID"].ToString());
                                string _Aadhar = CryptoHelper.Encrypt(row["Aadhar Number"].ToString());

                                SqlParameter[] paramEmp = new SqlParameter[]
                               {
                                     new SqlParameter("@FName",row["Full Name"].ToString()),
                                     new SqlParameter("@MName",""),
                                     new SqlParameter("@LName",""),
                                     new SqlParameter("@SName",""),
                                     new SqlParameter("@AtdharName",row["Aadhar Number"].ToString()),
                                     new SqlParameter("@DOB",row["Date of Birth"].ToString()),
                                     new SqlParameter("@Age",row["Age"].ToString()),
                                     new SqlParameter("@Gender",row["Gender"].ToString()),
                                     new SqlParameter("@Pphoto",""),
                                     new SqlParameter("@PanNo",row["Pan Number"].ToString()),
                                     new SqlParameter("@Email",row["Email Id"].ToString()),
                                     new SqlParameter("@ContactNo",row["Mobile No"].ToString()),
                                     new SqlParameter("@AltContact",row["Mobile No"].ToString()),
                                     new SqlParameter("@CAddress",row["Address"].ToString()),
                                     new SqlParameter("@PAddress",row["Address"].ToString()),
                                     new SqlParameter("@State",row["State"].ToString()),

                                     new SqlParameter("@City",row["City"].ToString()),
                                     new SqlParameter("@Pincode",row["PinCode"].ToString()),


                                     new SqlParameter("@EmpId",row["Employee Id"].ToString()),
                                     new SqlParameter("@Dsgn",row["Designation"].ToString()),

                                     new SqlParameter("@Dept",row["Department"].ToString()),
                                     new SqlParameter("@BatchName",row["Branch"].ToString()),
                                     new SqlParameter("@DOJ",""),
                                     new SqlParameter("@EmpStatus",row["Employee Status"].ToString()),
                                     new SqlParameter("@Bgroup",row["Blood Group"].ToString()),
                                     new SqlParameter("@HealthID",row["Health ID"].ToString()),

                                     new SqlParameter("@Qualification",""),
                                     new SqlParameter("@Pyear",""),
                                     new SqlParameter("@Grade",""),
                                     new SqlParameter("@University",""),
                                     new SqlParameter("@CompName",""),
                                     new SqlParameter("@Period",""),

                                     new SqlParameter("@frm",""),
                                     new SqlParameter("@tto",""),
                                     new SqlParameter("@dsgnn",""),
                                     new SqlParameter("@Documents",""),
                                     new SqlParameter("@orgId","2"),

                                     new SqlParameter("@Returnval",SqlDbType.NVarChar,50)
                               };
                                string ResultEmp = DAL.ExecuteStoredProcedureRetnString("Sp_AddEmployeeDetails", paramEmp);

                                string[] getData = ResultEmp.Split('/');
                                row["Status"] = getData[0];
                                row["Remark"] = getData[1];
                                if (getData[0] == "Success")
                                {
                                    SqlParameter[] param = new SqlParameter[]
                                     {
                                     new SqlParameter("@sFullName",row["Full Name"].ToString()),
                                     new SqlParameter("@sMobile",_Mobile),
                                     new SqlParameter("@sEmailId",_EmailId),
                                     new SqlParameter("@sGender",row["Gender"].ToString()),
                                     new SqlParameter("@sBirthDate",row["Date of Birth"].ToString()),
                                     new SqlParameter("@sAddress",row["Address"].ToString()),
                                     new SqlParameter("@sRole","Employee"),
                                     new SqlParameter("@sCountry","India"),
                                     new SqlParameter("@sState",row["State"].ToString()),
                                     new SqlParameter("@sCity",row["City"].ToString()),
                                     new SqlParameter("@sPincode",row["PinCode"].ToString()),
                                     new SqlParameter("@EmployeeId",row["Employee Id"].ToString()),
                                     new SqlParameter("@AadharCard",_Aadhar),
                                     new SqlParameter("@HealthId",_HealthId),
                                     new SqlParameter("@Department",row["Department"].ToString()),
                                     new SqlParameter("@Returnval",SqlDbType.Int)
                                     };
                                    int Result = DAL.ExecuteStoredProcedureRetnInt("Sp_AddEmployeeUpdated", param);

                                    if (Result >= 1)
                                    {
                                        SqlParameter[] param1 = new SqlParameter[]
                                             {
                                            new SqlParameter("@EmpId",Result),
                                            new SqlParameter("@OrgId",Request.Cookies["OrgId"].Value.ToString()),
                                            new SqlParameter("@BranchId",Request.Cookies["BranchId"].Value.ToString()),
                                            new SqlParameter("@CreatedBy",Request.Cookies["HRId"].Value.ToString()),
                                            new SqlParameter("@Returnval",SqlDbType.Int)
                                             };
                                        int ResultVal = DAL.ExecuteStoredProcedureRetnInt("Sp_AddOrgEmployee", param1);
                                        if (ResultVal == 1)
                                        {
                                            SqlParameter[] param2 = new SqlParameter[]
                                                 {
                                                new SqlParameter("@UserId",Result),
                                                new SqlParameter("@Mobile",_Mobile),
                                                new SqlParameter("@EmailId",_EmailId),
                                                new SqlParameter("@Role","Employee"),
                                                new SqlParameter("@Password",_password),
                                                 new SqlParameter("@UserName",""),
                                                new SqlParameter("@Returnval",SqlDbType.Int)
                                                 };
                                            int ResultVal1 = DAL.ExecuteStoredProcedureRetnInt("Sp_AddUserLoginCredentials", param2);


                                            lblError.Text = count + " / " + rowCount + " Records Upload Successfully. ";
                                            lblError.Visible = true;
                                            lblError.ForeColor = System.Drawing.Color.Green;
                                            count++;
                                        }
                                        else if (ResultVal == -2)
                                        {
                                            lblError.Text = "Already Added. ";
                                            lblError.Visible = true;
                                            lblError.ForeColor = System.Drawing.Color.Orange;
                                        }
                                        else
                                        {
                                            Msg = "● Something Went Wrong, Please Try Again After Some Time!";
                                        }
                                    }

                                    else if (Result == -2)
                                    {
                                        lblError.Text = "Already Added. ";
                                        lblError.Visible = true;
                                        lblError.ForeColor = System.Drawing.Color.Orange;
                                    }
                                    else
                                    {
                                        Msg = "● Something Went Wrong, Please Try Again After Some Time!";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
    private string CreateRandomPassword()
    {
        // Create a string of characters, numbers, special characters that allowed in the password  
        string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
        Random random = new Random();

        // Select one random character at a time from the string  
        // and create an array of chars  
        char[] chars = new char[6];
        for (int i = 0; i < 6; i++)
        {
            chars[i] = validChars[random.Next(0, validChars.Length)];
        }
        return new string(chars);
    }
}