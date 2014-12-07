using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalLOGTAISAN
    {
        public static List<bizLOGTAISAN> getall()
        {
            List<bizLOGTAISAN> result = new List<bizLOGTAISAN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from LOGTAISAN", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizPHONG PHONG = dalPHONG.getbyid(Int32.Parse(rdr["PHONG_ID"].ToString()));
                    bizLOGTAISAN s = new bizLOGTAISAN(Int32.Parse(rdr["ID"].ToString()), PHONG, DateTime.Parse(rdr["NGAYTAO"].ToString()), rdr["MOTA"].ToString());
                    result.Add(s);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static List<bizLOGTAISAN> thongke(DateTime tungay, DateTime denngay, bizPHONG PHONG)
        {
            List<bizLOGTAISAN> result = new List<bizLOGTAISAN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM LOGTAISAN WHERE PHONG_ID='{0}' AND NGAYTAO BETWEEN CONVERT(datetime,'{1}') AND CONVERT(datetime,'{2}')", PHONG.ID, ((DateTime)tungay).ToString("M/d/yyyy H:mm:ss"), ((DateTime)denngay).ToString("M/d/yyyy H:mm:ss")), conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizPHONG bizPHONG = dalPHONG.getbyid(Int32.Parse(rdr["PHONG_ID"].ToString()));
                    bizLOGTAISAN s = new bizLOGTAISAN(Int32.Parse(rdr["ID"].ToString()), bizPHONG, DateTime.Parse(rdr["NGAYTAO"].ToString()), rdr["MOTA"].ToString());
                    result.Add(s);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static bool them(bizLOGTAISAN LOGTAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into LOGTAISAN(PHONG_ID,NGAYTAO,MOTA) values('{0}','{1}',N'{2}')", LOGTAISAN.PHONG.ID, ((DateTime)LOGTAISAN.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), LOGTAISAN.MOTA);
                SqlCommand cmd = new SqlCommand(s, conn);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }
    }
}
