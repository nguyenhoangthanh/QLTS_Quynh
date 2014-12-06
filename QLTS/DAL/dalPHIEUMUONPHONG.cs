using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalPHIEUMUONPHONG
    {
        public static List<bizPHIEUMUONPHONG> getall()
        {
            List<bizPHIEUMUONPHONG> result = new List<bizPHIEUMUONPHONG>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from PHIEUMUONPHONG", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizQUANTRIVIEN QUANTRIVIEN = null;
                    try
                    {
                        QUANTRIVIEN = dalQUANTRIVIEN.getbyid(Int32.Parse(rdr["QUANTRIVIEN_ID"].ToString()));
                    }
                    catch { }
                    bool GIANGVIENMUON = rdr["GIANGVIENMUON"] == "1";
                    bizPHIEUMUONPHONG s = new bizPHIEUMUONPHONG(Int32.Parse(rdr["ID"].ToString()), rdr["KHOA"].ToString(), DateTime.Parse(rdr["NGAYMUON"].ToString()), DateTime.Parse(rdr["NGAYTRA"].ToString()), rdr["LYDOMUON"].ToString(), rdr["GHICHU"].ToString(), Int32.Parse(rdr["SOLUONGSV"].ToString()), Int32.Parse(rdr["NGUOIMUON_ID"].ToString()), QUANTRIVIEN, rdr["TINHTRANG"].ToString(), GIANGVIENMUON, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bizPHIEUMUONPHONG getbyid(int ID)
        {
            bizPHIEUMUONPHONG result = new bizPHIEUMUONPHONG();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from PHIEUMUONPHONG where ID={0}", ID), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                bizQUANTRIVIEN QUANTRIVIEN = null;
                try
                {
                    QUANTRIVIEN = dalQUANTRIVIEN.getbyid(Int32.Parse(rdr["QUANTRIVIEN_ID"].ToString()));
                }
                catch { }
                bool GIANGVIENMUON = rdr["GIANGVIENMUON"] == "1";
                result = new bizPHIEUMUONPHONG(Int32.Parse(rdr["ID"].ToString()), rdr["KHOA"].ToString(), DateTime.Parse(rdr["NGAYMUON"].ToString()), DateTime.Parse(rdr["NGAYTRA"].ToString()), rdr["LYDOMUON"].ToString(), rdr["GHICHU"].ToString(), Int32.Parse(rdr["SOLUONGSV"].ToString()), Int32.Parse(rdr["NGUOIMUON_ID"].ToString()), QUANTRIVIEN, rdr["TINHTRANG"].ToString(), GIANGVIENMUON, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizPHIEUMUONPHONG PHIEUMUONPHONG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();
                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into PHIEUMUONPHONG(KHOA,NGAYMUON,NGAYTRA,LYDOMUON,GHICHU,SOLUONGSV,NGUOIMUON_ID,QUANTRIVIEN_ID,TINHTRANG,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',null,N'{7}',N'{8}','{9}','{10}','{11}')", PHIEUMUONPHONG.KHOA, ((DateTime)PHIEUMUONPHONG.NGAYMUON).ToString("M/d/yyyy H:mm:ss"), ((DateTime)PHIEUMUONPHONG.NGAYTRA).ToString("M/d/yyyy H:mm:ss"), PHIEUMUONPHONG.LYDOMUON, PHIEUMUONPHONG.GHICHU, PHIEUMUONPHONG.SOLUONGSV, PHIEUMUONPHONG.NGUOIMUON_ID, PHIEUMUONPHONG.TINHTRANG, PHIEUMUONPHONG.SUBID, PHIEUMUONPHONG.MOTA, ((DateTime)PHIEUMUONPHONG.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)PHIEUMUONPHONG.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
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

        public static bool sua(bizPHIEUMUONPHONG PHIEUMUONPHONG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update PHIEUMUONPHONG set KHOA=N'{0}', NGAYMUON=N'{1}', NGAYTRA=N'{2}', LYDOMUON=N'{3}', SOLUONGSV=N'{4}', SUBID=N'{5}', MOTA=N'{6}', NGAYSUA='{7}' where ID={8}", PHIEUMUONPHONG.KHOA, ((DateTime)PHIEUMUONPHONG.NGAYMUON).ToString("M/d/yyyy H:mm:ss"), ((DateTime)PHIEUMUONPHONG.NGAYTRA).ToString("M/d/yyyy H:mm:ss"), PHIEUMUONPHONG.LYDOMUON, PHIEUMUONPHONG.SOLUONGSV, PHIEUMUONPHONG.SUBID, PHIEUMUONPHONG.MOTA, ((DateTime)PHIEUMUONPHONG.NGAYSUA).ToString("M/d/yyyy H:mm:ss"), PHIEUMUONPHONG.ID);
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

        public static bool duyet(bizPHIEUMUONPHONG PHIEUMUONPHONG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update PHIEUMUONPHONG set QUANTRIVIEN_ID=N'{0}', TINHTRANG=N'{1}', GHICHU=N'{2}', NGAYSUA='{3}' where ID={4}", PHIEUMUONPHONG.QUANTRIVIEN.ID, PHIEUMUONPHONG.TINHTRANG, PHIEUMUONPHONG.GHICHU, ((DateTime)PHIEUMUONPHONG.NGAYSUA).ToString("M/d/yyyy H:mm:ss"), PHIEUMUONPHONG.ID);
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

        public static bool xoa(bizPHIEUMUONPHONG PHIEUMUONPHONG)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete PHIEUMUONPHONG where ID='{0}'", PHIEUMUONPHONG.ID);
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
