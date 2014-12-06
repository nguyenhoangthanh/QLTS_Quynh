using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalGIANGVIEN
    {
        public static List<bizGIANGVIEN> getall()
        {
            List<bizGIANGVIEN> result = new List<bizGIANGVIEN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from GIANGVIEN", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizGIANGVIEN s = new bizGIANGVIEN(Int32.Parse(rdr["ID"].ToString()), rdr["TENGV"].ToString(), rdr["EMAIL"].ToString(), rdr["USERNAME"].ToString(), rdr["PASSWORD"].ToString(), DateTime.Parse(rdr["NGAYSINH"].ToString()), rdr["GIOITINH"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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
        public static bizGIANGVIEN getbyid(int ID)
        {
            bizGIANGVIEN result = new bizGIANGVIEN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from GIANGVIEN where ID={0}", ID), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizGIANGVIEN(Int32.Parse(rdr["ID"].ToString()), rdr["TENGV"].ToString(), rdr["EMAIL"].ToString(), rdr["USERNAME"].ToString(), rdr["PASSWORD"].ToString(), DateTime.Parse(rdr["NGAYSINH"].ToString()), rdr["GIOITINH"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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
        public static bizGIANGVIEN getbyusername(string username)
        {
            bizGIANGVIEN result = new bizGIANGVIEN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from GIANGVIEN where USERNAME='{0}'", username), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizGIANGVIEN(Int32.Parse(rdr["ID"].ToString()), rdr["TENGV"].ToString(), rdr["EMAIL"].ToString(), rdr["USERNAME"].ToString(), rdr["PASSWORD"].ToString(), DateTime.Parse(rdr["NGAYSINH"].ToString()), rdr["GIOITINH"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static int GiangVienDaMuonPhong(int ID)
        {
            bizGIANGVIEN result = new bizGIANGVIEN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from PHIEUMUONPHONG where GIANGVIENMUON = 1 and NGUOIMUON_ID = {0}", ID), conn);

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

        public static bool them(bizGIANGVIEN GIANGVIEN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into GIANGVIEN(TENGV,EMAIL,USERNAME,PASSWORD,NGAYSINH,GIOITINH,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}',N'{1}',N'{2}',N'{3}','{4}',N'{5}',N'{6}',N'{7}','{8}','{9}')", GIANGVIEN.TENGV, GIANGVIEN.EMAIL, GIANGVIEN.USERNAME, GIANGVIEN.PASSWORD, ((DateTime)GIANGVIEN.NGAYSINH).ToString("M/d/yyyy"), GIANGVIEN.GIOITINH, GIANGVIEN.SUBID, GIANGVIEN.MOTA, ((DateTime)GIANGVIEN.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)GIANGVIEN.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
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

        public static bool sua(bizGIANGVIEN GIANGVIEN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update GIANGVIEN set TENGV=N'{0}',EMAIL=N'{1}',USERNAME=N'{2}',PASSWORD=N'{3}', NGAYSINH=N'{4}', GIOITINH=N'{5}', SUBID=N'{6}', MOTA=N'{7}', NGAYSUA='{8}' where ID={9}", GIANGVIEN.TENGV, GIANGVIEN.EMAIL, GIANGVIEN.USERNAME, GIANGVIEN.PASSWORD, ((DateTime)GIANGVIEN.NGAYSINH).ToString("M/d/yyyy"), GIANGVIEN.GIOITINH, GIANGVIEN.SUBID, GIANGVIEN.MOTA, DateTime.Now.ToString("M/d/yyyy H:mm:ss"), GIANGVIEN.ID);
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

        public static bool xoa(bizGIANGVIEN GIANGVIEN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete GIANGVIEN where ID='{0}'", GIANGVIEN.ID);
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
