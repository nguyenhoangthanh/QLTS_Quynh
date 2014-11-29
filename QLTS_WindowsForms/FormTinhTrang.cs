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
    public partial class FormTinhTrang : Form
    {
        public bizTINHTRANG TINHTRANG = new bizTINHTRANG();
        public List<bizTINHTRANG> listTINHTRANG = new List<bizTINHTRANG>();
        public string TinhTrang = "";
        public int IDTINHTRANG = 0;
        public FormTinhTrang()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                listTINHTRANG = dalTINHTRANG.getall();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = listTINHTRANG;
                if (listTINHTRANG.Count() < 1)
                {
                    buttonXoa.Enabled = false;
                    buttonSua.Enabled = false;
                }
                else
                {
                    IDTINHTRANG = Int32.Parse(dataGridView.Rows[0].Cells["ID"].Value.ToString());
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
                    if (dalTINHTRANG.TINHTRANGDangSuDungChoTAISAN(IDTINHTRANG) > 0)
                    {
                        MessageBox.Show("Tình trạng này đang được sử dụng.");
                        return;
                    }
                    TINHTRANG = dalTINHTRANG.getbyid(IDTINHTRANG);
                    if (dalTINHTRANG.xoa(TINHTRANG))
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
                MessageBox.Show("Chọn tình trạng để xoá!");
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
                TINHTRANG = dalTINHTRANG.getbyid(IDTINHTRANG);
                textBoxTen.Text = TINHTRANG.VALUE;
                textBoxMoTa.Text = TINHTRANG.MOTA;
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
                        bizTINHTRANG biz = dalTINHTRANG.getbyvalue(textBoxTen.Text.Trim());
                        if (biz != null)
                        {
                            MessageBox.Show("Trạng thái đã tồn tại");
                            return;
                        }
                        TINHTRANG = new bizTINHTRANG();
                        TINHTRANG.VALUE = textBoxTen.Text;
                        TINHTRANG.KEY = helpper.KEY(TINHTRANG.VALUE);
                        TINHTRANG.MOTA = textBoxMoTa.Text;
                        if (dalTINHTRANG.them(TINHTRANG))
                        {
                            MessageBox.Show("Thêm thành công");
                            textBoxTen.Text = textBoxMoTa.Text = "";
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
                        TINHTRANG = dalTINHTRANG.getbyid(IDTINHTRANG);
                        TINHTRANG.VALUE = textBoxTen.Text;
                        TINHTRANG.MOTA = textBoxMoTa.Text;
                        if (dalTINHTRANG.sua(TINHTRANG))
                        {
                            MessageBox.Show("Cập nhật thành công");
                            textBoxTen.Text = textBoxMoTa.Text = "";
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
                textBoxTen.Text = textBoxMoTa.Text = "";
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
                IDTINHTRANG = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                buttonXoa.Enabled = true;
                buttonSua.Enabled = true;
            }
            catch { }
        }
    }
}
