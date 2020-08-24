using KMDIDailyHealthProfile.DAILYHEALTHPROFILE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webaftersales.DAILYHEALTHPROFILE
{
    public partial class dhpchangepass : System.Web.UI.Page
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
        private string empno
        {
            get
            {
                return Session["dhp_EMPNO"].ToString();
            }
        }
        private string username
        {
            get
            {
                return Session["dhp_USERNAME"].ToString();
            }
        }
        private string sqlconstr
        {
            get
            {
                return ConnectionString.sqlconstr();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (checkpassword() == false || checkusername() == true)
                {
                    string x = "";
                    string y = "";
                    if (ViewState["passerror"] != null)
                    {
                        x = ViewState["passerror"].ToString();
                    }
                    if (ViewState["usererror"] != null)
                    {
                        y = ViewState["usererror"].ToString();
                    }
                    CustomValidator err = new CustomValidator();
                    err.ValidationGroup = "val1";
                    err.IsValid = false;
                    err.ErrorMessage = x + y;
                    Page.Validators.Add(err);
                }
                else
                {
                    try
                    {
                        
                        using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                        {
                            sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("update EMPTBL set password = '" + tboxpassword.Text + "',username='" + tboxusername.Text + "' where empno = '" + empno + "'", sqlcon);
                            sqlcmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                    finally
                    {
                        Session.Abandon();
                        Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
                    }
                }
            }
        }
        private bool checkpassword()
        {
            bool hasrow;

            
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("select * from emptbl where username = '" + username + "' and password = '" + tboxoldpassord.Text + "'", sqlcon);
                SqlDataReader dr = sqlcmd.ExecuteReader();
                if (dr.HasRows)
                {
                    hasrow = true;
                }
                else
                {
                    hasrow = false;
                    ViewState["passerror"] = "old password is incorrect / ";
                }
            }
            return hasrow;
        }
        private bool checkusername()
        {
            bool hasrow;

            
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("select * from emptbl where username = '" + tboxusername.Text + "' and not empno =  '" + empno + "'", sqlcon);
                SqlDataReader dr = sqlcmd.ExecuteReader();
                if (dr.HasRows)
                {
                    hasrow = true;
                    ViewState["usererror"] = "username is already taken";
                }
                else
                {
                    hasrow = false;
                }
            }
            return hasrow;
        }

    }
}