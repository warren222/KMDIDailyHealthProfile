using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class RPTpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {

                    refreshreport();

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
        private void refreshreport()
        {
            SqlDataSource1.ConnectionString = sqlconstr;
            SqlDataSource2.ConnectionString = sqlconstr;
            SqlDataSource3.ConnectionString = sqlconstr;
            SqlDataSource4.ConnectionString = sqlconstr;
            ReportViewer1.LocalReport.EnableExternalImages = true;
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
            if (tboxdate.Text != "")
            {
                d = Convert.ToDateTime(tboxdate.Text).ToString("MMMM dd, yyyy");
            }
            ReportParameter dateconducted = new ReportParameter("dateconducted", d);
            ReportParameter cboxvalue = new ReportParameter("cboxvalue", s);
            ReportViewer1.LocalReport.SetParameters(dateconducted);
            ReportViewer1.LocalReport.SetParameters(cboxvalue);
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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["dhp_pagesender"] = "reportpage";
            Response.Redirect("~/DAILYHEALTHPROFILE/dhpsignature.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            refreshreport();
        }
    }
}