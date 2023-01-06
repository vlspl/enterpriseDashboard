using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginBO
/// </summary>
public class LoginBO
{
    private string _userName;
    private string _password;
    public LoginBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string UserName
    {
        get
        {
            return _userName;
        }
        set
        {
            _userName = value;
        }
    }
    public string Password
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
}