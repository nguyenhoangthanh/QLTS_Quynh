using QLTS.BLL;
using QLTS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLTS_Web
{
    public partial class XemTaiSanTheoLoai : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                List<bizLOAITAISAN> ListLOAITAISAN = dalLOAITAISAN.getall();
                ListBox.DataSource = ListLOAITAISAN;
                ListBox.DataValueField = "ID";
                ListBox.DataTextField = "TENLOAI";
                ListBox.DataBind();
            }
            catch { }
        }

        protected void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IDLOAITAISAN = Int32.Parse(ListBox.SelectedValue.ToString());
                List<bizTAISAN> ListTAISAN = dalTAISAN.getall().Where(c => c.LOAITAISAN.ID == IDLOAITAISAN).ToList();
                GridView.DataSource = ListTAISAN;
                GridView.DataBind();
            }
            catch { }
        }
    }
}