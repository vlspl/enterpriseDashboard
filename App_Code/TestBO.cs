using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Test
/// </summary>
public class TestBO
{
    private string _testName;
    private string _Status;
    private string _Range;
    public TestBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string testName
    {
        get
        {
            return _testName;
        }
        set
        {
            _testName = value;
        }
    }
    public string range
    {
        get
        {
            return _Range;
        }
        set
        {
            _Range = value;
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