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
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    string filepath = "~/Uploads/DHPuploads/page2/signature/patient/" + empno + dhpid + "/";

                    Boolean IsExists = System.IO.Directory.Exists(Server.MapPath(filepath));
                    if (!IsExists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(filepath));
                    }


                    foreach (string strfilename in Directory.GetFiles(Server.MapPath(filepath)))
                    {

                        FileInfo fileinfo = new FileInfo(strfilename);
                      
                        string prepared = new Uri(Server.MapPath("~/Uploads/DHPuploads/page2/signature/patient/" + empno + dhpid + "/" + fileinfo.Name)).AbsoluteUri;
                        ReportParameter param1 = new ReportParameter("patientsignature", prepared);
                        ReportViewer1.LocalReport.SetParameters(param1);

                    }

                }

            }
            else
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
            }
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
    }
}