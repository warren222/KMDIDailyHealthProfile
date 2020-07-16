using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webaftersales.DAILYHEALTHPROFILE
{
    public partial class DHPmaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            username.Text = Session["dhp_USERNAME"].ToString() + " ";
            if (Session["dhp_USERACCT"].ToString() == "Admin")
            {
                LinkButton3.Visible = true;
            }
            else
            {
                LinkButton3.Visible = false;
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
        }
    }
}