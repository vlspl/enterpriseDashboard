using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessHandler;
using CrossPlatformAESEncryption.Helper;

public partial class MIS_Reports : System.Web.UI.Page
{
    DBClass db = new DBClass();
    DataAccessLayer DAL = new DataAccessLayer();
    string  branchId, userId;
    int OrgId;
    protected void Page_Load(object sender, EventArgs e)
    {
        branchId = Session["BranchId"].ToString();
        OrgId = int.Parse(Session["OrgId"].ToString());
        if (!this.IsPostBack)
        {
            db.bindDrp("select rpt_Name from MISReportMaster", DropDownList1, "rpt_Name", "rpt_Name");
            DropDownList1.Items.Insert(0, new ListItem("All", "All"));
        }
    }
    void bindGrid()
    {
        string spName = db.getData("select spName from MISReportMaster where rpt_Name='" + DropDownList1.Text + "'").ToString();
        string frodate = txtfromDate.Text;
        string todate = txttodate.Text;
        string d1 = frodate;
        string d2 = todate;
        DateTime appointdt1 = DateTime.ParseExact(d1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime appointdt2 = DateTime.ParseExact(d2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        string startDate = appointdt1.ToString("MM/dd/yyyy");
        string EndDate = appointdt2.ToString("MM/dd/yyyy");
        GridView1.DataSource = GetEmpDetails(spName, branchId, OrgId, startDate, EndDate);
        GridView1.DataBind();
        btnexporttoexcel.Visible = true;
        DataTable dt = new DataTable();
        dt = GetEmpDetails(spName, branchId, OrgId, startDate, EndDate);
    }
    protected void Btn_Show_Click(object sender, EventArgs e)
    {
        //string LabId = Request.Cookies["LabId"].Value.ToString();
        bindGrid();
    }
    public DataTable GetEmpDetails(string spName, string branchId,int orgId, string startDate, string EndDate)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlParameter[] paramMISReport = new SqlParameter[]
             {
                 new SqlParameter("@parentbranchId",branchId),
                 new SqlParameter("@orgId",OrgId),
                 new SqlParameter("@gender",""),
                 new SqlParameter("@dept",""),
                 new SqlParameter("@branchNm",""),
                 new SqlParameter("@frmdate",startDate),
                 new SqlParameter("@toDate",EndDate)


              };
            dt = DAL.ExecuteStoredProcedureDataTable(spName, paramMISReport);
            return dt;
        }
        catch (Exception ex)
        {
            dt = null;
            return dt;
        }

    }

    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", " " + DropDownList1.Text + "" + ".xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            //BindGridview();
            //Change the Header Row back to white color
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            {
                GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#f3f6ff");
            }
            GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindGrid();
    }
 protected void grvReportDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string mobNo = (dr["Mobile No"].ToString());
            string emailId = (dr["Email Id"].ToString());

            if (emailId != "")
                e.Row.Cells[2].Text = CryptoHelper.Decrypt(emailId);
            else
                e.Row.Cells[2].Text = (emailId);
            if (mobNo != "")
                e.Row.Cells[3].Text = CryptoHelper.Decrypt(mobNo);
            else
                e.Row.Cells[3].Text = (mobNo);
        }
    }
public override void VerifyRenderingInServerForm(Control control)
{
  /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
     server control at run time. */
}
}