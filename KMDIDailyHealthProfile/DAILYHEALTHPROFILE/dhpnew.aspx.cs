using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webaftersales.DAILYHEALTHPROFILE
{
    public partial class dhpnew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dhp_USERNAME"] != null)
            {

                if (!IsPostBack)
                {
                    lbldate.Text = Session["dhpdate"].ToString();
                    lblname.Text = Session["dhpname"].ToString();
                    lblempno.Text = Session["dhpempno"].ToString();
                    lblage.Text = Session["dhpage"].ToString();
                    lblbirthday.Text = Session["dhpbirthday"].ToString();
                    getdata();
                    if (acct == "Admin")
                    {
                        tboxCOM.Enabled = true;
                    }
                    else
                    {
                        tboxCOM.Enabled = false;
                    }
                    getbodytempdata();
                    loadsymptoms();
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
        private string acct
        {
            get
            {
                return Session["dhp_USERACCT"].ToString();
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
        private void getbodytempdata()
        {
            try
            {
                string str = " select * from dhp_bodytemp where empno = @empno and dhpid=@dhpid order by cast(ACTUALTIMETAKEN as time) asc";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
                    DataTable tb = new DataTable();
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcmd;
                        da.Fill(tb);
                        GridView1.DataSource = tb;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "addonval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }

        }
        private void getdata()
        {
            try
            {
                string str = " select * from asnwersheettbl where empno = @empno and dhpid=@dhpid";
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
                                DCEXyes.Checked = getbol(rd["DCEX"].ToString());
                                DCEXno.Checked = getbol(rd["DCEXno"].ToString());
                                tboxDCDO.Text = rd["DCDO"].ToString();
                                tboxDCET.Text = rd["DCET"].ToString();
                                tboxDCRE.Text = rd["DCRE"].ToString();
                                FEEXyes.Checked = getbol(rd["FEEX"].ToString());
                                FEEXno.Checked = getbol(rd["FEEXno"].ToString());
                                tboxFEDO.Text = rd["FEDO"].ToString();
                                tboxFEET.Text = rd["FEET"].ToString();
                                tboxFERE.Text = rd["FERE"].ToString();
                                MPEXyes.Checked = getbol(rd["MPEX"].ToString());
                                MPEXno.Checked = getbol(rd["MPEXno"].ToString());
                                tboxMPDO.Text = rd["MPDO"].ToString();
                                tboxMPET.Text = rd["MPET"].ToString();
                                tboxMPRE.Text = rd["MPRE"].ToString();
                                WEEXyes.Checked = getbol(rd["WEEX"].ToString());
                                WEEXno.Checked = getbol(rd["WEEXno"].ToString());
                                tboxWEDO.Text = rd["WEDO"].ToString();
                                tboxWEET.Text = rd["WEET"].ToString();
                                tboxWERE.Text = rd["WERE"].ToString();
                                DSEXyes.Checked = getbol(rd["DSEX"].ToString());
                                DSEXno.Checked = getbol(rd["DSEXno"].ToString());
                                tboxDSDO.Text = rd["DSDO"].ToString();
                                tboxDSET.Text = rd["DSET"].ToString();
                                tboxDSRE.Text = rd["DSRE"].ToString();
                                DTEXyes.Checked = getbol(rd["DTEX"].ToString());
                                DTEXno.Checked = getbol(rd["DTEXno"].ToString());
                                tboxDTDO.Text = rd["DTDO"].ToString();
                                tboxDTET.Text = rd["DTET"].ToString();
                                tboxDTRE.Text = rd["DTRE"].ToString();
                                DIEXyes.Checked = getbol(rd["DIEX"].ToString());
                                DIEXno.Checked = getbol(rd["DIEXno"].ToString());
                                tboxDIDO.Text = rd["DIDO"].ToString();
                                tboxDIET.Text = rd["DIET"].ToString();
                                tboxDIRE.Text = rd["DIRE"].ToString();
                                DBEXyes.Checked = getbol(rd["DBEX"].ToString());
                                DBEXno.Checked = getbol(rd["DBEXno"].ToString());
                                tboxDBDO.Text = rd["DBDO"].ToString();
                                tboxDBET.Text = rd["DBET"].ToString();
                                tboxDBRE.Text = rd["DBRE"].ToString();
                                LBEXyes.Checked = getbol(rd["LBEX"].ToString());
                                LBEXno.Checked = getbol(rd["LBEXno"].ToString());
                                tboxLBDO.Text = rd["LBDO"].ToString();
                                tboxLBET.Text = rd["LBET"].ToString();
                                tboxLBRE.Text = rd["LBRE"].ToString();
                                VOEXyes.Checked = getbol(rd["VOEX"].ToString());
                                VOEXno.Checked = getbol(rd["VOEXno"].ToString());
                                tboxVODO.Text = rd["VODO"].ToString();
                                tboxVOET.Text = rd["VOET"].ToString();
                                tboxVORE.Text = rd["VORE"].ToString();
                                OSEXyes.Checked = getbol(rd["OSEX"].ToString());
                                OSEXno.Checked = getbol(rd["OSEXno"].ToString());
                                tboxOSDO.Text = rd["OSDO"].ToString();
                                tboxOSET.Text = rd["OSET"].ToString();
                                tboxOSRE.Text = rd["OSRE"].ToString();
                                tboxOS.Text = rd["OS"].ToString();
                                tboxCOM.Text = rd["COMMENT"].ToString();

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

        private bool getbol(string val)
        {
            return (val != "0");
        }
        private string historystr(string actionmade)
        {
         
                string insertstr = " declare @idpp as integer = (select isnull(max(isnull(id,0)),0)+1 from ASNWERSHEETtbl_history) " +
                                  "insert into ASNWERSHEETtbl_history " +
                                   "(ID ,	" +
                                       "ACTIONMADE,	" +
                                         "EMPNOEDITEDBY,	" +
                                           "DATEALTERED,	" +
                                   "EMPNO,	" +
                                   "DHPID,	" +
                                   "DCEX ,	" +
                                   "DCEXno ,	" +
                                   "DCDO ,	" +
                                   "DCET ,	" +
                                   "DCRE ,	" +
                                   "FEEX ,	" +
                                   "FEEXno ,	" +
                                   "FEDO ,	" +
                                   "FEET ,	" +
                                   "FERE ,	" +
                                   "MPEX ,	" +
                                   "MPEXno ,	" +
                                   "MPDO ,	" +
                                   "MPET ,	" +
                                   "MPRE ,	" +
                                   "WEEX ,	" +
                                   "WEEXno ,	" +
                                   "WEDO ,	" +
                                   "WEET ,	" +
                                   "WERE ,	" +
                                   "DSEX ,	" +
                                   "DSEXno ,	" +
                                   "DSDO ,	" +
                                   "DSET ,	" +
                                   "DSRE ,	" +
                                   "DTEX ,	" +
                                   "DTEXno ,	" +
                                   "DTDO ,	" +
                                   "DTET ,	" +
                                   "DTRE ,	" +
                                   "DIEX ,	" +
                                   "DIEXno ,	" +
                                   "DIDO ,	" +
                                   "DIET ,	" +
                                   "DIRE ,	" +
                                   "DBEX ,	" +
                                   "DBEXno ,	" +
                                   "DBDO ,	" +
                                   "DBET ,	" +
                                   "DBRE ,	" +
                                   "LBEX ,	" +
                                   "LBEXno ,	" +
                                   "LBDO ,	" +
                                   "LBET ,	" +
                                   "LBRE ,	" +
                                   "VOEX ,	" +
                                   "VOEXno ,	" +
                                   "VODO ,	" +
                                   "VOET ,	" +
                                   "VORE ,	" +
                                   "OSEX ,	" +
                                   "OSEXno ,	" +
                                   "OSDO ,	" +
                                   "OSET ,	" +
                                   "OSRE ,	" +
                                   " OS,COMMENT) " +
                                   "values	" +
                                   "(@idpp ,	" +
                                       "'"+actionmade+"',	" +
                                         "@editedby,	" +
                                           "getdate(),	" +
                                   "@empno," +
                                   "@dhpid," +
                                   "@DCEX ," +
                                   "@DCEXno ," +
                                   "@DCDO ," +
                                   "@DCET ," +
                                   "@DCRE ," +
                                   "@FEEX ," +
                                   "@FEEXno ," +
                                   "@FEDO ," +
                                   "@FEET ," +
                                   "@FERE ," +
                                   "@MPEX ," +
                                   "@MPEXno ," +
                                   "@MPDO ," +
                                   "@MPET ," +
                                   "@MPRE ," +
                                   "@WEEX ," +
                                   "@WEEXno ," +
                                   "@WEDO ," +
                                   "@WEET ," +
                                   "@WERE ," +
                                   "@DSEX ," +
                                   "@DSEXno ," +
                                   "@DSDO ," +
                                   "@DSET ," +
                                   "@DSRE ," +
                                   "@DTEX ," +
                                   "@DTEXno ," +
                                   "@DTDO ," +
                                   "@DTET ," +
                                   "@DTRE ," +
                                   "@DIEX ," +
                                   "@DIEXno ," +
                                   "@DIDO ," +
                                   "@DIET ," +
                                   "@DIRE ," +
                                   "@DBEX ," +
                                   "@DBEXno ," +
                                   "@DBDO ," +
                                   "@DBET ," +
                                   "@DBRE ," +
                                   "@LBEX ," +
                                   "@LBEXno ," +
                                   "@LBDO ," +
                                   "@LBET ," +
                                   "@LBRE ," +
                                   "@VOEX ," +
                                   "@VOEXno ," +
                                   "@VODO ," +
                                   "@VOET ," +
                                   "@VORE ," +
                                   "@OSEX ," +
                                   "@OSEXno ," +
                                   "@OSDO ," +
                                   "@OSET ," +
                                   "@OSRE , " +
                                   " @OS,@COMMENT) ";
                return insertstr;
            
          
        }
        private void insertanswersheet()
        {
            try
            {
                string find = "select * from ASNWERSHEETtbl where empno=@empno and dhpid=@dhpid";
                bool exist = false;


                string insertstr = " declare @id as integer = (select isnull(max(isnull(id,0)),0)+1 from ASNWERSHEETtbl) " +
                                   "insert into ASNWERSHEETtbl " +
                                    "(ID ,	" +
                                    "EMPNO,	" +
                                    "DHPID,	" +
                                    "DCEX ,	" +
                                    "DCEXno ,	" +
                                    "DCDO ,	" +
                                    "DCET ,	" +
                                    "DCRE ,	" +
                                    "FEEX ,	" +
                                    "FEEXno ,	" +
                                    "FEDO ,	" +
                                    "FEET ,	" +
                                    "FERE ,	" +
                                    "MPEX ,	" +
                                    "MPEXno ,	" +
                                    "MPDO ,	" +
                                    "MPET ,	" +
                                    "MPRE ,	" +
                                    "WEEX ,	" +
                                    "WEEXno ,	" +
                                    "WEDO ,	" +
                                    "WEET ,	" +
                                    "WERE ,	" +
                                    "DSEX ,	" +
                                    "DSEXno ,	" +
                                    "DSDO ,	" +
                                    "DSET ,	" +
                                    "DSRE ,	" +
                                    "DTEX ,	" +
                                    "DTEXno ,	" +
                                    "DTDO ,	" +
                                    "DTET ,	" +
                                    "DTRE ,	" +
                                    "DIEX ,	" +
                                    "DIEXno ,	" +
                                    "DIDO ,	" +
                                    "DIET ,	" +
                                    "DIRE ,	" +
                                    "DBEX ,	" +
                                    "DBEXno ,	" +
                                    "DBDO ,	" +
                                    "DBET ,	" +
                                    "DBRE ,	" +
                                    "LBEX ,	" +
                                    "LBEXno ,	" +
                                    "LBDO ,	" +
                                    "LBET ,	" +
                                    "LBRE ,	" +
                                    "VOEX ,	" +
                                    "VOEXno ,	" +
                                    "VODO ,	" +
                                    "VOET ,	" +
                                    "VORE ,	" +
                                    "OSEX ,	" +
                                    "OSEXno ,	" +
                                    "OSDO ,	" +
                                    "OSET ,	" +
                                    "OSRE ,	" +
                                    " OS,COMMENT) " +
                                    "values	" +
                                    "(@id ,	" +
                                    "@empno," +
                                    "@dhpid," +
                                    "@DCEX ," +
                                    "@DCEXno ," +
                                    "@DCDO ," +
                                    "@DCET ," +
                                    "@DCRE ," +
                                    "@FEEX ," +
                                    "@FEEXno ," +
                                    "@FEDO ," +
                                    "@FEET ," +
                                    "@FERE ," +
                                    "@MPEX ," +
                                    "@MPEXno ," +
                                    "@MPDO ," +
                                    "@MPET ," +
                                    "@MPRE ," +
                                    "@WEEX ," +
                                    "@WEEXno ," +
                                    "@WEDO ," +
                                    "@WEET ," +
                                    "@WERE ," +
                                    "@DSEX ," +
                                    "@DSEXno ," +
                                    "@DSDO ," +
                                    "@DSET ," +
                                    "@DSRE ," +
                                    "@DTEX ," +
                                    "@DTEXno ," +
                                    "@DTDO ," +
                                    "@DTET ," +
                                    "@DTRE ," +
                                    "@DIEX ," +
                                    "@DIEXno ," +
                                    "@DIDO ," +
                                    "@DIET ," +
                                    "@DIRE ," +
                                    "@DBEX ," +
                                    "@DBEXno ," +
                                    "@DBDO ," +
                                    "@DBET ," +
                                    "@DBRE ," +
                                    "@LBEX ," +
                                    "@LBEXno ," +
                                    "@LBDO ," +
                                    "@LBET ," +
                                    "@LBRE ," +
                                    "@VOEX ," +
                                    "@VOEXno ," +
                                    "@VODO ," +
                                    "@VOET ," +
                                    "@VORE ," +
                                    "@OSEX ," +
                                    "@OSEXno ," +
                                    "@OSDO ," +
                                    "@OSET ," +
                                    "@OSRE , " +
                                    " @OS,@COMMENT) "+
                                    historystr("Insert");
                string updatestr = " update ASNWERSHEETtbl set " +
                                    " DCEX = @DCEX , " +
                                    " DCEXno = @DCEXno , " +
                                    " DCDO = @DCDO , " +
                                    " DCET = @DCET , " +
                                    " DCRE = @DCRE , " +
                                    " FEEX = @FEEX , " +
                                    " FEEXno = @FEEXno , " +
                                    " FEDO = @FEDO , " +
                                    " FEET = @FEET , " +
                                    " FERE = @FERE , " +
                                    " MPEX = @MPEX , " +
                                    " MPEXno = @MPEXno , " +
                                    " MPDO = @MPDO , " +
                                    " MPET = @MPET , " +
                                    " MPRE = @MPRE , " +
                                    " WEEX = @WEEX , " +
                                    " WEEXno = @WEEXno , " +
                                    " WEDO = @WEDO , " +
                                    " WEET = @WEET , " +
                                    " WERE = @WERE , " +
                                    " DSEX = @DSEX , " +
                                    " DSEXno = @DSEXno , " +
                                    " DSDO = @DSDO , " +
                                    " DSET = @DSET , " +
                                    " DSRE = @DSRE , " +
                                    " DTEX = @DTEX , " +
                                    " DTEXno = @DTEXno , " +
                                    " DTDO = @DTDO , " +
                                    " DTET = @DTET , " +
                                    " DTRE = @DTRE , " +
                                    " DIEX = @DIEX , " +
                                    " DIEXno = @DIEXno , " +
                                    " DIDO = @DIDO , " +
                                    " DIET = @DIET , " +
                                    " DIRE = @DIRE , " +
                                    " DBEX = @DBEX , " +
                                    " DBEXno = @DBEXno , " +
                                    " DBDO = @DBDO , " +
                                    " DBET = @DBET , " +
                                    " DBRE = @DBRE , " +
                                    " LBEX = @LBEX , " +
                                    " LBEXno = @LBEXno , " +
                                    " LBDO = @LBDO , " +
                                    " LBET = @LBET , " +
                                    " LBRE = @LBRE , " +
                                    " VOEX = @VOEX , " +
                                    " VOEXno = @VOEXno , " +
                                    " VODO = @VODO , " +
                                    " VOET = @VOET , " +
                                    " VORE = @VORE , " +
                                    " OSEX = @OSEX , " +
                                    " OSEXno = @OSEXno , " +
                                    " OSDO = @OSDO , " +
                                    " OSET = @OSET , " +
                                    " OSRE = @OSRE ,  " +
                                    " OS = @OS ,  " +
                                    " COMMENT = @COMMENT " +
                                    " where EMPNO=@empno and DHPID=@dhpid "+
                                          historystr("Update");


                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
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
                            setparam(sqlcmd);
                        }
                    }
                    else
                    {
                        using (SqlCommand sqlcmd = new SqlCommand(insertstr, sqlcon))
                        {
                            setparam(sqlcmd);
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
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "val2";
                err.IsValid = false;
                err.ErrorMessage = "page 1 saved successfully";
                Page.Validators.Add(err);
            }

        }
        private void setparam(SqlCommand sqlcmd)
        {

            sqlcmd.Parameters.AddWithValue("@editedby", Session["dhp_currentuser"].ToString());
            sqlcmd.Parameters.AddWithValue("@empno", empno);
            sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
            sqlcmd.Parameters.AddWithValue("@DCEX", DCEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@DCEXno", DCEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@DCDO", tboxDCDO.Text);
            sqlcmd.Parameters.AddWithValue("@DCET", tboxDCET.Text);
            sqlcmd.Parameters.AddWithValue("@DCRE", tboxDCRE.Text);
            sqlcmd.Parameters.AddWithValue("@FEEX", FEEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@FEEXno", FEEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@FEDO", tboxFEDO.Text);
            sqlcmd.Parameters.AddWithValue("@FEET", tboxFEET.Text);
            sqlcmd.Parameters.AddWithValue("@FERE", tboxFERE.Text);
            sqlcmd.Parameters.AddWithValue("@MPEX", MPEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@MPEXno", MPEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@MPDO", tboxMPDO.Text);
            sqlcmd.Parameters.AddWithValue("@MPET", tboxMPET.Text);
            sqlcmd.Parameters.AddWithValue("@MPRE", tboxMPRE.Text);
            sqlcmd.Parameters.AddWithValue("@WEEX", WEEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@WEEXno", WEEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@WEDO", tboxWEDO.Text);
            sqlcmd.Parameters.AddWithValue("@WEET", tboxWEET.Text);
            sqlcmd.Parameters.AddWithValue("@WERE", tboxWERE.Text);
            sqlcmd.Parameters.AddWithValue("@DSEX", DSEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@DSEXno", DSEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@DSDO", tboxDSDO.Text);
            sqlcmd.Parameters.AddWithValue("@DSET", tboxDSET.Text);
            sqlcmd.Parameters.AddWithValue("@DSRE", tboxDSRE.Text);
            sqlcmd.Parameters.AddWithValue("@DTEX", DTEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@DTEXno", DTEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@DTDO", tboxDTDO.Text);
            sqlcmd.Parameters.AddWithValue("@DTET", tboxDTET.Text);
            sqlcmd.Parameters.AddWithValue("@DTRE", tboxDTRE.Text);
            sqlcmd.Parameters.AddWithValue("@DIEX", DIEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@DIEXno", DIEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@DIDO", tboxDIDO.Text);
            sqlcmd.Parameters.AddWithValue("@DIET", tboxDIET.Text);
            sqlcmd.Parameters.AddWithValue("@DIRE", tboxDIRE.Text);
            sqlcmd.Parameters.AddWithValue("@DBEX", DBEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@DBEXno", DBEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@DBDO", tboxDBDO.Text);
            sqlcmd.Parameters.AddWithValue("@DBET", tboxDBET.Text);
            sqlcmd.Parameters.AddWithValue("@DBRE", tboxDBRE.Text);
            sqlcmd.Parameters.AddWithValue("@LBEX", LBEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@LBEXno", LBEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@LBDO", tboxLBDO.Text);
            sqlcmd.Parameters.AddWithValue("@LBET", tboxLBET.Text);
            sqlcmd.Parameters.AddWithValue("@LBRE", tboxLBRE.Text);
            sqlcmd.Parameters.AddWithValue("@VOEX", VOEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@VOEXno", VOEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@VODO", tboxVODO.Text);
            sqlcmd.Parameters.AddWithValue("@VOET", tboxVOET.Text);
            sqlcmd.Parameters.AddWithValue("@VORE", tboxVORE.Text);
            sqlcmd.Parameters.AddWithValue("@OSEX", OSEXyes.Checked);
            sqlcmd.Parameters.AddWithValue("@OSEXno", OSEXno.Checked);
            sqlcmd.Parameters.AddWithValue("@OSDO", tboxOSDO.Text);
            sqlcmd.Parameters.AddWithValue("@OSET", tboxOSET.Text);
            sqlcmd.Parameters.AddWithValue("@OSRE", tboxOSRE.Text);
            sqlcmd.Parameters.AddWithValue("@OS", tboxOS.Text);
            sqlcmd.Parameters.AddWithValue("@COMMENT", tboxCOM.Text);


            sqlcmd.ExecuteNonQuery();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            insertanswersheet();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = " declare @id as integer = (select isnull(max(isnull(id,0)),0)+1 from dhp_bodytemp)" +
                    " insert into dhp_bodytemp (id,empno,dhpid,ACTUALTIMETAKEN,timeofday,TEMPREADING)values(@id,@empno,@dhpid,@att,@timeofday,@tr)"+
                    " declare @idpp as integer = (select isnull(max(isnull(id,0)),0)+1 from dhp_bodytemp_history) " +
                    " insert into dhp_bodytemp_history (ID,ITEMID,empno,dhpid,actionmade,EMPNOEDITEDBY,DATEALTERED,TIMEOFDAY,ACTUALTIMETAKEN,TEMPREADING) values(@idpp,@id,@empno,@dhpid,'Insert',@editedby,getdate(),@timeofday,@att,@tr)";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
                 
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        sqlcmd.Parameters.AddWithValue("@att", tboxaddonatt.Text);
                        sqlcmd.Parameters.AddWithValue("@timeofday", cboxaddontimeofday.Text);
                        sqlcmd.Parameters.AddWithValue("@tr", tboxaddontr.Text);
                        sqlcmd.Parameters.AddWithValue("@editedby", Session["dhp_currentuser"].ToString());
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "addonval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getbodytempdata();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "myedit")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                visibility(row, false, true);
            }
            else if (e.CommandName == "mycancel")
            {

                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                visibility(row, true, false);

            }
            else if (e.CommandName == "myupdate")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                updatebodytemp(((Label)row.FindControl("lblid")).Text,
                    ((TextBox)row.FindControl("tboxeditaddonatt")).Text,
                ((DropDownList)row.FindControl("cboxeditaddontimeofday")).Text,
                ((TextBox)row.FindControl("tboxeditaddontr")).Text);
            }
            else if (e.CommandName == "mydelete")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView1.Rows[rowindex];
                deletebodytemp(((Label)row.FindControl("lblid")).Text);
            }
        }
        private void visibility(GridViewRow row, bool x, bool y)
        {
            ((Label)row.FindControl("lblatt")).Visible = x;
            ((Label)row.FindControl("lbltimeofday")).Visible = x;
            ((Label)row.FindControl("lbltr")).Visible = x;
            ((LinkButton)row.FindControl("btnedit")).Visible = x;
            ((LinkButton)row.FindControl("btndelete")).Visible = x;
            ((RegularExpressionValidator)row.FindControl("RegularExpressionValidator5")).Visible = x;
            ((RequiredFieldValidator)row.FindControl("RequiredFieldValidator442")).Visible = x;
            ((RequiredFieldValidator)row.FindControl("RequiredFieldValidator143")).Visible = x;

            ((TextBox)row.FindControl("tboxeditaddonatt")).Visible = y;
            ((DropDownList)row.FindControl("cboxeditaddontimeofday")).Visible = y;
            ((TextBox)row.FindControl("tboxeditaddontr")).Visible = y;
            ((LinkButton)row.FindControl("btnupdate")).Visible = y;
            ((LinkButton)row.FindControl("btncancel")).Visible = y;
            ((RegularExpressionValidator)row.FindControl("RegularExpressionValidator5")).Visible = y;
            ((RequiredFieldValidator)row.FindControl("RequiredFieldValidator442")).Visible = y;
            ((RequiredFieldValidator)row.FindControl("RequiredFieldValidator143")).Visible = y;
        }
        private void deletebodytemp(string id)
        {
            try
            {
                string str = " delete from dhp_bodytemp where id = @id"+
                        " declare @idpp as integer = (select isnull(max(isnull(id,0)),0)+1 from dhp_bodytemp_history) " +
                    " insert into dhp_bodytemp_history (ID,ITEMID,empno,dhpid,actionmade,EMPNOEDITEDBY,DATEALTERED) values(@idpp,@id,@empno,@dhpid,'Delete',@editedby,getdate())";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
                  
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        sqlcmd.Parameters.AddWithValue("@editedby", Session["dhp_currentuser"].ToString());
                        sqlcmd.Parameters.AddWithValue("@id", id);
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "addonval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getbodytempdata();
            }
        }

        private void updatebodytemp(string id, string att, string td, string tr)
        {
            try
            {
                string str = " update dhp_bodytemp set ACTUALTIMETAKEN=@att,timeofday=@timeofday,TEMPREADING=@tr where id = @id"+
                   " declare @idpp as integer = (select isnull(max(isnull(id,0)),0)+1 from dhp_bodytemp_history) " +
                    " insert into dhp_bodytemp_history (ID,ITEMID,empno,dhpid,actionmade,EMPNOEDITEDBY,DATEALTERED,TIMEOFDAY,ACTUALTIMETAKEN,TEMPREADING) values(@idpp,@id,@empno,@dhpid,'Update',@editedby,getdate(),@timeofday,@att,@tr)";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
               
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        sqlcmd.Parameters.AddWithValue("@id", id);
                        sqlcmd.Parameters.AddWithValue("@att", att);
                        sqlcmd.Parameters.AddWithValue("@timeofday", td);
                        sqlcmd.Parameters.AddWithValue("@tr", tr);
                        sqlcmd.Parameters.AddWithValue("@editedby", Session["dhp_currentuser"].ToString());
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "addonval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                getbodytempdata();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getbodytempdata();
        }
        private void loadsymptoms()
        {
            try
            {
                string str = "SELECT * FROM DHP_symptom WHERE DHPID=@dhpid and empno=@empno";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
                    DataTable tb = new DataTable();
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
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
                err.ValidationGroup = "symptonval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string str = " declare @id as integer = (select isnull(max(isnull(id,0)),0)+1 from DHP_symptom) " +
                                 " insert into DHP_symptom (ID,EMPNO,DHPID,SYMPTOM,DATEOFONSET,TIMEOFONSET,REMARKS) " +
                                 "values " +
                                 "(@id, @empno, @dhpid, @SYMPTOM, @DATEOFONSET, @TIMEOFONSET, @REMARKS)"+
" declare @idpp as integer = (select isnull(max(isnull(id,0)),0)+1 from DHP_symptom_history)				" +
" insert into DHP_symptom_history 																			" +
" (ID,ITEMID,EMPNO,DHPID,ACTIONMADE,EMPNOEDITEDBY,DATEALTERED,SYMPTOM,DATEOFONSET,TIMEOFONSET,REMARKS)		" +
" values																									" +
" (@idpp,@id, @empno, @dhpid,'Insert',@editedby,getdate(),@SYMPTOM, @DATEOFONSET, @TIMEOFONSET, @REMARKS)	";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
                    DataTable tb = new DataTable();
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        sqlcmd.Parameters.AddWithValue("@SYMPTOM", ddlsymptom.Text);
                        sqlcmd.Parameters.AddWithValue("@DATEOFONSET", tboxdateofonset.Text);
                        sqlcmd.Parameters.AddWithValue("@TIMEOFONSET", tboxtimeonset.Text);
                        sqlcmd.Parameters.AddWithValue("@REMARKS", tboxremarks.Text);
                        sqlcmd.Parameters.AddWithValue("@editedby", Session["dhp_currentuser"].ToString());
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "symptonval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                loadsymptoms();
            }

        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            loadsymptoms();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "myedit")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                g2visibility(row, true, false);
            }
            else if (e.CommandName == "mycancel")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                g2visibility(row, false, true);
            }
            else if (e.CommandName == "myupdate")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                updatesymptom(((Label)row.FindControl("lblid2")).Text,
                    ((DropDownList)row.FindControl("ddleditsymptom")).Text,
                ((TextBox)row.FindControl("tboxeditdateofonset")).Text,
                ((TextBox)row.FindControl("tboxedittimeonset")).Text,
                ((TextBox)row.FindControl("tboxeditremarks")).Text);
            }
            else if (e.CommandName == "mydelete")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow row = GridView2.Rows[rowindex];
                deletesymptom(((Label)row.FindControl("lblid2")).Text);
            }
        }

        private void deletesymptom(string id)
        {
            try
            {
                string str = "delete from DHP_symptom where id  = @id"+
                       " declare @idpp as integer = (select isnull(max(isnull(id,0)),0)+1 from DHP_symptom_history)				" +
" insert into DHP_symptom_history 																			" +
" (ID,ITEMID,EMPNO,DHPID,ACTIONMADE,EMPNOEDITEDBY,DATEALTERED)		" +
" values																									" +
" (@idpp,@id, @empno, @dhpid,'Delete',@editedby,getdate())	";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
               
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@id", id);
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        sqlcmd.Parameters.AddWithValue("@editedby", Session["dhp_currentuser"].ToString());
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "symptonval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                loadsymptoms();
            }
        }

        private void updatesymptom(string id, string symptom, string dateofonset, string timeofonset, string remarks)
        {
            try
            {
                string str = "update DHP_symptom set SYMPTOM= @SYMPTOM,DATEOFONSET= @DATEOFONSET, TIMEOFONSET=@TIMEOFONSET, REMARKS=@REMARKS where id = @id"+
                    " declare @idpp as integer = (select isnull(max(isnull(id,0)),0)+1 from DHP_symptom_history)				" +
" insert into DHP_symptom_history 																			" +
" (ID,ITEMID,EMPNO,DHPID,ACTIONMADE,EMPNOEDITEDBY,DATEALTERED,SYMPTOM,DATEOFONSET,TIMEOFONSET,REMARKS)		" +
" values																									" +
" (@idpp,@id, @empno, @dhpid,'Update',@editedby,getdate(),@SYMPTOM, @DATEOFONSET, @TIMEOFONSET, @REMARKS)	";
                string cs = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
                    DataTable tb = new DataTable();
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        sqlcmd.Parameters.AddWithValue("@dhpid", dhpid);
                        sqlcmd.Parameters.AddWithValue("@id", id);
                        sqlcmd.Parameters.AddWithValue("@SYMPTOM", symptom);
                        sqlcmd.Parameters.AddWithValue("@DATEOFONSET", dateofonset);
                        sqlcmd.Parameters.AddWithValue("@TIMEOFONSET", timeofonset);
                        sqlcmd.Parameters.AddWithValue("@REMARKS", remarks);
                        sqlcmd.Parameters.AddWithValue("@editedby", Session["dhp_currentuser"].ToString());
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "symptonval";
                err.IsValid = false;
                err.ErrorMessage = ex.Message.ToString();
                Page.Validators.Add(err);
            }
            finally
            {
                loadsymptoms();
            }
        }

        private void g2visibility(GridViewRow row, bool x, bool y)
        {
            ((LinkButton)row.FindControl("btnedit2")).Visible = y;
            ((LinkButton)row.FindControl("btndelete2")).Visible = y;
            ((Label)row.FindControl("lblsymptom")).Visible = y;
            ((Label)row.FindControl("lbldateonset")).Visible = y;
            ((Label)row.FindControl("lblestimatedtime")).Visible = y;
            ((Label)row.FindControl("lblremarks")).Visible = y;

            ((LinkButton)row.FindControl("btnupdate2")).Visible = x;
            ((LinkButton)row.FindControl("btncancel2")).Visible = x;
            ((DropDownList)row.FindControl("ddleditsymptom")).Visible = x;
            ((TextBox)row.FindControl("tboxeditdateofonset")).Visible = x;
            ((TextBox)row.FindControl("tboxedittimeonset")).Visible = x;
            ((TextBox)row.FindControl("tboxeditremarks")).Visible = x;
        }
    }
}