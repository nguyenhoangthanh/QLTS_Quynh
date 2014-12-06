using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public static class dalPHONG
    {
        public static List<bizPHONG> getall()
        {
            List<bizPHONG> result = new List<bizPHONG>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from PHONG", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizDIADIEM DIADIEM = dalDIADIEM.getbyid(Int32.Parse(rdr["DIADIEM_ID"].ToString()));
                    bizNHANVIEN NHANVIEN = dalNHANVIEN.getbyid(Int32.Parse(rdr["NHANVIEN_ID"].ToString()));
                    bizPHONG s = new bizPHONG(Int32.Parse(rdr["ID"].ToString()), rdr["TENPHONG"].ToString(), DIADIEM, NHANVIEN, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static int TAISANTrongPHONG(int ID)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select count(*) from CTTAISAN where PHONG_ID={0}", ID), conn);

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

        public static bizPHONG getbyid(int id)
        {
            bizPHONG result = new bizPHONG();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from PHONG where ID={0}", id), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                bizDIADIEM DIADIEM = dalDIADIEM.getbyid(Int32.Parse(rdr["DIADIEM_ID"].ToString()));
                bizNHANVIEN NHANVIEN = dalNHANVIEN.getbyid(Int32.Parse(rdr["NHANVIEN_ID"].ToString()));
                result = new bizPHONG(Int32.Parse(rdr["ID"].ToString()), rdr["TENPHONG"].ToString(), DIADIEM, NHANVIEN, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizPHONG PHONG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                bizDIADIEM DIADIEM = new bizDIADIEM();
                DIADIEM.COSO = PHONG.DIADIEM.COSO;
                DIADIEM.KHU = PHONG.DIADIEM.KHU;
                DIADIEM.TANG = PHONG.DIADIEM.TANG;
                // 3. Pass the connection to a command object
                if (dalDIADIEM.them(DIADIEM) == true)
                {
                    DIADIEM = dalDIADIEM.getlast();
                    String s = String.Format(@"insert into PHONG(TENPHONG,DIADIEM_ID,NHANVIEN_ID,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}','{1}',N'{2}',N'{3}',N'{4}','{5}','{6}')", PHONG.TENPHONG, DIADIEM.ID, PHONG.NHANVIEN.ID, PHONG.SUBID, PHONG.MOTA, ((DateTime)PHONG.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)PHONG.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
                    SqlCommand cmd = new SqlCommand(s, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return false;
                }

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

        public static bool sua(bizPHONG PHONG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                bizDIADIEM DIADIEM = dalDIADIEM.getbyid(PHONG.DIADIEM.ID);
                DIADIEM.COSO = PHONG.DIADIEM.COSO;
                DIADIEM.KHU = PHONG.DIADIEM.KHU;
                DIADIEM.TANG = PHONG.DIADIEM.TANG;
                // 3. Pass the connection to a command object
                if (dalDIADIEM.sua(DIADIEM) == true)
                {
                    String s = String.Format("update PHONG set TENPHONG=N'{0}', DIADIEM_ID='{1}',NHANVIEN_ID='{2}', SUBID=N'{3}', MOTA=N'{4}', NGAYSUA='{5}' where ID={6}", PHONG.TENPHONG, PHONG.DIADIEM.ID, PHONG.NHANVIEN.ID, PHONG.SUBID, PHONG.MOTA, DateTime.Now.ToString("M/d/yyyy H:mm:ss"), PHONG.ID);
                    SqlCommand cmd = new SqlCommand(s, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return false;
                }
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

        public static bool xoa(bizPHONG PHONG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                bizDIADIEM DIADIEM = new bizDIADIEM();
                DIADIEM.COSO = PHONG.DIADIEM.COSO;
                DIADIEM.KHU = PHONG.DIADIEM.KHU;
                DIADIEM.TANG = PHONG.DIADIEM.TANG;
                // 3. Pass the connection to a command object
                if (dalDIADIEM.xoa(DIADIEM) == true)
                {
                    String s = String.Format("delete PHONG where ID='{0}'", PHONG.ID);
                    SqlCommand cmd = new SqlCommand(s, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return false;
                }
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
