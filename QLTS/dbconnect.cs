using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS
{
    public static class dbconnect
    {
        public static string cnstring = @"Server=.\SQLEXPRESS;Initial Catalog=QLTS_Quynh; Integrated Security=True;Database=QLTS_Quynh;";

        //Cấu hình gửi mail
        public static string smtp_host = "dsesgu.edu.vn";
        public static int smtp_port = 25;
        public static bool smtp_usessl = false;
        public static string sender_email = "test@dsesgu.edu.vn";
        public static string sender_password = "1thanh";
    }
}
