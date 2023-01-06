using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LabBO
/// </summary>
public class LabBO
{
    private string _labName;
    private string _labOwner;
    private string _emailId;
    private string _Address;
    private string _contactNo;
    private string _latitude;
    private string _status;
    private string _userNm;
    private string _password;
    private string _confirmPassword;
    private string _location;
    private string _createdBy;
    private string _createdAt;
    public LabBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string LabName
    {
        get
        {
            return _labName;
        }
        set
        {
            _labName = value;
        }

    }
    public string LabOwner
    {
        get
        {
            return _labOwner;
        }
        set
        {
            _labOwner = value;
        }

    }
    public string EmailId
    {
        get
        {
            return _emailId;
        }
        set
        {
            _emailId = value;
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
    public string contactNo
    {
        get
        {
            return _contactNo;
        }
        set
        {
            _contactNo = value;
        }

    }
    public string Status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
        }

    }
    public string latitude
    {
        get
        {
            return _latitude;
        }
        set
        {
            _latitude = value;
        }

    }
    public string userName
    {
        get
        {
            return _userNm;
        }
        set
        {
            _userNm = value;
        }

    }
    public string password
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
        }

    }
    public string Confirmpassword
    {
        get
        {
            return _confirmPassword;
        }
        set
        {
            _confirmPassword = value;
        }

    }
    public string Location
    {
        get
        {
            return _location;
        }
        set
        {
            _location = value;
        }

    }
    public string CreatedBy
    {
        get
        {
            return _createdBy;
        }
        set
        {
            _createdBy = value;
        }

    }
    public string CreatedAt
    {
        get
        {
            return _createdAt;
        }
        set
        {
            _createdAt = value;
        }

    }
}