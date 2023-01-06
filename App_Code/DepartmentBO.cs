using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentBO
/// </summary>
public class DepartmentBO
{
    private string _deptName;
    private string _Status;
    public DepartmentBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string deptName
    {
        get
        {
            return _deptName;
        }
        set
        {
            _deptName = value;
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
}