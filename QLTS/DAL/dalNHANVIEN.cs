using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalNHANVIEN
    {
        public static List<bizNHANVIEN> getall()
        {
            List<bizNHANVIEN> result = new List<bizNHANVIEN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from NHANVIEN", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizNHANVIEN s = new bizNHANVIEN(Int32.Parse(rdr["ID"].ToString()), rdr["HOTEN"].ToString(), rdr["SODIENTHOAI"].ToString(), rdr["GIOITINH"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static int NHANVIENDangQuanLyPHONG(int ID)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select count(*) from NHANVIEN-PHONG where NHANVIEN_ID={0}", ID), conn);

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

        public static bizNHANVIEN getbyid(int ID)
        {
            bizNHANVIEN result = new bizNHANVIEN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from NHANVIEN where ID={0}", ID), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizNHANVIEN(Int32.Parse(rdr["ID"].ToString()), rdr["HOTEN"].ToString(), rdr["SODIENTHOAI"].ToString(), rdr["GIOITINH"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizNHANVIEN NHANVIEN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into NHANVIEN(HOTEN,SODIENTHOAI,GIOITINH,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}',N'{1}',N'{2}',N'{3}','{4}','{5}','{6}')", NHANVIEN.HOTEN, NHANVIEN.SODIENTHOAI, NHANVIEN.GIOITINH, NHANVIEN.SUBID, NHANVIEN.MOTA, ((DateTime)NHANVIEN.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)NHANVIEN.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
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

        public static bool sua(bizNHANVIEN NHANVIEN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update NHANVIEN set HOTEN=N'{0}', SODIENTHOAI=N'{1}',GIOITINH=N'{2}', SUBID=N'{3}', MOTA=N'{4}', NGAYSUA='{5}' where ID={6}", NHANVIEN.HOTEN, NHANVIEN.SODIENTHOAI, NHANVIEN.GIOITINH, NHANVIEN.SUBID, NHANVIEN.MOTA, DateTime.Now.ToString("M/d/yyyy H:mm:ss"), NHANVIEN.ID);
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

        public static bool xoa(bizNHANVIEN NHANVIEN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete NHANVIEN where ID='{0}'", NHANVIEN.ID);
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
