using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserCreationBO
/// </summary>
public class UserCreationBO
{
    private string _Name, _designation,_country, _city, _mobile, _emailId, _dept, _pwd, _masterId, _orgId, _remark;
    private string _createdBy,_editedBy,_deletedBy;
    private DateTime _CreatedDate, _editedDate, _deletedDate;


    public UserCreationBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Name
    {
        get
        {
            return _Name;
        }
        set
        {
            _Name = value;
        }
    }
    public string Designation
    {
        get
        {
            return _designation;
        }
        set
        {
            _designation = value;
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
    public string MobileNo
    {
        get
        {
            return _mobile;
        }
        set
        {
            _mobile = value;
        }
    }
    public string Email
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
    public string Department
    {
        get
        {
            return _dept;
        }
        set
        {
            _dept = value;
        }
    }
    public string Password
    {
        get
        {
            return _pwd;
        }
        set
        {
             _pwd = value; ;
 
        }
    }
    public string masterId
    {
        get
        {
            return _masterId;
        }
        set
        {
            _masterId = value; 

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
    public string Remark
    {
        get
        {
            return _remark;
        }
        set
        {
            _remark = value;

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
    public DateTime CreatedDate
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
    public string EditedBy
    {
        get
        {
            return _editedBy;
        }
        set
        {
            _editedBy = value;

        }
    }
    public DateTime EditedDate
    {
        get
        {
            return _editedDate;
        }
        set
        {
            _editedDate = value;

        }
    }
    public string DeletedBy
    {
        get
        {
            return _deletedBy;
        }
        set
        {
            _deletedBy = value;

        }
    }
    public DateTime DeletedDate
    {
        get
        {
            return _deletedDate;
        }
        set
        {
            _deletedDate = value;

        }
    }
}