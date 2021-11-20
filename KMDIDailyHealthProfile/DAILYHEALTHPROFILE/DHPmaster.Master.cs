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
            if (Session["dhp_USERACCT"].ToString() == "Admin" || Session["dhp_DEPARTMENT"].ToString() == "Management")
            {
                LinkButton5.Visible = true;
                LinkButton4.Visible = true;
                LinkButton3.Visible = true;
                LinkButton7.Visible = true;
            }
            else
            {
                LinkButton5.Visible = false;
                LinkButton4.Visible = false;
                LinkButton3.Visible = false;
                LinkButton7.Visible = false;
            }
            if (Session["dhp_EMPNO"].ToString() == "1604-016" || Session["dhp_EMPNO"].ToString() == "1611-004")
            {
                LinkButton6.Visible = true;
            }
            else
            {
                LinkButton6.Visible = false;
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("http://dhp.kennethandmock.com");
            //Response.Redirect("http://121.58.229.248:8083/dhpApp/DAILYHEALTHPROFILE/dhplogin.aspx");
        }
        protected void lll(object sender, EventArgs e)
        {
           
        }
    }
}