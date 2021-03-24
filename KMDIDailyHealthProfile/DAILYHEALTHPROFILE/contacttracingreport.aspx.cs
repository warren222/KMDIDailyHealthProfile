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
                    if (Session["contacttracingtbox"] == null)
                    {
                        Session["contacttracingtbox"] = "";
                    }
                    string d = Session["contacttracingtbox"].ToString();
                    SqlDataSource1.SelectCommand = " declare @date as varchar(30)='" + d + "' " +
"  SELECT EMPNO,FULLNAME, Person_Interract, DEPARTMENT,POSCODE,@date AS DATE " +
"  FROM ( " +
" 			 SELECT A.EMPNO, CONCAT(b.SURNAME, ', ',b.FIRSTNAME) AS FULLNAME, CAST( " +
" 					CASE " +
" 					     WHEN name is null " +
" 					        THEN 0 " +
" 					     ELSE 1 " +
" 					END AS bit) as Person_Interract, A.RDATE, b.DEPARTMENT,b.POSCODE " +
" 			 FROM ( " +
" 					 SELECT DISTINCT A.EMPNO,A.RDATE,NAME,DEPARTMENT,POSCODE " +
" 					 FROM (  " +
" 							SELECT a.[EMPNO] " +
" 								  ,a.ID " +
" 							      ,[RDATE] " +
" 							FROM [DHPDB].[dbo].[DHRtbl] as A " +
" 							LEFT JOIN [DHPDB].[dbo].[EMPTBL] as B " +
" 							on a.EMPNO = b.EMPNO " +
" 					  WHERE RDATE = cast(@date as date) and B.userstatus = 'Active' " +
" 					       ) as A " +
" 					  LEFT JOIN ( " +
" 									SELECT B.ID, B.EMPNO,RDATE, CONCAT(SURNAME, ', ',FIRSTNAME) AS NAME, DEPARTMENT,POSCODE  " +
" 									FROM [DHPDB].[dbo].[DHRtbl] AS b  " +
" 									LEFT JOIN [DHPDB].[dbo].[EMPTBL] AS c " +
" 									ON b.empno = c.empno  " +
" 									WHERE b.rdate = cast(@date AS DATE) and b.id in (select distinct a.dhpid from [DHPDB].[dbo].[PERSONSINTERACT] as a where a.dhpid = b.id)) AS B " +
" 					ON A.ID = B.ID ) as A " +
" 			LEFT JOIN [DHPDB].[dbo].[EMPTBL] AS b " +
" 			ON a.EMPNO = b.EMPNO) AS a " +
"  WHERE POSCODE <> '' " +
"  ORDER BY Person_Interract ASC,DEPARTMENT ASC, FULLNAME ASC ";
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