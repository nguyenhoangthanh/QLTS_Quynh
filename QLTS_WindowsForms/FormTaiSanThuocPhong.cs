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
        public bizCTTAISAN CTTAISAN;
        public FormTaiSanThuocPhong()
        {
            InitializeComponent();
            DanhSachPhong();
        }
        private void DanhSachPhong(bizPHONG PHONG = null)
        {
            try
            {
                List<bizPHONG> ListPhong = dalPHONG.getall();
                var ListPhongCustom = ListPhong.Select(item => new
                {
                    ID = item.ID,
                    TENPHONG = item.DIADIEM.TANG == null ? string.Format("{0} [{1}]", item.TENPHONG, item.DIADIEM.COSO.TENCOSO) : string.Format("{0} [{1} - {2} - {3}]", item.TENPHONG, item.DIADIEM.COSO == null ? "" : item.DIADIEM.COSO.TENCOSO, item.DIADIEM.KHU == null ? "" : item.DIADIEM.KHU.TEN, item.DIADIEM.TANG == null ? "" : item.DIADIEM.TANG.TENTANG)
                });

                listBoxPhong.DataSource = ListPhongCustom.ToList();
                listBoxPhong.DisplayMember = "TENPHONG";
                listBoxPhong.ValueMember = "ID";                

                List<bizCTTAISAN> ListCTTAISAN = new List<bizCTTAISAN>();
                if (PHONG == null)
                {
                    IDPHONG = ListPhong.FirstOrDefault().ID;
                }
                else
                {
                    IDPHONG = PHONG.ID;
                }
                ListCTTAISAN = dalCTTAISAN.TaiSan(IDPHONG);

                var ListTAISAN = ListCTTAISAN.Select(item => new
                {
                    ID = item.ID,
                    SUBID = item.TAISAN.SUBID,
                    TEN = item.TAISAN.TENTAISAN,
                    SOLUONG = item.SOLUONG,
                    TINHTRANG = item.TINHTRANG.VALUE,
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
                    SUBID = item.TAISAN.SUBID,
                    TEN = item.TAISAN.TENTAISAN,
                    SOLUONG = item.SOLUONG,
                    TINHTRANG = item.TINHTRANG.VALUE,
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
            if (frm._CAPNHAT == true)
            {
                DanhSachPhong(frm._PHONG);
                CTTAISAN = frm._CTTAISAN;
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiSanThuocPhong frm = new FormQuanLyTaiSanThuocPhong(dalPHONG.getbyid(IDPHONG), dalCTTAISAN.getbyid(IDCTTAISAN), "SUA");
            frm.ShowDialog();
            if (frm._CAPNHAT == true)
            {
                DanhSachPhong(frm._PHONG);
                CTTAISAN = frm._CTTAISAN;
            }
        }
        private void buttonChuyenTaiSan_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiSanThuocPhong frm = new FormQuanLyTaiSanThuocPhong(dalPHONG.getbyid(IDPHONG), dalCTTAISAN.getbyid(IDCTTAISAN), "CHUYENTAISAN");
            frm.ShowDialog();
            if (frm._CAPNHAT == true)
            {
                DanhSachPhong(frm._PHONG);
                CTTAISAN = frm._CTTAISAN;
            }
        }

        private void buttonChuyenTinhTrang_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiSanThuocPhong frm = new FormQuanLyTaiSanThuocPhong(dalPHONG.getbyid(IDPHONG), dalCTTAISAN.getbyid(IDCTTAISAN), "CHUYENTINHTRANG");
            frm.ShowDialog();
            if (frm._CAPNHAT == true)
            {
                DanhSachPhong(frm._PHONG);
                CTTAISAN = frm._CTTAISAN;
            }
        }

        private void buttonThanhLy_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiSanThuocPhong frm = new FormQuanLyTaiSanThuocPhong(dalPHONG.getbyid(IDPHONG), dalCTTAISAN.getbyid(IDCTTAISAN), "THANHLY");
            frm.ShowDialog();
            if (frm._CAPNHAT == true)
            {
                DanhSachPhong(frm._PHONG);
                CTTAISAN = frm._CTTAISAN;
            }
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn muốn loại bỏ tài sản này ra khỏi phòng?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bizCTTAISAN CTTAISAN = dalCTTAISAN.getbyid(IDCTTAISAN);
                    if (dalCTTAISAN.xoa(CTTAISAN))
                    {
                        bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                        LOGTAISAN.PHONG = CTTAISAN.PHONG;
                        LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã loại bỏ tài sản [{1}] ra khỏi phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, CTTAISAN.PHONG.TENPHONG);
                        dalLOGTAISAN.them(LOGTAISAN);
                        MessageBox.Show("Loại bỏ tài sản ra khỏi phòng thành công");
                        DanhSachPhong();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong khi loại bỏ tài sản ra khỏi phòng!");
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
