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
    public partial class FormThemTaiSan : Form
    {
        bizPHONG PHONG;
        public FormThemTaiSan(bizPHONG _PHONG)
        {
            InitializeComponent();
            PHONG = _PHONG;
        }

        public void LoadData()
        {
            this.Text = groupBox.Text = "Thêm tài sản vào phòng " + PHONG.TENPHONG;
            List<bizTAISAN> ListTAISAN = dalTAISAN.getall();
        }
    }
}
