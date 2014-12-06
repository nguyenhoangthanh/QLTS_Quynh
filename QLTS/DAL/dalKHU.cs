using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalKHU
    {
        public static List<bizKHU> getall()
        {
            List<bizKHU> result = new List<bizKHU>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from KHU", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizCOSO COSO = dalCOSO.getbyid(Int32.Parse(rdr["COSO_ID"].ToString()));
                    bizKHU s = new bizKHU(Int32.Parse(rdr["ID"].ToString()), rdr["TEN"].ToString(), COSO, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static int TANGTrongKHU(int ID)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select count(*) from TANG where KHU_ID={0}", ID), conn);

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

        public static bizKHU getbyid(int makhu)
        {
            bizKHU result = new bizKHU();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from KHU where ID={0}", makhu), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                bizCOSO COSO = dalCOSO.getbyid(Int32.Parse(rdr["COSO_ID"].ToString()));
                result = new bizKHU(Int32.Parse(rdr["ID"].ToString()), rdr["TEN"].ToString(), COSO, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizKHU KHU)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into KHU(TEN,COSO_ID,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}','{1}',N'{2}',N'{3}',N'{4}','{5}')", KHU.TEN, KHU.COSO.ID, KHU.SUBID, KHU.MOTA, ((DateTime)KHU.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)KHU.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
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

        public static bool sua(bizKHU KHU)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update KHU set TEN=N'{0}', COSO_ID='{1}', SUBID=N'{2}', MOTA=N'{3}', NGAYSUA='{4}' where ID={5}", KHU.TEN, KHU.COSO.ID, KHU.SUBID, KHU.MOTA, DateTime.Now.ToString("M/d/yyyy H:mm:ss"), KHU.ID);
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

        public static bool xoa(bizKHU KHU)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete KHU where ID='{0}'", KHU.ID);
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
