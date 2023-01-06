using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssignTestBal
/// </summary>
public class AssignTestBal
{
    AssignTestBO testBo = new AssignTestBO();
    public AssignTestBal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SaveTestBL(TestBO testBL) // passing Bussiness object Here  
    {
        try
        {

            AssignTestDal objtest = new AssignTestDal(); // Creating object of Dataccess  
            return objtest.AddAssignTestDetails(testBo); // calling Method of DataAccess  
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}