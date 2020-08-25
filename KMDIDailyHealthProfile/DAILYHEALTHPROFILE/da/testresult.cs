using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE.da
{
    public class testresult
    {
        public string ID { set; get; }
        public string EMPNO { set; get; }
        public string  DHPID { set; get; }
        public string DATETESTDONE { set; get; }
        public string TIMETEST { set; get; }
        public string SERIALNO { set; get; }
        public string TESTRESULT { set; get; }
        public string ADMINISTEREDBY { set; get; }

    }
    public class gettestresult
    {
        public static List<testresult> testresult(string empno,string cs)
        {
            List<testresult> li = new List<testresult>();
            try
            {
                string str = " select [ID],[EMPNO],[DHPID],format(cast([DATETESTDONE] as date),'MMMM-dd-yyyy') as DATETESTDONE,[TIMETEST],[SERIALNO],[TESTRESULT],[PATIENTNAME],[ADMINISTEREDBY] from [DHPPAGE2]"+
                    " where empno = @empno and datetestdone <> '' order by cast([DATETESTDONE] as date) desc, cast([TIMETEST] as time) asc";
          
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();
               
                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@empno", empno);
                        using (SqlDataReader dr = sqlcmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                testresult tr = new testresult();
                                tr.ID = dr["ID"].ToString();
                                tr.EMPNO = dr["EMPNO"].ToString();
                                tr.DHPID = dr["DHPID"].ToString();
                                tr.DATETESTDONE = dr["DATETESTDONE"].ToString();
                                tr.TESTRESULT = dr["TESTRESULT"].ToString();
                                tr.TIMETEST = dr["TIMETEST"].ToString();
                                tr.SERIALNO = dr["SERIALNO"].ToString();
                                tr.ADMINISTEREDBY = dr["ADMINISTEREDBY"].ToString();
                                li.Add(tr);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
              
            }
            return li;
        }
    }
}