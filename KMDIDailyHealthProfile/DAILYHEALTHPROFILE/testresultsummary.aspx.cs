using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class testresultsummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {
                    if (Session["testresultsearchkey"] != null)
                    {
                        tboxsearchkey.Text = Session["testresultsearchkey"].ToString();
                    }
                    loadata();
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
        private void loadata()
        {
            try
            {
                GridView1.DataSource = da.employees.getemployees(tboxsearchkey.Text, sqlconstr);
                GridView1.DataBind();
                Session["testresultsearchkey"] = tboxsearchkey.Text;
            }
            catch(Exception ex)
            {
                errorrmessage(ex.ToString());
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

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            loadata();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loadata();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["testresultsearchkey"] = tboxsearchkey.Text;
            Response.Redirect("~/DAILYHEALTHPROFILE/testresultsummaryreport.aspx");
        }
    }
}