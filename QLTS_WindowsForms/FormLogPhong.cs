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
    public partial class FormLogPhong : Form
    {
        public FormLogPhong()
        {
            InitializeComponent();
            DanhSachPhong();
        }
        private void DanhSachPhong()
        {
            List<bizPHONG> ListPhong = dalPHONG.getall();
            comboBoxPhong.DataSource = ListPhong;
            comboBoxPhong.DisplayMember = "TENPHONG";
            comboBoxPhong.ValueMember = "ID";
        }
        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime TuNgay = dateTimePickerTuNgay.Value;
                DateTime DenNgay = dateTimePickerDenNgay.Value;
                if (TuNgay > DenNgay)
                {
                    MessageBox.Show("Thời gian không hợp lệ");
                    return;
                }
                try
                {
                    int IDPHONG = Convert.ToInt32(comboBoxPhong.SelectedValue);
                    bizPHONG PHONG = dalPHONG.getbyid(IDPHONG);
                    List<bizLOGTAISAN> ListLOGTAISAN = dalLOGTAISAN.thongke(TuNgay, DenNgay, PHONG);
                    if (ListLOGTAISAN != null && ListLOGTAISAN.Count > 0)
                    {
                        dataGridView.AutoGenerateColumns = false;
                        dataGridView.DataSource = ListLOGTAISAN;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào đúng theo điều kiện. Vui lòng thử lại");
                        dataGridView.AutoGenerateColumns = false;
                        dataGridView.DataSource = null;
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn phòng cần thống kê");
                }

            }
            catch { }
        }
    }
}
