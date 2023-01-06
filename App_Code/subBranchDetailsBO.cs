using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for subBranchDetailsBO
/// </summary>
public class subBranchDetailsBO
{
    //private string _UserId;
   
    private string _subBranchId;
    private int _branch_subBranchID;
    private int _parentBranchId;
    private int _branchId;
    private int _orgId;
    private string _status;
    private string _createdBy;
    private DateTime _createdDate;
    private string _editedBy;
    private DateTime _editedDate;
    private string _deletedBy;
    private DateTime _deletedDate;
    public string ParentBranch;
    public string subBranch;
   
  


    
    public string subBranchId
    {
        get
        {
            return _subBranchId;
        }
        set
        {
            _subBranchId = value;
        }
    }
    public int Branch_subBranchID
    {
        get
        {
            return _branch_subBranchID;
        }
        set
        {
            _branch_subBranchID = value;
        }
    }
    public int ParentBranchId
    {
        get
        {
            return _parentBranchId;
        }
        set
        {
            _parentBranchId = value;
        }
    }
    public int BranchId
    {
        get
        {
            return _branchId;
        }
        set
        {
            _branchId = value;
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

   // public static object SubBranch { get; internal set; }

    public subBranchDetailsBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}