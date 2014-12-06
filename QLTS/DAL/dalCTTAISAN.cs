using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalCTTAISAN
    {
        public static List<bizCTTAISAN> thongke(DateTime tungay, DateTime denngay, bizPHONG PHONG)
        {
            List<bizCTTAISAN> result = new List<bizCTTAISAN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM CTTAISAN WHERE PHONG_ID='{0}' AND NGAY BETWEEN CONVERT(datetime,'{1}') AND CONVERT(datetime,'{2}')", PHONG.ID, tungay, denngay), conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizPHONG bizPHONG = dalPHONG.getbyid(Int32.Parse(rdr["PHONG_ID"].ToString()));
                    bizTAISAN TAISAN = dalTAISAN.getbyid(Int32.Parse(rdr["TAISAN_ID"].ToString()));
                    bizTINHTRANG TINHTRANG = dalTINHTRANG.getbyid(Int32.Parse(rdr["TINHTRANG_ID"].ToString()));
                    bizCTTAISAN s = new bizCTTAISAN(Int32.Parse(rdr["ID"].ToString()), DateTime.Parse(rdr["NGAY"].ToString()), Int32.Parse(rdr["SOLUONG"].ToString()), bizPHONG, TAISAN, TINHTRANG, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static List<bizCTTAISAN> TaiSan(int IDPHONG)
        {
            List<bizCTTAISAN> result = new List<bizCTTAISAN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM CTTAISAN WHERE PHONG_ID='{0}'", IDPHONG), conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizPHONG bizPHONG = dalPHONG.getbyid(Int32.Parse(rdr["PHONG_ID"].ToString()));
                    bizTAISAN TAISAN = dalTAISAN.getbyid(Int32.Parse(rdr["TAISAN_ID"].ToString()));
                    bizTINHTRANG TINHTRANG = dalTINHTRANG.getbyid(Int32.Parse(rdr["TINHTRANG_ID"].ToString()));
                    bizCTTAISAN s = new bizCTTAISAN(Int32.Parse(rdr["ID"].ToString()), DateTime.Parse(rdr["NGAY"].ToString()), Int32.Parse(rdr["SOLUONG"].ToString()), bizPHONG, TAISAN, TINHTRANG, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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
        public static bizCTTAISAN getbyid(int ID)
        {
            bizCTTAISAN result = new bizCTTAISAN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from CTTAISAN where ID={0}", ID), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                bizPHONG bizPHONG = dalPHONG.getbyid(Int32.Parse(rdr["PHONG_ID"].ToString()));
                bizTAISAN TAISAN = dalTAISAN.getbyid(Int32.Parse(rdr["TAISAN_ID"].ToString()));
                bizTINHTRANG TINHTRANG = dalTINHTRANG.getbyid(Int32.Parse(rdr["TINHTRANG_ID"].ToString()));
                result = new bizCTTAISAN(Int32.Parse(rdr["ID"].ToString()), DateTime.Parse(rdr["NGAY"].ToString()), Int32.Parse(rdr["SOLUONG"].ToString()), bizPHONG, TAISAN, TINHTRANG, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizCTTAISAN CTTAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into CTTAISAN(NGAY,SOLUONG,PHONG_ID,TAISAN_ID,TINHTRANG_ID,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}',N'{1}',N'{2}',N'{3}','{4}','{5}','{6}','{7}','{8}')", ((DateTime)CTTAISAN.NGAY).ToString("M/d/yyyy H:mm:ss"), CTTAISAN.SOLUONG, CTTAISAN.PHONG.ID, CTTAISAN.TAISAN.ID, CTTAISAN.TINHTRANG.ID, CTTAISAN.SUBID, CTTAISAN.MOTA, ((DateTime)CTTAISAN.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)CTTAISAN.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
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

        public static bool sua(bizCTTAISAN CTTAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update CTTAISAN set NGAY=N'{0}', SOLUONG=N'{1}', PHONG_ID=N'{2}', TAISAN_ID=N'{3}', TINHTRANG_ID=N'{4}', SUBID=N'{5}', MOTA=N'{6}', NGAYSUA='{7}' where ID={8}", ((DateTime)CTTAISAN.NGAY).ToString("M/d/yyyy H:mm:ss"), CTTAISAN.SOLUONG, CTTAISAN.PHONG.ID, CTTAISAN.TAISAN.ID, CTTAISAN.TINHTRANG.ID, CTTAISAN.SUBID, CTTAISAN.MOTA, ((DateTime)CTTAISAN.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)CTTAISAN.NGAYSUA).ToString("M/d/yyyy H:mm:ss"), CTTAISAN.ID);
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

        public static bool xoa(bizCTTAISAN CTTAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete CTTAISAN where ID='{0}'", CTTAISAN.ID);
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
