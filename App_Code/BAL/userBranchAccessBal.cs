using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for userBranchAccessBal
/// </summary>
public class userBranchAccessBal
{
    public userBranchAccessBal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SaveBranchBL(userBranchAssignBO userBranchAssignBal) // passing Bussiness object Here  
    {
        try
        {

           
            userBranchAccessDAL objbranchAcess = new userBranchAccessDAL(); // Creating object of Dataccess  
            return objbranchAcess.userBranchAssignDetails(userBranchAssignBal,0,0); // calling Method of DataAccess  
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}