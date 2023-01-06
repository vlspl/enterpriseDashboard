using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalBal
/// </summary>
public class HospitalBal
{
    public HospitalBal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SaveHospitalBL(hospitalLabBO hospitalBL) // passing Bussiness object Here  
    {
        try
        {

            hospitalDAL objHospital = new hospitalDAL(); // Creating object of Dataccess  
            return objHospital.AddHospitalDetails(hospitalBL); // calling Method of DataAccess  
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}