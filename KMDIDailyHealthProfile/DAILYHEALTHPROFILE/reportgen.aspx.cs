using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class reportgen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {

                    Session["dhpdate"] = "";

                    Session["dhpname"] = "";

                    Session["dhpage"] = "";

                    Session["dhpbirthday"] = "";

                    Session["dhpempno"] = "0";

                    Session["dhp_id"] = "0";

                    if (Session["dhpreportsearchkey"] != null)
                    {
                        tboxsearchkey.Text = Session["dhpreportsearchkey"].ToString();
                    }
                    if (Session["dhpreportdatekey"] != null)
                    {
                        tboxdate.Text = Session["dhpreportdatekey"].ToString();
                    }
                    if (Session["dhpreportcbox"] != null)
                    {
                        cboxstatus.Checked = Convert.ToBoolean(Session["dhpreportcbox"]);
                    }

                    loademployees();
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    loadreport();
                }

            }
            else
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
            }
        }
        private string sqlconstr
        {
            get
            {
                return ConnectionString.sqlconstr();
            }
        }
        private void errorrmessage(string message)
        {
            CustomValidator err = new CustomValidator();
            err.ValidationGroup = "val1";
            err.IsValid = false;
            err.ErrorMessage = message;
            Page.Validators.Add(err);
        }
        private string empno
        {
            get
            {
                return Session["dhpempno"].ToString();
            }
        }
        private string dhpid
        {
            get
            {
                return Session["dhp_id"].ToString();
            }
        }
        private void loademployees()
        {
            try
            {
                GridView1.SelectedIndex = -1;
                
                string str = "    select * into #tbl from(SELECT 																	 " +
"	a.ID,																															 " +
"	a.EMPNO,																														 " +
"	a.RDATE,																													     " +
"   A.RTIME, " +
"   CAST(DATEDIFF(DD,CAST(C.BIRTHDAY AS DATE),GETDATE())/365.25 AS INT) AS AGE," +
"   c.BIRTHDAY, " +
"	c.surname+', '+c.firstname+' '+c.mi as FULLNAME,																				 " +
"	case when																														 " +
"    DCEX  = '1' or																													 " +
"    FEEX  = '1' or																													 " +
"    MPEX  = '1' or																													 " +
"    WEEX  = '1' or																													 " +
"    DSEX  = '1' or																													 " +
"    DTEX  = '1' or																													 " +
"    DIEX  = '1' or																													 " +
"    DBEX  = '1' or																													 " +
"    LBEX  = '1' or																													 " +
"    OSEX  = '1' then 'yes' else 'no' end as [status]																				 " +
"	from ((DHRtbl as a																												 " +
"	left join ASNWERSHEETtbl as b																									 " +
"	on a.id = b.dhpid)																											 	 " +
"	left join EMPTBL AS c																										 	 " +
"	on a.empno = c.empno)																											 " +
"	where case when isdate(a.RDATE)=1 then cast(a.RDATE as date) else a.RDATE end = case when @date = '' then a.RDATE else @date end " +
"	and (c.surname like '%'+@searchkey+'%' or c.mi like '%'+@searchkey+'%' or c.firstname like '%'+@searchkey+'%')					 " +
"	) as tbl																														 " +
"	select 																															 " +
"	ID,																																 " +
"	EMPNO,																															 " +
"	FULLNAME,																														 " +
"	[status],                                                                                                                        " +
"   AGE," +
"   BIRTHDAY," +
"   RDATE,                                                                                                                            " +
"   RTIME " +
"	from #tbl where [status] = case when @status='no' then [status] else @status end												 " +
"	order by cast(RDATE as date) desc, cast(RTIME as datetime) desc																	 ";

                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        DataTable tb = new DataTable();
                        string stat = "no";
                        if (cboxstatus.Checked)
                        {
                            stat = "yes";
                        }

                        sqlcmd.Parameters.AddWithValue("@searchkey", tboxsearchkey.Text);
                        sqlcmd.Parameters.AddWithValue("@date", tboxdate.Text);
                        sqlcmd.Parameters.AddWithValue("@status", stat);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(tb);
                        GridView1.DataSource = tb;
                        GridView1.DataBind();

                        Session["dhpreportsearchkey"] = tboxsearchkey.Text;
                        Session["dhpreportdatekey"] = tboxdate.Text;
                        Session["dhpreportcbox"] = cboxstatus.Checked;
                        DataTable dt = new DataTable();

                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.ToString());
            }
        }
        private void loadreport()
        {
            ReportViewer1.LocalReport.EnableExternalImages = true;


            string blanksign = new Uri(Server.MapPath("~/images/blank.jpg")).AbsoluteUri;
            ReportParameter blankparam = new ReportParameter("patientsignature", blanksign);
            ReportViewer1.LocalReport.SetParameters(blankparam);


            string filepath = "~/Uploads/DHPuploads/page2/signature/patient/" + empno + dhpid + "/";
            string filepath2 = "~/Uploads/DHPuploads/page2/signature/physician/" + empno + dhpid + "/";
            Boolean IsExists = System.IO.Directory.Exists(Server.MapPath(filepath));
            if (!IsExists)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(filepath));
            }
            Boolean IsExists2 = System.IO.Directory.Exists(Server.MapPath(filepath2));
            if (!IsExists2)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(filepath2));
            }

            foreach (string strfilename in Directory.GetFiles(Server.MapPath(filepath)))
            {

                FileInfo fileinfo = new FileInfo(strfilename);

                string prepared = new Uri(Server.MapPath("~/Uploads/DHPuploads/page2/signature/patient/" + empno + dhpid + "/" + fileinfo.Name)).AbsoluteUri;
                ReportParameter param1 = new ReportParameter("patientsignature", prepared);
                ReportViewer1.LocalReport.SetParameters(param1);

            }
            foreach (string strfilename in Directory.GetFiles(Server.MapPath(filepath2)))
            {

                FileInfo fileinfo = new FileInfo(strfilename);

                string physician = new Uri(Server.MapPath("~/Uploads/DHPuploads/page2/signature/physician/" + empno + dhpid + "/" + fileinfo.Name)).AbsoluteUri;
                ReportParameter param1 = new ReportParameter("physiciansignature", physician);
                ReportViewer1.LocalReport.SetParameters(param1);

            }

            string s = "0";
            if (cbox.Checked)
            {
                s = "1";

            }
            string d = "";
            if (tboxdateah.Text != "")
            {
                d = Convert.ToDateTime(tboxdateah.Text).ToString("MMMM dd, yyyy");
            }
            ReportParameter dateconducted = new ReportParameter("dateconducted", d);
            ReportParameter cboxvalue = new ReportParameter("cboxvalue", s);
            ReportViewer1.LocalReport.SetParameters(dateconducted);
            ReportViewer1.LocalReport.SetParameters(cboxvalue);

            //ReportViewer1.LocalReport.Refresh();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            loademployees();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loademployees();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "myselect")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                GridView1.SelectedIndex = rowindex;
                setsession(row);
                loadreport();

            }
            if (e.CommandName == "page1")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                setsession(row);
                Session["pagesender"] = "reportgen";
                Response.Redirect("~/DAILYHEALTHPROFILE/dhpnew.aspx");
            }
            if (e.CommandName == "page2")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                setsession(row);
                Session["pagesender"] = "reportgen";
                Response.Redirect("~/DAILYHEALTHPROFILE/dhppage2.aspx");
            }
            if (e.CommandName == "page3")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                setsession(row);
                Session["pagesender"] = "reportgen";
                Response.Redirect("~/DAILYHEALTHPROFILE/dhppage3.aspx");
            }
        }
        private void setsession(GridViewRow row)
        {
            Session["dhp_id"] = ((Label)row.FindControl("lblid")).Text;
            Session["dhpdate"] = ((Label)row.FindControl("lbldate")).Text;
            Session["dhpname"] = ((Label)row.FindControl("lblname")).Text;
            Session["dhpage"] = ((Label)row.FindControl("lblage")).Text;
            Session["dhpempno"] = ((Label)row.FindControl("lblempno")).Text;
            Session["dhpbirthday"] = ((Label)row.FindControl("lblbirthday")).Text;

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            loadreport();
        }
    }
}
