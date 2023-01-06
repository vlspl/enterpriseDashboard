using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BranchBal
/// </summary>
public class BranchBal
{
    public BranchBal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SaveBranchBL(BranchBO branchBL) // passing Bussiness object Here  
    {
        try
        {

            BranchDal objbranch = new BranchDal(); // Creating object of Dataccess  
            return objbranch.AddBranchDetails(branchBL,""); // calling Method of DataAccess  
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}