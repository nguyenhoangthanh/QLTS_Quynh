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
    public partial class FormNhanVien : Form
    {
        public bizNHANVIEN NHANVIEN = new bizNHANVIEN();
        public List<bizNHANVIEN> listNHANVIEN = new List<bizNHANVIEN>();
        public string TinhTrang = "";
        public int IDNHANVIEN = 0;
        public FormNhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                listNHANVIEN = dalNHANVIEN.getall();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = listNHANVIEN;
                if (listNHANVIEN.Count() < 1)
                {
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
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
                comboBox.DisplayMember = "Text";
                comboBox.ValueMember = "Value";
                var items = new[] { 
                    new { Text = "Nam", Value = "Nam" }, 
                    new { Text = "Nữ", Value = "Nữ" }
                };
                comboBox.DataSource = items;
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
                    NHANVIEN = dalNHANVIEN.getbyid(IDNHANVIEN);
                    if (dalNHANVIEN.xoa(NHANVIEN))
                    {
                        MessageBox.Show("Xoá thành công");
                        LoadData();
                        if (dataGridView.RowCount > 0)
                        {
                            IDNHANVIEN = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xoá lỗi rồi!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chọn nhân viên để xoá!");
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
                NHANVIEN = dalNHANVIEN.getbyid(IDNHANVIEN);
                textBoxMa.Text = NHANVIEN.SUBID;
                textBoxTen.Text = NHANVIEN.HOTEN;
                textBoxSoDienThoai.Text = NHANVIEN.SODIENTHOAI;
                comboBox.DisplayMember = "Text";
                comboBox.ValueMember = "Value";
                var items = new[] { 
                    new { Text = "Nam", Value = "Nam" }, 
                    new { Text = "Nữ", Value = "Nữ" }
                };
                comboBox.DataSource = items;
                comboBox.SelectedValue = NHANVIEN.GIOITINH;
                textBoxMoTa.Text = NHANVIEN.MOTA;
            }
            catch { }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (TinhTrang.Equals("THEM"))
                {
                    if (!textBoxTen.Text.Trim().Equals(""))
                    {
                        NHANVIEN = new bizNHANVIEN();
                        NHANVIEN.HOTEN = textBoxTen.Text;
                        NHANVIEN.SUBID = textBoxMa.Text;
                        NHANVIEN.SODIENTHOAI = textBoxSoDienThoai.Text;
                        NHANVIEN.GIOITINH = comboBox.SelectedValue.ToString();
                        NHANVIEN.MOTA = textBoxMoTa.Text;
                        if (dalNHANVIEN.them(NHANVIEN))
                        {
                            MessageBox.Show("Thêm thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxSoDienThoai.Text = textBoxMoTa.Text = "";
                            LoadData();
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
                    if (!textBoxTen.Text.Trim().Equals(""))
                    {
                        NHANVIEN = dalNHANVIEN.getbyid(IDNHANVIEN);
                        NHANVIEN.HOTEN = textBoxTen.Text;
                        NHANVIEN.SUBID = textBoxMa.Text;
                        NHANVIEN.SODIENTHOAI = textBoxSoDienThoai.Text;
                        NHANVIEN.GIOITINH = comboBox.SelectedValue.ToString();
                        NHANVIEN.MOTA = textBoxMoTa.Text;
                        if (dalNHANVIEN.sua(NHANVIEN))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxSoDienThoai.Text = textBoxMoTa.Text = "";
                            LoadData();
                            IDNHANVIEN = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
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
                textBoxMa.Text = textBoxTen.Text = textBoxSoDienThoai.Text = textBoxMoTa.Text = "";
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
                IDNHANVIEN = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }
    }
}
