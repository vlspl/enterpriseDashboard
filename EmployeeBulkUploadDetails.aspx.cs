using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrossPlatformAESEncryption;
using CrossPlatformAESEncryption.Helper;
using System.IO;
using Validation;
using Spire.Xls;

public partial class EmployeeBulkUploadDetails : System.Web.UI.Page
{
    DBClass db = new DBClass();
    OleDbConnection Econ;
    SqlConnection con;
    DataAccessLayer DAL = new DataAccessLayer();
    string constr, Query, sqlconn, userName, OrgId, branchId;
    int uploadId;
    InputValidation Ival = new InputValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        //userName = CryptoHelper.Decrypt(Session["userName"].ToString());
        branchId = Session["BranchId"].ToString();
        OrgId = (Session["OrgId"].ToString());
        userName = db.getData("SELECT Name FROM OrganizationUsers WHERE Org_Id = '" + OrgId + "' and Branch_ID='"+ branchId + "'").ToString();

        bindGrid();
        // db.bindDrp("select Name from ");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string path = string.Concat(Server.MapPath("~/BulkUploadFiles/" + FileUpload1.FileName));
        FileUpload1.SaveAs(path);

        //insert into bulk Upload Master

        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_AddbulkUploadMaster",con);
        cmd.Parameters.AddWithValue("@fileName", FileUpload1.FileName);
        cmd.Parameters.AddWithValue("@userName", userName);
        cmd.Parameters.AddWithValue("@uploadDate", System.DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@Org_Id", OrgId);
        cmd.Parameters.AddWithValue("@uploadForWhome", "Emp");
        cmd.Parameters.AddWithValue("@branchId", branchId);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        con.Close();
         uploadId =int.Parse(DAL.ExecuteScalar("select max(uploadId) from EmpBulkUploadMaster"));

        
        //display Bulk Upload master details
        bindGrid();

        //insert into temp Table
        InsertExcelRecords(path);

      


        //Insert into EmployeeDetails Table
        InsertIntoEmp(uploadId);

        //Update employeedetails with branch id
        con.Open();
        SqlCommand cmdemp = new SqlCommand("update EmployeeDetails set branchId='"+branchId+"' where orgId='"+OrgId+"' and uploadId='"+uploadId+"'", con);
      
        cmdemp.ExecuteNonQuery();
        con.Close();

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "insertSuccess", "alert('Uploaded successfully');location.href='EmployeeBulkUploadDetails.aspx';", true);

    }

    public void bindGrid()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_BindBulkUploadDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@orgId", OrgId);
        cmd.Parameters.AddWithValue("@uploadForWhome", "Emp");
        cmd.Parameters.AddWithValue("@branchId", branchId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridEmpBulk.DataSource = dt;
        GridEmpBulk.DataBind();
        con.Close();
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
    DataTable RemoveEmptyRowsFromDataTable(DataTable Exceldt)
    {
        for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
        {
            if (Exceldt.Rows[i][1] == DBNull.Value)
                Exceldt.Rows[i].Delete();
        }
        Exceldt.AcceptChanges();
        return Exceldt;
    }
    public DataTable excelupload(string path)
    {
        Workbook workbook = new Workbook();
        workbook.LoadFromFile(@path);

        Worksheet sheet = workbook.Worksheets[0];

        DataTable tbl = sheet.ExportDataTable();
        return tbl;
    }

      private void InsertExcelRecords(string FilePath)
    {
        DataTable dtReturn = new DataTable();
        // ExcelConn(FilePath);

        //Query = string.Format("select [Full Name],[Employee Id],[Date of Birth],[Aadhar Number],[Mobile No],[Email Id],Gender,State,City,PinCode,Address,[Health ID],Department,[Pan Number],Age,Designation,Branch,[Blood Group],[Employee Status],Status,Remark,'"+OrgId+"' as OrgId,'"+uploadId+"' as UploadId FROM [{0}]", "Sheet1$");
        //OleDbCommand Ecom = new OleDbCommand(Query, Econ);
        //Econ.Open();

        //DataSet ds = new DataSet();
        //OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
        //Econ.Close();
        //oda.Fill(ds);

        // DataTable Exceldt = ds.Tables[0];
        DataTable Exceldt = excelupload(FilePath);

        dtReturn = RemoveEmptyRowsFromDataTable(Exceldt);
        dtReturn.Columns.Add("UploadId");
        //dtReturn.Columns["UploadId"].DefaultValue =uploadId;
        //dtReturn.Columns["Organization Id"].DefaultValue = OrgId;
       foreach(DataRow row in dtReturn.Rows)
        {
            row["UploadId"] = uploadId;
            row["Organization Id"] = OrgId;

        }

        connection();
        //creating object of SqlBulkCopy    
        SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //assigning Destination table name    
        objbulk.DestinationTableName = "temp";
        //Mapping Table column    
        objbulk.ColumnMappings.Add("Full Name", "fullName"); //excel tblColumn
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
        objbulk.ColumnMappings.Add("UploadId", "uploadId");
        //objbulk.ColumnMappings.Add("", "orgId");
        //inserting Datatable Records to DataBase    
        con.Open();
        objbulk.WriteToServer(dtReturn);
        con.Close();
    }
    protected void DownloadFile(object sender, CommandEventArgs e)
    {
        InputValidation Ival = new InputValidation();
        con.Open();
        string uploadId = e.CommandArgument.ToString();
        SqlCommand cmd = new SqlCommand("select * from temp where orgId='"+OrgId+ "' and uploadId='"+ uploadId + "'", con);//uploadeId='"+0+"' and 
        //cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        // DataTable dt = new DataTable();=

        DataTable dt = new DataTable();// (DataTable)ViewState["DataTable"];
        da.Fill(dt);
        CreateExcelFile(dt);

        ExportToExcel();
        //mail send code here
        //string Password = CreateRandomPassword();
        //if (Ival.IsValidEmailAddress(dt.row["Email Id"].ToString()))
        //{
        //    ClsEmailTemplates emailTemp = new ClsEmailTemplates();
        //    string mailSent = emailTemp.sendmail(row["Email Id"].ToString(), Password, row["Full Name"].ToString(), row["Mobile No"].ToString());
        //}
        //string filePath = (sender as LinkButton).CommandArgument;

        //RespCreateExcelFileonse.ContentType = ContentType;
        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //Response.WriteFile(filePath);
        //Response.End();
    }
    public void CreateExcelFile(DataTable Excel)
    {
        //Clears all content output from the buffer stream.    
        Response.ClearContent();
        //Adds HTTP header to the output stream    
        Response.AddHeader("content-disposition", string.Format("attachment; filename=BulkUploadFiles/EmployeeLogFile.xls"));
        // Gets or sets the HTTP MIME type of the output stream    
        Response.ContentType = "application/vnd.ms-excel";
        string space = "";
        foreach (DataColumn dcolumn in Excel.Columns)
        {
            Response.Write(space + dcolumn.ColumnName);
            space = "\t";
        }
        Response.Write("\n");
        int countcolumn;
        foreach (DataRow dr in Excel.Rows)
        {
            space = "";
            for (countcolumn = 0; countcolumn < Excel.Columns.Count; countcolumn++)
            {
                Response.Write(space + dr[countcolumn].ToString());
                space = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }

    private void ExportToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "EmployeeLogFile" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //GridView1.GridLines = GridLines.Both;
        //GridView1.HeaderStyle.Font.Bold = true;
        //GridView1.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

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
    public void InsertIntoEmp(int uploadId)
    {
        int Result = 0;
       // insert into employee details table
        DataTable dt_emp = new DataTable();
        con.Open();


        SqlCommand cmd = new SqlCommand("Sp_AddEmployeeDetailsBulkUpload_New", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@orgId", OrgId);
        cmd.Parameters.AddWithValue("@uploadId", uploadId);
       
        cmd.ExecuteNonQuery();
        con.Close();

        // here update emp table with branch Id
        con.Open();


        SqlCommand cmdUpdateEmp = new SqlCommand("SP_UpdateEmpWithBranchID", con);
        cmdUpdateEmp.CommandType = CommandType.StoredProcedure;
        cmdUpdateEmp.Parameters.AddWithValue("@orgId", OrgId);
        cmdUpdateEmp.Parameters.AddWithValue("@uploadId", uploadId);

        cmdUpdateEmp.ExecuteNonQuery();
        con.Close();


        SqlParameter[] param1 = new SqlParameter[]
        {   
                      new SqlParameter("@OrgId",OrgId),
                      new SqlParameter("@uploadId",uploadId),
                    //  new SqlParameter("@Returnval",SqlDbType.Int)
        };
        dt_emp = DAL.ExecuteStoredProcedureDataTable("SP_bindSuccessRecordOnly", param1);

        string Password, subject, mailbody;
        foreach (DataRow row in dt_emp.Rows)
        {
             Password = CreateRandomPassword();
             subject = "HowzU Connect – Thank you for your registration. Sign in today.";
             mailbody  = "Greetings of the day! <br />" +

                "<h3>Congratulations! You have successfully registered for Howzu App. </h3><br />" +

                "Now it’s time to update your health details to have your personalised digital health Valet for you and your family members." +

                 "<br />Follow the steps below for the further process now :<br /><br />" +
                 "<b>1 . Download the App :</b><br /><br />" +
                "<b>iOS User</b> : https://apps.apple.com/in/app/howzu/id1481816983 <br />" +
                "<b>Android User</b> : https://play.google.com/store/apps/details?id=com.howzu <br /><br />" +
                "<b>2 . Kindly use following credentials to Sign in,</b><br /><br />" +
                        "<b>User Name : " + row["ContactNo"].ToString() + "</b><br />" +
                        "<b>PassCode : " + Password + "</b><br /><br />" +

                "Along with tracking your health report, HowzU will also help you to find best path labs and manage each of your family members' health data at your fingertips.<br />" +

                "We are delighted to welcome you to the Howzu family, and are looking for a long and endeavoring business Relationship.<br /><br />" +

                "<b>Regards,</b><br />" +
                "<b>Howzu Team. </b> ";

            string _password = CryptoHelper.Encrypt(Password);
            string _EmailId = CryptoHelper.Encrypt(row["Email"].ToString());
            string _Mobile = CryptoHelper.Encrypt(row["ContactNo"].ToString());
            string _HealthId = CryptoHelper.Encrypt(row["HealthID"].ToString());
            string _Aadhar = CryptoHelper.Encrypt(row["AtdharName"].ToString());



            ////insert into branchMaster
            //SqlParameter[] paramBranch = new SqlParameter[]
            //              {
            //                 new SqlParameter("@Org_Id",OrgId),
            //                 new SqlParameter("@BranchName",row["BatchName"].ToString()),
            //                 new SqlParameter("@BranchAddress",""),
            //                 new SqlParameter("@Contact",""),
            //                 new SqlParameter("@Email",""),
            //                 new SqlParameter("@BranchDetails",""),
            //                 // new SqlParameter("@parentBranchId",_parentBranchId),
            //                  // new SqlParameter("@branchType","Sub"),
            //                 new SqlParameter("@returnval",SqlDbType.Int)
            //               };
            //int ResultBranch = DAL.ExecuteStoredProcedureRetnInt("Sp_AddOrgnizationBranch", paramBranch);


            string _getDOB = row["DOB"].ToString();
            string[] _dob = _getDOB.Split(' ');


            //  Insert intoApp User Details
            SqlParameter[] param = new SqlParameter[]
                                {
                                     new SqlParameter("@sFullName",row["FName"].ToString()),
                                     new SqlParameter("@sMobile",_Mobile),
                                     new SqlParameter("@sEmailId",_EmailId),
                                     new SqlParameter("@sGender",row["Gender"].ToString()),
                                    // new SqlParameter("@sBirthDate",_getDOB.Length>11? row["DOB"].ToString().Substring(0, 11):row["DOB"].ToString()),
                                    new SqlParameter("@sBirthDate",_dob[0]),
                                    new SqlParameter("@sAddress",row["CAddress"].ToString()),
                                     new SqlParameter("@sRole","Employee"),
                                     new SqlParameter("@sCountry","India"),
                                     new SqlParameter("@sState",row["State"].ToString()),
                                     new SqlParameter("@sCity",row["City"].ToString()),
                                     new SqlParameter("@sPincode",row["PinCode"].ToString()),
                                     new SqlParameter("@EmployeeId",row["EmployeeId"].ToString()),
                                     new SqlParameter("@AadharCard",_Aadhar),
                                     new SqlParameter("@HealthId",_HealthId),
                                     new SqlParameter("@Department",row["dept"].ToString()),
                                     new SqlParameter("@Returnval",SqlDbType.Int)
                                };
                 Result = DAL.ExecuteStoredProcedureRetnInt("Sp_AddEmployeeUpdated", param);
                //  Insert into Organization Employee Details
                if (Result > 1)
                {
                    SqlParameter[] paramOrgEmp = new SqlParameter[]
                       {
                      new SqlParameter("@EmpId",Result),
                      new SqlParameter("@OrgId",row["orgId"].ToString()),
                      new SqlParameter("@BranchId",branchId),
                      new SqlParameter("@CreatedBy",Request.Cookies["HRId"].Value.ToString()),
                      new SqlParameter("@Returnval",SqlDbType.Int)
                       };
                    int ResultVal = DAL.ExecuteStoredProcedureRetnInt("Sp_AddOrgEmployee", paramOrgEmp);

                    //Insert into User Login Master Details
                    SqlParameter[] param2 = new SqlParameter[]
                            {
                      new SqlParameter("@UserId",Result),
                      new SqlParameter("@Mobile",_Mobile),
                      new SqlParameter("@EmailId",_EmailId),
                      new SqlParameter("@Role","Employee"),
                      new SqlParameter("@Password",_password),
                      new SqlParameter("@UserName",""),
                     // new SqlParameter("@loginStatus","A"),
                       new SqlParameter("@orgId",OrgId),
                      new SqlParameter("@Returnval",SqlDbType.Int)

                            };
                    int ResultVal1 = DAL.ExecuteStoredProcedureRetnInt("Sp_AddUserLoginCredentialsEnterprise", param2);
                    //insert into new table UserOrgAsign
                    SqlParameter[] paramEmpOrg = new SqlParameter[]
                        {
                      new SqlParameter("@branchId",branchId),
                      new SqlParameter("@orgId",OrgId),
                      new SqlParameter("@userId",Result),
                      new SqlParameter("@createdBy",userName),
                      new SqlParameter("@createdDate",System.DateTime.Now),
                      new SqlParameter("@Returnval",SqlDbType.Int)
                        };
                    int ResultValEmpOrg = DAL.ExecuteStoredProcedureRetnInt("SP_AddUserOrgAssign", paramEmpOrg);

 			if (Ival.IsValidEmailAddress(row["Email"].ToString()))
           		 {
              		  string getexistingPassword = Password;
               		 if (Result == -2)
                    getexistingPassword = db.getData("select Password from UserLoginMaster where Mobile='" + _Mobile + "'");


               		 ClsEmailTemplates emailTemp = new ClsEmailTemplates();
                		string mailSent = emailTemp.sendmail(row["Email"].ToString(), getexistingPassword, row["FName"].ToString(), row["ContactNo"].ToString(), mailbody, subject);
          		  }
                WhatsappMsg msg = new WhatsappMsg();
                //msg.sendWhatsappMsg("+91"+txtContactNo.Text, "Org Emp Welcome", txtFName.Text+','+ txtContactNo.Text+','+password);
                msg.sendWhatsappMsg("+91" + row["ContactNo"].ToString(), "Org Emp Welcome", row["FName"].ToString() + ',' + row["ContactNo"].ToString() + ',' + Password);

                }
                else
               {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

                //  get employee id here
               
                 string empId= db.getData("select EmployeeId from EmployeeDetails where contactNo='" + row["ContactNo"].ToString() + "' and orgId='"+OrgId+"'");
                //Update in appUser Table
                cn.Open();
                SqlCommand cmdApp = new SqlCommand("update appUser set EmployeeId='" + empId + "' where sMobile='" + _Mobile+ "'", cn);
                cmdApp.ExecuteNonQuery();
                cn.Close();

                //Update in OrgnizationEmployee Table

                cn.Open();
                SqlCommand cmd1 = new SqlCommand("update OrgnizationEmployee set Org_Id='" + OrgId.ToString() + "',Branch_ID='" + Request.Cookies["BranchId"].Value.ToString() + "' where Emp_ID IN (select sAppUserId from appUser where sMobile='" +_Mobile + "')", cn);
                cmd1.ExecuteNonQuery();
                cn.Close();
            }

           


        }



    }
}