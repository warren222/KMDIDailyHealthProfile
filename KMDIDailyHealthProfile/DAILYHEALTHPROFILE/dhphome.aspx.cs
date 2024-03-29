﻿using KMDIDailyHealthProfile.DAILYHEALTHPROFILE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webaftersales.DAILYHEALTHPROFILE
{
    public partial class dhphome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {
                    log();
                    lblToday.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                    if (Session["dhpsearchkey"] != null)
                    {
                        tboxsearchkey.Text = Session["dhpsearchkey"].ToString();
                    }
                    if (Session["dhpdatekey"] != null)
                    {
                        tboxdate.Text = Session["dhpdatekey"].ToString();
                    }
                    if (Session["dhpcbox"] != null)
                    {
                        cboxstatus.Checked = Convert.ToBoolean(Session["dhpcbox"]);
                    }
                    if (acct == "Admin")
                    {
                        LinkButton2.Visible = true;

                    }
                    else
                    {
                        LinkButton2.Visible = false;

                    }  
                    Panel1.Visible = panelaccess();
                    getdata();
                    loademployee();
                    if (sqlconstr.Contains("121.58.229.248"))
                    {
                        lblserver.Text = "Server 1";
                    }
                    else
                    {
                        lblserver.Text = "Server 2";
                    }
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
        bool panelaccess()
        {
            bool x = false;      
            
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                using (SqlCommand sqlcmd = new SqlCommand("SELECT * from backtractaccesstb where empno = @empno", sqlcon))
                {
                    sqlcon.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    sqlcmd.Parameters.AddWithValue("@empno", empno);
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
                }
            }
            return x;
        }

        private string empno
        {
            get
            {
                return Session["dhp_EMPNO"].ToString();
            }
        }
        private string acct
        {
            get
            {
                return Session["dhp_USERACCT"].ToString();
            }
        }
        private void loademployee()
        {
            try
            {
                DataTable tb = new DataTable();
                
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    using (SqlCommand sqlcmd = new SqlCommand("SELECT surname+', '+firstname+' '+mi as FULLNAME,EMPNO FROM EMPTBL WHERE [USERSTATUS] = 'Active' order by surname asc", sqlcon))
                    {
                        sqlcon.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(tb);
                        DDLemployee.DataSource = tb;
                        DDLemployee.DataTextField = "FULLNAME";
                        DDLemployee.DataValueField = "EMPNO";
                        DDLemployee.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
            }
        }
        private void getdata()
        {
            try
            {
                DataTable tb = new DataTable();
                

                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                    {
                        string stat = "no";
                        if (cboxstatus.Checked)
                        {
                            stat = "yes";
                        }

                        sqlcon.Open();
                        sqlcmd.CommandText = "DHPstp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@accttype", acct);
                        sqlcmd.Parameters.AddWithValue("@searchkey", tboxsearchkey.Text);
                        sqlcmd.Parameters.AddWithValue("@date", tboxdate.Text);
                        sqlcmd.Parameters.AddWithValue("@status", stat);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(tb);
                        GridView1.DataSource = tb;
                        GridView1.DataBind();
                        lblcountrow.Text = tb.Rows.Count.ToString() + " result(s) found";
                        Session["dhpsearchkey"] = tboxsearchkey.Text;
                        Session["dhpdatekey"] = tboxdate.Text;
                        Session["dhpcbox"] = cboxstatus.Checked;
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string find = "select * from dhrtbl where empno=@empno and rdate=@rdate";
                bool exist = false;

                
                string str = " declare @id as integer = (select isnull(max(isnull(id,0)),0)+1 from dhrtbl)" +
                             " insert into dhrtbl (id,empno,rdate,rtime)values(@id,@empno,@rdate,@rtime)";
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcmd = new SqlCommand(find, sqlcon))
                    {

                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@rdate", DateTime.Now.ToString("MM-dd-yyyy"));

                        using (SqlDataReader rd = sqlcmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                exist = true;
                            }
                            else
                            {
                                exist = false;
                            }
                        }

                    }
                    if (exist)
                    {
                        errorrmessage("One report per day only!");
                    }
                    else
                    {
                        using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                        {

                            sqlcmd.Parameters.AddWithValue("@empno", empno);
                            sqlcmd.Parameters.AddWithValue("@rdate", DateTime.Now.ToString("MM-dd-yyyy"));
                            sqlcmd.Parameters.AddWithValue("@rtime", DateTime.Now.ToString("hh:mm:ss tt"));
                            sqlcmd.ExecuteNonQuery();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
            }
            finally
            {
                getdata();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "page1")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                setsession(row);
                Session["pagesender"] = "dhphome";
                Response.Redirect("~/DAILYHEALTHPROFILE/dhpnew.aspx");
            }
            if (e.CommandName == "page2")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                setsession(row);
                Session["pagesender"] = "dhphome";
                Response.Redirect("~/DAILYHEALTHPROFILE/dhppage2.aspx");
            }
            if (e.CommandName == "page3")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                setsession(row);
                Session["pagesender"] = "dhphome";
                Response.Redirect("~/DAILYHEALTHPROFILE/dhppage3.aspx");
            }
            if (e.CommandName == "myreport")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                setsession(row);
                Response.Redirect("~/DAILYHEALTHPROFILE/RPTpage.aspx");
            }
        }
        private void setsession(GridViewRow row)
        {
            Session["dhp_id"] = ((Label)row.FindControl("lblid")).Text;
            Session["dhpdate"] = ((Label)row.FindControl("lbldate")).Text;
            Session["dhpname"] = ((Label)row.FindControl("lblname")).Text;
            Session["dhpage"] = ((Label)row.FindControl("lblage")).Text;
            Session["dhpempno"] = ((Label)row.FindControl("lblempno")).Text;
            Session["dhpbirthday"] = ((Label)row.FindControl("lblbirthday")).Text;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            getdata();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getdata();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (tboxdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "Script", "alert('please select date!');", true);
            }
            else
            {
                Session["dhpdatekey"] = tboxdate.Text;
                Response.Redirect("~/DAILYHEALTHPROFILE/dhpreport.aspx");
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            tboxdate.Text = TBOXinputdate.Text;
            tboxsearchkey.Text = DDLemployee.Text.ToString();
            if (Convert.ToDateTime(TBOXinputdate.Text) > DateTime.Now)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "val2";
                err.IsValid = false;
                err.ErrorMessage = "date should not exceed the current date!";
                Page.Validators.Add(err);
            }

            if (IsValid)
            {


                try
                {
                    string find = "select * from dhrtbl where empno=@empno and rdate=@rdate";
                    bool exist = false;

                    
                    string str = " declare @id as integer = (select isnull(max(isnull(id,0)),0)+1 from dhrtbl)" +
                                 " insert into dhrtbl (id,empno,rdate,rtime)values(@id,@empno,@rdate,@rtime)";
                    using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                    {
                        sqlcon.Open();
                        using (SqlCommand sqlcmd = new SqlCommand(find, sqlcon))
                        {

                            sqlcmd.Parameters.AddWithValue("@empno", DDLemployee.Text.ToString());
                            sqlcmd.Parameters.AddWithValue("@rdate", Convert.ToDateTime(TBOXinputdate.Text).ToString("MM-dd-yyyy"));

                            using (SqlDataReader rd = sqlcmd.ExecuteReader())
                            {
                                if (rd.HasRows)
                                {
                                    exist = true;
                                }
                                else
                                {
                                    exist = false;
                                }
                            }

                        }
                        if (exist)
                        {
                            CustomValidator err = new CustomValidator();
                            err.ValidationGroup = "val2";
                            err.IsValid = false;
                            err.ErrorMessage = "One report per day only, DHP already exist!";
                            Page.Validators.Add(err);
                        }
                        else
                        {
                            using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                            {

                                sqlcmd.Parameters.AddWithValue("@empno", DDLemployee.Text.ToString());
                                sqlcmd.Parameters.AddWithValue("@rdate", Convert.ToDateTime(TBOXinputdate.Text).ToString("MM-dd-yyyy"));
                                sqlcmd.Parameters.AddWithValue("@rtime", DateTime.Now.ToString("hh:mm:ss tt"));
                                sqlcmd.ExecuteNonQuery();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    CustomValidator err = new CustomValidator();
                    err.ValidationGroup = "val2";
                    err.IsValid = false;
                    err.ErrorMessage = ex.Message.ToString();
                    Page.Validators.Add(err);
                }
                finally
                {
                    getdata();
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton page3 = (LinkButton)e.Row.FindControl("LinkButton6");
                LinkButton page2 = (LinkButton)e.Row.FindControl("LinkButton5");
                if (acct == "Admin" || acct == "Unique")
                {
                    page3.Visible = true;
                    page2.Visible = true;
                }
                else
                {
                    page3.Visible = false;
                    page2.Visible = false;
                }
            }

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(ConnectionString.sqlconstr()))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                    {
                        sqlcmd.CommandText = "Date_Time_Record_Stp";
                        sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Command", "Create");
                        sqlcmd.Parameters.AddWithValue("@Emp_no", Session["dhp_EMPNO"].ToString());
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message);
            }
            finally
            {
                log();
            }
        }
        private void log()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(ConnectionString.sqlconstr()))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                    {
                        sqlcmd.CommandText = "Date_Time_Record_Stp";
                        sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Command", "Load");
                        sqlcmd.Parameters.AddWithValue("@Emp_no", Session["dhp_EMPNO"].ToString());
                        GridView2.DataSource = sqlcmd.ExecuteReader();
                        GridView2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message);
            }
        }
    }
}