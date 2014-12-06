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
    public partial class FormQuanTriVien : Form
    {
        public string HoTenQTV
        {
            get { return TENQUANTRIVIEN; }
        }

        public bizQUANTRIVIEN QUANTRIVIEN = new bizQUANTRIVIEN();
        public List<bizQUANTRIVIEN> listQUANTRIVIEN = new List<bizQUANTRIVIEN>();
        public string TinhTrang = "";
        public int IDQUANTRIVIEN = 0;
        public string TENQUANTRIVIEN = "";
        public FormQuanTriVien()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                listQUANTRIVIEN = dalQUANTRIVIEN.getall();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = listQUANTRIVIEN;
                if (listQUANTRIVIEN.Count() < 1)
                {
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
                }
                else
                {
                    IDQUANTRIVIEN = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
                    buttonXoa.Enabled = true;
                    buttonSua.Enabled = true;
                }
            }
            catch { }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                buttonOK.Text = "Thêm";
                panel.Visible = true;
                TinhTrang = "THEM";
                buttonThem.Enabled = false;
            }
            catch { }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Visible = false;
                buttonThem.Enabled = buttonSua.Enabled = true;
                if (MessageBox.Show("Bạn muốn xoá?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (IDQUANTRIVIEN == Properties.Settings.Default.IDQUANTRIVIEN)
                    {
                        MessageBox.Show("Quản trị viên này đang đăng nhập.");
                        return;
                    }
                    if (dalQUANTRIVIEN.QuanTriVienDaMuonPhong(IDQUANTRIVIEN) > 0)
                    {
                        MessageBox.Show("Quản trị viên này đã có mượn phòng.");
                        return;
                    }
                    QUANTRIVIEN = dalQUANTRIVIEN.getbyid(IDQUANTRIVIEN);
                    if (dalQUANTRIVIEN.xoa(QUANTRIVIEN))
                    {
                        MessageBox.Show("Xoá thành công");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá lỗi rồi!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chọn cơ sở để xoá!");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {
                buttonThem.Enabled = true;
                buttonOK.Text = "Cập nhật";
                panel.Visible = true;
                TinhTrang = "SUA";
                buttonSua.Enabled = false;

                QUANTRIVIEN = dalQUANTRIVIEN.getbyid(IDQUANTRIVIEN);
                textBoxHoTen.Text = QUANTRIVIEN.TENQTVIEN;
                textBoxEmail.Text = QUANTRIVIEN.EMAIL;
                textBoxTaiKhoan.Text = QUANTRIVIEN.USERNAME;
                textBoxTaiKhoan.ReadOnly = true;
                textBoxMatKhau.Text = "******";
                textBoxNhapLaiMatKhau.Text = "******";
                textBoxMoTa.Text = QUANTRIVIEN.MOTA;
            }
            catch { }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (TinhTrang.Equals("THEM"))
                {
                    if (!textBoxHoTen.Text.Trim().Equals("") && !textBoxEmail.Text.Trim().Equals("") && !textBoxTaiKhoan.Text.Trim().Equals("") && !textBoxMatKhau.Text.Trim().Equals("") && !textBoxNhapLaiMatKhau.Text.Trim().Equals(""))
                    {
                        if (!textBoxMatKhau.Text.Trim().Equals(textBoxNhapLaiMatKhau.Text.Trim()))
                        {
                            MessageBox.Show("Mật khẩu không trùng khớp");
                            textBoxNhapLaiMatKhau.Focus();
                            return;
                        }
                        if (dalQUANTRIVIEN.getbyusername(textBoxTaiKhoan.Text.Trim()) != null)
                        {
                            MessageBox.Show("Tài khoản đã có trong hệ thống.");
                            textBoxTaiKhoan.Focus();
                            return;
                        }

                        QUANTRIVIEN = new bizQUANTRIVIEN();
                        QUANTRIVIEN.TENQTVIEN = textBoxHoTen.Text;
                        QUANTRIVIEN.EMAIL = textBoxEmail.Text;
                        QUANTRIVIEN.USERNAME = textBoxTaiKhoan.Text;
                        QUANTRIVIEN.PASSWORD = textBoxMatKhau.Text;
                        QUANTRIVIEN.MOTA = textBoxMoTa.Text;
                        if (dalQUANTRIVIEN.them(QUANTRIVIEN))
                        {
                            MessageBox.Show("Thêm thành công");
                            textBoxHoTen.Text = textBoxEmail.Text = textBoxTaiKhoan.Text = textBoxMatKhau.Text = textBoxNhapLaiMatKhau.Text = textBoxMoTa.Text = "";
                            LoadData();
                            buttonHuyBo.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Thêm lỗi rồi!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Điền đầy đủ trường");
                    }
                }
                else if (TinhTrang.Equals("SUA"))
                {
                    if (!textBoxHoTen.Text.Trim().Equals("") && !textBoxEmail.Text.Trim().Equals("") && !textBoxTaiKhoan.Text.Trim().Equals("") && !textBoxMatKhau.Text.Trim().Equals("") && !textBoxNhapLaiMatKhau.Text.Trim().Equals(""))
                    {
                        if (!textBoxMatKhau.Text.Trim().Equals(textBoxNhapLaiMatKhau.Text.Trim()))
                        {
                            MessageBox.Show("Mật khẩu không trùng khớp");
                            return;
                        }
                        QUANTRIVIEN = dalQUANTRIVIEN.getbyid(IDQUANTRIVIEN);
                        QUANTRIVIEN.TENQTVIEN = textBoxHoTen.Text;
                        QUANTRIVIEN.EMAIL = textBoxEmail.Text;
                        if (textBoxMatKhau.Text != "******")
                        {
                            QUANTRIVIEN.PASSWORD = textBoxMatKhau.Text;
                        }
                        QUANTRIVIEN.MOTA = textBoxMoTa.Text;
                        if (dalQUANTRIVIEN.sua(QUANTRIVIEN))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            if (QUANTRIVIEN.ID == Properties.Settings.Default.IDQUANTRIVIEN)
                            {
                                TENQUANTRIVIEN = QUANTRIVIEN.TENQTVIEN == "" ? "Quản trị viên" : QUANTRIVIEN.TENQTVIEN;
                            }
                            textBoxHoTen.Text = textBoxEmail.Text = textBoxTaiKhoan.Text = textBoxMatKhau.Text = textBoxNhapLaiMatKhau.Text = textBoxMoTa.Text = "";
                            textBoxTaiKhoan.ReadOnly = false;
                            LoadData();
                            buttonHuyBo.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật lỗi rồi!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Điền đầy đủ trường");
                    }
                }
            }
            catch { }
        }

        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Visible = false;
                textBoxHoTen.Text = textBoxEmail.Text = textBoxTaiKhoan.Text = textBoxMatKhau.Text = textBoxNhapLaiMatKhau.Text = textBoxMoTa.Text = "";
                if (TinhTrang.Equals("THEM"))
                {
                    buttonThem.Enabled = true;
                }
                else if (TinhTrang.Equals("SUA"))
                {
                    buttonSua.Enabled = true;
                }
                TinhTrang = "";
            }
            catch { }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDQUANTRIVIEN = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }
    }
}
