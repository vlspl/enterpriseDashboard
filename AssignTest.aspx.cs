using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssignTest : System.Web.UI.Page
{
    public int EmpChieldID;
    AssignTestDal objdal = new AssignTestDal();
    DataTable dtFillData;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            objdal.bindDrp("select deptName from AddDepartment ", drpDept,"deptName","deptName");
            objdal.bindDrp("select branchName from AddBranch ", drpBranch, "branchName", "branchName");
            objdal.bindDrp("select FName from EmployeeDetails ", drpEmployee, "FName", "FName");
            objdal.bindDrp("select testName from AddTest ", drptest, "testName", "testName");

            if (Request.QueryString["assignTestId"] != null)
            {
                dtFillData = objdal.fillData(Request.QueryString["assignTestId"]);
                foreach (DataRow row in dtFillData.Rows)
                {
                 
                    drpDept.Text = row["deptName"].ToString();
                    drpBranch.Text = row["branch"].ToString();
                    txtAge.Text = row["age"].ToString();
                    drpEmployee.Text = row["employee"].ToString();
                    drptest.Text = row["test"].ToString();
                    txtPeriod.Text = row["period"].ToString();
                }
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        insert();


    }
  
    private void insert()
    {
        try
        {
            string Output = string.Empty;
            AssignTestBO objAssignTestBO = new AssignTestBO();

            objAssignTestBO.DeptName = drpDept.Text;
            objAssignTestBO.Branch = drpBranch.Text;
            objAssignTestBO.Age=txtAge.Text;
            objAssignTestBO.Employee=drpEmployee.Text;
            objAssignTestBO.Test=drptest.Text;
            objAssignTestBO.Period=txtPeriod.Text;

            AssignTestDal objdal = new AssignTestDal();

            int j = objdal.AddAssignTestDetails(objAssignTestBO);
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);

            drpDept.Text = drpBranch.Text = drpEmployee.Text = drptest.Text = "--Select--";
            txtAge.Text = txtPeriod.Text=string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}