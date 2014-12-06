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
    public partial class FormPhong : Form
    {
        bizPHONG PHONG = new bizPHONG();
        List<bizPHONG> ListPHONG = new List<bizPHONG>();
        List<bizTANG> ListTANG = new List<bizTANG>();
        List<bizKHU> ListKHU = new List<bizKHU>();
        List<bizCOSO> ListCOSO = new List<bizCOSO>();
        public string TinhTrang = "";
        public bool SUACOSOLANDAU = false;
        public bool SUAKHULANDAU = false;
        public int IDPHONG = 0;
        public FormPhong()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                ListPHONG = dalPHONG.getall();
                var ListPHONGCustom = ListPHONG.Select(item => new
                {
                    ID = item.ID,
                    SUBID = item.SUBID ?? "",
                    TENPHONG = item.TENPHONG ?? "",
                    TENTANG = item.DIADIEM.TANG == null ? "" : item.DIADIEM.TANG.TENTANG,
                    TENKHU = item.DIADIEM.KHU == null ? "" : item.DIADIEM.KHU.TEN,
                    TENCOSO = item.DIADIEM.COSO == null ? "" : item.DIADIEM.COSO.TENCOSO,
                    TENNHANVIEN = item.NHANVIEN == null ? "" : item.NHANVIEN.HOTEN,
                    MOTA = item.MOTA ?? "",
                    NGAYTAO = item.NGAYTAO,
                    NGAYSUA = item.NGAYSUA
                }).ToList();

                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = ListPHONGCustom;
                if (ListPHONGCustom.Count() < 1)
                {
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
                }
                else
                {
                    IDPHONG = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
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
                CheckRadioButton();
                buttonOK.Text = "Thêm";
                panel.Visible = true;
                TinhTrang = "THEM";
                buttonThem.Enabled = false;
                ListCOSO = dalCOSO.getall();
                if (ListCOSO != null && ListCOSO.Count > 0)
                {
                    comboBoxCoSo.DataSource = ListCOSO;
                    comboBoxCoSo.DisplayMember = "TENCOSO";
                    comboBoxCoSo.ValueMember = "ID";
                    comboBoxCoSo.Enabled = true;
                }
                else
                {
                    comboBoxCoSo.Enabled = false;
                    comboBoxCoSo.Text = "Chưa có cơ sở";
                }

                List<bizNHANVIEN> ListNhanVien = dalNHANVIEN.getall();
                if (ListNhanVien != null && ListNhanVien.Count > 0)
                {
                    comboBoxNhanVien.DataSource = ListNhanVien;
                    comboBoxNhanVien.DisplayMember = "HOTEN";
                    comboBoxNhanVien.ValueMember = "ID";
                    comboBoxNhanVien.Enabled = true;
                }
                else
                {
                    comboBoxNhanVien.Enabled = false;
                    comboBoxNhanVien.Text = "Chưa có nhân viên";
                }
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
                    if (dalPHONG.TAISANTrongPHONG(IDPHONG) > 0)
                    {
                        MessageBox.Show("Phòng đang chứa tài sản.");
                        return;
                    }
                    PHONG = dalPHONG.getbyid(IDPHONG);
                    if (dalPHONG.xoa(PHONG))
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
                MessageBox.Show("Chọn phòng để xoá!");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {
                CheckRadioButton();
                buttonThem.Enabled = true;
                buttonOK.Text = "Cập nhật";
                panel.Visible = true;
                TinhTrang = "SUA";
                buttonSua.Enabled = false;
                PHONG = dalPHONG.getbyid(IDPHONG);
                textBoxMa.Text = PHONG.SUBID;
                textBoxTen.Text = PHONG.TENPHONG;
                ListCOSO = dalCOSO.getall();
                if (ListCOSO != null && ListCOSO.Count > 0)
                {
                    comboBoxCoSo.DataSource = ListCOSO;
                    comboBoxCoSo.DisplayMember = "TENCOSO";
                    comboBoxCoSo.ValueMember = "ID";
                    comboBoxCoSo.Enabled = true;
                    SUACOSOLANDAU = true;
                    comboBoxCoSo.SelectedValue = PHONG.DIADIEM.COSO.ID;
                    if (PHONG.DIADIEM.KHU != null && PHONG.DIADIEM.TANG != null)
                    {
                        radioButtonTang.Select();
                        ListKHU = dalKHU.getall().Where(c => c.COSO.ID == PHONG.DIADIEM.COSO.ID).ToList();
                        if (ListKHU != null && ListKHU.Count > 0)
                        {
                            comboBoxKhu.DataSource = ListKHU;
                            comboBoxKhu.DisplayMember = "TEN";
                            comboBoxKhu.ValueMember = "ID";
                            comboBoxKhu.Enabled = true;
                            SUAKHULANDAU = true;
                            comboBoxKhu.SelectedValue = PHONG.DIADIEM.KHU.ID;
                        }

                        ListTANG = dalTANG.getall().Where(c => c.KHU.ID == PHONG.DIADIEM.KHU.ID).ToList();
                        if (ListTANG != null && ListTANG.Count > 0)
                        {
                            comboBoxTang.DataSource = ListTANG;
                            comboBoxTang.DisplayMember = "TENTANG";
                            comboBoxTang.ValueMember = "ID";
                            comboBoxTang.Enabled = true;
                            comboBoxTang.SelectedValue = PHONG.DIADIEM.TANG.ID;
                        }
                    }
                    else
                    {
                        radioButtonCoSo.Select();
                    }
                }
                else
                {
                    comboBoxCoSo.Enabled = false;
                    comboBoxCoSo.Text = "Chưa có cơ sở";
                }

                List<bizNHANVIEN> ListNhanVien = dalNHANVIEN.getall();
                if (ListNhanVien != null && ListNhanVien.Count > 0)
                {
                    comboBoxNhanVien.DataSource = ListNhanVien;
                    comboBoxNhanVien.DisplayMember = "HOTEN";
                    comboBoxNhanVien.ValueMember = "ID";
                    comboBoxNhanVien.Enabled = true;
                    comboBoxNhanVien.SelectedValue = PHONG.NHANVIEN.ID;
                }
                else
                {
                    comboBoxNhanVien.Enabled = false;
                    comboBoxNhanVien.Text = "Chưa có nhân viên";
                }
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
                        PHONG = new bizPHONG();
                        PHONG.TENPHONG = textBoxTen.Text;
                        PHONG.SUBID = textBoxMa.Text;
                        bizDIADIEM DIADIEM = new bizDIADIEM();
                        try
                        {
                            DIADIEM.COSO = dalCOSO.getbyid(Convert.ToInt32(comboBoxCoSo.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm cơ sở trước");
                        }
                        if (radioButtonTang.Checked == true)
                        {
                            try
                            {
                                DIADIEM.KHU = dalKHU.getbyid(Convert.ToInt32(comboBoxKhu.SelectedValue.ToString()));
                            }
                            catch
                            {
                                MessageBox.Show("Thêm khu trước");
                            }
                            try
                            {
                                DIADIEM.TANG = dalTANG.getbyid(Convert.ToInt32(comboBoxTang.SelectedValue.ToString()));
                            }
                            catch
                            {
                                MessageBox.Show("Thêm tầng trước");
                            }
                        }
                        PHONG.DIADIEM = DIADIEM;
                        PHONG.MOTA = textBoxMoTa.Text ?? "";
                        try
                        {
                            PHONG.NHANVIEN = dalNHANVIEN.getbyid(Convert.ToInt32(comboBoxNhanVien.SelectedValue.ToString()));
                        }
                        catch
                        {

                        }
                        if (dalPHONG.them(PHONG))
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
                    if (!textBoxTen.Text.Trim().Equals(""))
                    {
                        PHONG = dalPHONG.getbyid(IDPHONG);
                        PHONG.TENPHONG = textBoxTen.Text;
                        PHONG.SUBID = textBoxMa.Text;
                        try
                        {
                            PHONG.DIADIEM.COSO = dalCOSO.getbyid(Convert.ToInt32(comboBoxCoSo.SelectedValue.ToString()));
                        }
                        catch
                        {
                            MessageBox.Show("Thêm cơ sở trước");
                            return;
                        }
                        if (radioButtonTang.Checked == true)
                        {
                            try
                            {
                                PHONG.DIADIEM.KHU = dalKHU.getbyid(Convert.ToInt32(comboBoxKhu.SelectedValue.ToString()));
                            }
                            catch
                            {
                                MessageBox.Show("Thêm khu trước");
                                return;
                            }
                            try
                            {
                                PHONG.DIADIEM.TANG = dalTANG.getbyid(Convert.ToInt32(comboBoxTang.SelectedValue.ToString()));
                            }
                            catch
                            {
                                MessageBox.Show("Thêm tầng trước");
                                return;
                            }
                        }
                        else
                        {
                            PHONG.DIADIEM.KHU = null;
                            PHONG.DIADIEM.TANG = null;
                        }
                        PHONG.MOTA = textBoxMoTa.Text ?? "";
                        try
                        {
                            PHONG.NHANVIEN = dalNHANVIEN.getbyid(Convert.ToInt32(comboBoxNhanVien.SelectedValue.ToString()));
                        }
                        catch
                        {
                            
                        }
                        if (dalPHONG.sua(PHONG))
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
                textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
                comboBoxCoSo.SelectedIndex = 0;
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
                IDPHONG = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }

        private void comboBoxCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SUACOSOLANDAU == true)
                {
                    SUACOSOLANDAU = false;
                    return;
                }
                if (comboBoxCoSo.SelectedValue != null && radioButtonTang.Checked == true)
                {
                    int IDCOSO = Convert.ToInt32(comboBoxCoSo.SelectedValue.ToString());
                    ListKHU = dalKHU.getall().Where(c => c.COSO.ID == IDCOSO).ToList();
                    if (ListKHU != null && ListKHU.Count > 0)
                    {
                        comboBoxKhu.DataSource = ListKHU;
                        comboBoxKhu.DisplayMember = "TEN";
                        comboBoxKhu.ValueMember = "ID";
                        comboBoxKhu.Enabled = true;
                    }
                    else
                    {
                        comboBoxKhu.Enabled = false;
                        comboBoxKhu.DataSource = null;
                        comboBoxKhu.Text = "Chưa có khu";

                        comboBoxTang.Enabled = false;
                        comboBoxTang.DataSource = null;
                        comboBoxTang.Text = "Chưa có tầng";
                    }
                }
                else
                {
                    comboBoxKhu.Text = "";
                }
            }
            catch { }
        }
        private void comboBoxKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SUAKHULANDAU == true)
                {
                    SUAKHULANDAU = false;
                    return;
                }
                if (comboBoxKhu.SelectedValue != null && radioButtonTang.Checked == true)
                {
                    int IDKHU = Convert.ToInt32(comboBoxKhu.SelectedValue.ToString());
                    ListTANG = dalTANG.getall().Where(c => c.KHU.ID == IDKHU).ToList();
                    if (ListTANG != null && ListTANG.Count > 0)
                    {
                        comboBoxTang.DataSource = ListTANG;
                        comboBoxTang.DisplayMember = "TENTANG";
                        comboBoxTang.ValueMember = "ID";
                        comboBoxTang.Enabled = true;
                    }
                    else
                    {
                        comboBoxTang.Enabled = false;
                        comboBoxTang.DataSource = null;
                        comboBoxTang.Text = "Chưa có tầng";
                    }
                }
                else
                {
                    comboBoxTang.Text = "";
                }
            }
            catch { }
        }

        private void radioButtonCoSo_CheckedChanged(object sender, EventArgs e)
        {
            CheckRadioButton();
        }

        private void radioButtonTang_CheckedChanged(object sender, EventArgs e)
        {
            CheckRadioButton();
        }

        public void CheckRadioButton()
        {
            if (radioButtonCoSo.Checked == true)
            {
                comboBoxCoSo.Enabled = true;
                comboBoxKhu.Enabled = comboBoxTang.Enabled = false;
                comboBoxKhu.Text = "";
                comboBoxTang.Text = "";
            }
            else
            {
                try
                {
                    int IDCOSO = Convert.ToInt32(comboBoxCoSo.SelectedValue.ToString());
                    ListKHU = dalKHU.getall().Where(c => c.COSO.ID == IDCOSO).ToList();
                    if (ListKHU != null && ListKHU.Count > 0)
                    {
                        comboBoxKhu.DataSource = ListKHU;
                        comboBoxKhu.DisplayMember = "TEN";
                        comboBoxKhu.ValueMember = "ID";
                        comboBoxKhu.Enabled = true;

                        int IDKHU = Convert.ToInt32(comboBoxKhu.SelectedValue.ToString());
                        ListTANG = dalTANG.getall().Where(c => c.KHU.ID == IDKHU).ToList();
                        if (ListTANG != null && ListTANG.Count > 0)
                        {
                            comboBoxTang.DataSource = ListTANG;
                            comboBoxTang.DisplayMember = "TENTANG";
                            comboBoxTang.ValueMember = "ID";
                            comboBoxTang.Enabled = true;
                        }
                        else
                        {
                            comboBoxTang.Enabled = false;
                            comboBoxTang.DataSource = null;
                            comboBoxTang.Text = "Chưa có tầng";
                        }
                    }
                    else
                    {
                        comboBoxKhu.Enabled = false;
                        comboBoxKhu.DataSource = null;
                        comboBoxKhu.Text = "Chưa có khu";

                        comboBoxTang.Enabled = false;
                        comboBoxTang.DataSource = null;
                        comboBoxTang.Text = "Chưa có tầng";
                    }
                }
                catch
                {
                    comboBoxCoSo.Text = "Chưa có cơ sở";
                    comboBoxCoSo.Enabled = false;
                    comboBoxKhu.Text = "Chưa có khu";
                    comboBoxKhu.Enabled = false;
                    comboBoxTang.Text = "Chưa có tầng";
                    comboBoxTang.Enabled = false;
                }
            }
        }
    }
}
