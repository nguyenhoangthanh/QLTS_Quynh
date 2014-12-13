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
    public partial class FormQuanLyTaiSanThuocPhong : Form
    {
        bizPHONG PHONG;
        bizPHONG PHONGCU;
        bizCTTAISAN CTTAISAN;
        bizTINHTRANG TINHTRANGTSCU;
        int SOLUONGCU = -1;
        string TINHTRANG = "";
        bool CAPNHAT = false;
        public bool _CAPNHAT { get { return CAPNHAT; } }
        public bizPHONG _PHONG { get { return PHONG; } }
        public bizCTTAISAN _CTTAISAN { get { return CTTAISAN; } }
        public FormQuanLyTaiSanThuocPhong(bizPHONG _PHONG, bizCTTAISAN _CTTAISAN, string _TINHTRANG)
        {
            try
            {
                InitializeComponent();
                PHONG = _PHONG;
                CTTAISAN = _CTTAISAN;
                if (CTTAISAN != null)
                {
                    SOLUONGCU = CTTAISAN.SOLUONG;
                    PHONGCU = CTTAISAN.PHONG;
                    TINHTRANGTSCU = CTTAISAN.TINHTRANG;
                }
                TINHTRANG = _TINHTRANG;
                LoadData();
            }
            catch { }
        }

        public void LoadData()
        {
            try
            {
                List<bizPHONG> ListPHONG;
                List<bizTAISAN> ListTAISAN;
                List<bizTINHTRANG> ListTINHTRANG;
                switch (TINHTRANG)
                {
                    case "THEM":
                        this.Text = groupBox.Text = "Chuyển tài sản vào phòng";
                        buttonOK.Text = "Thêm";
                        ListPHONG = dalPHONG.getall();
                        comboBoxPhong.DataSource = ListPHONG;
                        comboBoxPhong.DisplayMember = "TENPHONG";
                        comboBoxPhong.ValueMember = "ID";
                        if (PHONG != null)
                        {
                            comboBoxPhong.SelectedValue = PHONG.ID;
                        }
                        ListTAISAN = dalTAISAN.getallTaiSanCoTheThemVaoPhong();
                        comboBoxTaiSan.DataSource = ListTAISAN;
                        comboBoxTaiSan.DisplayMember = "TENTAISAN";
                        comboBoxTaiSan.ValueMember = "ID";
                        if (ListTAISAN != null && ListTAISAN.Count > 0)
                        {
                            if (ListTAISAN.FirstOrDefault().TAISANKHONGGIOIHAN == false)
                            {
                                textBoxSoLuong.ReadOnly = true;
                                textBoxSoLuong.Text = "1";
                            }
                            else
                            {
                                textBoxSoLuong.ReadOnly = false;
                                textBoxSoLuong.Text = "";
                            }
                        }
                        ListTINHTRANG = dalTINHTRANG.getall();
                        comboBoxTinhTrang.DataSource = ListTINHTRANG;
                        comboBoxTinhTrang.DisplayMember = "VALUE";
                        comboBoxTinhTrang.ValueMember = "ID";
                        break;
                    case "SUA":
                        this.Text = groupBox.Text = "Cập nhật chuyển tài sản vào phòng";
                        buttonOK.Text = "Cập nhật";
                        ListPHONG = new List<bizPHONG>();
                        ListPHONG.Add(PHONG);
                        comboBoxPhong.DataSource = ListPHONG;
                        comboBoxPhong.DisplayMember = "TENPHONG";
                        comboBoxPhong.ValueMember = "ID";
                        comboBoxPhong.SelectedValue = PHONG.ID;
                        comboBoxPhong.Enabled = false;
                        ListTAISAN = dalTAISAN.getallTaiSanCoTheThemVaoPhong();
                        ListTAISAN.Add(CTTAISAN.TAISAN);
                        comboBoxTaiSan.DataSource = ListTAISAN;
                        comboBoxTaiSan.DisplayMember = "TENTAISAN";
                        comboBoxTaiSan.ValueMember = "ID";
                        comboBoxTaiSan.SelectedValue = CTTAISAN.TAISAN.ID;
                        textBoxSoLuong.Text = CTTAISAN.SOLUONG.ToString();
                        ListTINHTRANG = dalTINHTRANG.getall();
                        comboBoxTinhTrang.DataSource = ListTINHTRANG;
                        comboBoxTinhTrang.DisplayMember = "VALUE";
                        comboBoxTinhTrang.ValueMember = "ID";
                        comboBoxTinhTrang.SelectedValue = CTTAISAN.TINHTRANG.ID;
                        break;
                    case "CHUYENTAISAN":
                        this.Text = groupBox.Text = "Chuyển tài sản từ phòng " + PHONG.TENPHONG + " sang phòng mới";
                        buttonOK.Text = "Chuyển";
                        ListPHONG = dalPHONG.getall();
                        comboBoxPhong.DataSource = ListPHONG;
                        comboBoxPhong.DisplayMember = "TENPHONG";
                        comboBoxPhong.ValueMember = "ID";
                        comboBoxPhong.SelectedValue = PHONG.ID;
                        ListTAISAN = new List<bizTAISAN>();
                        ListTAISAN.Add(CTTAISAN.TAISAN);
                        comboBoxTaiSan.DataSource = ListTAISAN;
                        comboBoxTaiSan.DisplayMember = "TENTAISAN";
                        comboBoxTaiSan.ValueMember = "ID";
                        comboBoxTaiSan.SelectedValue = CTTAISAN.TAISAN.ID;
                        comboBoxTaiSan.Enabled = false;
                        textBoxSoLuong.Text = CTTAISAN.SOLUONG.ToString();
                        ListTINHTRANG = new List<bizTINHTRANG>();
                        ListTINHTRANG.Add(CTTAISAN.TINHTRANG);
                        comboBoxTinhTrang.DataSource = ListTINHTRANG;
                        comboBoxTinhTrang.DisplayMember = "VALUE";
                        comboBoxTinhTrang.ValueMember = "ID";
                        comboBoxTinhTrang.SelectedValue = CTTAISAN.TINHTRANG.ID;
                        comboBoxTinhTrang.Enabled = false;
                        dateTimePickerNgayNhap.Value = CTTAISAN.NGAY;
                        dateTimePickerNgayNhap.Enabled = false;
                        textBoxMoTa.Text = CTTAISAN.MOTA;
                        textBoxMoTa.ReadOnly = true;
                        break;
                    case "CHUYENTINHTRANG":
                        this.Text = groupBox.Text = "Đổi tình trạng tài sản " + CTTAISAN.TAISAN.TENTAISAN;
                        buttonOK.Text = "Chuyển";
                        ListPHONG = new List<bizPHONG>();
                        ListPHONG.Add(PHONG);
                        comboBoxPhong.DataSource = ListPHONG;
                        comboBoxPhong.DisplayMember = "TENPHONG";
                        comboBoxPhong.ValueMember = "ID";
                        comboBoxPhong.SelectedValue = PHONG.ID;
                        comboBoxPhong.Enabled = false;
                        ListTAISAN = new List<bizTAISAN>();
                        ListTAISAN.Add(CTTAISAN.TAISAN);
                        comboBoxTaiSan.DataSource = ListTAISAN;
                        comboBoxTaiSan.DisplayMember = "TENTAISAN";
                        comboBoxTaiSan.ValueMember = "ID";
                        comboBoxTaiSan.SelectedValue = CTTAISAN.TAISAN.ID;
                        comboBoxTaiSan.Enabled = false;
                        textBoxSoLuong.Text = CTTAISAN.SOLUONG.ToString();
                        textBoxSoLuong.ReadOnly = true;
                        ListTINHTRANG = dalTINHTRANG.getall();
                        comboBoxTinhTrang.DataSource = ListTINHTRANG;
                        comboBoxTinhTrang.DisplayMember = "VALUE";
                        comboBoxTinhTrang.ValueMember = "ID";
                        comboBoxTinhTrang.SelectedValue = CTTAISAN.TINHTRANG.ID;
                        dateTimePickerNgayNhap.Value = CTTAISAN.NGAY;
                        dateTimePickerNgayNhap.Enabled = false;
                        textBoxMoTa.Text = CTTAISAN.MOTA;
                        textBoxMoTa.ReadOnly = true;
                        break;
                    case "THANHLY":
                        this.Text = groupBox.Text = "Thanh lý tài sản";
                        buttonOK.Text = "Thanh lý";
                        labelThongBao.Visible = true;
                        ListPHONG = dalPHONG.getall();
                        comboBoxPhong.DataSource = ListPHONG;
                        comboBoxPhong.DisplayMember = "TENPHONG";
                        comboBoxPhong.ValueMember = "ID";
                        comboBoxPhong.SelectedValue = PHONG.ID;
                        ListTAISAN = new List<bizTAISAN>();
                        ListTAISAN.Add(CTTAISAN.TAISAN);
                        comboBoxTaiSan.DataSource = ListTAISAN;
                        comboBoxTaiSan.DisplayMember = "TENTAISAN";
                        comboBoxTaiSan.ValueMember = "ID";
                        comboBoxTaiSan.SelectedValue = CTTAISAN.TAISAN.ID;
                        comboBoxTaiSan.Enabled = false;
                        textBoxSoLuong.Text = CTTAISAN.SOLUONG.ToString();
                        textBoxSoLuong.ReadOnly = true;
                        ListTINHTRANG = dalTINHTRANG.getall();
                        comboBoxTinhTrang.DataSource = ListTINHTRANG;
                        comboBoxTinhTrang.DisplayMember = "VALUE";
                        comboBoxTinhTrang.ValueMember = "ID";
                        comboBoxTinhTrang.SelectedValue = CTTAISAN.TINHTRANG.ID;
                        dateTimePickerNgayNhap.Value = CTTAISAN.NGAY;
                        dateTimePickerNgayNhap.Enabled = false;
                        textBoxMoTa.Text = CTTAISAN.MOTA;
                        textBoxMoTa.ReadOnly = true;
                        break;
                }
            }
            catch { }
        }

        private void comboBoxTaiSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IDTAISAN = Int32.Parse(comboBoxTaiSan.SelectedValue.ToString());
                bizTAISAN TAISAN = dalTAISAN.getbyid(IDTAISAN);
                if (TAISAN.TAISANKHONGGIOIHAN == false)
                {
                    textBoxSoLuong.ReadOnly = true;
                    textBoxSoLuong.Text = "1";
                }
                else
                {
                    textBoxSoLuong.ReadOnly = false;
                    textBoxSoLuong.Text = "";
                }
            }
            catch { }
        }

        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                switch (TINHTRANG)
                {
                    case "THEM":
                        CTTAISAN = new bizCTTAISAN();
                        try
                        {
                            CTTAISAN.PHONG = dalPHONG.getbyid(Int32.Parse(comboBoxPhong.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm phòng trước");
                            return;
                        }

                        try
                        {
                            CTTAISAN.TAISAN = dalTAISAN.getbyid(Int32.Parse(comboBoxTaiSan.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tài sản trước");
                            return;
                        }

                        try
                        {
                            CTTAISAN.SOLUONG = Int32.Parse(textBoxSoLuong.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Số lượng không đúng");
                            textBoxSoLuong.Focus();
                            return;
                        }

                        CTTAISAN.NGAY = dateTimePickerNgayNhap.Value;

                        try
                        {
                            CTTAISAN.TINHTRANG = dalTINHTRANG.getbyid(Int32.Parse(comboBoxTinhTrang.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tình trạng trước");
                            return;
                        }

                        CTTAISAN.MOTA = textBoxMoTa.Text;

                        if (dalCTTAISAN.them(CTTAISAN))
                        {
                            bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                            LOGTAISAN.PHONG = CTTAISAN.PHONG;
                            LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển thành công tài sản [{1}] vào phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, CTTAISAN.PHONG.TENPHONG);
                            dalLOGTAISAN.them(LOGTAISAN);
                            MessageBox.Show("Chuyển tài sản vào phòng thành công");
                            CAPNHAT = true;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong khi chuyển!");
                        }
                        break;
                    case "SUA":
                        try
                        {
                            CTTAISAN.TAISAN = dalTAISAN.getbyid(Int32.Parse(comboBoxTaiSan.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tài sản trước");
                            return;
                        }

                        try
                        {
                            CTTAISAN.SOLUONG = Int32.Parse(textBoxSoLuong.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Số lượng không đúng");
                            textBoxSoLuong.Focus();
                            return;
                        }

                        CTTAISAN.NGAY = dateTimePickerNgayNhap.Value;

                        try
                        {
                            CTTAISAN.TINHTRANG = dalTINHTRANG.getbyid(Int32.Parse(comboBoxTinhTrang.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tình trạng trước");
                            return;
                        }

                        CTTAISAN.MOTA = textBoxMoTa.Text;

                        if (dalCTTAISAN.sua(CTTAISAN))
                        {
                            bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                            LOGTAISAN.PHONG = CTTAISAN.PHONG;
                            LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã cập nhật thông tin tài sản [{1}] của phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, CTTAISAN.PHONG.TENPHONG);
                            dalLOGTAISAN.them(LOGTAISAN);
                            MessageBox.Show("Cập nhật chuyển tài sản vào phòng thành công");
                            CAPNHAT = true;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong khi cập nhật chuyển!");
                        }
                        break;
                    case "CHUYENTAISAN":
                        int SOLUONGMOI;
                        try
                        {
                            SOLUONGMOI = Int32.Parse(textBoxSoLuong.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Số lượng không đúng");
                            textBoxSoLuong.Focus();
                            return;
                        }
                        if (SOLUONGMOI > SOLUONGCU)
                        {
                            MessageBox.Show("Số lượng chuyển phải nhỏ hơn hoặc bằng số lượng cũ");
                            textBoxSoLuong.Focus();
                            return;
                        }
                        if (SOLUONGMOI == SOLUONGCU)
                        {
                            try
                            {
                                CTTAISAN.PHONG = dalPHONG.getbyid(Int32.Parse(comboBoxPhong.SelectedValue.ToString()));
                            }
                            catch
                            {
                                MessageBox.Show("Thêm phòng trước");
                                return;
                            }
                            if (Object.Equals(PHONGCU.ID, CTTAISAN.PHONG.ID))
                            {
                                MessageBox.Show("Vui lòng chọn phòng mới");
                                return;
                            }
                            if (dalCTTAISAN.sua(CTTAISAN))
                            {
                                bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                LOGTAISAN.PHONG = CTTAISAN.PHONG;
                                LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển tài sản [{1}] với số lượng [{2}] từ phòng [{3}] sang phòng [{4}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, CTTAISAN.SOLUONG, PHONGCU.TENPHONG, CTTAISAN.PHONG.TENPHONG);
                                dalLOGTAISAN.them(LOGTAISAN);
                                MessageBox.Show("Cập nhật chuyển phòng thành công");
                                CAPNHAT = true;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi trong khi cập nhật chuyển phòng!");
                            }
                        }
                        else
                        {
                            bizPHONG PHONGMOI;
                            try
                            {
                                PHONGMOI = dalPHONG.getbyid(Int32.Parse(comboBoxPhong.SelectedValue.ToString()));
                            }
                            catch
                            {
                                MessageBox.Show("Thêm phòng trước");
                                return;
                            }
                            if (Object.Equals(PHONGCU, PHONGMOI))
                            {
                                MessageBox.Show("Vui lòng chọn phòng mới");
                                return;
                            }
                            int SOLUONGCONLAI = SOLUONGCU - SOLUONGMOI;
                            //them tai san phong moi
                            bizCTTAISAN CTTAISANMOI = new bizCTTAISAN();
                            CTTAISANMOI.NGAY = CTTAISAN.NGAY;
                            CTTAISANMOI.SOLUONG = SOLUONGMOI;
                            CTTAISANMOI.PHONG = PHONGMOI;
                            CTTAISANMOI.TAISAN = CTTAISAN.TAISAN;
                            CTTAISANMOI.TINHTRANG = CTTAISAN.TINHTRANG;
                            CTTAISANMOI.SUBID = CTTAISAN.SUBID;
                            CTTAISANMOI.MOTA = CTTAISAN.MOTA;
                            if (dalCTTAISAN.them(CTTAISANMOI))
                            {
                                //sửa số lượng tài sản cũ
                                CTTAISAN.SOLUONG = SOLUONGCONLAI;
                                if (dalCTTAISAN.sua(CTTAISAN))
                                {
                                    bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                    LOGTAISAN.PHONG = CTTAISAN.PHONG;
                                    LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển tài sản [{1}] với số lượng [{2}] từ phòng [{3}] sang phòng [{4}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, CTTAISAN.SOLUONG, CTTAISAN.PHONG.TENPHONG, PHONGMOI.TENPHONG);
                                    dalLOGTAISAN.them(LOGTAISAN);
                                    MessageBox.Show("Cập nhật chuyển phòng thành công");
                                    CAPNHAT = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật chuyển phòng!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi trong khi cập nhật chuyển phòng!");
                            }
                        }
                        break;
                    case "CHUYENTINHTRANG":
                        try
                        {
                            CTTAISAN.TINHTRANG = dalTINHTRANG.getbyid(Int32.Parse(comboBoxTinhTrang.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tình trạng trước");
                            return;
                        }

                        if (dalCTTAISAN.sua(CTTAISAN))
                        {
                            bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                            LOGTAISAN.PHONG = CTTAISAN.PHONG;
                            LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển tài sản [{1}] từ tình trạng [{2}] sang tình trạng [{3}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, TINHTRANGTSCU.VALUE, CTTAISAN.TINHTRANG.VALUE);
                            dalLOGTAISAN.them(LOGTAISAN);
                            MessageBox.Show("Cập nhật chuyển tình trạng tài sản thành công");
                            CAPNHAT = true;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong khi cập nhật chuyển!");
                        }
                        break;
                    case "THANHLY":
                        try
                        {
                            CTTAISAN.PHONG = dalPHONG.getbyid(Int32.Parse(comboBoxPhong.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm phòng trước");
                            return;
                        }

                        try
                        {
                            CTTAISAN.TINHTRANG = dalTINHTRANG.getbyid(Int32.Parse(comboBoxTinhTrang.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tình trạng trước");
                            return;
                        }

                        if (dalCTTAISAN.sua(CTTAISAN))
                        {
                            bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                            LOGTAISAN.PHONG = CTTAISAN.PHONG;
                            LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã thanh lý tài sản [{1}] của phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, PHONGCU.TENPHONG);
                            dalLOGTAISAN.them(LOGTAISAN);
                            MessageBox.Show("Thanh lý tài sản thành công");
                            CAPNHAT = true;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong khi thanh lý!");
                        }
                        break;
                }
            }
            catch { }
        }

    }
}
