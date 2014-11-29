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
    public partial class FormTaiSan : Form
    {
        public bizTAISAN TAISAN = new bizTAISAN();
        public List<bizTAISAN> listTAISAN = new List<bizTAISAN>();
        public List<bizLOAITAISAN> listLOAITAISAN = new List<bizLOAITAISAN>();
        public string TinhTrang = "";
        public int IDTAISAN = 0;
        public FormTaiSan()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                listTAISAN = dalTAISAN.getall();
                var ListTAISANCustom = listTAISAN.Select(item => new
                {
                    ID = item.ID,
                    SUBID = item.SUBID,
                    TENTAISAN = item.TENTAISAN,
                    NGAYMUA = item.NGAYMUA,
                    TENLOAI = item.LOAITAISAN.TENLOAI,
                    MOTA = item.MOTA,
                    NGAYTAO = item.NGAYTAO,
                    NGAYSUA = item.NGAYSUA
                }).ToList();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = ListTAISANCustom;

                if (listTAISAN.Count() < 1)
                {
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
                }
                else
                {
                    IDTAISAN = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
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
                listLOAITAISAN = dalLOAITAISAN.getall();
                comboBox.DataSource = listLOAITAISAN;
                comboBox.DisplayMember = "TENLOAI";
                comboBox.ValueMember = "ID";
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
                    if (dalTAISAN.TAISANDangSuDungChoPHONG(IDTAISAN) > 0)
                    {
                        MessageBox.Show("Tài sản này đang thuộc phòng.");
                        return;
                    }
                    TAISAN = dalTAISAN.getbyid(IDTAISAN);
                    if (dalTAISAN.xoa(TAISAN))
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
                MessageBox.Show("Chọn tài sản để xoá!");
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

                TAISAN = dalTAISAN.getbyid(IDTAISAN);
                textBoxMa.Text = TAISAN.SUBID;
                textBoxTen.Text = TAISAN.TENTAISAN;
                dateTimePicker.Value = (DateTime)TAISAN.NGAYMUA;
                listLOAITAISAN = dalLOAITAISAN.getall();
                comboBox.DataSource = listLOAITAISAN;
                comboBox.DisplayMember = "TENLOAI";
                comboBox.ValueMember = "ID";
                comboBox.SelectedValue = TAISAN.LOAITAISAN.ID;
                textBoxMoTa.Text = TAISAN.MOTA;
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
                        try
                        {
                            TAISAN = new bizTAISAN();
                            TAISAN.TENTAISAN = textBoxTen.Text;
                            TAISAN.SUBID = textBoxMa.Text;
                            TAISAN.NGAYMUA = dateTimePicker.Value;
                            bizLOAITAISAN LOAITAISAN = dalLOAITAISAN.getbyid(Convert.ToInt32(comboBox.SelectedValue.ToString()));
                            TAISAN.LOAITAISAN = LOAITAISAN;
                            TAISAN.MOTA = textBoxMoTa.Text;
                            if (dalTAISAN.them(TAISAN))
                            {
                                MessageBox.Show("Thêm thành công");
                                textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
                                dateTimePicker.ResetText();                                
                                LoadData();
								buttonHuyBo.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Thêm lỗi rồi!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Có lỗi trong khi thêm.");
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
                        TAISAN = dalTAISAN.getbyid(IDTAISAN);
                        TAISAN.TENTAISAN = textBoxTen.Text;
                        TAISAN.SUBID = textBoxMa.Text;
                        TAISAN.NGAYMUA = dateTimePicker.Value;
                        bizLOAITAISAN LOAITAISAN = dalLOAITAISAN.getbyid(Convert.ToInt32(comboBox.SelectedValue.ToString()));
                        TAISAN.LOAITAISAN = LOAITAISAN;
                        TAISAN.MOTA = textBoxMoTa.Text;
                        if (dalTAISAN.sua(TAISAN))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            textBoxMa.Text = textBoxTen.Text = textBoxMoTa.Text = "";
                            dateTimePicker.ResetText();                            
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
                dateTimePicker.ResetText();                
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
                IDTAISAN = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }
    }
}
