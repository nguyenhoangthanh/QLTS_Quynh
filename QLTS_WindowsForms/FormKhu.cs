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
    public partial class FormKhu : Form
    {
        bizKHU KHU = new bizKHU();
        List<bizKHU> ListKHU = new List<bizKHU>();
        List<bizCOSO> ListCOSO = new List<bizCOSO>();
        public string TinhTrang = "";
        public int IDKHU = 0;
        public FormKhu()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                ListKHU = dalKHU.getall();
                var ListKHUCustom = ListKHU.Select(item => new
                {
                    ID = item.ID,
                    SUBID = item.SUBID,
                    TEN = item.TEN,
                    TENCOSO = item.COSO.TENCOSO,
                    MOTA = item.MOTA,
                    NGAYTAO = item.NGAYTAO,
                    NGAYSUA = item.NGAYSUA
                }).ToList();

                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = ListKHUCustom;
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
                comboBox.DataSource = ListCOSO;
                comboBox.DisplayMember = "TENCOSO";
                comboBox.ValueMember = "MACOSO";
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
                    KHU = dalKHU.getbyid(IDKHU);
                    if (dalKHU.xoa(KHU))
                    {
                        MessageBox.Show("Xoá thành công");
                        LoadData();
                        IDKHU = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Xoá lỗi rồi!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chọn khu để xoá!");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {
                buttonOK.Text = "Cập nhật";
                panel.Visible = true;
                TinhTrang = "SUA";
                buttonSua.Enabled = false;

                KHU = dalKHU.getbyid(IDKHU);
                textBoxMa.Text = KHU.SUBID;
                textBoxTen.Text = KHU.TEN;
                ListCOSO = dalCOSO.getall();
                comboBox.DataSource = ListCOSO;
                comboBox.DisplayMember = "TENCOSO";
                comboBox.ValueMember = "MACOSO";
                comboBox.SelectedValue = KHU.COSO.MACOSO;
                textBoxMoTa.Text = KHU.MOTA;
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
                        KHU = new bizKHU();
                        KHU.TEN = textBoxTen.Text;
                        KHU.SUBID = textBoxMa.Text;
                        int IDCOSO = Convert.ToInt32(comboBox.SelectedValue.ToString());
                        KHU.COSO = dalCOSO.getbyid(IDCOSO);
                        KHU.MOTA = textBoxMoTa.Text;
                        if (dalKHU.them(KHU))
                        {
                            MessageBox.Show("Thêm thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
                            comboBox.SelectedIndex = 0;
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
                        KHU = dalKHU.getbyid(IDKHU);
                        KHU.TEN = textBoxTen.Text;
                        KHU.SUBID = textBoxMa.Text;
                        KHU.COSO.MACOSO = Convert.ToInt32(comboBox.SelectedValue);
                        KHU.MOTA = textBoxMoTa.Text;
                        if (dalKHU.sua(KHU))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
                            comboBox.SelectedIndex = 0;
                            LoadData();
                            IDKHU = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
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
                comboBox.SelectedIndex = 0;
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
                IDKHU = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }
    }
}
