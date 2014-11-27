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
    public partial class FormCoSo : Form
    {
        public bizCOSO COSO = new bizCOSO();
        public List<bizCOSO> listCOSO = new List<bizCOSO>();
        public string TinhTrang = "";
        public int IDCOSO = 0;
        public FormCoSo()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                listCOSO = dalCOSO.getall();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = listCOSO;
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
                if (MessageBox.Show("Bạn muốn xoá?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    COSO = dalCOSO.getbyid(IDCOSO);
                    if (dalCOSO.xoa(COSO))
                    {
                        MessageBox.Show("Xoá thành công");
                        LoadData();
                        IDCOSO = Int32.Parse(dataGridView.Rows[0].Cells["MACOSO"].Value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Xoá lỗi rồi!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chọn cơ sở để xoá!");
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

                COSO = dalCOSO.getbyid(IDCOSO);
                textBoxMa.Text = COSO.SUBID;
                textBoxTen.Text = COSO.TENCOSO;
                textBoxDiaChi.Text = COSO.DIACHI;
                textBoxMoTa.Text = COSO.MOTA;
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
                        COSO = new bizCOSO();
                        COSO.TENCOSO = textBoxTen.Text;
                        COSO.SUBID = textBoxMa.Text;
                        COSO.DIACHI = textBoxDiaChi.Text;
                        COSO.MOTA = textBoxMoTa.Text;
                        if (dalCOSO.them(COSO))
                        {
                            MessageBox.Show("Thêm thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxDiaChi.Text = textBoxMoTa.Text = "";
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
                        COSO = dalCOSO.getbyid(IDCOSO);
                        COSO.TENCOSO = textBoxTen.Text;
                        COSO.SUBID = textBoxMa.Text;
                        COSO.DIACHI = textBoxDiaChi.Text;
                        COSO.MOTA = textBoxMoTa.Text;
                        if (dalCOSO.sua(COSO))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxDiaChi.Text = textBoxMoTa.Text = "";
                            LoadData();
                            IDCOSO = Int32.Parse(dataGridView.Rows[0].Cells["MACOSO"].Value.ToString());
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
                textBoxMa.Text = textBoxTen.Text = textBoxDiaChi.Text = textBoxMoTa.Text = "";
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
                IDCOSO = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["MACOSO"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }
    }
}
