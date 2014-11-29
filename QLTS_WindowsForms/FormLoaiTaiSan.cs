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
    public partial class FormLoaiTaiSan : Form
    {
        public bizLOAITAISAN LOAITAISAN = new bizLOAITAISAN();
        public List<bizLOAITAISAN> listLOAITAISAN = new List<bizLOAITAISAN>();
        public string TinhTrang = "";
        public int IDLOAITAISAN = 0;
        public FormLoaiTaiSan()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                listLOAITAISAN = dalLOAITAISAN.getall();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = listLOAITAISAN;
                if (listLOAITAISAN.Count() < 1)
                {
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
                }
                else
                {
                    IDLOAITAISAN = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
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
                    if (dalLOAITAISAN.TAISANTrongLOAITAISAN(IDLOAITAISAN) > 0)
                    {
                        MessageBox.Show("Loại này đang có tài sản.");
                        return;
                    }
                    LOAITAISAN = dalLOAITAISAN.getbyid(IDLOAITAISAN);
                    if (dalLOAITAISAN.xoa(LOAITAISAN))
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
                MessageBox.Show("Chọn loại để xoá!");
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

                LOAITAISAN = dalLOAITAISAN.getbyid(IDLOAITAISAN);
                textBoxMa.Text = LOAITAISAN.SUBID;
                textBoxTen.Text = LOAITAISAN.TENLOAI;
                textBoxMoTa.Text = LOAITAISAN.MOTA;
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
                        LOAITAISAN = new bizLOAITAISAN();
                        LOAITAISAN.TENLOAI = textBoxTen.Text;
                        LOAITAISAN.SUBID = textBoxMa.Text;
                        LOAITAISAN.MOTA = textBoxMoTa.Text;
                        if (dalLOAITAISAN.them(LOAITAISAN))
                        {
                            MessageBox.Show("Thêm thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
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
                        LOAITAISAN = dalLOAITAISAN.getbyid(IDLOAITAISAN);
                        LOAITAISAN.TENLOAI = textBoxTen.Text;
                        LOAITAISAN.SUBID = textBoxMa.Text;
                        LOAITAISAN.MOTA = textBoxMoTa.Text;
                        if (dalLOAITAISAN.sua(LOAITAISAN))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
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
                IDLOAITAISAN = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }
    }
}
