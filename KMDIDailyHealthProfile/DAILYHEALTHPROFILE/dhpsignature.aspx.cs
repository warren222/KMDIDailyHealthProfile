using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webaftersales.DAILYHEALTHPROFILE
{
    public partial class dhpsignature : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {

                }

            }
            else
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
            }
        }
        public static void UploadImage(string imageData, string fileNameWitPath)
        {
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))

                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
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
        private string pagesender
        {
            get
            {
                return Session["dhp_pagesender"].ToString();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (pagesender == "page2_patient" || pagesender == "page2_physician" || pagesender == "page2_administered" || pagesender == "page2_clientsreco" || pagesender== "reportpage")
            {
                senderbutton(pagesender);
            }
            else if (pagesender == "page3")
            {
                senderbutton(pagesender);
            }
        

        }
        private void senderbutton(string senderpage)
        {
            string filepath = "";

            if(senderpage == "page2_physician" || pagesender == "reportpage")
            {
                filepath = "~/Uploads/DHPuploads/page2/signature/physician/" + empno + dhpid + "/";
            }
            else if(senderpage == "page2_administered")
            {
                filepath = "~/Uploads/DHPuploads/page2/signature/administered/" + empno + dhpid + "/";
            }
            else if (senderpage == "page2_patient")
            {
                filepath = "~/Uploads/DHPuploads/page2/signature/patient/" + empno + dhpid + "/";
            }
            else if (senderpage == "page2_clientsreco")
            {
                filepath = "~/Uploads/DHPuploads/page2/signature/patientreco/" + empno + dhpid + "/";
            }
            else
            {
                filepath = "~/Uploads/DHPuploads/" + senderpage + "/" + "signature/" + empno + dhpid + "/";
            }
            Boolean IsExists = System.IO.Directory.Exists(Server.MapPath(filepath));
            if (!IsExists)
            {     
                System.IO.Directory.CreateDirectory(Server.MapPath(filepath));           
            }
            System.IO.DirectoryInfo folderInfo = new DirectoryInfo(Server.MapPath(filepath));
            foreach (FileInfo file in folderInfo.GetFiles())
            {
                file.Delete();
            }
            UploadImage(Request.Form["myurl"].ToString().Replace("data:image/png;base64,", ""), Server.MapPath(filepath + empno + senderpage + DateTime.Now.ToString("HH:mm:ss").Replace(":","") + ".jpg"));
            if (pagesender == "page2_patient" || pagesender == "page2_physician" || pagesender == "page2_administered" || pagesender == "page2_clientsreco")
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhppage2.aspx");
            }
            else if (pagesender == "reportpage")
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/RPTpage.aspx");
            }
            else if (pagesender == "page3")
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhppage3.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (pagesender == "page2_patient" || pagesender == "page2_physician" || pagesender == "page2_administered" || pagesender == "page2_clientsreco")
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhppage2.aspx");
            }
            else if (pagesender == "reportpage")
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/RPTpage.aspx");
            }
            else if (pagesender == "page3")
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhppage3.aspx");
            }
        }
    }
}