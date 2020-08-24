using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KMDIDailyHealthProfile.DAILYHEALTHPROFILE.da
{
    public class Emp
    {
        public string EMPNO { set; get; }
        public string FULLNAME { set; get; }
        public string constr { set; get; }
        public List<testresult> testresultsummary
        {
            get
            {
                return gettestresult.testresult(this.EMPNO,this.constr );
            }
        }
    }

    public class employees
    {
        public static List<Emp> getemployees(string key,string cs)
        {

            List<Emp> li = new List<Emp>();
            try
            {
              
                string str = " select * into #tbl from (select distinct [EMPNO] as EMPNO from [DHPPAGE2]) as tbl " +
                             " select a.EMPNO,b.SURNAME+', '+b.FIRSTNAME+' '+MI AS FULLNAME from #tbl as a left join emptbl as b ON a.EMPNO = b.EMPNO WHERE SURNAME LIKE @key or firstname like @key";
     
                using (SqlConnection sqlcon = new SqlConnection(cs))
                {
                    sqlcon.Open();

                    using (SqlCommand sqlcmd = new SqlCommand(str, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@key", "%" + key + "%");
                        using (SqlDataReader dr = sqlcmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Emp tr = new Emp();
                                tr.EMPNO = dr["EMPNO"].ToString();
                                tr.FULLNAME = dr["FULLNAME"].ToString();
                                tr.constr = cs;
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