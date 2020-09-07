using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class contacttracingreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {
                    if (Session["contacttracingtbox"] != null)
                    {
                        Session["contacttracingtbox"] = "";
                    }
                    SqlDataSource1.SelectCommand = " select * into #dhpidtb from (select distinct b.id from quarantinetbl as a " +
" left join " +
" DHRtbl as b " +
" on a.empno = b.empno and cast(a.sdate as date) <= cast(b.rdate as date) " +
" where a.edate = '') as tb " +
" select A.ID,A.EMPNO,A.DHPID,B.SURNAME+', '+B.FIRSTNAME+' '+B.MI AS PATIENT,A.FULLNAME,A.DATED,A.REMARKS from personsinteract AS A " +
" LEFT JOIN EMPTBL AS B ON A.EMPNO = B.EMPNO " +
" where A.dhpid in (select id from #dhpidtb) and (B.SURNAME like '%'+'" + Session["contacttracingtbox"].ToString() + "'+'%' or B.FIRSTNAME like  '%'+'" + Session["contacttracingtbox"].ToString() + "'+'%') ";
                    SqlDataSource1.ConnectionString = sqlconstr;   
                    ReportViewer2.LocalReport.Refresh();
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
    }
}