using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webaftersales.DAILYHEALTHPROFILE
{
    public partial class dhpfullimage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {
               
                if (!IsPostBack)
                {
                    Image1.ImageUrl = Request.QueryString["dhpImageUrl"];
                   
                }
                if (acct == "Admin")
                {
                    Button1.Visible = true;
                }
                else
                {
                    Button1.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
            }
        }
        private string acct
        {
            get
            {
                return Session["dhp_USERACCT"].ToString();
            }
        }
        private string imagepath
        {
            get
            {
                return Session["dhpimgpath"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            File.Delete(Server.MapPath(imagepath));
            Response.Redirect("~/DAILYHEALTHPROFILE/dhppage2.aspx");
        }
    }

}