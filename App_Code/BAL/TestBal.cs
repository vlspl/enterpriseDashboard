using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TestBal
/// </summary>
public class TestBal
{
    public TestBal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SaveTestBL(TestBO testBL) // passing Bussiness object Here  
    {
        try
        {

            TestDal objtest = new TestDal(); // Creating object of Dataccess  
            return objtest.AddTestDetails(testBL); // calling Method of DataAccess  
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}