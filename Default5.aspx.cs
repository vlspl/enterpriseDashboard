using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using CrossPlatformAESEncryption.Helper;
using DataAccessHandler;

public partial class Default5 : System.Web.UI.Page
{
    OleDbConnection Econ;
    SqlConnection con;
    DataAccessLayer DAL = new DataAccessLayer();
    string constr, Query, sqlconn;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void ExcelConn(string FilePath)
    {

        constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1;""", FilePath);
        Econ = new OleDbConnection(constr);
      //5 connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
}
    private void connection()
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        sqlconn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        con = new SqlConnection(sqlconn);

    }
    private void InsertExcelRecords(string FilePath)
    {

        ExcelConn(FilePath);


        // Query = string.Format("select fullName,empId,dob,aadharNo,mobileNo,emailId,gender,state,city,pinCode,address,healthId,dept,panNo,age,designation,branch,bloodGrp,empStatus,status,remark FROM [{0}]", "Sheet1$");
        Query = string.Format("select [Full Name],[Employee Id],[Date of Birth],[Aadhar Number],[Mobile No],[Email Id],Gender,State,City,PinCode,Address,[Health ID],Department,[Pan Number],Age,Designation,Branch,[Blood Group],[Employee Status],Status,Remark,[Organization Id] FROM [{0}]", "Sheet1$");
        OleDbCommand Ecom = new OleDbCommand(Query, Econ);
        Econ.Open();

        DataSet ds = new DataSet();
        OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
        Econ.Close();
        oda.Fill(ds);
        DataTable Exceldt = ds.Tables[0];
        connection();
        //creating object of SqlBulkCopy    
        SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //assigning Destination table name    
        objbulk.DestinationTableName = "temp";
        //Mapping Table column    
        objbulk.ColumnMappings.Add("Full Name", "fullName");
        objbulk.ColumnMappings.Add("Employee Id", "empId");
        objbulk.ColumnMappings.Add("Date of Birth", "dob");
        objbulk.ColumnMappings.Add("Aadhar Number", "aadharNo");
        objbulk.ColumnMappings.Add("Mobile No", "mobileNo");
        objbulk.ColumnMappings.Add("Email Id", "emailId");
        objbulk.ColumnMappings.Add("Gender", "gender");
        objbulk.ColumnMappings.Add("State", "state");
        objbulk.ColumnMappings.Add("City", "city");
        objbulk.ColumnMappings.Add("PinCode", "pinCode");
        objbulk.ColumnMappings.Add("Address", "address");
        objbulk.ColumnMappings.Add("Health ID", "healthId");
        objbulk.ColumnMappings.Add("Department", "dept");
        objbulk.ColumnMappings.Add("Pan Number", "panNo");
        objbulk.ColumnMappings.Add("Age", "age");
        objbulk.ColumnMappings.Add("Designation", "designation");
        objbulk.ColumnMappings.Add("Branch", "branch");
        objbulk.ColumnMappings.Add("Blood Group", "bloodGrp");
        objbulk.ColumnMappings.Add("Employee Status", "empStatus");
        objbulk.ColumnMappings.Add("Status", "status");
        objbulk.ColumnMappings.Add("Remark", "remark"); 
        objbulk.ColumnMappings.Add("Organization Id", "orgId");
        //inserting Datatable Records to DataBase    
        con.Open();
        objbulk.WriteToServer(Exceldt);
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string CurrentFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
        string path = string.Concat(Server.MapPath("~/" + FileUpload1.FileName));
        FileUpload1.SaveAs(path);

        InsertExcelRecords(path);
        // insert into emp tables
        insertIntoEmpTable();

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
    public void insertIntoEmpTable()
    {
        string Msg = "";
        string Query = string.Format("select fullName,empId,dob,aadharNo,mobileNo,emailId,gender,state,city,pinCode,address,healthId,dept,panNo,age,designation,branch,bloodGrp,empStatus,remark,status,orgId from  temp ");//where status='Success'
        connection();
        SqlCommand cmd = new SqlCommand(Query, con);
        con.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter oda = new SqlDataAdapter(cmd);
        con.Close();
        oda.Fill(ds);
        DataTable Exceldt = ds.Tables[0];
        int rowCount = Convert.ToInt32(Exceldt.Rows.Count);
        if (Exceldt.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in Exceldt.Rows)
            {
                string Password = CreateRandomPassword();
                
                string _password = CryptoHelper.Encrypt(Password);
                string _EmailId = CryptoHelper.Encrypt(row["emailId"].ToString());
                string _Mobile = CryptoHelper.Encrypt(row["mobileNo"].ToString());
                string _HealthId = CryptoHelper.Encrypt(row["healthId"].ToString());
                string _Aadhar = CryptoHelper.Encrypt(row["aadharNo"].ToString());

                SqlParameter[] paramEmp = new SqlParameter[]
               {
                                     new SqlParameter("@FName",row["fullName"].ToString()),
                                     //new SqlParameter("@MName",""),
                                     //new SqlParameter("@LName",""),
                                     //new SqlParameter("@SName",""),
                                     new SqlParameter("@AtdharName",row["aadharNo"].ToString()),
                                     new SqlParameter("@DOB",row["dob"].ToString()),
                                     new SqlParameter("@Age",row["age"].ToString()),
                                     new SqlParameter("@Gender",row["gender"].ToString()),
                                    // new SqlParameter("@Pphoto",""),
                                     new SqlParameter("@PanNo",row["PanNo"].ToString()),
                                     new SqlParameter("@Email",row["emailId"].ToString()),
                                     new SqlParameter("@ContactNo",row["mobileNo"].ToString()),
                                   //  new SqlParameter("@AltContact",row["mobileNo"].ToString()),
                                     new SqlParameter("@CAddress",row["address"].ToString()),
                                    // new SqlParameter("@PAddress",row["address"].ToString()),
                                     new SqlParameter("@State",row["state"].ToString()),

                                     new SqlParameter("@City",row["city"].ToString()),
                                     new SqlParameter("@Pincode",row["pinCode"].ToString()),


                                     new SqlParameter("@EmpId",row["empId"].ToString()),
                                     new SqlParameter("@Dsgn",row["designation"].ToString()),

                                     new SqlParameter("@Dept",row["dept"].ToString()),
                                     new SqlParameter("@BatchName",row["branch"].ToString()),
                                    // new SqlParameter("@DOJ",""),
                                     new SqlParameter("@EmpStatus",row["EmpStatus"].ToString()),
                                     new SqlParameter("@Bgroup",row["bloodGrp"].ToString()),
                                     new SqlParameter("@HealthID",row["healthId"].ToString()),

                                     //new SqlParameter("@Qualification",""),
                                     //new SqlParameter("@Pyear",""),
                                     //new SqlParameter("@Grade",""),
                                     //new SqlParameter("@University",""),
                                     //new SqlParameter("@CompName",""),
                                     //new SqlParameter("@Period",""),

                                     //new SqlParameter("@frm",""),
                                     //new SqlParameter("@tto",""),
                                     //new SqlParameter("@dsgnn",""),
                                     //new SqlParameter("@Documents",""),
                                     new SqlParameter("@orgId","2"),

                                     //new SqlParameter("@Returnval",SqlDbType.NVarChar,50)
                                      new SqlParameter("@Returnval",SqlDbType.Int)
                                      //new SqlParameter("@remark",SqlDbType.Int),
                                      //new SqlParameter("@status",SqlDbType.Int)
               };
               // string ResultEmp = DAL.ExecuteStoredProcedureRetnString("Sp_AddEmployeeDetailsBulkUpload", paramEmp);
               int ResultEmp= DAL.ExecuteStoredProcedureRetnInt("Sp_AddEmployeeDetailsBulkUpload", paramEmp);
                //string[] getData = ResultEmp.Split('/');
                //row["Status"] = getData[0];
                //row["Remark"] = getData[1];
                //if (getData[0] == "Success")
                if(ResultEmp==1)
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
                else
                {
                    Msg = "● Something Went Wrong, Please Try Again After Some Time!";
                    //DBClass db = new DBClass();
                    //Exception ex;
                    //db.insert("update temp set status='Fail',remark='' where ContactNo='"+ row["Mobile No"].ToString() + "'");
                }
            }
        }
    }
} 
