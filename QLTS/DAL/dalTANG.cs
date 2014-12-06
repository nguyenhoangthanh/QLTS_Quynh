using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalTANG
    {
        public static List<bizTANG> getall()
        {
            List<bizTANG> result = new List<bizTANG>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from TANG", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizKHU KHU = dalKHU.getbyid(Int32.Parse(rdr["KHU_ID"].ToString()));
                    bizTANG s = new bizTANG(Int32.Parse(rdr["ID"].ToString()), rdr["TENTANG"].ToString(), KHU, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static int PHONGTrongTANG(int ID)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select count(*) from DIADIEM where DIADIEM.TANG_ID={0}", ID), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                return Convert.ToInt32(rdr[0].ToString());
            }
            catch
            {
                return -1;
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
        }

        public static bizTANG getbyid(int maTANG)
        {
            bizTANG result = new bizTANG();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from TANG where ID={0}", maTANG), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                bizKHU KHU = dalKHU.getbyid(Int32.Parse(rdr["KHU_ID"].ToString()));
                result = new bizTANG(Int32.Parse(rdr["ID"].ToString()), rdr["TENTANG"].ToString(), KHU, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizTANG TANG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into TANG(TENTANG,KHU_ID,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}','{1}',N'{2}',N'{3}',N'{4}','{5}')", TANG.TENTANG, TANG.KHU.ID, TANG.SUBID, TANG.MOTA, ((DateTime)TANG.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)TANG.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
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

        public static bool sua(bizTANG TANG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update TANG set TENTANG=N'{0}', KHU_ID='{1}', SUBID=N'{2}', MOTA=N'{3}', NGAYSUA='{4}' where ID={5}", TANG.TENTANG, TANG.KHU.ID, TANG.SUBID, TANG.MOTA, DateTime.Now.ToString("M/d/yyyy H:mm:ss"), TANG.ID);
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

        public static bool xoa(bizTANG TANG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete TANG where ID='{0}'", TANG.ID);
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
