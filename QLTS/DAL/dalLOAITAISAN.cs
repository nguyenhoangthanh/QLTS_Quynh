using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public static class dalLOAITAISAN
    {
        public static List<bizLOAITAISAN> getall()
        {
            List<bizLOAITAISAN> result = new List<bizLOAITAISAN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from LOAITAISAN", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizLOAITAISAN s = new bizLOAITAISAN(Int32.Parse(rdr["ID"].ToString()), rdr["TENLOAI"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static int TAISANTrongLOAITAISAN(int ID)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select count(*) from TAISAN where LOAITAISAN_ID={0}", ID), conn);

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

        public static bizLOAITAISAN getbyid(int maloaitaisan)
        {
            bizLOAITAISAN result = new bizLOAITAISAN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from LOAITAISAN where ID={0}", maloaitaisan), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizLOAITAISAN(Int32.Parse(rdr["ID"].ToString()), rdr["TENLOAI"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizLOAITAISAN LOAITAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into LOAITAISAN(TENLOAI,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}',N'{1}',N'{2}',N'{3}','{4}')", LOAITAISAN.TENLOAI, LOAITAISAN.SUBID, LOAITAISAN.MOTA, ((DateTime)LOAITAISAN.NGAYTAO).ToString("M/d/yyyy HH:mm:ss"), ((DateTime)LOAITAISAN.NGAYSUA).ToString("M/d/yyyy HH:mm:ss"));
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

        public static bool sua(bizLOAITAISAN LOAITAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update LOAITAISAN set TENLOAI=N'{0}', SUBID=N'{1}', MOTA=N'{2}', NGAYSUA='{3}' where ID={4}", LOAITAISAN.TENLOAI, LOAITAISAN.SUBID, LOAITAISAN.MOTA, DateTime.Now.ToString("M/d/yyyy HH:mm:ss"), LOAITAISAN.ID);
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

        public static bool xoa(bizLOAITAISAN LOAITAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete LOAITAISAN where ID='{0}'", LOAITAISAN.ID);
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
