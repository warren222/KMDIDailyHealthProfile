using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class travelhistory : System.Web.UI.Page
    {
        private string sqlconstr
        {
            get
            {
                return ConnectionString.sqlconstr();

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {
                    tboxDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    SqlDataSource1.ConnectionString = sqlconstr;
                    ReportViewer1.LocalReport.Refresh();
                }
            }
            else
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = sqlconstr;
            ReportViewer1.LocalReport.Refresh();
        }
    }
}