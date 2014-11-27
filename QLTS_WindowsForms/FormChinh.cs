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
    }
}
