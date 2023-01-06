using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeptBal
/// </summary>
public class DeptBal
{

    public DeptBal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SaveDeptBL(DepartmentBO deptBL) // passing Bussiness object Here  
    {
        try
        {

            DeptDal objEmp = new DeptDal(); // Creating object of Dataccess  
            return objEmp.AddDeptDetails(deptBL,"",""); // calling Method of DataAccess  
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}