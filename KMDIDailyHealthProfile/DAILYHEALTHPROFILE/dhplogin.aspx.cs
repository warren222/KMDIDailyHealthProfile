﻿using KMDIDailyHealthProfile.DAILYHEALTHPROFILE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webaftersales.DAILYHEALTHPROFILE
{
    public partial class dhplogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int port = HttpContext.Current.Request.Url.Port;
                switch (port)
                {
                    case 8083:
                        server1.Checked = true;
                        break;
                    case 8082:
                        server2.Checked = true;
                        break;
                    default:
                        server1.Checked = true;
                        break;
                }
                //Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                //ConnectionStringsSection sec = (ConnectionStringsSection)config.GetSection("connectionStrings");
                //sec.ConnectionStrings["DefaultConnection"].ConnectionString = "Set the connection string here";
                //config.Save();
                if (Request.Cookies["DHPusername"] != null && Request.Cookies["DHPpassword"] != null)
                {
                    tboxempno.Text = Request.Cookies["DHPusername"].Value;
                    tboxpassword.Attributes["value"] = Request.Cookies["DHPpassword"].Value;
                }
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
        protected void tboxpassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (server1.Checked)
                {
                    ConnectionString.getConnectionString("server1");
                }
                else
                {
                    ConnectionString.getConnectionString("server2");
                }
                string cs = ConnectionString.sqlconstr();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("select EMPNO,SURNAME+', '+FIRSTNAME+' '+MI AS FULLNAME,BIRTHDAY,USERACCT,USERNAME,DEPARTMENT from EMPTBL where USERNAME = @empno and PASSWORD = @Password", sqlcon);
                    sqlcmd.Parameters.AddWithValue("@empno", tboxempno.Text);
                    sqlcmd.Parameters.AddWithValue("@Password", tboxpassword.Text);
                    SqlDataReader rd = sqlcmd.ExecuteReader();
                    if (rd.HasRows)
                    {

                        while (rd.Read())
                        {
                            Session["dhp_EMPNO"] = rd[0].ToString();
                            Session["dhp_currentuser"] = rd[0].ToString();
                            Session["dhp_FULLNAME"] = rd[1].ToString();
                            Session["dhp_BIRTHDAY"] = rd[2].ToString();
                            Session["dhp_USERACCT"] = rd[3].ToString();
                            Session["dhp_USERNAME"] = rd[4].ToString();
                            Session["dhp_DEPARTMENT"] = rd[5].ToString();
                            if (CheckBox1.Checked)
                            {
                                Response.Cookies["DHPusername"].Expires = DateTime.Now.AddDays(30);
                                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                            }
                            else
                            {
                                Response.Cookies["DHPusername"].Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies["DHPpassword"].Expires = DateTime.Now.AddDays(-1);

                            }
                            Response.Cookies["DHPusername"].Value = tboxempno.Text.Trim();
                            Response.Cookies["DHPpassword"].Value = tboxpassword.Text.Trim();
                            Response.Redirect("~/DAILYHEALTHPROFILE/dhphome.aspx");

                        }

                        rd.Close();
                    }
                    else
                    {
                        CustomValidator err = new CustomValidator();
                        err.ValidationGroup = "val1";
                        err.IsValid = false;
                        err.ErrorMessage = "invalid login";
                        Page.Validators.Add(err);
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
            }
        }
    }
}