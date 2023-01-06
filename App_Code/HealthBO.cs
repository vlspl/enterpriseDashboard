using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HealthBO
/// </summary>
public class HealthBO
{
    private string _packageName;
    private string _DeptName;
    private string _branch;
    private string _age;
    private string _gender;
    private string _test;
    private string _status;
    private string _organizationName;
    private string _CreatedDate;
    public HealthBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string PackageName
    {
        get
        {
            return _packageName;
        }
        set
        {
            _packageName = value;
        }
    }
    public string organization
    {
        get
        {
            return _organizationName;
        }
        set
        {
            _organizationName = value;
        }
    }
    public string DeptName
    {
        get
        {
            return _DeptName;
        }
        set
        {
            _DeptName = value;
        }
    }
    public string Branch
    {
        get
        {
            return _branch;
        }
        set
        {
            _branch = value;
        }
    }
    public string Age
    {
        get
        {
            return _age;
        }
        set
        {
            _age = value;
        }
    }
    public string Gender
    {
        get
        {
            return _gender;
        }
        set
        {
            _gender = value;
        }
    }
    public string Test
    {
        get
        {
            return _test;
        }
        set
        {
            _test = value;
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
    public string CreatedDate
    {
        get
        {
            return _CreatedDate;
        }
        set
        {
            _CreatedDate = value;
        }
    }
}