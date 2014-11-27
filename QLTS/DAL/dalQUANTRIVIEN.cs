using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalQUANTRIVIEN
    {
        public static List<bizQUANTRIVIEN> getall()
        {
            List<bizQUANTRIVIEN> result = new List<bizQUANTRIVIEN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from QUANTRIVIEN", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizQUANTRIVIEN s = new bizQUANTRIVIEN(Int32.Parse(rdr["MAQTVIEN"].ToString()), rdr["TENQTVIEN"].ToString(), rdr["EMAIL"].ToString(), rdr["USENAME"].ToString(), rdr["PASSWORD"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUADOI"].ToString()));
                    result.Add(s);
                }
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

        public static bizQUANTRIVIEN getbyid(int maqtvien)
        {
            bizQUANTRIVIEN result = new bizQUANTRIVIEN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from QUANTRIVIEN where MAQTVIEN={0}", maqtvien), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizQUANTRIVIEN(Int32.Parse(rdr["MAQTVIEN"].ToString()), rdr["TENQTVIEN"].ToString(), rdr["EMAIL"].ToString(), rdr["USENAME"].ToString(), rdr["PASSWORD"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUADOI"].ToString()));
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

        public static bizQUANTRIVIEN getbyusername(string username)
        {
            bizQUANTRIVIEN result = new bizQUANTRIVIEN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from QUANTRIVIEN where USENAME=N'{0}'", username), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizQUANTRIVIEN(Int32.Parse(rdr["MAQTVIEN"].ToString()), rdr["TENQTVIEN"].ToString(), rdr["EMAIL"].ToString(), rdr["USENAME"].ToString(), rdr["PASSWORD"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUADOI"].ToString()));
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

        public static bool them(bizQUANTRIVIEN quantrivien)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into QUANTRIVIEN(TENQTVIEN,EMAIL,USENAME,PASSWORD,SUBID,MOTA,NGAYTAO,NGAYSUADOI) values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}','{7}','{8}')", quantrivien.TENQTVIEN, quantrivien.EMAIL, quantrivien.USENAME, quantrivien.PASSWORD, quantrivien.SUBID, quantrivien.MOTA, ((DateTime)quantrivien.NGAYTAO).ToString("M/d/yyyy HH:mm:ss"), ((DateTime)quantrivien.NGAYSUADOI).ToString("M/d/yyyy HH:mm:ss"));
                SqlCommand cmd = new SqlCommand(s, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
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

        public static bool sua(bizQUANTRIVIEN quantrivien)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update QUANTRIVIEN set TENQTVIEN=N'{0}', EMAIL=N'{1}',PASSWORD=N'{2}', SUBID=N'{3}', MOTA=N'{4}', NGAYSUADOI='{5}' where MAQTVIEN={6}", quantrivien.TENQTVIEN, quantrivien.EMAIL, quantrivien.PASSWORD, quantrivien.SUBID, quantrivien.MOTA, ((DateTime)quantrivien.NGAYSUADOI).ToString("M/d/yyyy HH:mm:ss"), quantrivien.MAQTVIEN);
                SqlCommand cmd = new SqlCommand(s, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
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

        public static bool xoa(bizQUANTRIVIEN quantrivien)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete QUANTRIVIEN where MAQTVIEN='{0}'", quantrivien.MAQTVIEN);
                SqlCommand cmd = new SqlCommand(s, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
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
