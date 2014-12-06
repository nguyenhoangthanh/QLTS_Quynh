using QLTS.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLTS.DAL
{
    public static class dalDIADIEM
    {
        public static bizDIADIEM getlast()
        {
            bizDIADIEM result = new bizDIADIEM();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select top 1 * from DIADIEM order by ID desc", conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();

                bizCOSO COSO = dalCOSO.getbyid(Int32.Parse(rdr["COSO_ID"].ToString()));
                bizKHU KHU = null;
                bizTANG TANG = null;
                try
                {
                    KHU = dalKHU.getbyid(Int32.Parse(rdr["KHU_ID"].ToString()));
                }
                catch { }
                try
                {
                    TANG = dalTANG.getbyid(Int32.Parse(rdr["TANG_ID"].ToString()));
                }
                catch { }
                result = new bizDIADIEM(Int32.Parse(rdr["ID"].ToString()), COSO, KHU, TANG, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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
        public static bizDIADIEM getbyid(int id)
        {
            bizDIADIEM result = new bizDIADIEM();
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(string.Format("select * from DIADIEM where ID={0}", id), conn);

                // get query results
                rdr = cmd.ExecuteReader();
                rdr.Read();

                bizCOSO COSO = dalCOSO.getbyid(Int32.Parse(rdr["COSO_ID"].ToString()));
                bizKHU KHU = null;
                bizTANG TANG = null;
                try
                {
                    KHU = dalKHU.getbyid(Int32.Parse(rdr["KHU_ID"].ToString()));
                }
                catch { }
                try
                {
                    TANG = dalTANG.getbyid(Int32.Parse(rdr["TANG_ID"].ToString()));
                }
                catch { }
                result = new bizDIADIEM(Int32.Parse(rdr["ID"].ToString()), COSO, KHU, TANG, rdr["SUBID"].ToString(), rdr["MOTA"].ToString(), DateTime.Parse(rdr["NGAYTAO"].ToString()), DateTime.Parse(rdr["NGAYSUA"].ToString()));
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
        public static bool them(bizDIADIEM DIADIEM)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s;
                if (DIADIEM.KHU == null && DIADIEM.TANG == null)
                {
                    s = String.Format(@"insert into DIADIEM(COSO_ID,KHU_ID,TANG_ID,SUBID,MOTA,NGAYTAO,NGAYSUA) values('{0}',null,null,N'{1}',N'{2}','{3}','{4}')", DIADIEM.COSO.ID, DIADIEM.SUBID, DIADIEM.MOTA, ((DateTime)DIADIEM.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)DIADIEM.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
                }
                else
                {
                    s = String.Format(@"insert into DIADIEM(COSO_ID,KHU_ID,TANG_ID,SUBID,MOTA,NGAYTAO,NGAYSUA) values('{0}','{1}','{2}',N'{3}',N'{4}','{5}','{6}')", DIADIEM.COSO.ID, DIADIEM.KHU.ID, DIADIEM.TANG.ID, DIADIEM.SUBID, DIADIEM.MOTA, ((DateTime)DIADIEM.NGAYTAO).ToString("M/d/yyyy H:mm:ss"), ((DateTime)DIADIEM.NGAYSUA).ToString("M/d/yyyy H:mm:ss"));
                }
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

        public static bool sua(bizDIADIEM DIADIEM)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s;
                if (DIADIEM.KHU == null && DIADIEM.TANG == null)
                {
                    s = String.Format("update DIADIEM set COSO_ID='{0}', KHU_ID=null, TANG_ID=null, SUBID=N'{1}', MOTA=N'{2}', NGAYSUA='{3}' where ID={4}", DIADIEM.COSO.ID, DIADIEM.SUBID, DIADIEM.MOTA, DateTime.Now.ToString("M/d/yyyy H:mm:ss"), DIADIEM.ID);
                }
                else
                {
                    s = String.Format("update DIADIEM set COSO_ID='{0}', KHU_ID='{1}', TANG_ID='{2}', SUBID=N'{3}', MOTA=N'{4}', NGAYSUA='{5}' where ID={6}", DIADIEM.COSO.ID, DIADIEM.KHU.ID, DIADIEM.TANG.ID, DIADIEM.SUBID, DIADIEM.MOTA, DateTime.Now.ToString("M/d/yyyy H:mm:ss"), DIADIEM.ID);
                }
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

        public static bool xoa(bizDIADIEM DIADIEM)
        {
            SqlConnection conn = new SqlConnection(dbconnect.cnstring);

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                String s = String.Format("delete DIADIEM where ID='{0}'", DIADIEM.ID);
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
