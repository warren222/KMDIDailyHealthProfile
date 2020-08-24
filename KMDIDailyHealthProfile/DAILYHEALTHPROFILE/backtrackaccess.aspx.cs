using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE
{
    public partial class backtrackaccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {
                    loaddata();
                    loadddldata();
                }

            }
            else
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
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
        private string sqlconstr
        {
            get
            {
                return ConnectionString.sqlconstr();
            }
        }
        private void loadddldata()
        {
            try
            {
           
                string str = "select EMPNO,surname+', '+firstname+' '+mi as FULLNAME from emptbl where not empno in (select empno from backtractaccesstb) order by surname asc,firstname asc, mi asc";
                
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand(str, sqlcon);
                    DropDownList1.DataSource = sqlcmd.ExecuteReader();
                    DropDownList1.DataValueField = "EMPNO";
                    DropDownList1.DataTextField = "FULLNAME";
                    DropDownList1.DataBind();
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.ToString());
            }
        }
        private void loaddata()
        {
            try
            {
                DataTable tb = new DataTable();
                string str = "select a.EMPNO,surname+', '+firstname+' '+mi as FULLNAME from backtractaccesstb as a left join emptbl as b on a.empno = b.empno";
                
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand(str, sqlcon);
                    SqlDataAdapter da= new SqlDataAdapter();
                    da.SelectCommand = sqlcmd;
                    da.Fill(tb);
                    GridView1.DataSource = tb;
                    GridView1.DataBind();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "mydelete")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                deleteme(((Label)row.FindControl("lblempno")).Text);
            }
        }

        private void deleteme(string empno)
        {
            try
            {
                DataTable tb = new DataTable();
                string str = "delete from backtractaccesstb where empno = @empno";
                
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand(str, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@empno", empno);
                    sqlcmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.ToString());
            }
            finally
            {
                loaddata();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool x = false;
                string str = "select * from backtractaccesstb where empno = @empno";
                
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand(str, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@empno", DropDownList1.Text);
                    using (SqlDataReader rd = sqlcmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            x = true;
                        }
                        else
                        {
                            x = false;
                        }
                    }

                    if (x)
                    {
                        errorrmessage("account already exist!");
                    }
                    else
                    {
                        string addstr = "insert into backtractaccesstb (empno)values(@empno)";
                        using (SqlCommand cmd = new SqlCommand(addstr, sqlcon))
                        {
                            cmd.Parameters.AddWithValue("@empno", DropDownList1.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.ToString());
            }
            finally
            {
                loaddata();
            }
        }
    }
}