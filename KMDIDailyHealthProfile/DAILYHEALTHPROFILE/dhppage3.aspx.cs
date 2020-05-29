using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webaftersales.DAILYHEALTHPROFILE
{
    public partial class dhppage3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {
                signaturepath();
                loadimage();
                if (!IsPostBack)
                {
                    lbldate.Text = Session["dhpdate"].ToString();
                    lblname.Text = Session["dhpname"].ToString();
                    lblempno.Text = Session["dhpempno"].ToString();
                    lblage.Text = Session["dhpage"].ToString();
                    lblbirthday.Text = Session["dhpbirthday"].ToString();
                    getdatatb1();
                    getdatatb2();
                    loaddhpage3();
                    access();
                }

            }
            else
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhplogin.aspx");
            }
        }
        private void signaturepath()
        {
            string filepath = "~/Uploads/DHPuploads/page3/signature/" + empno + dhpid + "/";
            Boolean IsExists = System.IO.Directory.Exists(Server.MapPath(filepath));
            if (!IsExists)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(filepath));
            }
        }
        private void loadimage()
        {
            Panel4.Controls.Clear();
            Image img = new Image();
            string filepath = "~/Uploads/DHPuploads/page3/signature/" + empno + dhpid + "/";

            foreach (string strfilename in Directory.GetFiles(Server.MapPath(filepath)))
            {
                ImageButton imgbutton = new ImageButton();
                FileInfo fileinfo = new FileInfo(strfilename);
                imgbutton.ImageUrl = filepath + fileinfo.Name;
                imgbutton.Width = Unit.Pixel(350);
                imgbutton.Height = Unit.Pixel(200);
                imgbutton.Style.Add("margin", "5px");
                imgbutton.CssClass = "img-thumbnail";
                Panel4.Controls.Add(imgbutton);
            }

        }
        private void access()
        {
            if (acct == "Admin")
            {
                btnaddnewrecord.Visible = true;
                Button3.Visible = true;
                pnl1.Enabled = true;
                Button2.Visible = true;
            }
            else
            {
                btnaddnewrecord.Visible = false;
                Button3.Visible = false;
                pnl1.Enabled = false;
                Button2.Visible = false;
            }
        }
        private string acct
        {
            get
            {
                return Session["dhp_USERACCT"].ToString();
            }
        }
        private string empno
        {
            get
            {
                return Session["dhpempno"].ToString();
            }
        }
        private string dhpid
        {
            get
            {
                return Session["dhp_id"].ToString();
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
        private void inserttbl1()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string str = "declare @ID as integer = (select isnull(max(isnull(id,0)),0)+1 from dhpisolationmonitoring)  " +
                                "insert into dhpisolationmonitoring  " +
                                "(ID,								 " +
                                "EMPNO,								 " +
                                "DHPID,								 " +
                                "TIMERECORD,						 " +
                                "BODYTEMP,							 " +
                                "OXYGENSATURATION,					 " +
                                "CHILLS,							 " +
                                "STOMACHACHE,						 " +
                                "VOMITINGEPISODE,					 " +
                                "BOWELMOVEMENT)						 " +
                                "values								 " +
                                "(@ID,								 " +
                                "@EMPNO,							 " +
                                "@DHPID,							 " +
                                "@TIMERECORD,						 " +
                                "@BODYTEMP,							 " +
                                "@OXYGENSATURATION,					 " +
                                "@CHILLS,							 " +
                                "@STOMACHACHE,						 " +
                                "@VOMITINGEPISODE,					 " +
                                "@BOWELMOVEMENT)					 ";
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        string temp = tboxbodytemp.Text;
                        if (temp == "")
                        {
                            temp = "0";
                        }
                     

                        sqlcmd.Parameters.AddWithValue("@EMPNO", empno);
                        sqlcmd.Parameters.AddWithValue("@DHPID", dhpid);
                        sqlcmd.Parameters.AddWithValue("@TIMERECORD", tboxtimerecord.Text);
                        sqlcmd.Parameters.AddWithValue("@BODYTEMP", temp);
                        sqlcmd.Parameters.AddWithValue("@OXYGENSATURATION", tboxoxygensaturation.Text);
                        sqlcmd.Parameters.AddWithValue("@CHILLS", dlchills.Text);
                        sqlcmd.Parameters.AddWithValue("@STOMACHACHE", dlstomachache.Text);
                        sqlcmd.Parameters.AddWithValue("@VOMITINGEPISODE", tboxvomiting.Text);
                        sqlcmd.Parameters.AddWithValue("@BOWELMOVEMENT", tboxbowelmovement.Text);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "addval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getdatatb1();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            inserttbl1();
        }
        private void getdatatb1()
        {
            try
            {
                DataTable tb = new DataTable();
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string str = "select * from dhpisolationmonitoring where empno=@EMPNO AND DHPID=@DHPID";
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@EMPNO", empno);
                        sqlcmd.Parameters.AddWithValue("@DHPID", dhpid);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(tb);
                        GridView1.DataSource = tb;
                        GridView1.DataBind();
                        if(acct == "Admin")
                        {
                            GridView1.Columns[0].Visible = true;
                        }
                        else
                        {
                            GridView1.Columns[0].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "myedit")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                editmode(row, false, true);

            }
            else if (e.CommandName == "mycancel")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                editmode(row, true, false);
            }
            else if (e.CommandName == "myupdate")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                if (IsValid)
                {
                    updatefunctio(((Label)row.FindControl("lblid")).Text,
             ((TextBox)row.FindControl("tboxedittimerecord")).Text,
             ((TextBox)row.FindControl("tboxeditbodytemp")).Text,
             ((TextBox)row.FindControl("tboxeditoxygensaturation")).Text,
             ((DropDownList)row.FindControl("dleditchills")).Text,
             ((DropDownList)row.FindControl("dleditstomachache")).Text,
             ((TextBox)row.FindControl("tboxeditvomiting")).Text,
             ((TextBox)row.FindControl("tboxeditbowelmovement")).Text);
                }

            }
            else if (e.CommandName == "mydelete")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                deletefunctio(((Label)row.FindControl("lblid")).Text);
            }
          
        }
      
      

        private void deletefunctio(string id)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string str = "delete from dhpisolationmonitoring " +
                                "where id=@ID";
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@id", id);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
            }
            finally
            {
                getdatatb1();
            }
        }

        private void updatefunctio(string id, string timerecord, string bodytemp, string oxygensaturation, string chills, string stomachache, string vomiting, string bowelmovement)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string str = "update dhpisolationmonitoring set " +
                                "TIMERECORD=@TIMERECORD,						 " +
                                "BODYTEMP=@BODYTEMP,							 " +
                                "OXYGENSATURATION=@OXYGENSATURATION,					 " +
                                "CHILLS=@CHILLS,							 " +
                                "STOMACHACHE=@STOMACHACHE,						 " +
                                "VOMITINGEPISODE=@VOMITINGEPISODE,					 " +
                                "BOWELMOVEMENT=@BOWELMOVEMENT						 " +
                                "where id=@ID";
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@id", id);
                        sqlcmd.Parameters.AddWithValue("@TIMERECORD", timerecord);
                        sqlcmd.Parameters.AddWithValue("@BODYTEMP", bodytemp);
                        sqlcmd.Parameters.AddWithValue("@OXYGENSATURATION", oxygensaturation);
                        sqlcmd.Parameters.AddWithValue("@CHILLS", chills);
                        sqlcmd.Parameters.AddWithValue("@STOMACHACHE", stomachache);
                        sqlcmd.Parameters.AddWithValue("@VOMITINGEPISODE", vomiting);
                        sqlcmd.Parameters.AddWithValue("@BOWELMOVEMENT", bowelmovement);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
            }
            finally
            {
                getdatatb1();
            }
        }

        private void editmode(GridViewRow row, bool t, bool f)
        {
            ((LinkButton)row.FindControl("btnedit")).Visible = t;
            ((LinkButton)row.FindControl("btndelete")).Visible = t;
            ((Label)row.FindControl("lbltimerecord")).Visible = t;
            ((Label)row.FindControl("lblbodytemp")).Visible = t;
            ((Label)row.FindControl("lbloxygensaturation")).Visible = t;
            ((Label)row.FindControl("lblchills")).Visible = t;
            ((Label)row.FindControl("lblstomachache")).Visible = t;
            ((Label)row.FindControl("lblvomiting")).Visible = t;
            ((Label)row.FindControl("lblbowelmovement")).Visible = t;

            ((RegularExpressionValidator)row.FindControl("RegularExpressionValidator33")).Visible = f;
            ((LinkButton)row.FindControl("btnupdate")).Visible = f;
            ((LinkButton)row.FindControl("btncancel")).Visible = f;
            ((TextBox)row.FindControl("tboxedittimerecord")).Visible = f;
            ((TextBox)row.FindControl("tboxeditbodytemp")).Visible = f;
            ((TextBox)row.FindControl("tboxeditoxygensaturation")).Visible = f;
            ((DropDownList)row.FindControl("dleditchills")).Visible = f;
            ((DropDownList)row.FindControl("dleditstomachache")).Visible = f;
            ((TextBox)row.FindControl("tboxeditvomiting")).Visible = f;
            ((TextBox)row.FindControl("tboxeditbowelmovement")).Visible = f;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            btnaddnewrecord.Visible = true;
        }

        protected void btnaddnewrecord_Click(object sender, EventArgs e)
        {
            btnaddnewrecord.Visible = false;
            Panel1.Visible = true;
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "myedit")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                ((LinkButton)row.FindControl("lbtnedit")).Visible = false;
                ((LinkButton)row.FindControl("lbtndelete")).Visible = false;
                ((Label)row.FindControl("lblmedicine")).Visible = false;
                ((Label)row.FindControl("lbltimeadministered")).Visible = false;
                ((Label)row.FindControl("lbldosage")).Visible = false;
                ((Label)row.FindControl("lblpurpose")).Visible = false;

                ((LinkButton)row.FindControl("lbtnupdate")).Visible = true;
                ((LinkButton)row.FindControl("lbtncancel")).Visible = true;
                ((TextBox)row.FindControl("tboxeditmedicine")).Visible = true;
                ((TextBox)row.FindControl("tboxedittimeadministered")).Visible = true;
                ((TextBox)row.FindControl("tboxeditdosage")).Visible = true;
                ((TextBox)row.FindControl("tboxeditpurpose")).Visible = true;
            }
           else if (e.CommandName == "mycancel")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                ((LinkButton)row.FindControl("lbtnedit")).Visible = true;
                ((LinkButton)row.FindControl("lbtndelete")).Visible = true;
                ((Label)row.FindControl("lblmedicine")).Visible = true;
                ((Label)row.FindControl("lbltimeadministered")).Visible = true;
                ((Label)row.FindControl("lbldosage")).Visible = true;
                ((Label)row.FindControl("lblpurpose")).Visible = true;

                ((LinkButton)row.FindControl("lbtnupdate")).Visible = false;
                ((LinkButton)row.FindControl("lbtncancel")).Visible = false;
                ((TextBox)row.FindControl("tboxeditmedicine")).Visible = false;
                ((TextBox)row.FindControl("tboxedittimeadministered")).Visible = false;
                ((TextBox)row.FindControl("tboxeditdosage")).Visible = false;
                ((TextBox)row.FindControl("tboxeditpurpose")).Visible = false;
            }
            else if (e.CommandName == "myupdate")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                updatetbl2(((Label)row.FindControl("lblid2")).Text,
                    ((TextBox)row.FindControl("tboxeditmedicine")).Text,
                ((TextBox)row.FindControl("tboxedittimeadministered")).Text,
                ((TextBox)row.FindControl("tboxeditdosage")).Text,
                ((TextBox)row.FindControl("tboxeditpurpose")).Text);
            }
            else if (e.CommandName == "mydelete")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                deletetbl2(((Label)row.FindControl("lblid2")).Text);
            }
        }

        private void deletetbl2(string id)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string str = "delete from dhpreliefadministration where ID=@ID ";

                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@ID", id);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "medval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getdatatb2();
            }
        }

        private void updatetbl2(string id, string medicine, string timeadministered, string dosage, string purpose)
        {
          try
            {
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string str =            "update dhpreliefadministration set " +
                                        "MEDICINE = @MEDICINE,							  " +
                                        "TIMEADMINISTERED = @TIMEADMINISTERED,					  " +
                                        "DOSAGE = @DOSAGE,							  " +
                                        "PURPOSE = @PURPOSE	where ID=@ID		";

                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@ID", id);
                        sqlcmd.Parameters.AddWithValue("@MEDICINE", medicine);
                        sqlcmd.Parameters.AddWithValue("@TIMEADMINISTERED", timeadministered);
                        sqlcmd.Parameters.AddWithValue("@DOSAGE", dosage);
                        sqlcmd.Parameters.AddWithValue("@PURPOSE", purpose);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "medval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getdatatb2();
            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Button3.Visible = false;
            Panel3.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {           
            Panel3.Visible =false;
            Button3.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string str = "declare @ID as integer = (select isnull(max(isnull(id,0)),0)+1 from dhpreliefadministration) " +
                                        "insert into dhpreliefadministration  " +
                                        "(ID,								  " +
                                        "EMPNO,								  " +
                                        "DHPID,								  " +
                                        "MEDICINE,							  " +
                                        "TIMEADMINISTERED,					  " +
                                        "DOSAGE,							  " +
                                        "PURPOSE)							  " +
                                        "values								  " +
                                        "(@ID,								  " +
                                        "@EMPNO,							  " +
                                        "@DHPID,							  " +
                                        "@MEDICINE,							  " +
                                        "@TIMEADMINISTERED,					  " +
                                        "@DOSAGE,							  " +
                                        "@PURPOSE)							  ";

                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@EMPNO", empno);
                        sqlcmd.Parameters.AddWithValue("@DHPID", dhpid);
                        sqlcmd.Parameters.AddWithValue("@MEDICINE", tboxmedicine.Text);
                        sqlcmd.Parameters.AddWithValue("@TIMEADMINISTERED", tboxtimeadministered.Text);
                        sqlcmd.Parameters.AddWithValue("@DOSAGE", tboxdosage.Text);
                        sqlcmd.Parameters.AddWithValue("@PURPOSE", tboxpurpose.Text);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "medval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getdatatb2();
            }
        }

        private void getdatatb2()
        {
            try
            {
                DataTable tb = new DataTable();
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string str = "select * from dhpreliefadministration where empno=@EMPNO AND DHPID=@DHPID";
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@EMPNO", empno);
                        sqlcmd.Parameters.AddWithValue("@DHPID", dhpid);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(tb);
                        GridView2.DataSource = tb;
                        GridView2.DataBind();
                        if (acct == "Admin")
                        {
                            GridView2.Columns[0].Visible = true;
                        }
                        else
                        {
                            GridView2.Columns[0].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["dhp_pagesender"] = "page3";
            Response.Redirect("~/DAILYHEALTHPROFILE/dhpsignature.aspx");
        }
        private void loaddhpage3()
        {
            try
            {
                string str = "select personnel,datecollected from dhppage3 where empno=@empno and dhpid=@dhpid";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();

                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {

                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        using (SqlDataReader rd = sqlcmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                tboxpersonnel.Text=rd["personnel"].ToString();
                                tboxdatecollected.Text = rd["datecollected"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorrmessage(ex.Message.ToString());
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                string find = "select * from dhppage3 where empno=@empno and dhpid=@dhpid";
                bool exist = false;
                string insertstr = " declare @id as integer = (select isnull(max(isnull(id,0)),0)+1 from dhppage3)" +
                                " insert into dhppage3" +
                                " (ID,EMPNO,DHPID,PERSONNEL,DATECOLLECTED)" +
                                " values(@id,@empno,@dhpid,@personnel,@datecollected)";
                string updatestr = " update dhppage3 set				   " +
                                " personnel=@personnel,		   " +
                                " datecollected=@datecollected";
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();

                    using (SqlCommand sqlcmd = new SqlCommand(find, sqlcon))
                    {

                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
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
                        using (SqlCommand sqlcmd = new SqlCommand(updatestr, sqlcon))
                        {
                            sqlcmd.Parameters.AddWithValue("@empno", empno);
                            sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                            sqlcmd.Parameters.AddWithValue("@personnel", tboxpersonnel.Text);
                            sqlcmd.Parameters.AddWithValue("@datecollected", tboxdatecollected.Text);
                            sqlcmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand sqlcmd = new SqlCommand(insertstr, sqlcon))
                        {
                            sqlcmd.Parameters.AddWithValue("@empno", empno);
                            sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                            sqlcmd.Parameters.AddWithValue("@personnel", tboxpersonnel.Text);
                            sqlcmd.Parameters.AddWithValue("@datecollected", tboxdatecollected.Text);
                            sqlcmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "signerror";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "success";
                err.IsValid = false;
                err.ErrorMessage = "page 3 saved successfully!";
                Page.Validators.Add(err);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getdatatb1();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            getdatatb2();
        }
    }
}