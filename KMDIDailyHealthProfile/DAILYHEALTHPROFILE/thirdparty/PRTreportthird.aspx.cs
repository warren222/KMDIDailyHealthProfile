﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE.thirdparty
{
    public partial class PRTreportthird : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                Session["dhpempno"] = empno;
                Session["dhp_id"] = dhpid;
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

            }


        }
        private string empno
        {
            get
            {
                if (Session["dhpempno"] != null)
                {
                    return Session["dhpempno"].ToString();
                }
                else
                {
                    return Request.QueryString["dhpempno"].ToString();
                }

            }
        }
        private string dhpid
        {
            get
            {
                if (Session["dhp_id"] != null)
                {
                    return Session["dhp_id"].ToString();
                }
                else
                {
                    return Request.QueryString["dhp_id"].ToString();
                }
            }
        }
    }
}