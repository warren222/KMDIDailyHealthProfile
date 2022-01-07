using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class AntiGenValidity : System.Web.UI.Page
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            checkAntiGen(tboxempno.Text);
        }
        private string sqlconstr
        {
            get
            {
                return ConnectionString.sqlconstr();
            }
        }
        private void checkAntiGen(string empno)
        {
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    sqlcmd.CommandText = "check_antigen_stp";
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Empno", empno);
                    using (SqlDataReader rd = sqlcmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                lblFullname.Text = rd[0].ToString();
                                lblEmpno.Text = rd[1].ToString();
                                lbldate.Text = rd[2].ToString();
                                lbltestvalidity.Text = rd[3].ToString();
                                lbltextvaliditydate.Text = rd[4].ToString();
                                lbliscleared.Text = rd[5].ToString();
                                lblantigenserial.Text = rd[6].ToString();
                                lblantigenresult.Text = rd[7].ToString();
                            }
                        }
                        else
                        {
                            lbldate.Text = "No result";
                            lblEmpno.Text = "No result";
                            lblFullname.Text = "No result";
                            lbliscleared.Text = "No result";
                            lbltextvaliditydate.Text = "No result";
                            lblantigenresult.Text = "No result";
                        }

                    }
                    if (lbliscleared.Text == "Cleared")
                    {
                        Image1.Visible = true;
                        Image2.Visible = false;
                        Image3.Visible = false;
                        lbliscleared.ForeColor = System.Drawing.Color.Green;

                    }
                    else if (lbliscleared.Text == "Not Cleared")
                    {
                        Image1.Visible = false;
                        Image2.Visible = true;
                        Image3.Visible = false;
                        lbliscleared.ForeColor = System.Drawing.Color.Red;

                    }
                    else
                    {
                        Image1.Visible = false;
                        Image2.Visible = false;
                        Image3.Visible = true;
                    }

                    if (lblantigenresult.Text.Trim() == "*SARS-COV-2 ANTIGEN NOT PRESENT")
                    {
                        lblantigenresult.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (lblantigenresult.Text.Trim() == "*SARS-COV-2 ANTIGEN PRESENT")
                    {
                        lblantigenresult.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}