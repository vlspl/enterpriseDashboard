using BitsBizLogic;
using CrossPlatformAESEncryption.Helper;
using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validation;


public partial class Employee : System.Web.UI.Page
{
    public int EmpChieldID;
    EmPpDal objbal = new EmPpDal();
    DataTable dtFillData;
    DBClass db = new DBClass();
    ClsAddEmployee ObjAddEmp = new ClsAddEmployee();
    DataAccessLayer DAL = new DataAccessLayer();
    InputValidation Ival = new InputValidation();
    string gender , userNm, orgId, branchId;
    SqlConnection cn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        orgId=  Session["OrgId"].ToString();
        branchId=Session["BranchId"].ToString();
       // orgId = int.Parse(db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
        
            if (!this.IsPostBack)
            {
                db.bindDrp("select deptName,deptId from AddDepartment where orgId='" + orgId+"'", drpDept, "deptName", "deptId");
                drpDept.Items.Insert(0, new ListItem("--Select--", "--Select--")); //updated code to set first value "All"

            db.bindDrp("select BranchName,ID from BranchMaster where Org_Id='" + orgId + "' and ID='"+branchId+"'", drpBranch, "BranchName", "ID");
         
            if(branchId=="0")
               drpBranch.Items.Insert(0, new ListItem("Main Branch", "Main Branch")); //updated code to set first value "All"

            //drpBranch.Text=
           // WhatsappMsg msg = new WhatsappMsg();
            //msg.sendWhatsappMsg("+91"+txtContactNo.Text, "Org Emp Welcome", txtFName.Text+','+ txtContactNo.Text+','+password);
            //  msg.sendWhatsappMsg("+918600666159", "Org Emp Welcome", "Hasrhada,admin,@qwerJK");
          //  msg.sendWhatsappMsg("+918600666159", "Test Completed Msg To Emp", "Harshada");
            if (Request.QueryString["EmployeeId"] != null)
                {
                    dtFillData = objbal.fillData(Request.QueryString["EmployeeId"]);//http://localhost:25398/Test.aspx
                    foreach (DataRow row in dtFillData.Rows)
                    {
                        // basic Info
                        txtFName.Text = row["FName"].ToString();
                        //txtMName.Text = row["MName"].ToString();
                        //txtLName.Text = row["LName"].ToString();
                        //txtSName.Text = row["SName"].ToString();
                        txtAdhar.Text = row["AtdharName"].ToString();
                        txtDOB.Text = row["DOB"].ToString();
                        txtAge.Text = row["age"].ToString();
                        txtPan.Text = row["PanNo"].ToString();
                        if (row["Gender"].ToString() == "Male")
                            rbMale.Checked = true;
                        else
                            rbFemale.Checked = true;

                        // Contact Info
                        txtEmail.Text = row["Email"].ToString();
                        txtContactNo.Text = row["ContactNo"].ToString();
                        txtAContactNo.Text = row["AltContact"].ToString();
                        txtxCAdd.Text = row["CAddress"].ToString();
                        txtState.Text = row["State"].ToString();
                        txtPadd.Text = row["PAddress"].ToString();
                        txtCity.Text = row["City"].ToString();
                        txtpincode.Text = row["Pincode"].ToString();

                        // Organizational Info
                        txtEmpid.Text = row["EmpId"].ToString();
                        txtdsgn.Text = row["Dsgn"].ToString();
                        txtDOJ.Text = row["DOJ"].ToString();
                        drpDept.SelectedItem.Text = row["Dept"].ToString();
                        drpBranch.Text = row["BatchName"].ToString();
                        txtEmpStatus.Text = row["EmpStatus"].ToString();

                        // Health Info
                        txtBG.Text = row["Bgroup"].ToString();
                        txtHID.Text = row["HealthID"].ToString();


                        BtnUpdate.Visible = true;
                    BtnDelete.Visible = true;
                    BtnSave.Visible = false;
                    updateStatus.Visible = true;
                    }

                }
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("QualificationId"), new DataColumn("Qulification"), new DataColumn("Pyear"), new DataColumn("Grade"), new DataColumn("University") });

                ViewState["Qulification"] = dt;

                if (Request.QueryString["EmployeeId"] != null)
                {

                    dt = objbal.fillQualification(Request.QueryString["EmployeeId"]);
                    this.BindGrid();

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }


                DataTable dty = new DataTable();
                dty.Columns.AddRange(new DataColumn[5] { new DataColumn("ExpId"), new DataColumn("CompName"), new DataColumn("Period"), new DataColumn("tto"), new DataColumn("Cdsgn") });

                ViewState["Expirence"] = dty;

                if (Request.QueryString["EmployeeId"] != null)
                {
                    dty = objbal.fillExperience(Request.QueryString["EmployeeId"]);
                    this.BindGridwithExp();
                    GrdExp.DataSource = dty;
                    GrdExp.DataBind();
                }

            }
       
    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch(txtAge.Text, "[^0-9]"))
        {
            //MessageBox.Show("Please enter only numbers.");
            //  ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Please enter only numbers.!\");", true);
            lblWarning.Text = ("● Please enter only numbers!");
            txtAge.Text = txtAge.Text.Remove(txtAge.Text.Length - 1);
        }
        else if(int.Parse(txtAge.Text)>100)
        {
            lblWarning.Text = ("● Age Should not be greater than 100!");
            txtAge.Text = txtAge.Text.Remove(txtAge.Text.Length - 1);
        }
    }
   
    protected void UploadFile(object sender, EventArgs e)
    {
        string folderPath = Server.MapPath("~/Images/");

        //Check whether Directory (Folder) exists.
        if (!Directory.Exists(folderPath))
        {
            //If Directory (Folder) does not exists Create it.
            Directory.CreateDirectory(folderPath);
        }

        //Save the File to the Directory (Folder).
        //  FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

        //Display the Picture in Image control.
       // Image1.ImageUrl = "~/Images/" + Path.GetFileName(fileuploadimages.FileName);
    }
    private void FillEditData(string editEmpId)
    {
        EmPpDal objbal = new EmPpDal();
        DataTable dt;
        dt = objbal.EditEmplDetails(editEmpId);
        txtFName.Text = (string)dt.Rows[0]["FName"];

    }
    void save()
    {
        // insert  into table  Employee Details

        SaveData();
        saveQulification();
        SaveExpDetails();

        // insert  into table appUser
        string password = CreateRandomPassword();

        if (db.chkDBValue("select * from appUser where sMobile='" + CryptoHelper.Encrypt(txtContactNo.Text) + "'"))
        {
            //Update in appUser Table
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("update appUser set EmployeeId='" + EmpChieldID.ToString() + "' where sMobile='" + CryptoHelper.Encrypt(txtContactNo.Text) + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();



            //Update in OrgnizationEmployee Table
            if (db.chkDBValue("select * from OrgnizationEmployee where Emp_ID IN (select sAppUserId from appUser where sMobile='" + CryptoHelper.Encrypt(txtContactNo.Text) + "')"))
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("update OrgnizationEmployee set Org_Id='" + orgId.ToString() + "',Branch_ID='" + Request.Cookies["BranchId"].Value.ToString() + "' where Emp_ID IN (select sAppUserId from appUser where sMobile='" + CryptoHelper.Encrypt(txtContactNo.Text) + "')", cn);
                cmd1.ExecuteNonQuery();
                cn.Close();
            }
            else
            {
                string empId = db.getData("select sAppUserId from appUser where sMobile='" + CryptoHelper.Encrypt(txtContactNo.Text) + "'");
                SqlParameter[] param1 = new SqlParameter[]
                {
                      new SqlParameter("@EmpId",empId),
                      new SqlParameter("@OrgId",orgId),
                      new SqlParameter("@BranchId",branchId),
                      new SqlParameter("@CreatedBy",Request.Cookies["HRId"].Value.ToString()),
                      new SqlParameter("@Returnval",SqlDbType.Int)
                 };
                int ResultVal = DAL.ExecuteStoredProcedureRetnInt("Sp_AddOrgEmployee", param1);// Insert into Organization Employee Details

            }


            // mail send code here
            ClsEmailTemplates emailTemp = new ClsEmailTemplates();
            string subject = "HowzU Connect – Thank you for your registration. Sign in today.";
            string mailbody = mailbody = "Greetings of the day! <br />" +

                "<h3>Congratulations! You have successfully registered for Howzu App. </h3><br />" +

                "Now it’s time to update your health details to have your personalised digital health Valet for you and your family members." +

                 "<br />Follow the steps below for the further process now :<br /><br />" +
                 "<b>1 . Download the App :</b><br /><br />" +
                "<b>iOS User</b> : https://apps.apple.com/in/app/howzu/id1481816983 <br />" +
                "<b>Android User</b> : https://play.google.com/store/apps/details?id=com.howzu <br /><br />" +
                "<b>2 . Kindly use following credentials to Sign in,</b><br /><br />" +
                        "<b>User Name : " + txtContactNo.Text + "</b><br />" +
                        "<b>PassCode : " + password + "</b><br /><br />" +

                "Along with tracking your health report, HowzU will also help you to find best path labs and manage each of your family members' health data at your fingertips.<br />" +

                "We are delighted to welcome you to the Howzu family, and are looking for a long and endeavoring business Relationship.<br /><br />" +

                "<b>Regards,</b><br />" +
                "<b>Howzu Team. </b> ";

            string mailSent = emailTemp.sendmail(txtEmail.Text, password, txtFName.Text, txtContactNo.Text, mailbody, subject);
        }
        else
        {
            string Msg = ObjAddEmp.AddEmployee(txtFName.Text, txtContactNo.Text, txtEmail.Text, gender,
                txtDOB.Text,
                txtxCAdd.Text, txtState.Text, txtCity.Text, txtpincode.Text, EmpChieldID.ToString(), txtAdhar.Text,
                orgId.ToString(), Request.Cookies["BranchId"].Value.ToString(), Request.Cookies["HRId"].Value.ToString(), password);

            if (Msg.ToString() == "1")
            {
                litErrorMessage.Text = ApplicationLogic.SuccessMessage("● Saved Suceessfully.");
                ClearControles();
            }
            else if (Msg.ToString() == "-2")
            {
                litErrorMessage.Text = ApplicationLogic.ErrorWarning("● Already Exist!");
            }
            else if (Msg.ToString() == "● Something Went Wrong, Please Try Again After Some Time!")
            {
                litErrorMessage.Text = ApplicationLogic.Error("● Something Went Wrong, Please Try Again After Some Time!");
            }
            else
            {
                litErrorMessage.Text = ApplicationLogic.ErrorWarning(Msg);
            }

        }

        // System.Threading.Thread.Sleep(500);
        // ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "insertSuccess", "alert('Save successfully');location.href='EmployeeDetails.aspx';", true);        //for display employee details list




        SqlParameter[] paramEmpList = new SqlParameter[]
             {

            new SqlParameter("@parentbranchId",branchId),
            new SqlParameter("@orgId",orgId),


             };
        DataTable dt_getEmpDtls = DAL.ExecuteStoredProcedureDataTable("SP_EmpDetailsFromAddEmp", paramEmpList);
        Session["EmpDtls"] = dt_getEmpDtls; //qryForEmpList+ " order by 1 desc ";
        WhatsappMsg msg = new WhatsappMsg();
        msg.sendWhatsappMsg("+91" + txtContactNo.Text, "Org Emp Welcome", txtFName.Text + ',' + txtContactNo.Text + ',' + password);
        //msg.sendWhatsappMsg("+91" + txtContactNo.Text, "Lab Payment", txtFName.Text + ',' + "1580" + ',' + "Satyam Lab");

        //  Response.Redirect("EmployeeDetails.aspx");
        clearallText();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        save();
    }
    private void ExcelConn(string FilePath)
    {
        
        string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);
        SqlConnection cn = new SqlConnection(constr);
        

    }
    //protected void btnUpload_Click(object sender, EventArgs e)
    //{

       
    //}
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
    public void ClearControles()
    {
        txtFName.Text = "";
        txtContactNo.Text = "";
        txtEmail.Text = "";
        txtDOB.Text = "";
        txtxCAdd.Text = "";
        txtCity.Text = "";
        txtpincode.Text = "";
        txtEmpid.Text = "";
        txtAdhar.Text = "";
        txtState.Text = "";
    }

    public void clearallText()
    {
        
        foreach (Control control in this.Controls)
        {
            if (control is TextBox)
            {
                TextBox txt = (TextBox)control;
                txt.Text = "";
            }

        }
    }
    private void SaveExpDetails()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("EmpChieldID1", typeof(int)), new DataColumn("CompName", typeof(string)), new DataColumn("Period", typeof(string)), new DataColumn("tto", typeof(string)), new DataColumn("Cdsgn", typeof(string)) });
        foreach (GridViewRow row in GrdExp.Rows)
        {

            dt.Rows.Clear();
            string CompName = row.Cells[0].Text;
            string Period = row.Cells[1].Text;
            string tto = row.Cells[2].Text;
            string Cdsgn = row.Cells[3].Text;

            dt.Rows.Add(EmpChieldID,CompName, Period, tto, Cdsgn);
            EmPpDal objbal = new EmPpDal();
            if (GrdExp.Rows.Count > 0)
            {
                DataTable j = objbal.AddExpDetails(dt, EmpChieldID);
            }
            else
                litErrorMessage.Text = "Please Add Experience Details.";

        }




    }

    private void saveQulification()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("EmpChieldID1", typeof(int)), new DataColumn("Qulification", typeof(string)), new DataColumn("Pyear", typeof(string)), new DataColumn("Grade", typeof(string)), new DataColumn("University", typeof(string)) });
        foreach (GridViewRow row in GridView1.Rows)
        {
            dt.Rows.Clear();
           // string EmpChieldID1 =int.Parse(txtEmpid.Text).ToString();
            string Qualification = row.Cells[0].Text;
            string Pyear = row.Cells[1].Text;
            string Grade = row.Cells[2].Text;
            string University = row.Cells[3].Text;

            dt.Rows.Add(EmpChieldID, Qualification, Pyear, Grade, University);
            EmPpDal objbal = new EmPpDal();
            if (GridView1.Rows.Count > 0)
            {
                DataTable j = objbal.AddQulificionDetails(dt, EmpChieldID);
            }
            else
                litErrorMessage.Text = "Please Add Qualification Details.";


        }
    }


    private void SaveData()
    {
        string Output = string.Empty;


        EmployeeBO objempBo = new EmployeeBO();

        objempBo.Fname = txtFName.Text;
        objempBo.MName = "";
        objempBo.LName = "";
        objempBo.SName = "";
        //objempBo.SName = txtLName.Text;
        objempBo.AtdharName = txtAdhar.Text;

        string dt = Request.Form[txtDOB.UniqueID];
        objempBo.DOB = dt;

       
        if (rbMale.Checked)
        {
            gender = "Male";
        }
        else if (rbFemale.Checked)
        {
            gender = "Female";
        }

        objempBo.Gender = gender;
        objempBo.Age = txtAge.Text;



        //string filename = Path.GetFileName(fileuploadimages.PostedFile.FileName);
        //if (filename != null)
        //{
        //    fileuploadimages.SaveAs(Server.MapPath("~/Images/" + filename));
        //    objempBo.Pphoto = filename.ToString();
        //}
        objempBo.PanNo = txtPan.Text;
        objempBo.Email = txtEmail.Text;
        objempBo.ContactNo = txtContactNo.Text;
        objempBo.AltContact = txtAContactNo.Text;
        objempBo.CAddress = txtxCAdd.Text;
        objempBo.PAddress = txtPadd.Text;
        objempBo.State = txtState.Text;
        objempBo.City = txtCity.Text;
        objempBo.Pincode = txtpincode.Text;
        objempBo.EmpId = txtEmpid.Text;
        objempBo.Dsgn = txtdsgn.Text;
        objempBo.Dept = drpDept.SelectedItem.Text;
        objempBo.BatchName = drpBranch.SelectedItem.Text;
        objempBo.DOJ = txtDOJ.Text;
        objempBo.EmpStatus = txtEmpStatus.Text;
        objempBo.Bgroup = txtBG.Text;
        objempBo.HealthID = txtHID.Text;

        objempBo.Qualification = txtQualification.Text;
        objempBo.Pyear = txtPyear.Text;
        objempBo.Grade = txtGrade.Text;
        objempBo.University = txtUnversity.Text;
        objempBo.CompName = txtCname.Text;
        objempBo.Period = txtPeriod.Text;
        objempBo.frm = "";
        objempBo.tto = txtto.Text;
        objempBo.dsgnn = txtCdsgn.Text;
        objempBo.OrgId = orgId.ToString();
          objempBo.BranchId = branchId.ToString();
        int deptId =int.Parse(db.getData("select deptId from AddDepartment where deptName='"+drpDept.SelectedItem.Text+"'"));
        objempBo.DeptId = deptId.ToString();
        //string fileDoc = Path.GetFileName(DocId.PostedFile.FileName);
        //DocId.SaveAs(Server.MapPath("~/Images/" + fileDoc));

        //objempBo.Documents = fileDoc.ToString();



        EmPpDal objbal = new EmPpDal();

        EmpChieldID = objbal.AddEmplDetails(objempBo);


    }
    protected void BindGridwithExp()
    {
        
            GrdExp.DataSource = (DataTable)ViewState["Expirence"];
            GrdExp.DataBind();
        
    }

    protected void BindGrid()
    {
      
            GridView1.DataSource = (DataTable)ViewState["Qulification"];
            GridView1.DataBind();
        
    }
    protected void Insert(object sender, EventArgs e)
    {

        DataTable dt;
        //dt.Rows.Clear();
        if (Request.QueryString["EmployeeId"] != null)
        {
            dt = objbal.fillQualification(Request.QueryString["EmployeeId"]);
            this.BindGrid();
        }
        else
        {
            dt = (DataTable)ViewState["Qulification"];

            if (txtQualification.Text != "" && txtPyear.Text != "" && txtGrade.Text != "" && txtUnversity.Text!="")
            {
                dt.Rows.Add("", txtQualification.Text.Trim(), txtPyear.Text.Trim(), txtGrade.Text.Trim(), txtUnversity.Text.Trim());
                ViewState["Qulification"] = dt;
                this.BindGrid();
                txtQualification.Text = string.Empty;
                txtPyear.Text = string.Empty;
                txtGrade.Text = string.Empty;
                txtUnversity.Text = string.Empty;
            }
           
        }
    }
    protected void Btn_AddExp_Click(object sender, EventArgs e)
    {
        DataTable dtExp;
       // dtExp.Rows.Clear();
        if (Request.QueryString["EmployeeId"] != null)
        {
            dtExp = objbal.fillExperience(Request.QueryString["EmployeeId"]);
            this.BindGridwithExp();
        }
        else
            dtExp = (DataTable)ViewState["Expirence"];

        if (txtCname.Text != "" && txtPeriod.Text != "" && txtto.Text != "" && txtCdsgn.Text != "")
        {
            dtExp.Rows.Add("", txtCname.Text.Trim(), txtPeriod.Text.Trim(), txtto.Text.Trim(), txtCdsgn.Text.Trim());
            ViewState["Expirence"] = dtExp;
            this.BindGridwithExp();
            txtCname.Text = string.Empty;
            txtPeriod.Text = string.Empty;
            txtto.Text = string.Empty;
            txtCdsgn.Text = string.Empty;
        }
       
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt;
        int index = Convert.ToInt32(e.RowIndex);
        if (Request.QueryString["EmployeeId"] != null)
        {
            dt = objbal.fillQualification(Request.QueryString["EmployeeId"]);

           // this.BindGridwithExp();
        }
        else
             dt = ViewState["Qulification"] as DataTable;

        dt.Rows[index].Delete();
        ViewState["dt"] = dt;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //BindGrid();
    }
    protected void OnRowDeletingExp(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt;
        int index = Convert.ToInt32(e.RowIndex);
        if (Request.QueryString["EmployeeId"] != null)
        {
            dt = objbal.fillExperience(Request.QueryString["EmployeeId"]);
           // this.BindGridwithExp();
        }
        else
             dt = ViewState["Expirence"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["dt"] = dt;
        // BindGridwithExp();
        GrdExp.DataSource = dt;
        GrdExp.DataBind();
    }

    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
      txtAge.Text= get_age(Convert.ToDateTime(txtDOB.Text)).ToString();
    }
    public int get_age(DateTime dob)
    {
        int age = 0;
        age = DateTime.Now.Subtract(dob).Days;
        age = age / 365;
        return age;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked)
            {
                gender = "Female";
            }
            int deptId = int.Parse(db.getData("select deptId from AddDepartment where deptName='" + drpDept.SelectedItem.Text + "'"));
            //update Emp Details,Qualification Details and Exp Details
            SqlParameter[] param = new SqlParameter[]
          {
            new SqlParameter("@FName",txtFName.Text),
            new SqlParameter("@aadharNo",txtAdhar.Text),
             new SqlParameter("@dob",txtDOB.Text),
             new SqlParameter("@age",txtAge.Text),
             new SqlParameter("@gender",gender),
             new SqlParameter("@panNo",txtPan.Text),
             new SqlParameter("@email",txtEmail.Text),
             new SqlParameter("@contactNo",txtContactNo.Text),
             new SqlParameter("@altContact",txtAContactNo.Text),
             new SqlParameter("@address",txtxCAdd.Text),
             new SqlParameter("@pAddress",txtPadd.Text),
             new SqlParameter("@state",txtState.Text),
             new SqlParameter("@city",txtCity.Text),
             new SqlParameter("@pinCode",txtpincode.Text),
             new SqlParameter("@empId",txtEmpid.Text),
             new SqlParameter("@designation",txtdsgn.Text),
             new SqlParameter("@dept",drpDept.SelectedItem.Text),
             new SqlParameter("@branchName",drpBranch.SelectedItem.Text),

             new SqlParameter("@doj",txtDOJ.Text),
             new SqlParameter("@empStatus",txtEmpStatus.Text),
             new SqlParameter("@bloodGrp",txtBG.Text),
             new SqlParameter("@healthId",txtHID.Text),
             new SqlParameter("@branchId",drpBranch.SelectedItem.Value),
             
            new SqlParameter("@deptId",deptId),
             new SqlParameter("@compName",txtCname.Text),
             new SqlParameter("@from",txtPeriod.Text),
             new SqlParameter("@to",txtto.Text),
             new SqlParameter("@qualification",txtQualification.Text),
             new SqlParameter("@passYear",txtPyear.Text),
             new SqlParameter("@grade",txtGrade.Text),
             new SqlParameter("@university",txtUnversity.Text),
              new SqlParameter("@employeeId",Request.QueryString["EmployeeId"].ToString()),
             new SqlParameter ("@Returnval",SqlDbType.Int)
           };
            int returnval = DAL.ExecuteStoredProcedureRetnInt("SP_UpdateEmployeeDetails", param); //Update EmpDetails 

            if (returnval == 1)
            {
                // Update App User,UserLoginMaster
                SqlParameter[] paramAppUser = new SqlParameter[]
            {
            new SqlParameter("@sFullName",txtFName.Text),
            new SqlParameter("@sMobile",CryptoHelper.Encrypt(txtContactNo.Text)),
             new SqlParameter("@sEmailId",CryptoHelper.Encrypt(txtEmail.Text)),
             new SqlParameter("@sGender",gender),
             new SqlParameter("@sBirthDate",txtDOB.Text),
             new SqlParameter("@sAddress",txtxCAdd.Text),
             new SqlParameter("@sCountry","India"),
             new SqlParameter("@sState",txtState.Text),
             new SqlParameter("@sCity",txtCity.Text),
             new SqlParameter("@sPincode",txtpincode.Text),
             new SqlParameter("@AadharCard",CryptoHelper.Encrypt(txtAdhar.Text)),
             new SqlParameter("@EmployeeId",Request.QueryString["EmployeeId"].ToString()),
             new SqlParameter ("@Returnval",SqlDbType.Int)
             };
            int returnvalAppuser = DAL.ExecuteStoredProcedureRetnInt("SP_updateAppUser", paramAppUser);

            }

            // insert into Deactivated EMployee Details table
            SqlParameter[] paramDeactiveUser = new SqlParameter[]
        {
            new SqlParameter("@orgId",orgId),
            new SqlParameter("@empId",Request.QueryString["EmployeeId"].ToString()),
             new SqlParameter("@reason",txtReason.Text),
              new SqlParameter("@deactivatedBy",""),
               new SqlParameter("@date",System.DateTime.Now.ToString("MM/dd/yyyy")),
               new SqlParameter("@Returnval",SqlDbType.Int),
        };
            int returnvalDeactiveEmp = DAL.ExecuteStoredProcedureRetnInt("SP_AddDeactivatedEmployee", paramDeactiveUser);


          //  ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Updated Successfully!\");", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "insertSuccess", "alert('Employee Updated successfully');location.href='EmployeeDetails.aspx';", true);        //for display employee details list


            clearallText();
            BtnUpdate.Visible = false;
            BtnDelete.Visible = false;
            BtnSave.Visible = true;
           // Response.Redirect("EmployeeDetails.aspx");
        }
        catch(Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        EmPpDal objdal = new EmPpDal();
        objdal.DeleteEmployeeDetails(Request.QueryString["EmployeeId"].ToString());
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "insertSuccess", "alert('Employee Deleted successfully');location.href='EmployeeDetails.aspx';", true);        //for display employee details list

    }
    protected void drpEmpStatus_TextChanged(object sender, EventArgs e)
    {
        


    }

    protected void drpEmpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (drpEmpStatus.Text == "Deactive")
        //    divReason.Visible = true;
    }
}