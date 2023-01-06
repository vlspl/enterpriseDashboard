using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeHealthInsurance : System.Web.UI.Page
{
    public int EmpChieldID;
    InsuranceDal objdal = new InsuranceDal();
    DataTable dtFillData;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            objdal.bindDrp("select deptName from AddDepartment ", drpDept, "deptName", "deptName");
            drpDept.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"
          
            objdal.bindDrp("select branchName from AddBranch ", drpBranch, "branchName", "branchName");
            drpBranch.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"
           
            objdal.bindDrp("select hospitalName from Hospital_LabMaster ", drpHospital, "hospitalName", "hospitalName");
            drpHospital.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"
          
            objdal.bindDrp("select City_branch from EnterpriseData ", drpCity, "City_branch", "City_branch");
            drpCity.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"

            if (Request.QueryString["insuranceId"] != null)
            {
                dtFillData = objdal.fillData(Request.QueryString["insuranceId"]);
                foreach (DataRow row in dtFillData.Rows)
                {
                    // basic Info
                    txtPolicy.Text = row["policyName"].ToString();
                    drpDept.Text = row["deptName"].ToString();
                    drpBranch.Text = row["branch"].ToString();
                    drpState.Text= row["state"].ToString();
                    drpCity.Text= row["city"].ToString();
                    txtAge.Text = row["age"].ToString();
                    drpGender.Text = row["gender"].ToString();
                    drpHospital.Text = row["hospitalNm"].ToString();
                    drpStatus.Text = row["status"].ToString();


                }
                BtnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        SaveData();
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
        Response.Redirect("EmployeeInsuranceDetails.aspx");
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
      
        objdal.DeleteInsuranceDetails(int.Parse(Request.QueryString["insuranceId"]));

        SaveData();
        BtnSave.Visible = true;
        btnUpdate.Visible = false;
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Updated Successfully!\");", true);
        Response.Redirect("EmployeeInsuranceDetails.aspx");
    }
    private void SaveData()
    {
        string Output = string.Empty;


        InsuranceBO objempInsurancehBo = new InsuranceBO();

        objempInsurancehBo.PolicyName = txtPolicy.Text;
        objempInsurancehBo.DeptName = drpDept.Text;
        objempInsurancehBo.Branch = drpBranch.Text;
        objempInsurancehBo.State = drpState.Text;
        objempInsurancehBo.City = drpCity.Text;
        objempInsurancehBo.Age = txtAge.Text;
        //objempBo.SName = txtLName.Text;
        objempInsurancehBo.Gender = drpGender.Text;
        objempInsurancehBo.HospitalNm = drpHospital.Text;
        objempInsurancehBo.Status = drpStatus.Text;

        EmpChieldID = objdal.AddInsuranceDetails(objempInsurancehBo);


    }
}