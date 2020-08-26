using KMDIDailyHealthProfile.DAILYHEALTHPROFILE;
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
    public partial class dhppage2 : System.Web.UI.Page
    {
        string filepath3 = "~/Uploads/DHPuploads/page2/testresult/";
        protected void Page_Load(object sender, EventArgs e)

        {

            if (Session["dhp_USERNAME"] != null)
            {
            
                signaturephoto();
                testresultphotos();
                loadimages();
                loadsignature();
                if (!IsPostBack)
                {
                    lbldate.Text = Session["dhpdate"].ToString();
                    lblname.Text = Session["dhpname"].ToString();
                    lblempno.Text = Session["dhpempno"].ToString();
                    lblage.Text = Session["dhpage"].ToString();
                    lblbirthday.Text = Session["dhpbirthday"].ToString();
                  
                    getdata();
                    //gettravelhistory();
                    getpersoninteract();
                    access();

                    if (tboxpatientname.Text == "")
                    {
                        tboxpatientname.Text= Session["dhpname"].ToString();
                    }
                    if (tboxrecopatient.Text == "")
                    {
                        tboxrecopatient.Text= Session["dhpname"].ToString();
                    }
                    if (tboxphysician.Text == "")
                    {
                        tboxphysician.Text = "Dra. Chiaoling Sua-Lao";
                    }
                    if (tboxlicense.Text == "")
                    {
                        tboxlicense.Text = "0072107";
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
        private void access()
        {
            if (acct == "Admin")
            {
                //pnl1.Visible = true;
                pnl2.Enabled = true;
                pnl3.Enabled = true;
                pnl4.Enabled = true;
                pnl5.Visible = true;
                tboxexposuretovirus.Enabled = true;
            }
            else
            {
                //pnl1.Visible = false;
                pnl2.Enabled = false;
                pnl3.Enabled = false;
                pnl4.Enabled = false;
                pnl5.Visible = false;
                tboxexposuretovirus.Enabled = false;
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
        private void signaturephoto()
        {
            createsignaturepath("patient");
            createsignaturepath("physician");
            createsignaturepath("administered");
            createsignaturepath("patientreco");
        }
        private void createsignaturepath(string foldername)
        {
            string filepath = "~/Uploads/DHPuploads/page2/signature/" + foldername + "/" + empno + dhpid + "/";
            Boolean IsExists = System.IO.Directory.Exists(Server.MapPath(filepath));
            if (!IsExists)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(filepath));
            }
        }
        private void testresultphotos()
        {

            string filepath2 = "~/Uploads/DHPuploads/page2/testresult/" + empno + dhpid + "/";
            Boolean IsExists2 = System.IO.Directory.Exists(Server.MapPath(filepath2));
            if (!IsExists2)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(filepath2));
            }


        }
        //private void gettravelsummary()
        //{
        //    try
        //    {
        //       
        //        string str = " select travelhistory from dhptravelhistory where empno=@empno and dhpid=@dhpid order by sorting asc";
        //        using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
        //        {
        //            using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
        //            {
        //                sqlcon.Open();
        //                sqlcmd.Parameters.AddWithValue("@empno", empno);
        //                sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);

        //                using (SqlDataReader rd = sqlcmd.ExecuteReader())
        //                {
        //                    string co = "";
        //                    string span = " <span class='glyphicon glyphicon-arrow-right'></span> ";
        //                    while (rd.Read())
        //                    {
        //                        co += "<strong class='text-info'>" + rd[0].ToString() + "</strong>" + span;
        //                    }
        //                    if (co == "")
        //                    {
        //                        co = span;
        //                    }
        //                    string complete = "From " + co;

        //                    int colength = complete.Length - 55;

        //                    lbltravelsummary.Text = complete.Substring(0, colength);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomValidator err = new CustomValidator();
        //        err.ValidationGroup = "mainval";
        //        err.IsValid = false;
        //        err.ErrorMessage = ex.Message.ToString();
        //        Page.Validators.Add(err);
        //    }

        //}
        private void loadsignature()
        {
            getimage(Panel1, "patient");
            getimage(pnlphysician, "physician");
            getimage(pnladministered, "administered");
            getimage(pnlpatientreco, "patientreco");
        }
        private void getimage(Panel pnl, string foldername)
        {
            pnl.Controls.Clear();
            Image img = new Image();
            string filepath = "~/Uploads/DHPuploads/page2/signature/" + foldername + "/" + empno + dhpid + "/";

            foreach (string strfilename in Directory.GetFiles(Server.MapPath(filepath)))
            {
                ImageButton imgbutton = new ImageButton();
                FileInfo fileinfo = new FileInfo(strfilename);
                imgbutton.ImageUrl = filepath + fileinfo.Name;
                imgbutton.Width = Unit.Pixel(350);
                imgbutton.Height = Unit.Pixel(200);
                imgbutton.Style.Add("margin", "5px");
                imgbutton.CssClass = "img-thumbnail";
                pnl.Controls.Add(imgbutton);
            }
        }
        private void loadimages()
        {
            Panel2.Controls.Clear();
            string filepath2 = "~/Uploads/DHPuploads/page2/testresult/" + empno + dhpid + "/";
            foreach (string strfilename in Directory.GetFiles(Server.MapPath(filepath2)))
            {
                ImageButton imgbutton = new ImageButton();
                FileInfo fileinfo = new FileInfo(strfilename);
                imgbutton.ImageUrl = filepath2 + fileinfo.Name;
                imgbutton.Width = Unit.Pixel(300);
                imgbutton.Height = Unit.Pixel(300);
                imgbutton.Style.Add("margin", "5px");
                imgbutton.CssClass = "img-thumbnail";
                imgbutton.Click += new ImageClickEventHandler(Imgbutton_Click);
                Table tb = new Table();

                Panel2.Controls.Add(imgbutton);
            }
        }
        private void Imgbutton_Click(object sender, ImageClickEventArgs e)
        {
            Session["dhpimgpath"] = ((ImageButton)sender).ImageUrl.ToString();
            Response.Redirect("~/DAILYHEALTHPROFILE/dhpfullimage.aspx?dhpImageUrl=" + ((ImageButton)sender).ImageUrl);
            //File.Delete(Server.MapPath(((ImageButton)sender).ImageUrl));
            //Session["imgpath"] = ((ImageButton)sender).ImageUrl.ToString();
            //Response.Redirect("~/AFTERSALESPROJ/viewimage.aspx?ImageUrl=" + ((ImageButton)sender).ImageUrl);
        }
        private void errorrmessage(string message)
        {
            CustomValidator err = new CustomValidator();
            err.ValidationGroup = "g1";
            err.IsValid = false;
            err.ErrorMessage = message;
            Page.Validators.Add(err);
        }
        private void getdata()
        {
            try
            {
               
                string str = " select ID,EMPNO,DHPID,EXPOSURETOVIRUS,DATETESTDONE,TIMETEST,SERIALNO,TESTRESULT,PATIENTNAME,ADMINISTEREDBY,PHYSICIAN,LICENSENO,RECOENDO,RECOCALLIN,RECOSENDHOME,RECOOTHER,RECOPATIENT,COMMENT,RECOFITTOWORK,ANTIGENDATE,ANTIGENTIME,ANTIGENSERIAL,ANTIGENRESULT from dhppage2 where empno =@empno and dhpid=@dhpid";
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        string testresult = "";
                        string testresultantigen = "";
                        string sendhome = "";
                        string fittowork = "";
                        using (SqlDataReader rd = sqlcmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                tboxexposuretovirus.Text = rd["EXPOSURETOVIRUS"].ToString();
                                tboxdatetestdone.Text = rd["DATETESTDONE"].ToString();
                                tboxpatientname.Text = rd["PATIENTNAME"].ToString();
                                tboxadministeredby.Text = rd["ADMINISTEREDBY"].ToString();
                                tboxphysician.Text = rd["PHYSICIAN"].ToString();
                                testresult = rd["TESTRESULT"].ToString();
                                tboxrecoendo.Text = rd["RECOENDO"].ToString();
                                tboxrecocallin.Text = rd["RECOCALLIN"].ToString();
                                tboxrecoother.Text = rd["RECOOTHER"].ToString();
                                sendhome = rd["RECOSENDHOME"].ToString();
                                tboxrecopatient.Text= rd["RECOPATIENT"].ToString();
                                tboxtimetest.Text= rd["TIMETEST"].ToString();
                                tboxserialno.Text = rd["SERIALNO"].ToString();
                                tboxlicense.Text = rd["LICENSENO"].ToString();
                                tboxCOM.Text = rd["COMMENT"].ToString();
                                fittowork = rd["RECOFITTOWORK"].ToString();
                                TBOXantigendate.Text = rd["ANTIGENDATE"].ToString();
                                TBOXantigentime.Text = rd["ANTIGENTIME"].ToString();
                                TBOXantigenserialno.Text = rd["ANTIGENSERIAL"].ToString();
                                testresultantigen = rd["ANTIGENRESULT"].ToString();
                            }
                        }

                        for (int i = 0; i < cboxTESTRESULT.Items.Count; i++)
                        {
                            if (testresult.Contains(cboxTESTRESULT.Items[i].Value.ToString()))
                            {
                                cboxTESTRESULT.Items[i].Selected = true;
                            }
                        }
                        for (int i = 0; i < cboxantigen.Items.Count; i++)
                        {
                            if (testresultantigen.Contains(cboxantigen.Items[i].Value.ToString()))
                            {
                                cboxantigen.Items[i].Selected = true;
                            }
                        }
                        if (tboxrecoendo.Text != "")
                        {
                            cboxrecoendo.Checked = true;
                        }
                        if (tboxrecocallin.Text != "")
                        {
                            cboxrecocallin.Checked = true;
                        }
                        if (sendhome != "")
                        {
                            cboxrecosendhome.Checked = true;
                        }
                        if (fittowork != "")
                        {
                            cboxrecofittowork.Checked = true;
                        }
                        if (tboxrecoother.Text != "")
                        {
                            cboxrecoother.Checked = true;
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
            insert();
        }
        private void insert()
        {
            try
            {
                string testresult = "";
                string testresultantigen = "";
                foreach (ListItem li in cboxTESTRESULT.Items)
                {
                    if (li.Selected)
                    {
                        testresult += " *" + li.Value.ToString();
                    }
                }
                foreach (ListItem li in cboxantigen.Items)
                {
                    if (li.Selected)
                    {
                        testresultantigen += " *" + li.Value.ToString();
                    }
                }
                string sendhome = "";
                if (cboxrecosendhome.Checked)
                {
                    sendhome = "Send home";
                }


                string f="";
                if (cboxrecofittowork.Checked)
                {
                    f = "fit to work";
                }
             
               
                string find = "select * from dhppage2 where empno=@empno and dhpid=@dhpid";
                bool exist = false;
                string insertstr = " declare @id as integer = (select isnull(max(isnull(id,0)),0)+1 from dhppage2)" +
                                " insert into dhppage2" +
                                " (ID,EMPNO,DHPID,EXPOSURETOVIRUS,DATETESTDONE,TIMETEST,SERIALNO,TESTRESULT,PATIENTNAME,ADMINISTEREDBY,PHYSICIAN,LICENSENO,recoendo,recocallin,recosendhome,recoother,recopatient,comment,RECOFITTOWORK,ANTIGENDATE,ANTIGENTIME,ANTIGENSERIAL,ANTIGENRESULT)" +
                                " values(@id,@empno,@dhpid,@exposuretovirus,@datetestdone,@timetest,@serialno,@testresult,@patientname,@administeredby,@physician,@licenseno,@recoendo,@recocallin,@recosendhome,@recoother,@patientreco,@comment,@fittowork,@antigendate,@antigentime,@antigenserial,@antigenresult)";
                string updatestr = " update dhppage2 set				   " +
                                " EXPOSURETOVIRUS=@exposuretovirus,	   " +
                                " DATETESTDONE=@datetestdone,		   " +
                                " TESTRESULT=@testresult,			   " +
                                " TIMETEST=@timetest,			   " +
                                " SERIALNO=@serialno,			   " +
                                " PATIENTNAME=@patientname,			   " +
                                " ADMINISTEREDBY=@administeredby,	   " +
                                " PHYSICIAN=@physician,				   " +
                                " LICENSENO=@licenseno,				   " +
                                " recoendo=@recoendo,				   " +
                                " recocallin=@recocallin,			   " +
                                " recosendhome=@recosendhome,		   " +
                                " recoother=@recoother,				   " +
                                " recopatient=@patientreco,				   " +
                                " RECOFITTOWORK=@fittowork,				   " +
                                  " antigendate=@antigendate,				   " +
                                    " antigentime=@antigentime,				   " +
                                      " antigenserial=@antigenserial,				   " +
                                        " antigenresult=@antigenresult,				   " +
                                 " comment=@comment				   " +
                                " where EMPNO=@empno and DHPID=@dhpid  ";
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
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
                            setparam(sqlcmd, testresult, testresultantigen, sendhome, f);
                        }
                    }
                    else
                    {
                        using (SqlCommand sqlcmd = new SqlCommand(insertstr, sqlcon))
                        {
                            setparam(sqlcmd, testresult, testresultantigen, sendhome, f);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "val2";
                err.IsValid = false;
                err.ErrorMessage = ex.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "val2";
                err.IsValid = false;
                err.ErrorMessage = "page 2 saved successfully";
                Page.Validators.Add(err);
            }
        }
        private void setparam(SqlCommand sqlcmd, string testresult,string antigentestresult, string sendhome, string fittowork)
        {
            sqlcmd.Parameters.AddWithValue("@empno", empno);
            sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
            sqlcmd.Parameters.AddWithValue("@exposuretovirus", tboxexposuretovirus.Text);
            sqlcmd.Parameters.AddWithValue("@datetestdone", tboxdatetestdone.Text);
            sqlcmd.Parameters.AddWithValue("@testresult", testresult);
            sqlcmd.Parameters.AddWithValue("@timetest", tboxtimetest.Text);
            sqlcmd.Parameters.AddWithValue("@serialno", tboxserialno.Text);
            sqlcmd.Parameters.AddWithValue("@patientname", tboxpatientname.Text);
            sqlcmd.Parameters.AddWithValue("@administeredby", tboxadministeredby.Text);
            sqlcmd.Parameters.AddWithValue("@physician", tboxphysician.Text);
            sqlcmd.Parameters.AddWithValue("@licenseno", tboxlicense.Text);
            sqlcmd.Parameters.AddWithValue("@recoendo", tboxrecoendo.Text);
            sqlcmd.Parameters.AddWithValue("@recocallin", tboxrecocallin.Text);
            sqlcmd.Parameters.AddWithValue("@recosendhome", sendhome);
            sqlcmd.Parameters.AddWithValue("@recoother", tboxrecoother.Text);
            sqlcmd.Parameters.AddWithValue("@patientreco", tboxrecopatient.Text);
            sqlcmd.Parameters.AddWithValue("@comment", tboxCOM.Text);
            sqlcmd.Parameters.AddWithValue("@fittowork", fittowork);

            sqlcmd.Parameters.AddWithValue("@antigendate", TBOXantigendate.Text);
            sqlcmd.Parameters.AddWithValue("@antigentime", TBOXantigentime.Text);
            sqlcmd.Parameters.AddWithValue("@antigenserial", TBOXantigenserialno.Text);
            sqlcmd.Parameters.AddWithValue("@antigenresult",antigentestresult );
            sqlcmd.ExecuteNonQuery();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            insert();
            Session["dhp_pagesender"] = "page2_patient";
            Response.Redirect("~/DAILYHEALTHPROFILE/dhpsignature.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {

                foreach (HttpPostedFile thefile in FileUpload1.PostedFiles)
                {
                    string fileExtension = System.IO.Path.GetExtension(thefile.FileName).ToString().ToLower();

                    if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".gif")
                    {
                        double filesize = thefile.ContentLength;
                        if (filesize < 29360128.00)
                        {
                            thefile.SaveAs(Server.MapPath(filepath3 + empno + dhpid + "/" + thefile.FileName));
                            loadimages();
                            loadsignature();
                        }
                        else
                        {
                            CustomValidator err = new CustomValidator();
                            errorrmessage("You can only upload files of size lesser than 28 MB, but you are uploading a file of " + Math.Round((filesize / 1048576.00), 2) + " MB");
                        }
                    }
                    else
                    {
                        errorrmessage("invalid file type");
                    }
                }
            }
            else
            {
                errorrmessage("select image first");
            }

        }

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    gettravelhistory();
        //}

        //private void gettravelhistory()
        //{
        //    try
        //    {
        //       
        //        string str = "select * from dhptravelhistory where empno=@empno and dhpid=@dhpid order by sorting asc";
        //        using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
        //        {
        //            using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
        //            {
        //                sqlcon.Open();
        //                DataTable tb = new DataTable();
        //                sqlcmd.Parameters.AddWithValue("@empno", empno);
        //                sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
        //                SqlDataAdapter da = new SqlDataAdapter();
        //                da.SelectCommand = sqlcmd;
        //                da.Fill(tb);
        //                GridView1.DataSource = tb;
        //                GridView1.DataBind();
        //                if (acct == "Admin")
        //                {
        //                    GridView1.Columns[0].Visible = true;
        //                }
        //                else
        //                {
        //                    GridView1.Columns[0].Visible = false;
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errorrmessage(ex.Message.ToString());

        //    }
        //    finally
        //    {
        //        gettravelsummary();
        //    }
        //}
        //private void inserttravelhistory(string travelhistory)
        //{
        //    try
        //    {
        //       
        //        string str = "declare @id as integer = (select isnull(max(isnull(id,0)),0)+1 from dhptravelhistory)" +
        //            "declare @sorting as integer = (select count(isnull(id,0))+1 from dhptravelhistory where empno=@empno and dhpid=@dhpid)" +
        //            " insert into dhptravelhistory (id,empno,dhpid,sorting,travelhistory)values(@id,@empno,@dhpid,@sorting,@travelhistory)";
        //        using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
        //        {
        //            using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
        //            {
        //                sqlcon.Open();
        //                DataTable tb = new DataTable();
        //                sqlcmd.Parameters.AddWithValue("@empno", empno);
        //                sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
        //                sqlcmd.Parameters.AddWithValue("@travelhistory", travelhistory);
        //                sqlcmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomValidator err = new CustomValidator();
        //        err.ValidationGroup = "travelval";
        //        err.IsValid = false;
        //        err.ErrorMessage = ex.Message.ToString();
        //        Page.Validators.Add(err);
        //    }
        //    finally
        //    {
        //        gettravelhistory();
        //    }
        //}
        //protected void LinkButton4_Click(object sender, EventArgs e)
        //{
        //    inserttravelhistory(dltravelhistory.Text);
        //}

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "myedit")
        //    {
        //        int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
        //        GridViewRow row = GridView1.Rows[rowindex];
        //        ((LinkButton)row.FindControl("btnedit")).Visible = false;
        //        ((LinkButton)row.FindControl("btndelete")).Visible = false;
        //        ((Label)row.FindControl("lblsorting")).Visible = false;
        //        ((Label)row.FindControl("lbltravelhistory")).Visible = false;

        //        ((LinkButton)row.FindControl("btnupdate")).Visible = true;
        //        ((LinkButton)row.FindControl("btncancel")).Visible = true;
        //        ((TextBox)row.FindControl("tboxsorting")).Visible = true;
        //        ((TextBox)row.FindControl("tboxtravelhistory")).Visible = true;
        //    }
        //    else if (e.CommandName == "myupdate")
        //    {
        //        int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
        //        GridViewRow row = GridView1.Rows[rowindex];
        //        updatetravelhistory(((Label)row.FindControl("lblid")).Text,
        //                ((TextBox)row.FindControl("tboxsorting")).Text,
        //        ((TextBox)row.FindControl("tboxtravelhistory")).Text);
        //    }
        //    else if (e.CommandName == "mycancel")
        //    {
        //        int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
        //        GridViewRow row = GridView1.Rows[rowindex];
        //        ((LinkButton)row.FindControl("btnedit")).Visible = true;
        //        ((LinkButton)row.FindControl("btndelete")).Visible = true;
        //        ((Label)row.FindControl("lblsorting")).Visible = true;
        //        ((Label)row.FindControl("lbltravelhistory")).Visible = true;

        //        ((LinkButton)row.FindControl("btnupdate")).Visible = false;
        //        ((LinkButton)row.FindControl("btncancel")).Visible = false;
        //        ((TextBox)row.FindControl("tboxsorting")).Visible = false;
        //        ((TextBox)row.FindControl("tboxtravelhistory")).Visible = false;
        //    }
        //    else if (e.CommandName == "mydelete")
        //    {
        //        int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
        //        GridViewRow row = GridView1.Rows[rowindex];
        //        deletetravelhistory(((Label)row.FindControl("lblid")).Text);
        //    }
        //}

        //private void deletetravelhistory(string id)
        //{
        //    try
        //    {
        //       
        //        string str = " delete from dhptravelhistory where id = @id";
        //        using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
        //        {
        //            using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
        //            {
        //                sqlcon.Open();
        //                DataTable tb = new DataTable();
        //                sqlcmd.Parameters.AddWithValue("@id", id);
        //                sqlcmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomValidator err = new CustomValidator();
        //        err.ValidationGroup = "travelval";
        //        err.IsValid = false;
        //        err.ErrorMessage = ex.Message.ToString();
        //        Page.Validators.Add(err);
        //    }
        //    finally
        //    {
        //        gettravelhistory();
        //    }
        //}

        //private void updatetravelhistory(string id, string sorting, string travelhistory)
        //{
        //    try
        //    {
        //       
        //        string str = " update dhptravelhistory set sorting=@sorting,travelhistory=@travelhistory where id = @id";
        //        using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
        //        {
        //            using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
        //            {
        //                sqlcon.Open();
        //                DataTable tb = new DataTable();
        //                sqlcmd.Parameters.AddWithValue("@id", id);
        //                sqlcmd.Parameters.AddWithValue("@sorting", sorting);
        //                sqlcmd.Parameters.AddWithValue("@travelhistory", travelhistory);
        //                sqlcmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomValidator err = new CustomValidator();
        //        err.ValidationGroup = "travelval";
        //        err.IsValid = false;
        //        err.ErrorMessage = ex.Message.ToString();
        //        Page.Validators.Add(err);
        //    }
        //    finally
        //    {
        //        gettravelhistory();
        //    }
        //}

        //protected void LinkButton5_Click(object sender, EventArgs e)
        //{
        //    inserttravelhistory(tboxother.Text);
        //}

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            insert();
            Session["dhp_pagesender"] = "page2_physician";
            Response.Redirect("~/DAILYHEALTHPROFILE/dhpsignature.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            insert();
            Session["dhp_pagesender"] = "page2_administered";
            Response.Redirect("~/DAILYHEALTHPROFILE/dhpsignature.aspx");
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "myedit")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                ((LinkButton)row.FindControl("btneditg2")).Visible = false;
                ((LinkButton)row.FindControl("btndeleteg2")).Visible = false;
                ((Label)row.FindControl("lblfullnameg2")).Visible = false;

                ((TextBox)row.FindControl("tboxfullnameg2")).Visible = true;
                ((LinkButton)row.FindControl("btnupdateg2")).Visible = true;
                ((LinkButton)row.FindControl("btncancelg2")).Visible = true;
            }
            else if (e.CommandName == "mycancel")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                ((LinkButton)row.FindControl("btneditg2")).Visible = true;
                ((LinkButton)row.FindControl("btndeleteg2")).Visible = true;
                ((Label)row.FindControl("lblfullnameg2")).Visible = true;

                ((TextBox)row.FindControl("tboxfullnameg2")).Visible = false;
                ((LinkButton)row.FindControl("btnupdateg2")).Visible = false;
                ((LinkButton)row.FindControl("btncancelg2")).Visible = false;
            }
            else if (e.CommandName == "myupdate")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];

                updatepersonsinteract(((Label)row.FindControl("lblidg2")).Text,
             ((TextBox)row.FindControl("tboxfullnameg2")).Text);
            }
            else if (e.CommandName == "mydelete")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];

                deletepersonsinteract(((Label)row.FindControl("lblidg2")).Text);
            }
        }

        private void deletepersonsinteract(string id)
        {
            try
            {
               
                string str = "delete from personsinteract where id = @id";
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
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
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "g2";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getpersoninteract();
            }
        }

        private void updatepersonsinteract(string id, string fullname)
        {
            try
            {
               
                string str = "update personsinteract set fullname=@fullname where id = @id";
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@id", id);
                        sqlcmd.Parameters.AddWithValue("@fullname", fullname);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "g2";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getpersoninteract();
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            getpersoninteract();
        }

        private void getpersoninteract()
        {
            try
            {
               
                string str = " select * from personsinteract where dhpid=@dhpid and empno=@empno";
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        DataTable tb = new DataTable();
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(tb);
                        GridView2.DataSource = tb;
                        GridView2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "g2";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                string str = "declare @id as integer  =  (select isnull(max(isnull(id,0)),0)+1 from personsinteract)" +
                    " insert into personsinteract (id,empno,dhpid,fullname)values(@id,@empno,@dhpid,@fullname)";
                using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcon.Open();
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        sqlcmd.Parameters.AddWithValue("@fullname", tboxfullname.Text);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "g2";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getpersoninteract();
            }
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            insert();
            Session["dhp_pagesender"] = "page2_clientsreco";
            Response.Redirect("~/DAILYHEALTHPROFILE/dhpsignature.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["pagesender"].ToString() == "dhphome")
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/dhphome.aspx");
            }
            else if (Session["pagesender"].ToString() == "reportgen")
            {
                Response.Redirect("~/DAILYHEALTHPROFILE/reportgen.aspx");
            }
        }
    }
}