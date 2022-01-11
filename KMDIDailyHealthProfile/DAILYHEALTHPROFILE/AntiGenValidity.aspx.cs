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
                    lblDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
                    tboxempno.Text = Session["dhp_EMPNO"].ToString();
                    checkAntiGen(tboxempno.Text);
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
                    sqlcmd.CommandText = "dhp_clearance_stp";
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Empno", empno);
                    using (SqlDataReader rd = sqlcmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                lblClearance.Text = rd[0].ToString();
                                lblFullname.Text = rd[1].ToString();
                                lblantigendate.Text = rd[2].ToString();
                                lbltestvaliditydate.Text = rd[3].ToString();
                                lblantigenresult.Text = rd[4].ToString();
                                lblQuarantine_Date.Text = rd[5].ToString();
                                lblEnd_Quarantine_Date.Text = rd[6].ToString();
                                lblEnded_Quarantine_Date.Text = rd[7].ToString();
                                lblDHP_Report_1.Text = rd[8].ToString();
                                lblDHP_Report_2.Text = rd[9].ToString();
                                lblDHP_Report_1_Date.Text = rd[10].ToString();
                                lblDHP_Report_2_Date.Text = rd[11].ToString();
                                lblRemarks.Text = rd[12].ToString();
                            }
                        }
                        else
                        {
                            lblClearance.Text = "No Result";
                            lblFullname.Text = "No Result";
                            lblantigendate.Text = "No Result";
                            lbltestvaliditydate.Text = "No Result";
                            lblantigenresult.Text = "No Result";
                            lblQuarantine_Date.Text = "No Result";
                            lblEnd_Quarantine_Date.Text = "No Result";
                            lblEnded_Quarantine_Date.Text = "No Result";
                            lblDHP_Report_1.Text = "No Result";
                            lblDHP_Report_2.Text = "No Result";
                            lblDHP_Report_1_Date.Text = "No Result";
                            lblDHP_Report_2_Date.Text = "No Result";
                        }

                    }
                    if (lblClearance.Text == "Approved")
                    {
                        Image1.Visible = true;
                        Image2.Visible = false;
                        Image3.Visible = false;
                        lblClearance.ForeColor = System.Drawing.Color.Green;

                    }
                    else if (lblClearance.Text == "Denied")
                    {
                        Image1.Visible = false;
                        Image2.Visible = true;
                        Image3.Visible = false;
                        lblClearance.ForeColor = System.Drawing.Color.Red;
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
                    else if (lblantigenresult.Text.Trim() == "*NO TEST DONE")
                    {
                        lblantigendate.Text = "n/a";
                        lbltestvaliditydate.Text = "n/a";
                    }
                }
            }
        }
    }
}