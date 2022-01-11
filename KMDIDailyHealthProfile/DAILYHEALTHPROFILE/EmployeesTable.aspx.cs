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
    public partial class EmployeesTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {
                if (!IsPostBack)
                {
                    loaddata();
                }

            }
            else
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
            }
        }
        private string acct
        {
            get
            {
                return Session["dhp_USERACCT"].ToString();
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
                    using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                    {
                        sqlcmd.CommandText = "Emptbl_Stp";
                        sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Command", "load");
                        DataSet ds = new DataSet();
                        ds.Clear();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(ds, "emptbl");
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loaddata();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            savedata("insert", tboxsurname.Text, tboxfirstname.Text, tboxmi.Text, tboxdepartment.Text, tboxposcode.Text,
                 tboxuseracct.Text, tboxempno.Text, tboxempstatus.Text, tboxbirthday.Text, tboxuserstatus.Text, tboxaddress.Text,
                 ddlgender.Text, tboxdepartmentid.Text, tboxvalidity.Text);
        }
        private void savedata(string command, string surname, string firstname, string mi, string department,
            string poscode, string useracct, string empno, string empstatus, string birthday, string userstatus, string address,
            string gender, string deptid, string antigen_test_validity)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                    {
                        sqlcmd.CommandText = "Emptbl_Stp";
                        sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Command", command);
                        sqlcmd.Parameters.AddWithValue("@SURNAME", surname);
                        sqlcmd.Parameters.AddWithValue("@FIRSTNAME", firstname);
                        sqlcmd.Parameters.AddWithValue("@MI", mi);
                        sqlcmd.Parameters.AddWithValue("@DEPARTMENT", department);
                        sqlcmd.Parameters.AddWithValue("@POSCODE", poscode);
                        sqlcmd.Parameters.AddWithValue("@USERACCT", useracct);
                        sqlcmd.Parameters.AddWithValue("@EMPNO", empno);
                        sqlcmd.Parameters.AddWithValue("@EMPSTATUS", empstatus);
                        sqlcmd.Parameters.AddWithValue("@BIRTHDAY", birthday);
                        sqlcmd.Parameters.AddWithValue("@USERSTATUS", userstatus);
                        sqlcmd.Parameters.AddWithValue("@ADDRESS", address);
                        sqlcmd.Parameters.AddWithValue("@GENDER", gender);
                        sqlcmd.Parameters.AddWithValue("@DEPTID", deptid);
                        sqlcmd.Parameters.AddWithValue("@ANTIGEN_TEST_VALIDITY", antigen_test_validity);
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
                loaddata();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

            if (e.CommandName == "myEdit")
            {
                visibilityMethod(rowindex, true, false);
            }
            else if (e.CommandName == "myCancel")
            {
                visibilityMethod(rowindex, false, true);

            }
            else if (e.CommandName == "mySave")
            {
                GridViewRow row = GridView1.Rows[rowindex];
                savedata("edit",
                    ((TextBox)row.FindControl("tboxsurnameedit")).Text,
                    ((TextBox)row.FindControl("tboxfirstnameedit")).Text,
                    ((TextBox)row.FindControl("tboxmiedit")).Text,
                    ((TextBox)row.FindControl("tboxdepartmentedit")).Text,
                    ((TextBox)row.FindControl("tboxposcodeedit")).Text,
                    ((TextBox)row.FindControl("tboxuseracctedit")).Text,
                    ((Label)row.FindControl("lblempno")).Text,
                    ((TextBox)row.FindControl("tboxempstatusedit")).Text,
                    ((TextBox)row.FindControl("tboxbirthdayedit")).Text,
                    ((TextBox)row.FindControl("tboxuserstatusedit")).Text,
                    ((TextBox)row.FindControl("tboxaddressedit")).Text,
                    ((TextBox)row.FindControl("tboxgenderedit")).Text,
                    ((TextBox)row.FindControl("tboxdepartmentidedit")).Text,
                    ((TextBox)row.FindControl("tboxvalidityedit")).Text);

            }
        }
        private void visibilityMethod(int rowindex, bool x, bool y)
        {
            GridViewRow row = GridView1.Rows[rowindex];
            ((LinkButton)row.FindControl("btnEdit")).Visible = y;
            ((LinkButton)row.FindControl("btnSave")).Visible = x;
            ((LinkButton)row.FindControl("btnCancel")).Visible = x;


            ((TextBox)row.FindControl("tboxsurnameedit")).Visible = x;
            ((TextBox)row.FindControl("tboxfirstnameedit")).Visible = x;
            ((TextBox)row.FindControl("tboxmiedit")).Visible = x;
            ((TextBox)row.FindControl("tboxdepartmentedit")).Visible = x;
            ((TextBox)row.FindControl("tboxposcodeedit")).Visible = x;
            ((TextBox)row.FindControl("tboxuseracctedit")).Visible = x;
            ((TextBox)row.FindControl("tboxempstatusedit")).Visible = x;
            ((TextBox)row.FindControl("tboxbirthdayedit")).Visible = x;
            ((TextBox)row.FindControl("tboxuserstatusedit")).Visible = x;
            ((TextBox)row.FindControl("tboxaddressedit")).Visible = x;
            ((TextBox)row.FindControl("tboxgenderedit")).Visible = x;
            ((TextBox)row.FindControl("tboxdepartmentidedit")).Visible = x;
            ((TextBox)row.FindControl("tboxvalidityedit")).Visible = x;

            ((Label)row.FindControl("lblsurname")).Visible = y;
            ((Label)row.FindControl("lblfirstname")).Visible = y;
            ((Label)row.FindControl("lblmi")).Visible = y;
            ((Label)row.FindControl("lbldepartment")).Visible = y;
            ((Label)row.FindControl("lblposcode")).Visible = y;
            ((Label)row.FindControl("lbluseracct")).Visible = y;
            ((Label)row.FindControl("lblempstatus")).Visible = y;
            ((Label)row.FindControl("lblbirthday")).Visible = y;
            ((Label)row.FindControl("lbluserstatus")).Visible = y;
            ((Label)row.FindControl("lbladdress")).Visible = y;
            ((Label)row.FindControl("lblgender")).Visible = y;
            ((Label)row.FindControl("lbldepartmentid")).Visible = y;
            ((Label)row.FindControl("lblantigentestvalidity")).Visible = y;
        }
    }
}