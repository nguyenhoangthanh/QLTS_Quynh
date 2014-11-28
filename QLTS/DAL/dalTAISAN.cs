using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public class dalTAISAN
    {
        public static List<bizTAISAN> getall()
        {
            List<bizTAISAN> result = new List<bizTAISAN>();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from TAISAN", conn);

                // get query results
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bizLOAITAISAN LOAITAISAN = dalLOAITAISAN.getbyid(Int32.Parse(rdr["LOAITAISAN_ID"].ToString()));
                    bizTAISAN s = new bizTAISAN(Int32.Parse(rdr["ID"].ToString()), rdr["TENTAISAN"].ToString(), DateTime.Parse(rdr["NGAYMUA"].ToString()), LOAITAISAN, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bizTAISAN getbyid(int ID)
        {
            bizTAISAN result = new bizTAISAN();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from TAISAN where ID={0}", ID), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();
                bizLOAITAISAN LOAITAISAN = dalLOAITAISAN.getbyid(Int32.Parse(rdr["LOAITAISAN_ID"].ToString()));
                result = new bizTAISAN(Int32.Parse(rdr["ID"].ToString()), rdr["TENTAISAN"].ToString(), DateTime.Parse(rdr["NGAYMUA"].ToString()), LOAITAISAN, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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

        public static bool them(bizTAISAN TAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format(@"insert into TAISAN(TENTAISAN,NGAYMUA,LOAITAISAN_ID,SUBID,MOTA,NGAYTAO,NGAYSUA) values(N'{0}','{1}','{2}',N'{3}','{4}','{5}','{6}')", TAISAN.TENTAISAN, ((DateTime)TAISAN.NGAYMUA).ToString("M/d/yyyy HH:mm:ss"), TAISAN.LOAITAISAN.ID, TAISAN.SUBID, TAISAN.MOTA, ((DateTime)TAISAN.NGAYTAO).ToString("M/d/yyyy HH:mm:ss"), ((DateTime)TAISAN.NGAYSUA).ToString("M/d/yyyy HH:mm:ss"));
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

        public static bool sua(bizTAISAN TAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("update TAISAN set TENTAISAN=N'{0}', NGAYMUA=N'{1}',LOAITAISAN_ID='{2}', SUBID=N'{3}', MOTA=N'{4}', NGAYSUA='{5}' where ID={6}", TAISAN.TENTAISAN, ((DateTime)TAISAN.NGAYMUA).ToString("M/d/yyyy HH:mm:ss"),TAISAN.LOAITAISAN.ID, TAISAN.SUBID, TAISAN.MOTA, DateTime.Now.ToString("M/d/yyyy HH:mm:ss"), TAISAN.ID);
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

        public static bool xoa(bizTAISAN TAISAN)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete TAISAN where ID='{0}'", TAISAN.ID);
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
