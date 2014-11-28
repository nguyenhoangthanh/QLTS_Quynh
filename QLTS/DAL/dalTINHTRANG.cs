using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalTINHTRANG
    {
        public static List<bizTINHTRANG> getall()
        {
            List<bizTINHTRANG> result = new List<bizTINHTRANG>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from TINHTRANG", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizTINHTRANG s = new bizTINHTRANG(Int32.Parse(rdr["ID"].ToString()), rdr["KEY"].ToString(), rdr["VALUE"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bizTINHTRANG getbyid(int ID)
        {
            bizTINHTRANG result = new bizTINHTRANG();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from TINHTRANG where ID={0}", ID), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizTINHTRANG(Int32.Parse(rdr["ID"].ToString()), rdr["KEY"].ToString(), rdr["VALUE"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bizTINHTRANG getbyvalue(string VALUE)
        {
            bizTINHTRANG result = new bizTINHTRANG();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from TINHTRANG where VALUE=N'{0}'", VALUE), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizTINHTRANG(Int32.Parse(rdr["ID"].ToString()), rdr["KEY"].ToString(), rdr["VALUE"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizTINHTRANG TINHTRANG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into TINHTRANG([KEY],VALUE,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}',N'{1}',N'{2}',N'{3}','{4}','{5}')", TINHTRANG.KEY, TINHTRANG.VALUE, TINHTRANG.SUBID, TINHTRANG.MOTA, ((DateTime)TINHTRANG.NGAYTAO).ToString("M/d/yyyy HH:mm:ss"), ((DateTime)TINHTRANG.NGAYSUA).ToString("M/d/yyyy HH:mm:ss"));
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

        public static bool sua(bizTINHTRANG TINHTRANG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update TINHTRANG set [KEY]=N'{0}', VALUE=N'{1}', SUBID=N'{2}', MOTA=N'{3}', NGAYSUA='{4}' where ID={5}", TINHTRANG.KEY, TINHTRANG.VALUE, TINHTRANG.SUBID, TINHTRANG.MOTA, DateTime.Now.ToString("M/d/yyyy HH:mm:ss"), TINHTRANG.ID);
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

        public static bool xoa(bizTINHTRANG TINHTRANG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete TINHTRANG where ID='{0}'", TINHTRANG.ID);
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
