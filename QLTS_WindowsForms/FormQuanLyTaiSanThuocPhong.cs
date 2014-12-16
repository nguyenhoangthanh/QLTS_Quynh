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
        bizTAISAN TAISANCU;
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
                    TAISANCU = CTTAISAN.TAISAN;
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
                bizPHONG PHONGMOI;
                bizTAISAN TAISANMOI;
                bizTINHTRANG TINHTRANGMOI;
                int SOLUONGMOI;
                bizCTTAISAN CTTAISAN_TEMP;
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

                        CTTAISAN_TEMP = dalCTTAISAN.KiemTra(CTTAISAN.PHONG, CTTAISAN.TAISAN, CTTAISAN.TINHTRANG);
                        if (CTTAISAN_TEMP != null)
                        {
                            CTTAISAN_TEMP.SOLUONG += CTTAISAN.SOLUONG;
                            if (dalCTTAISAN.sua(CTTAISAN_TEMP))
                            {
                                bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                LOGTAISAN.PHONG = CTTAISAN_TEMP.PHONG;
                                LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển thành công tài sản [{1}] vào phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN_TEMP.TAISAN.TENTAISAN, CTTAISAN_TEMP.PHONG.TENPHONG);
                                dalLOGTAISAN.them(LOGTAISAN);
                                MessageBox.Show("Chuyển tài sản vào phòng thành công");
                                CAPNHAT = true;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi trong khi chuyển!");
                            }
                        }
                        else
                        {
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
                        }
                        break;
                    case "SUA":
                        try
                        {
                            TAISANMOI = dalTAISAN.getbyid(Int32.Parse(comboBoxTaiSan.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tài sản trước");
                            return;
                        }

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

                        CTTAISAN.NGAY = dateTimePickerNgayNhap.Value;

                        try
                        {
                            TINHTRANGMOI = dalTINHTRANG.getbyid(Int32.Parse(comboBoxTinhTrang.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tình trạng trước");
                            return;
                        }

                        CTTAISAN.MOTA = textBoxMoTa.Text;

                        CTTAISAN_TEMP = dalCTTAISAN.KiemTra(CTTAISAN.PHONG, TAISANMOI, TINHTRANGMOI, CTTAISAN.ID);
                        if (SOLUONGMOI == SOLUONGCU)
                        {
                            if (CTTAISAN_TEMP == null)
                            {
                                CTTAISAN.TINHTRANG = TINHTRANGMOI;
                                CTTAISAN.TAISAN = TAISANMOI;
                                if (dalCTTAISAN.sua(CTTAISAN))
                                {
                                    bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                    LOGTAISAN.PHONG = CTTAISAN.PHONG;
                                    LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã cập nhật tài sản [{1}] của phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, TAISANCU.TENTAISAN, PHONGCU.TENPHONG);
                                    dalLOGTAISAN.them(LOGTAISAN);
                                    MessageBox.Show("Cập nhật tài sản thành công");
                                    CAPNHAT = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật tài sản!");
                                }
                            }
                            else
                            {
                                CTTAISAN_TEMP.SOLUONG += SOLUONGMOI;
                                if (dalCTTAISAN.sua(CTTAISAN_TEMP))
                                {
                                    bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                    LOGTAISAN.PHONG = CTTAISAN_TEMP.PHONG;
                                    LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã cập nhật tài sản [{1}] của phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, TAISANCU.TENTAISAN, PHONGCU.TENPHONG);
                                    dalLOGTAISAN.them(LOGTAISAN);
                                    dalCTTAISAN.xoa(CTTAISAN);
                                    MessageBox.Show("Cập nhật tài sản thành công");
                                    CAPNHAT = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật tài sản!");
                                }
                            }
                        }
                        else
                        {
                            int SOLUONGCONLAI = SOLUONGCU - SOLUONGMOI;
                            if (CTTAISAN_TEMP == null)
                            {
                                CTTAISAN.SOLUONG = SOLUONGMOI;
                                CTTAISAN.TAISAN = TAISANMOI;
                                CTTAISAN.TINHTRANG = TINHTRANGMOI;
                                if (dalCTTAISAN.sua(CTTAISAN))
                                {
                                    bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                    LOGTAISAN.PHONG = CTTAISAN.PHONG;
                                    LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã cập nhật tài sản [{1}] của phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, TAISANCU.TENTAISAN, PHONGCU.TENPHONG);
                                    dalLOGTAISAN.them(LOGTAISAN);
                                    MessageBox.Show("Cập nhật tài sản thành công");
                                    CAPNHAT = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật tài sản!");
                                }
                            }
                            else
                            {
                                CTTAISAN_TEMP.SOLUONG += SOLUONGMOI;
                                if (dalCTTAISAN.sua(CTTAISAN_TEMP))
                                {
                                    CTTAISAN.SOLUONG = SOLUONGCONLAI;
                                    if (dalCTTAISAN.sua(CTTAISAN))
                                    {
                                        bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                        LOGTAISAN.PHONG = CTTAISAN_TEMP.PHONG;
                                        LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã cập nhật tài sản [{1}] của phòng [{2}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, TAISANCU.TENTAISAN, PHONGCU.TENPHONG);
                                        dalLOGTAISAN.them(LOGTAISAN);
                                        dalCTTAISAN.xoa(CTTAISAN);
                                        MessageBox.Show("Cập nhật tài sản thành công");
                                        CAPNHAT = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Có lỗi trong khi cập nhật tài sản!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật tài sản!");
                                }
                            }
                        }
                        break;
                    case "CHUYENTAISAN":
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
                        try
                        {
                            PHONGMOI = dalPHONG.getbyid(Int32.Parse(comboBoxPhong.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm phòng trước");
                            return;
                        }

                        if (Object.Equals(CTTAISAN.PHONG.ID, PHONGMOI.ID))
                        {
                            MessageBox.Show("Vui lòng chọn phòng mới");
                            return;
                        }

                        CTTAISAN_TEMP = dalCTTAISAN.KiemTra(PHONGMOI, CTTAISAN.TAISAN, CTTAISAN.TINHTRANG);
                        if (SOLUONGMOI == SOLUONGCU)
                        {
                            if (CTTAISAN_TEMP == null)
                            {
                                CTTAISAN.PHONG = PHONGMOI;
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
                                CTTAISAN_TEMP.SOLUONG += SOLUONGMOI;
                                if (dalCTTAISAN.sua(CTTAISAN_TEMP))
                                {
                                    bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                    LOGTAISAN.PHONG = CTTAISAN_TEMP.PHONG;
                                    LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển tài sản [{1}] với số lượng [{2}] từ phòng [{3}] sang phòng [{4}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN_TEMP.TAISAN.TENTAISAN, CTTAISAN_TEMP.SOLUONG, CTTAISAN.PHONG.TENPHONG, CTTAISAN_TEMP.PHONG.TENPHONG);
                                    dalLOGTAISAN.them(LOGTAISAN);
                                    dalCTTAISAN.xoa(CTTAISAN);
                                    MessageBox.Show("Cập nhật chuyển phòng thành công");
                                    CAPNHAT = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật chuyển phòng!");
                                }
                            }
                        }
                        else
                        {
                            int SOLUONGCONLAI = SOLUONGCU - SOLUONGMOI;
                            if (CTTAISAN_TEMP == null)
                            {
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
                                    CTTAISAN.SOLUONG = SOLUONGCONLAI;
                                    if (dalCTTAISAN.sua(CTTAISAN))
                                    {
                                        bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                        LOGTAISAN.PHONG = CTTAISAN.PHONG;
                                        LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển tài sản [{1}] với số lượng [{2}] từ phòng [{3}] sang phòng [{4}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, SOLUONGMOI, CTTAISAN.PHONG.TENPHONG, PHONGMOI.TENPHONG);
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
                            else
                            {
                                CTTAISAN_TEMP.SOLUONG += SOLUONGMOI;
                                if (dalCTTAISAN.sua(CTTAISAN_TEMP))
                                {
                                    CTTAISAN.SOLUONG = SOLUONGCONLAI;
                                    if (dalCTTAISAN.sua(CTTAISAN))
                                    {
                                        bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                        LOGTAISAN.PHONG = CTTAISAN.PHONG;
                                        LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển tài sản [{1}] với số lượng [{2}] từ phòng [{3}] sang phòng [{4}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, SOLUONGMOI, CTTAISAN.PHONG.TENPHONG, PHONGMOI.TENPHONG);
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
                        }
                        break;
                    case "CHUYENTINHTRANG":
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
                        try
                        {
                            TINHTRANGMOI = dalTINHTRANG.getbyid(Int32.Parse(comboBoxTinhTrang.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm tình trạng trước");
                            return;
                        }

                        if (TINHTRANGMOI.ID == CTTAISAN.TINHTRANG.ID)
                        {
                            MessageBox.Show("Chọn tình trạng mới.");
                            return;
                        }

                        CTTAISAN_TEMP = dalCTTAISAN.KiemTra(CTTAISAN.PHONG, CTTAISAN.TAISAN, TINHTRANGMOI);
                        if (SOLUONGMOI == SOLUONGCU)
                        {
                            if (CTTAISAN_TEMP == null)
                            {
                                CTTAISAN.TINHTRANG = TINHTRANGMOI;
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
                            }
                            else
                            {
                                CTTAISAN_TEMP.SOLUONG += SOLUONGMOI;
                                if (dalCTTAISAN.sua(CTTAISAN_TEMP))
                                {
                                    bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                    LOGTAISAN.PHONG = CTTAISAN_TEMP.PHONG;
                                    LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển tài sản [{1}] từ tình trạng [{2}] sang tình trạng [{3}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN_TEMP.TAISAN.TENTAISAN, CTTAISAN_TEMP.TINHTRANG.VALUE, CTTAISAN.TINHTRANG.VALUE);
                                    dalLOGTAISAN.them(LOGTAISAN);
                                    dalCTTAISAN.xoa(CTTAISAN);
                                    MessageBox.Show("Cập nhật chuyển tình trạng tài sản thành công");
                                    CAPNHAT = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật chuyển!");
                                }
                            }
                        }
                        else
                        {
                            int SOLUONGCONLAI = SOLUONGCU - SOLUONGMOI;
                            if (CTTAISAN_TEMP == null)
                            {
                                bizCTTAISAN CTTAISANMOI = new bizCTTAISAN();
                                CTTAISANMOI.NGAY = CTTAISAN.NGAY;
                                CTTAISANMOI.SOLUONG = SOLUONGMOI;
                                CTTAISANMOI.PHONG = CTTAISAN.PHONG;
                                CTTAISANMOI.TAISAN = CTTAISAN.TAISAN;
                                CTTAISANMOI.TINHTRANG = TINHTRANGMOI;
                                CTTAISANMOI.SUBID = CTTAISAN.SUBID;
                                CTTAISANMOI.MOTA = CTTAISAN.MOTA;
                                if (dalCTTAISAN.them(CTTAISANMOI))
                                {
                                    CTTAISAN.SOLUONG = SOLUONGCONLAI;
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
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật chuyển phòng!");
                                }
                            }
                            else
                            {
                                CTTAISAN_TEMP.SOLUONG += SOLUONGMOI;
                                if (dalCTTAISAN.sua(CTTAISAN_TEMP))
                                {
                                    CTTAISAN.SOLUONG = SOLUONGCONLAI;
                                    if (dalCTTAISAN.sua(CTTAISAN))
                                    {
                                        bizLOGTAISAN LOGTAISAN = new bizLOGTAISAN();
                                        LOGTAISAN.PHONG = CTTAISAN.PHONG;
                                        LOGTAISAN.MOTA = String.Format("Quản trị viên [{0}] đã chuyển tài sản [{1}] từ tình trạng [{2}] sang tình trạng [{3}]", dalQUANTRIVIEN.getbyid(Properties.Settings.Default.IDQUANTRIVIEN).TENQTVIEN, CTTAISAN.TAISAN.TENTAISAN, CTTAISAN.TINHTRANG.VALUE, CTTAISAN_TEMP.TINHTRANG.VALUE);
                                        dalLOGTAISAN.them(LOGTAISAN);
                                        MessageBox.Show("Cập nhật chuyển tình trạng tài sản thành công");
                                        CAPNHAT = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Có lỗi trong khi cập nhật chuyển!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi trong khi cập nhật chuyển!");
                                }
                            }
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
