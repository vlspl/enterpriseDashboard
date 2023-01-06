using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmpBal
/// </summary>
public class EmpBal
{

    public EmpBal()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int SaveEmployeeBL(EmployeeBO objBL) // passing Bussiness object Here  
    {
        try
        {

            EmPpDal objEmp = new EmPpDal(); // Creating object of Dataccess  
            return objEmp.AddEmplDetails(objBL); // calling Method of DataAccess  
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}