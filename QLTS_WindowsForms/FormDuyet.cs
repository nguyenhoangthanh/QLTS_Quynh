using QLTS;
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
    public partial class FormDuyet : Form
    {
        bizPHIEUMUONPHONG PHIEUMUONPHONG;
        public FormDuyet(bizPHIEUMUONPHONG _PHIEUMUONPHONG)
        {
            InitializeComponent();
            PHIEUMUONPHONG = _PHIEUMUONPHONG;
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                textBoxKhoa.Text = PHIEUMUONPHONG.KHOA;
                textBoxNgayMuon.Text = Convert.ToDateTime(PHIEUMUONPHONG.NGAYMUON).ToString("dd/M/yyyy");
                textBoxTuGio.Text = Convert.ToDateTime(PHIEUMUONPHONG.NGAYMUON).ToString("H:mm");
                textBoxDenGio.Text = Convert.ToDateTime(PHIEUMUONPHONG.NGAYTRA).ToString("H:mm");
                textBoxSoLuongSinhVien.Text = PHIEUMUONPHONG.SOLUONGSV.ToString();
                textBoxNguoiMuon.Text = PHIEUMUONPHONG.GIANGVIENMUON == true ? "Giảng viên" : "Quản trị viên";
                textBoxTenNguoiMuon.Text = PHIEUMUONPHONG.GIANGVIENMUON == true ? dalGIANGVIEN.getbyid(PHIEUMUONPHONG.NGUOIMUON_ID).TENGV : dalQUANTRIVIEN.getbyid(PHIEUMUONPHONG.NGUOIMUON_ID).TENQTVIEN;
                textBoxLyDoMuon.Text = PHIEUMUONPHONG.LYDOMUON;

                comboBoxTinhTrang.DisplayMember = "Text";
                comboBoxTinhTrang.ValueMember = "Value";
                var items = new[] { 
                    new { Text = "Chờ duyệt", Value = "Chờ duyệt" }, 
                    new { Text = "Đồng ý", Value = "Đồng ý" },
                    new { Text = "Huỷ bỏ", Value = "Huỷ bỏ" }
                };
                comboBoxTinhTrang.DataSource = items;

                if (PHIEUMUONPHONG.TINHTRANG != "")
                {
                    comboBoxTinhTrang.SelectedValue = PHIEUMUONPHONG.TINHTRANG;
                }

                textBoxDuocDuyetBoi.Text = PHIEUMUONPHONG.QUANTRIVIEN != null ? PHIEUMUONPHONG.QUANTRIVIEN.TENQTVIEN : "Chưa có người duyệt";
                textBoxGhiChu.Text = PHIEUMUONPHONG.GHICHU ?? "";
            }
            catch { }
        }

        private void buttonDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxGhiChu.Text == "")
                {
                    MessageBox.Show("Ghi chú không được rỗng");
                    textBoxGhiChu.Focus();
                    return;
                }
                PHIEUMUONPHONG.TINHTRANG = comboBoxTinhTrang.SelectedValue.ToString();
                PHIEUMUONPHONG.GHICHU = textBoxGhiChu.Text;
                bizQUANTRIVIEN QUANTRIVIEN = dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN);
                PHIEUMUONPHONG.QUANTRIVIEN = QUANTRIVIEN;
                if (checkBoxGuiMail.Checked == true)
                {
                    string receive_email = PHIEUMUONPHONG.GIANGVIENMUON == true ? dalGIANGVIEN.getbyid(PHIEUMUONPHONG.NGUOIMUON_ID).EMAIL : dalQUANTRIVIEN.getbyid(PHIEUMUONPHONG.NGUOIMUON_ID).EMAIL;
                    string tennguoimuon = PHIEUMUONPHONG.GIANGVIENMUON == true ? dalGIANGVIEN.getbyid(PHIEUMUONPHONG.NGUOIMUON_ID).TENGV : dalQUANTRIVIEN.getbyid(PHIEUMUONPHONG.NGUOIMUON_ID).TENQTVIEN;
                    string receive_title = "Thông báo về việc mượn phòng của bạn ngày " + PHIEUMUONPHONG.NGAYTAO.ToString("dd/M/yyyy");
                    string tinhtrang = "";
                    switch (PHIEUMUONPHONG.TINHTRANG)
                    {
                        case "Chờ duyệt":
                            tinhtrang = "đang được xét duyệt";
                            break;
                        case "Đồng ý":
                            tinhtrang = "đã được xét duyệt";
                            break;
                        case "Huỷ bỏ":
                            tinhtrang = "đã bị huỷ bỏ";
                            break;
                    }
                    string receive_html = string.Format("<p>Chào {0}</p><p>Phiếu mượn phòng của bạn {1}</p><p>Ghi chú từ người duyệt</p><p>{2}</p><p>Họ tên người duyệt:</p><p>{3}</p><p>Email người duyệt:</p><p>{4}</p><p>Đăng nhập website để xem thông tin.</p><p>Mọi thắc mắc liên hệ email người duyệt.</p>", tennguoimuon, tinhtrang, PHIEUMUONPHONG.GHICHU, PHIEUMUONPHONG.QUANTRIVIEN.TENQTVIEN, PHIEUMUONPHONG.QUANTRIVIEN.EMAIL);
                    helpper.sendMail(receive_email, receive_title, receive_html);
                }
                if (dalPHIEUMUONPHONG.duyet(PHIEUMUONPHONG) == true)
                {
                    MessageBox.Show("Duyệt thành công.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi trong khi duyệt");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi trong khi duyệt");
            }
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
