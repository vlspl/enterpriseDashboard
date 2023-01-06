using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Department : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        insert();
    }
    private void insert()
    {
        string Output = string.Empty;


        DepartmentBO objDeptBo = new DepartmentBO();

        objDeptBo.deptName = txtdeptName.Text;
        objDeptBo.status = drpStatus.Text;




        DeptDal objdal = new DeptDal();

        int j = objdal.AddDeptDetails(objDeptBo,"","");


    }
}