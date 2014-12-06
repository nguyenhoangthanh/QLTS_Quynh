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
    public partial class FormSuDungPhong : Form
    {
        public bizPHIEUMUONPHONG PHIEUMUONPHONG = new bizPHIEUMUONPHONG();
        public List<bizPHIEUMUONPHONG> listPHIEUMUONPHONG = new List<bizPHIEUMUONPHONG>();
        public string TinhTrang = "";
        public int IDPHIEUMUONPHONG = 0;
        public FormSuDungPhong()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                listPHIEUMUONPHONG = dalPHIEUMUONPHONG.getall();
                var ListPHIEUMUONPHONGCustom = listPHIEUMUONPHONG.Select(item => new
                {
                    ID = item.ID,
                    NGAYTAO = item.NGAYTAO.ToString("dd/M/yyyy"),
                    KHOA = item.KHOA,
                    NGAYMUON = Convert.ToDateTime(item.NGAYMUON).ToString("dd/M/yyyy"),
                    TUGIO = Convert.ToDateTime(item.NGAYMUON).ToString("H:mm"),
                    DENGIO = Convert.ToDateTime(item.NGAYTRA).ToString("H:mm"),
                    SOLUONGSV = item.SOLUONGSV,
                    NGUOIMUON = item.GIANGVIENMUON == true ? "Giảng viên" : "Quản trị viên",
                    TENNGUOIMUON = item.GIANGVIENMUON == true ? dalGIANGVIEN.getbyid(item.NGUOIMUON_ID).TENGV : dalQUANTRIVIEN.getbyid(item.NGUOIMUON_ID).TENQTVIEN,
                    STATUS = item.TINHTRANG,
                    NGUOIDUYET = item.QUANTRIVIEN == null ? "Chưa có người duyệt" : item.QUANTRIVIEN.TENQTVIEN,
                    GHICHU = item.GHICHU
                }).ToList();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = ListPHIEUMUONPHONGCustom;
                if (listPHIEUMUONPHONG.Count() < 1)
                {
                    buttonDuyet.Enabled = false;
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
                }
                else
                {
                    IDPHIEUMUONPHONG = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
                    buttonDuyet.Enabled = true;
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
                    PHIEUMUONPHONG = dalPHIEUMUONPHONG.getbyid(IDPHIEUMUONPHONG);
                    if (dalPHIEUMUONPHONG.xoa(PHIEUMUONPHONG))
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
                MessageBox.Show("Chọn phiếu mượn để xoá!");
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

                PHIEUMUONPHONG = dalPHIEUMUONPHONG.getbyid(IDPHIEUMUONPHONG);
                textBoxKhoa.Text = PHIEUMUONPHONG.KHOA;
                string ngaymuon = Convert.ToDateTime(PHIEUMUONPHONG.NGAYMUON).ToString("dd/M/yyyy");
                dateTimePickerNgayMuon.Value = Convert.ToDateTime(ngaymuon);
                string tugio = Convert.ToDateTime(PHIEUMUONPHONG.NGAYMUON).ToString("H:mm");
                dateTimePickerTuGio.Value = Convert.ToDateTime(tugio);
                string dengio = Convert.ToDateTime(PHIEUMUONPHONG.NGAYTRA).ToString("H:mm");
                dateTimePickerDenGio.Value = Convert.ToDateTime(dengio);
                textBoxLyDoMuon.Text = PHIEUMUONPHONG.LYDOMUON;
                textBoxSoLuongSinhVien.Text = PHIEUMUONPHONG.SOLUONGSV.ToString();
            }
            catch { }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (TinhTrang.Equals("THEM"))
                {
                    if (textBoxKhoa.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Khoa(Phòng) mượn không được rỗng");
                        textBoxKhoa.Focus();
                        return;
                    }
                    if (dateTimePickerNgayMuon.Value < DateTime.Now.Date)
                    {
                        MessageBox.Show("Ngày mượn phòng phải lớn hơn hoặc trùng với ngày hiện tại");
                        dateTimePickerNgayMuon.Focus();
                        return;
                    }
                    if (textBoxSoLuongSinhVien.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Số lượng sinh viên không được rỗng");
                        textBoxSoLuongSinhVien.Focus();
                        return;
                    }
                    if (textBoxLyDoMuon.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Lý do sử dụng không được rỗng");
                        textBoxLyDoMuon.Focus();
                        return;
                    }

                    string khoaphongmuon = textBoxKhoa.Text;
                    DateTime thoigianmuon = Convert.ToDateTime(dateTimePickerNgayMuon.Value.ToString("dd/M/yyyy") + " " + dateTimePickerTuGio.Value.ToString("H:mm"));
                    DateTime thoigiantra = Convert.ToDateTime(dateTimePickerNgayMuon.Value.ToString("dd/M/yyyy") + " " + dateTimePickerDenGio.Value.ToString("H:mm"));
                    if (thoigianmuon <= DateTime.Now)
                    {
                        MessageBox.Show("Thời gian mượn phải lớn hơn thời gian hiện tại");
                        dateTimePickerTuGio.Focus();
                        return;
                    }
                    if (thoigiantra <= thoigianmuon)
                    {
                        MessageBox.Show("Thời gian trả phải lớn hơn thời gian mượn");
                        dateTimePickerDenGio.Focus();
                        return;
                    }
                    try
                    {
                        Convert.ToInt32(textBoxSoLuongSinhVien.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Số lượng sinh viên phải là số");
                        textBoxSoLuongSinhVien.Focus();
                        return;
                    }
                    int soluong = Convert.ToInt32(textBoxSoLuongSinhVien.Text);
                    string lydosudung = textBoxLyDoMuon.Text;

                    PHIEUMUONPHONG = new bizPHIEUMUONPHONG();
                    PHIEUMUONPHONG.KHOA = khoaphongmuon;
                    PHIEUMUONPHONG.NGAYMUON = thoigianmuon;
                    PHIEUMUONPHONG.NGAYTRA = thoigiantra;
                    PHIEUMUONPHONG.SOLUONGSV = soluong;
                    PHIEUMUONPHONG.LYDOMUON = lydosudung;
                    PHIEUMUONPHONG.NGUOIMUON_ID = Properties.Settings.Default.IDQUANTRIVIEN;
                    PHIEUMUONPHONG.GIANGVIENMUON = false;
                    PHIEUMUONPHONG.TINHTRANG = "Chờ duyệt";
                    if (dalPHIEUMUONPHONG.them(PHIEUMUONPHONG))
                    {
                        MessageBox.Show("Thêm thành công");
                        textBoxKhoa.Text = textBoxSoLuongSinhVien.Text = textBoxLyDoMuon.Text = "";
                        dateTimePickerNgayMuon.Value = DateTime.Now;
                        dateTimePickerTuGio.Value = DateTime.Now;
                        dateTimePickerDenGio.Value = DateTime.Now;
                        LoadData();
                        buttonHuyBo.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Thêm lỗi rồi!");
                    }
                }
                else if (TinhTrang.Equals("SUA"))
                {
                    if (textBoxKhoa.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Khoa(Phòng) mượn không được rỗng");
                        textBoxKhoa.Focus();
                        return;
                    }
                    if (dateTimePickerNgayMuon.Value < DateTime.Now.Date)
                    {
                        MessageBox.Show("Ngày mượn phòng phải lớn hơn hoặc trùng với ngày hiện tại");
                        dateTimePickerNgayMuon.Focus();
                        return;
                    }
                    if (textBoxSoLuongSinhVien.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Số lượng sinh viên không được rỗng");
                        textBoxSoLuongSinhVien.Focus();
                        return;
                    }
                    if (textBoxLyDoMuon.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Lý do sử dụng không được rỗng");
                        textBoxLyDoMuon.Focus();
                        return;
                    }

                    string khoaphongmuon = textBoxKhoa.Text;
                    DateTime thoigianmuon = Convert.ToDateTime(dateTimePickerNgayMuon.Value.ToString("dd/M/yyyy") + " " + dateTimePickerTuGio.Value.ToString("H:mm"));
                    DateTime thoigiantra = Convert.ToDateTime(dateTimePickerNgayMuon.Value.ToString("dd/M/yyyy") + " " + dateTimePickerDenGio.Value.ToString("H:mm"));
                    if (thoigianmuon <= DateTime.Now)
                    {
                        MessageBox.Show("Thời gian mượn phải lớn hơn thời gian hiện tại");
                        dateTimePickerTuGio.Focus();
                    }
                    if (thoigiantra <= thoigianmuon)
                    {
                        MessageBox.Show("Thời gian trả phải lớn hơn thời gian mượn");
                        dateTimePickerDenGio.Focus();
                        return;
                    }
                    try
                    {
                        Convert.ToInt32(textBoxSoLuongSinhVien.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Số lượng sinh viên phải là số");
                        textBoxSoLuongSinhVien.Focus();
                        return;
                    }
                    int soluong = Convert.ToInt32(textBoxSoLuongSinhVien.Text);
                    string lydosudung = textBoxLyDoMuon.Text;

                    PHIEUMUONPHONG = dalPHIEUMUONPHONG.getbyid(IDPHIEUMUONPHONG);
                    PHIEUMUONPHONG.KHOA = khoaphongmuon;
                    PHIEUMUONPHONG.NGAYMUON = thoigianmuon;
                    PHIEUMUONPHONG.NGAYTRA = thoigiantra;
                    PHIEUMUONPHONG.SOLUONGSV = soluong;
                    PHIEUMUONPHONG.LYDOMUON = lydosudung;
                    PHIEUMUONPHONG.NGUOIMUON_ID = Properties.Settings.Default.IDQUANTRIVIEN;
                    PHIEUMUONPHONG.GIANGVIENMUON = false;
                    if (dalPHIEUMUONPHONG.sua(PHIEUMUONPHONG))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        textBoxKhoa.Text = textBoxSoLuongSinhVien.Text = textBoxLyDoMuon.Text = "";
                        dateTimePickerNgayMuon.Value = DateTime.Now;
                        dateTimePickerTuGio.Value = DateTime.Now;
                        dateTimePickerDenGio.Value = DateTime.Now;
                        LoadData();
                        buttonHuyBo.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật lỗi rồi!");
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
                textBoxKhoa.Text = textBoxSoLuongSinhVien.Text = textBoxLyDoMuon.Text = "";
                dateTimePickerNgayMuon.Value = DateTime.Now;
                dateTimePickerTuGio.Value = DateTime.Now;
                dateTimePickerDenGio.Value = DateTime.Now;
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
                IDPHIEUMUONPHONG = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }

        private void buttonDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                PHIEUMUONPHONG = dalPHIEUMUONPHONG.getbyid(IDPHIEUMUONPHONG);
                FormDuyet frm = new FormDuyet(PHIEUMUONPHONG);
                frm.ShowDialog();
                LoadData();
            }
            catch
            {
                MessageBox.Show("Chọn phiếu mượn để duyệt!");
            }
        }
    }
}
