using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace QLTS
{
    public class helpper
    {
        /// <summary>
        /// Chuyển chuổi có dấu thành không dấu
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CoDauThanhKhongDau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        /// <summary>
        /// Thay đổi ký tự đặt biệt thành ký tự bất kỳ, kể cả rỗng.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public static String thayDoiKyTuDacBiet(string input = "", string replace = " ")
        {
            string re = input;
            char[] special = { '-', '_', '.', ',', '!', '?', '#', '@', '$', '~', '`', '^', '%', '&', '*', '(', ')', '+', '=', ';', ':', '\'', '"', '[', ']', '{', '}', '|', '\\' };
            foreach (var item in special)
            {
                re = re.Replace(item.ToString(), replace);
            }
            return re;
        }

        /// <summary>
        /// Tạo khoá(KEY) từ giá trị(VALUE) đã nhập.
        /// </summary>
        /// <param name="VALUE"></param>
        /// <returns></returns>
        public static String KEY(string VALUE)
        {
            return (thayDoiKyTuDacBiet(CoDauThanhKhongDau(VALUE), "")).ToUpper();
        }

        /// <summary>
        /// Hàm rút gọn của sendMail nhiều tham số,
        /// lấy SMTP CONFIG từ Global ra cho gọn
        /// </summary>
        /// <param name="receive_email"></param>
        /// <param name="receive_title"></param>
        /// <param name="receive_html"></param>
        /// <returns></returns>
        public static int sendMail(String receive_email, String receive_title, String receive_html)
        {
            return sendMail(receive_email, receive_title, receive_html, dbconnect.smtp_host, dbconnect.smtp_port, dbconnect.smtp_usessl, dbconnect.sender_email, dbconnect.sender_password);
        }
        /// <summary>
        /// Hàm gửi email đơn lẻ
        /// </summary>
        /// <param name="smtp_host"></param>
        /// <param name="smtp_port">Cổng</param>
        /// <param name="smtp_usessl">Sử dụng SSL</param>
        /// <param name="sender_email">Cũng chính là tên đăng nhập SMTP</param>
        /// <param name="sender_password">Mật khẩu dạng thô</param>
        /// <param name="receive_email">Email người nhận</param>
        /// <param name="receive_title">Tiêu đề email</param>
        /// <param name="receive_html">Nội dung mail dạng HTML</param>
        /// <returns></returns>
        public static int sendMail(String receive_email, String receive_title, String receive_html, String smtp_host, int smtp_port, Boolean smtp_usessl, String sender_email, String sender_password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(receive_email);

                mail.Subject = receive_title;
                mail.IsBodyHtml = true;
                mail.Body = receive_html;
                mail.From = new MailAddress(sender_email);

                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = smtp_usessl;
                client.Host = smtp_host;
                client.Port = smtp_port;
                // setup Smtp authentication
                NetworkCredential credentials = new NetworkCredential(sender_email, sender_password);
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;
                client.Send(mail);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}
