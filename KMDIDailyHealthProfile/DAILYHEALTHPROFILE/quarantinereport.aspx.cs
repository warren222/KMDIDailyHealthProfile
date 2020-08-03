using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class quarantinereport : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["mydepartment"] = dpdepartment.Text;
                cbvalue();
                loadparameter();
            }
        }
        private void loadparameter()
        {
            ReportParameter param1 = new ReportParameter("department", dpdepartment.Text);
            ReportViewer1.LocalReport.SetParameters(param1);
            ReportViewer1.LocalReport.Refresh();
        }
        private void cbvalue()
        {
            if (cboxuq.Checked)
            {
                Session["rb"] = "1";
            }
            else
            {
                Session["rb"] = "0";
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


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["mydepartment"] = dpdepartment.Text;
            cbvalue();
            loadparameter();
            ReportViewer1.LocalReport.Refresh();
        }
    }
}