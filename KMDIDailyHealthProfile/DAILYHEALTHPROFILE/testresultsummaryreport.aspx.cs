using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class testresultsummaryreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {
                    SqlDataSource1.ConnectionString = sqlconstr;
                    SqlDataSource1.SelectCommand = " SELECT TEST,ID,EMPNO,DHPID,CASE WHEN ISDATE(DATETESTDONE)=1 THEN FORMAT(CAST(DATETESTDONE AS DATE),'MMMM-dd-yyyy') ELSE DATETESTDONE END AS DATETESTDONE " +
",CASE WHEN ISDATE(TIMETEST)=1 THEN FORMAT(CAST(TIMETEST AS datetime),'hh:mm tt') ELSE TIMETEST END AS TIMETEST " +
",SERIALNO,TESTRESULT,ADMINISTEREDBY,[PHYSICIAN],[LICENSENO],FULLNAME " +
" FROM ( SELECT 'RAPID TEST' AS TEST,[ID] " +
"      ,a.[EMPNO] " +
"      ,[DHPID] " +
"      ,[DATETESTDONE]	 " +
"      ,[TIMETEST]		 " +
"      ,[SERIALNO]		 " +
"      ,[TESTRESULT]	 " +
"      ,[ADMINISTEREDBY] " +
"      ,[PHYSICIAN]		 " +
"      ,[LICENSENO]		 " +
"	  ,b.SURNAME+', '+b.FIRSTNAME+' '+MI AS FULLNAME  " +
"       FROM [DHPPAGE2] as a left join emptbl as b	  " +
"       on a.empno = b.empno						  " +
"        WHERE datetestdone <> '' AND (SURNAME LIKE '%" + Session["testresultsearchkey"].ToString() +"%' or firstname like '%"+ Session["testresultsearchkey"].ToString() + "%')  " +
"		UNION ALL  " +
"	   SELECT 'ANTIGEN TEST',[ID] " +
"      ,a.[EMPNO]		  " +
"      ,[DHPID]			  " +
"      ,ANTIGENDATE		  " +
"      ,ANTIGENTIME		  " +
"      ,ANTIGENSERIAL	  " +
"      ,ANTIGENRESULT	  " +
"      ,[ADMINISTEREDBY]  " +
"      ,[PHYSICIAN]		  " +
"      ,[LICENSENO]		  " +
"	  ,b.SURNAME+', '+b.FIRSTNAME+' '+MI AS FULLNAME  " +
"       FROM [DHPPAGE2] as a left join emptbl as b  " +
"       on a.empno = b.empno  " +
"        WHERE ANTIGENDATE <> '' AND (SURNAME LIKE '%"+ Session["testresultsearchkey"].ToString() + "%' or firstname like '%" + Session["testresultsearchkey"].ToString() + "%')  " +
"		) AS TB  " +
"		order by case when isdate(datetestdone)=1 then cast([DATETESTDONE] as date) else datetestdone end desc,  " +
"        CASE WHEN ISDATE(TIMETEST)=1 THEN cast(TIMETEST AS datetime) ELSE TIMETEST END desc ";
                    ReportViewer1.LocalReport.Refresh();
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
    }
}