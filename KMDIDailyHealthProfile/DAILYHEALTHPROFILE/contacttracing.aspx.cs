using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class contacttracing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["dhp_USERNAME"] != null)
            {
                if (!IsPostBack)
                {
                    if (Session["contacttracingtbox"] != null)
                    {
                        tboxsearchkey.Text = Session["contacttracingtbox"].ToString();
                    }
                    loaddata();
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
        private void errorrmessage(string message)
        {
            CustomValidator err = new CustomValidator();
            err.ValidationGroup = "val1";
            err.IsValid = false;
            err.ErrorMessage = message;
            Page.Validators.Add(err);
        }
        private void loaddata()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    sqlcon.Open();
                    DataTable tb = new DataTable();

                    using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                    {
                        sqlcmd.CommandText = "cotacttracingspage";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@searchkey", tboxsearchkey.Text);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(tb);
                        GridView1.DataSource = tb;
                        GridView1.DataBind();
                        Session["contacttracingtbox"] = tboxsearchkey.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.ToString());
            }
        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loaddata();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["contacttracingtbox"] = tboxsearchkey.Text;
            Response.Redirect("~/DAILYHEALTHPROFILE/contacttracingreport.aspx");
        }
    }
}