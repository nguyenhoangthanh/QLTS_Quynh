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
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
            bizQUANTRIVIEN QUANTRIVIEN = dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN);
            labelQuanTriVien.Text = QUANTRIVIEN.TENQTVIEN == "" ? "Quản trị viên" : QUANTRIVIEN.TENQTVIEN;
        }

        private void buttonCOSO_Click(object sender, EventArgs e)
        {
            FormCoSo frm = new FormCoSo();
            frm.ShowDialog();
        }

        private void buttonKHU_Click(object sender, EventArgs e)
        {
            FormKhu frm = new FormKhu();
            frm.ShowDialog();
        }

        private void buttonLOAITAISAN_Click(object sender, EventArgs e)
        {
            FormLoaiTaiSan frm = new FormLoaiTaiSan();
            frm.ShowDialog();
        }

        private void buttonTinhTrang_Click(object sender, EventArgs e)
        {
            FormTinhTrang frm = new FormTinhTrang();
            frm.ShowDialog();
        }

        private void buttonTAISAN_Click(object sender, EventArgs e)
        {
            FormTaiSan frm = new FormTaiSan();
            frm.ShowDialog();
        }

        private void buttonNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien frm = new FormNhanVien();
            frm.ShowDialog();
        }

        private void buttonTANG_Click(object sender, EventArgs e)
        {
            FormTang frm = new FormTang();
            frm.ShowDialog();
        }

        private void buttonThongKeBaoCao_Click(object sender, EventArgs e)
        {
            FormThongKe frm = new FormThongKe();
            frm.ShowDialog();
        }

        private void buttonQuanLyDangKySuDungPhong_Click(object sender, EventArgs e)
        {
            FormSuDungPhong frm = new FormSuDungPhong();
            frm.ShowDialog();
        }

        private void buttonPHONG_Click(object sender, EventArgs e)
        {
            FormPhong frm = new FormPhong();
            frm.ShowDialog();
        }

        private void buttonGiangVien_Click(object sender, EventArgs e)
        {
            FormGiangVien frm = new FormGiangVien();
            frm.ShowDialog();
        }

        private void buttonQuanTriVien_Click(object sender, EventArgs e)
        {
            FormQuanTriVien frm = new FormQuanTriVien();
            frm.ShowDialog();
            if (frm.HoTenQTV != "")
            {
                this.labelQuanTriVien.Text = frm.HoTenQTV;
            }
        }

        private void buttonTAISANPHONG_Click(object sender, EventArgs e)
        {
            FormTaiSanThuocPhong frm = new FormTaiSanThuocPhong();
            frm.ShowDialog();
        }
    }
}
