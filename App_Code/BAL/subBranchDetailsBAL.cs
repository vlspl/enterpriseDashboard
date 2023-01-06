using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for subBranchDetailsBAL
/// </summary>
public class subBranchDetailsBAL
{
    public subBranchDetailsBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SaveBranchBL(subBranchDetailsBO subBranchDetailsBal) // passing Bussiness object Here  
    {
        try
        {


            subBranchDetailsDAL objbranchAcess = new subBranchDetailsDAL(); // Creating object of Dataccess  
            return objbranchAcess.subBranchDetails(subBranchDetailsBal, 0); // calling Method of DataAccess  
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}