using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for hospitalLabBO
/// </summary>
public class hospitalLabBO
{
    private string _HospitalName;
    private string _State;
    private string _City;
    private string _Address;
    private string _Status;
    
    public hospitalLabBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string HospitalName
    {
        get 
        {
            return _HospitalName;
        }
        set
        {
            _HospitalName = value;
        }

    }
    public string State
    {
        get
        {
            return _State;
        }
        set
        {
            _State = value;
        }

    }
    public string City
    {
        get
        {
            return _City;
        }
        set
        {
            _City = value;
        }
    }
    public string address
    {
        get
        {
            return _Address;
        }
        set
        {
            _Address = value;
        }

    }
    public string Status
    {
        get
        {
            return _Status;
        }
        set
        {
            _Status = value;
        }

    }
}