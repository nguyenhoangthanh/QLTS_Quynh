using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLTS_WindowsForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormDangNhap frm = new FormDangNhap();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormChinh());
            }
            else
            {
                Application.Exit();
            }            
        }
    }
}
