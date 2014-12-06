using QLTS.BLL;
using QLTS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLTS_WindowsForms
{
    public partial class FormDangNhap : Form
    {
        bizQUANTRIVIEN QUANTRIVIEN = new bizQUANTRIVIEN();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxTaiKhoan.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Điền tên tài khoản");
                    textBoxTaiKhoan.Focus();
                }
                else if (textBoxMatKhau.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Điền mật khẩu");
                    textBoxMatKhau.Focus();
                }
                else
                {
                    QUANTRIVIEN = dalQUANTRIVIEN.getbyusername(textBoxTaiKhoan.Text);
                    if (QUANTRIVIEN.USERNAME.Equals(""))
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                        textBoxTaiKhoan.Focus();
                    }
                    else
                    {
                        Properties.Settings.Default.IDQUANTRIVIEN = QUANTRIVIEN.ID;
                        FormChinh frm = new FormChinh();                        
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch { }
        }
    }
}