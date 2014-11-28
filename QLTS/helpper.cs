using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
