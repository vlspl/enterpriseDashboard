using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for userBranchAssignBO
/// </summary>
public class userBranchAssignBO
{
    private string _userName;
    private string _branchName;
    private string _status;
    private int _userId;
    private int _orgId;
    private string _createdBy;
    private DateTime _createdDate;
    private string _editedBy;
    private DateTime _editedDate;
    private string _deletedBy;
    private DateTime _deletedDate;
    private SqlConnection con;

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

    public int UserId
    {
        get
        {
            return _userId;
        }
        set
        {
            _userId = value;
        }
    }

    public int OrgId
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
            return _createdDate;
        }
        set
        {
            _createdDate = value;
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




    public userBranchAssignBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }


   
}