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
    }
}
