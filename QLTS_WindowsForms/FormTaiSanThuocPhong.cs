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
    public partial class FormTaiSanThuocPhong : Form
    {
        public int IDPHONG = 0;
        public int IDCTTAISAN = 0;
        public FormTaiSanThuocPhong()
        {
            InitializeComponent();
            DanhSachPhong();
        }
        private void DanhSachPhong()
        {
            try
            {
                List<bizPHONG> ListPhong = dalPHONG.getall();
                listBoxPhong.DataSource = ListPhong;
                listBoxPhong.DisplayMember = "TENPHONG";
                listBoxPhong.ValueMember = "ID";

                List<bizCTTAISAN> ListCTTAISAN = dalCTTAISAN.TaiSan(ListPhong.FirstOrDefault().ID);
                var ListTAISAN = ListCTTAISAN.Select(item => new
                {
                    ID = item.ID,
                    SUBID = item.SUBID,
                    TEN = item.TAISAN.TENTAISAN,
                    SOLUONG = item.SOLUONG,
                    NGAYNHAP = item.NGAY,
                    MOTA = item.MOTA
                }).ToList();

                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = ListTAISAN;
                if (ListTAISAN.Count() < 1)
                {
                    EnableButton(false);
                }
                else
                {
                    IDCTTAISAN = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
                    EnableButton();
                }
            }
            catch { }
        }

        private void listBoxPhong_Click(object sender, EventArgs e)
        {
            try
            {
                IDPHONG = Int32.Parse(listBoxPhong.SelectedValue.ToString());
                List<bizCTTAISAN> ListCTTAISAN = dalCTTAISAN.TaiSan(IDPHONG);
                var ListTAISAN = ListCTTAISAN.Select(item => new
                {
                    ID = item.ID,
                    SUBID = item.SUBID,
                    TEN = item.TAISAN.TENTAISAN,
                    SOLUONG = item.SOLUONG,
                    NGAYNHAP = item.NGAY,
                    MOTA = item.MOTA
                }).ToList();

                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = ListTAISAN;
                if (ListTAISAN.Count() < 1)
                {
                    EnableButton(false);
                }
                else
                {
                    IDCTTAISAN = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
                    EnableButton();
                }
            }
            catch { }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDCTTAISAN = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                EnableButton();
            }
            catch { }
        }

        public void EnableButton(bool Allow = true)
        {
            buttonChuyenTaiSan.Enabled = buttonChuyenTinhTrang.Enabled = buttonSua.Enabled = buttonXoa.Enabled = buttonThanhLy.Enabled = Allow;
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiSanThuocPhong frm = new FormQuanLyTaiSanThuocPhong(dalPHONG.getbyid(IDPHONG), null, "THEM");
            frm.ShowDialog();
            DanhSachPhong();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiSanThuocPhong frm = new FormQuanLyTaiSanThuocPhong(null, dalCTTAISAN.getbyid(IDCTTAISAN), "SUA");
            frm.ShowDialog();
            DanhSachPhong();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn muốn xoá?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bizCTTAISAN CTTAISAN = dalCTTAISAN.getbyid(IDCTTAISAN);
                    if (dalCTTAISAN.xoa(CTTAISAN))
                    {
                        MessageBox.Show("Xoá thành công");
                        DanhSachPhong();
                    }
                    else
                    {
                        MessageBox.Show("Xoá lỗi rồi!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chọn tài sản để xoá!");
            }
        }
    }
}
