using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InsuranceBO
/// </summary>
public class InsuranceBO
{
    private string _policyName;
    private string _DeptName;
    private string _branch;
    private string _state;
    private string _city;

    private string _age;
    private string _gender;
    private string _hospitalNm;
    private string _status;
    public InsuranceBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string PolicyName
    {
        get
        {
            return _policyName;
        }
        set
        {
            _policyName = value;
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
    public string State
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
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
    public string HospitalNm
    {
        get
        {
            return _hospitalNm;
        }
        set
        {
            _hospitalNm = value;
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
}