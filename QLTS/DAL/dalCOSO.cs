using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public static class dalCOSO
    {
        public static List<bizCOSO> getall()
        {
            List<bizCOSO> result = new List<bizCOSO>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from COSO", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizCOSO s = new bizCOSO(Int32.Parse(rdr["MACOSO"].ToString()), rdr["TENCOSO"].ToString(), rdr["DIACHI"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUADOI"].ToString()));
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

        public static bizCOSO getbyid(int macoso)
        {
            bizCOSO result = new bizCOSO();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from COSO where MACOSO={0}", macoso), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                result = new bizCOSO(Int32.Parse(rdr["MACOSO"].ToString()), rdr["TENCOSO"].ToString(), rdr["DIACHI"].ToString(), rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUADOI"].ToString()));
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

        public static bool them(bizCOSO coso)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into COSO(TENCOSO,DIACHI,SUBID,MOTA,NGAYTAO,NGAYSUADOI) values(N'{0}',N'{1}',N'{2}',N'{3}','{4}','{5}')", coso.TENCOSO, coso.DIACHI, coso.SUBID, coso.MOTA, ((DateTime)coso.NGAYTAO).ToString("M/d/yyyy HH:mm:ss"), ((DateTime)coso.NGAYSUADOI).ToString("M/d/yyyy HH:mm:ss"));
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

        public static bool sua(bizCOSO coso)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update COSO set TENCOSO=N'{0}', DIACHI=N'{1}', SUBID=N'{2}', MOTA=N'{3}', NGAYSUADOI='{4}' where MACOSO={5}", coso.TENCOSO, coso.DIACHI, coso.SUBID, coso.MOTA, ((DateTime)coso.NGAYSUADOI).ToString("M/d/yyyy HH:mm:ss"), coso.MACOSO);
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

        public static bool xoa(bizCOSO coso)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete COSO where MACOSO='{0}'", coso.MACOSO);
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
