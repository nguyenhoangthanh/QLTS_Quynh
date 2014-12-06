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
        bizCTTAISAN CTTAISAN;
        string TINHTRANG = "";
        public FormQuanLyTaiSanThuocPhong(bizPHONG _PHONG, bizCTTAISAN _CTTAISAN, string _TINHTRANG)
        {
            try
            {
                InitializeComponent();
                PHONG = _PHONG;
                CTTAISAN = _CTTAISAN;
                TINHTRANG = _TINHTRANG;
                LoadData();
            }
            catch { }
        }

        public void LoadData()
        {
            try
            {
                if (TINHTRANG.Equals("THEM"))
                {
                    this.Text = groupBox.Text = "Chuyển tài sản vào phòng";

                    List<bizPHONG> ListPHONG = dalPHONG.getall();
                    comboBoxPhong.DataSource = ListPHONG;
                    comboBoxPhong.DisplayMember = "TENPHONG";
                    comboBoxPhong.ValueMember = "ID";

                    if (PHONG != null)
                    {
                        comboBoxPhong.SelectedValue = PHONG.ID;
                    }

                    List<bizTAISAN> ListTAISAN = dalTAISAN.getallTaiSanCoTheThemVaoPhong();
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
                    List<bizTINHTRANG> ListTINHTRANG = dalTINHTRANG.getall();
                    comboBoxTinhTrang.DataSource = ListTINHTRANG;
                    comboBoxTinhTrang.DisplayMember = "VALUE";
                    comboBoxTinhTrang.ValueMember = "ID";
                }
                else if (TINHTRANG.Equals("SUA"))
                {
                    this.Text = groupBox.Text = "Cập nhật chuyển tài sản vào phòng";

                    List<bizPHONG> ListPHONG = dalPHONG.getall();
                    comboBoxPhong.DataSource = ListPHONG;
                    comboBoxPhong.DisplayMember = "TENPHONG";
                    comboBoxPhong.ValueMember = "ID";

                    if (PHONG != null)
                    {
                        comboBoxPhong.SelectedValue = PHONG.ID;
                    }

                    List<bizTAISAN> ListTAISAN = dalTAISAN.getallTaiSanCoTheThemVaoPhong();
                    ListTAISAN.Add(CTTAISAN.TAISAN);
                    comboBoxTaiSan.DataSource = ListTAISAN;
                    comboBoxTaiSan.DisplayMember = "TENTAISAN";
                    comboBoxTaiSan.ValueMember = "ID";
                    comboBoxTaiSan.SelectedValue = CTTAISAN.TAISAN.ID;
                    textBoxSoLuong.Text = CTTAISAN.SOLUONG.ToString();
                    List<bizTINHTRANG> ListTINHTRANG = dalTINHTRANG.getall();
                    comboBoxTinhTrang.DataSource = ListTINHTRANG;
                    comboBoxTinhTrang.DisplayMember = "VALUE";
                    comboBoxTinhTrang.ValueMember = "ID";
                    comboBoxTinhTrang.SelectedValue = CTTAISAN.TINHTRANG.ID;
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
                if (TINHTRANG.Equals("THEM"))
                {
                    bizCTTAISAN CTTAISAN = new bizCTTAISAN();
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
                        MessageBox.Show("Chuyển tài sản vào phòng thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong khi chuyển!");
                    }
                }
                else if (TINHTRANG.Equals("SUA"))
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
                        MessageBox.Show("Cập nhật chuyển tài sản vào phòng thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong khi cập nhật chuyển!");
                    }
                }
            }
            catch { }
        }

    }
}
