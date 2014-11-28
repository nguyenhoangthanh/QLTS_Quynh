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
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
        }

        private void buttonCOSO_Click(object sender, EventArgs e)
        {
            FormCoSo frm = new FormCoSo();
            frm.Show();            
        }

        private void buttonKHU_Click(object sender, EventArgs e)
        {
            FormKhu frm = new FormKhu();
            frm.Show();
        }

        private void buttonLOAITAISAN_Click(object sender, EventArgs e)
        {
            FormLoaiTaiSan frm = new FormLoaiTaiSan();
            frm.Show();
        }

        private void buttonTinhTrang_Click(object sender, EventArgs e)
        {
            FormTinhTrang frm = new FormTinhTrang();
            frm.Show();
        }

        private void buttonTAISAN_Click(object sender, EventArgs e)
        {
            FormTaiSan frm = new FormTaiSan();
            frm.Show();
        }

        private void buttonNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien frm = new FormNhanVien();
            frm.Show();
        }
    }
}
