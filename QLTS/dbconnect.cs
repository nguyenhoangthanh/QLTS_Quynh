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
        public static string smtp_host = "smtp.gmail.com";
        public static int smtp_port = 465;
        public static bool smtp_usessl = true;
        public static string sender_email = "nguyenthiquynh.1112@gmail.com";
        public static string sender_password = "chuotyeugao";
    }
}
