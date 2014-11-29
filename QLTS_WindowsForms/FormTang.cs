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
    public partial class FormTang : Form
    {
        bizTANG TANG = new bizTANG();
        List<bizTANG> ListTANG = new List<bizTANG>();
        List<bizKHU> ListKHU = new List<bizKHU>();
        List<bizCOSO> ListCOSO = new List<bizCOSO>();
        public string TinhTrang = "";
        public int IDTANG = 0;
        public FormTang()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                ListTANG = dalTANG.getall();
                var ListTANGCustom = ListTANG.Select(item => new
                {
                    ID = item.ID,
                    SUBID = item.SUBID,
                    TENTANG = item.TENTANG,
                    TENKHU = item.KHU.TEN,
                    TENCOSO = item.KHU.COSO.TENCOSO,
                    MOTA = item.MOTA,
                    NGAYTAO = item.NGAYTAO,
                    NGAYSUA = item.NGAYSUA
                }).ToList();

                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = ListTANGCustom;
                if (ListTANGCustom.Count() < 1)
                {
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
                }
                else
                {
                    IDTANG = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
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
                ListCOSO = dalCOSO.getall();
                comboBoxCoSo.DataSource = ListCOSO;
                comboBoxCoSo.DisplayMember = "TENCOSO";
                comboBoxCoSo.ValueMember = "ID";
                int IDCOSO = Convert.ToInt32(comboBoxCoSo.SelectedValue.ToString());
                comboBoxKhu.DataSource = dalKHU.getall().Where(c=>c.COSO.ID==IDCOSO).ToList();
                comboBoxKhu.DisplayMember = "TEN";
                comboBoxKhu.ValueMember = "ID";
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
                    if (dalTANG.PHONGTrongTANG(IDTANG) > 0)
                    {
                        MessageBox.Show("Có phòng trong tầng. Xoá phòng trước.");
                        return;
                    }
                    TANG = dalTANG.getbyid(IDTANG);
                    if (dalTANG.xoa(TANG))
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
                MessageBox.Show("Chọn tầng để xoá!");
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

                TANG = dalTANG.getbyid(IDTANG);
                textBoxMa.Text = TANG.SUBID;
                textBoxTen.Text = TANG.TENTANG;
                ListCOSO = dalCOSO.getall();
                comboBoxCoSo.DataSource = ListCOSO;
                comboBoxCoSo.DisplayMember = "TENCOSO";
                comboBoxCoSo.ValueMember = "ID";
                comboBoxCoSo.SelectedValue = TANG.KHU.COSO.ID;
                int IDCOSO = Convert.ToInt32(comboBoxCoSo.SelectedValue.ToString());
                comboBoxKhu.DataSource = dalKHU.getall().Where(c => c.COSO.ID == IDCOSO).ToList();
                comboBoxKhu.DisplayMember = "TEN";
                comboBoxKhu.ValueMember = "ID";
                comboBoxKhu.SelectedValue = TANG.KHU.ID;
                textBoxMoTa.Text = TANG.MOTA;
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
                        TANG = new bizTANG();
                        TANG.TENTANG = textBoxTen.Text;
                        TANG.SUBID = textBoxMa.Text;
                        int IDKHU = Convert.ToInt32(comboBoxKhu.SelectedValue.ToString());
                        TANG.KHU = dalKHU.getbyid(IDKHU);
                        TANG.MOTA = textBoxMoTa.Text;
                        if (dalTANG.them(TANG))
                        {
                            MessageBox.Show("Thêm thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
                            comboBoxCoSo.SelectedIndex = 0;
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
                        TANG = dalTANG.getbyid(IDTANG);
                        TANG.TENTANG = textBoxTen.Text;
                        TANG.SUBID = textBoxMa.Text;
                        TANG.KHU.ID = Convert.ToInt32(comboBoxKhu.SelectedValue);
                        TANG.MOTA = textBoxMoTa.Text;
                        if (dalTANG.sua(TANG))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
                            comboBoxCoSo.SelectedIndex = 0;
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
                IDTANG = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }

        private void comboBoxCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCoSo.SelectedValue != null)
                {
                    int IDCOSO = Convert.ToInt32(comboBoxCoSo.SelectedValue.ToString());
                    ListKHU = dalKHU.getall().Where(c => c.COSO.ID == IDCOSO).ToList();
                    comboBoxKhu.DataSource = ListKHU;
                    comboBoxKhu.DisplayMember = "TEN";
                    comboBoxKhu.ValueMember = "ID";
                }
            }
            catch { }
        }
    }
}
