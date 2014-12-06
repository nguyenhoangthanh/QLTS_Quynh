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
    public partial class FormGiangVien : Form
    {
        public bizGIANGVIEN GIANGVIEN = new bizGIANGVIEN();
        public List<bizGIANGVIEN> listGIANGVIEN = new List<bizGIANGVIEN>();
        public string TinhTrang = "";
        public int IDGIANGVIEN = 0;
        public FormGiangVien()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                listGIANGVIEN = dalGIANGVIEN.getall();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = listGIANGVIEN;
                if (listGIANGVIEN.Count() < 1)
                {
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
                }
                else
                {
                    IDGIANGVIEN = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
                    buttonXoa.Enabled = true;
                    buttonSua.Enabled = true;
                }
            }
            catch { }
        }

        public void ResetInput()
        {
            textBoxHoTen.Text = textBoxEmail.Text = textBoxTaiKhoan.Text = textBoxMatKhau.Text = textBoxNhapLaiMatKhau.Text= "";
            textBoxHoTen.ReadOnly = textBoxEmail.ReadOnly = textBoxTaiKhoan.ReadOnly = textBoxMatKhau.ReadOnly = textBoxNhapLaiMatKhau.ReadOnly = false;
            textBoxHoTen.Enabled = textBoxEmail.Enabled = textBoxTaiKhoan.Enabled = textBoxMatKhau.Enabled = textBoxNhapLaiMatKhau.Enabled = true;
            dateTimePickerNgaySinh.ResetText();
            radioButtonNam.Select();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                ResetInput();
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
                    if (dalGIANGVIEN.GiangVienDaMuonPhong(IDGIANGVIEN) > 0)
                    {
                        MessageBox.Show("Giảng viên này đã có mượn phòng.");
                        return;
                    }
                    GIANGVIEN = dalGIANGVIEN.getbyid(IDGIANGVIEN);
                    if (dalGIANGVIEN.xoa(GIANGVIEN))
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
                ResetInput();
                buttonThem.Enabled = true;
                buttonOK.Text = "Cập nhật";
                panel.Visible = true;
                TinhTrang = "SUA";
                buttonSua.Enabled = false;

                GIANGVIEN = dalGIANGVIEN.getbyid(IDGIANGVIEN);
                textBoxHoTen.Text = GIANGVIEN.TENGV;
                textBoxEmail.Text = GIANGVIEN.EMAIL;
                textBoxTaiKhoan.Text = GIANGVIEN.USERNAME;
                textBoxTaiKhoan.ReadOnly = true;
                textBoxMatKhau.Text = "******";
                textBoxNhapLaiMatKhau.Text = "******";
                dateTimePickerNgaySinh.Value = Convert.ToDateTime(GIANGVIEN.NGAYSINH);
                if (GIANGVIEN.GIOITINH == "Nam")
                {
                    radioButtonNam.Select();
                }
                else
                {
                    radioButtonNu.Select();
                }
                textBoxMoTa.Text = GIANGVIEN.MOTA;
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
                        if (dalGIANGVIEN.getbyusername(textBoxTaiKhoan.Text.Trim()) != null)
                        {
                            MessageBox.Show("Tài khoản đã có trong hệ thống.");
                            textBoxTaiKhoan.Focus();
                            return;
                        }

                        GIANGVIEN = new bizGIANGVIEN();
                        GIANGVIEN.TENGV = textBoxHoTen.Text;
                        GIANGVIEN.EMAIL = textBoxEmail.Text;
                        GIANGVIEN.USERNAME = textBoxTaiKhoan.Text;
                        GIANGVIEN.PASSWORD = textBoxMatKhau.Text;
                        GIANGVIEN.NGAYSINH = dateTimePickerNgaySinh.Value;
                        GIANGVIEN.GIOITINH = radioButtonNam.Checked == true ? "Nam" : "Nữ";
                        GIANGVIEN.MOTA = textBoxMoTa.Text;
                        if (dalGIANGVIEN.them(GIANGVIEN))
                        {
                            MessageBox.Show("Thêm thành công");
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
                        GIANGVIEN = dalGIANGVIEN.getbyid(IDGIANGVIEN);
                        GIANGVIEN.TENGV = textBoxHoTen.Text;
                        GIANGVIEN.EMAIL = textBoxEmail.Text;
                        if (textBoxMatKhau.Text != "******")
                        {
                            GIANGVIEN.PASSWORD = textBoxMatKhau.Text;
                        }
                        GIANGVIEN.NGAYSINH = dateTimePickerNgaySinh.Value;
                        GIANGVIEN.GIOITINH = radioButtonNam.Checked == true ? "Nam" : "Nữ";
                        GIANGVIEN.MOTA = textBoxMoTa.Text;
                        if (dalGIANGVIEN.sua(GIANGVIEN))
                        {
                            MessageBox.Show("Cập nhật thành công");
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
                ResetInput();
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
                IDGIANGVIEN = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }
    }
}
