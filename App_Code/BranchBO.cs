using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BranchBO
/// </summary>
public class BranchBO
{
    private string _branchName;
    private string _Status;
    private string _address;
    private string _country;
    private string _State;
    private string _city;
    private string _zipCode;
    private string _mobileNo;
    private string _email;
    private string _orgId;
    private string _ParentBranch;
   // private string _Status;
    private string _UserNameBranch;
    private string _Designation;
    public BranchBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string BranchName
    {
        get
        {
            return _branchName;
        }
        set
        {
            _branchName = value;
        }
    }
    public string status
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
    public string Address
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }
    public string Country
    {
        get
        {
            return _country;
        }
        set
        {
            _country = value;
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
            return _city;
        }
        set
        {
            _city = value;
        }
    }
    public string ZipCode
    {
        get
        {
            return _zipCode;
        }
        set
        {
            _zipCode = value;
        }
    }
    public string MobileNo
    {
        get
        {
            return _mobileNo;
        }
        set
        {
            _mobileNo = value;
        }
    }
    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            _email = value;
        }
    }

    public string OrgId
    {
        get
        {
            return _orgId;
        }
        set
        {
            _orgId = value;
        }
    }




    public string ParentBranch
    {
        get
        {
            return _ParentBranch;
        }
        set
        {
            _ParentBranch = value;
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
    public string UserNameBranch
    {
        get
        {
            return _UserNameBranch;
        }
        set
        {
            _UserNameBranch = value;
        }
    }
    public string Designation
    {
        get
        {
            return _Designation;
        }
        set
        {
            _Designation = value;
        }
    }
}