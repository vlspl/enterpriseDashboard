using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssignTestBO
/// </summary>
public class AssignTestBO
{
    private string _DeptName;
    private string _branch;
    private string _age;
    private string _employee;
    private string _test;
    private string _period;
    public AssignTestBO()
    {
        //
        // TODO: Add constructor logic here
        //
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
    public string Employee
    {
        get
        {
            return _employee;
        }
        set
        {
            _employee = value;
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
        public string Period
    {
        get
        {
            return _period;
        }
        set
        {
            _period = value;
        }
    }
       
}
