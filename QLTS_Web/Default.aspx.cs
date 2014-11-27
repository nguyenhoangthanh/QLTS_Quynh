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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            List<bizCOSO> ListCOSO = new List<bizCOSO>();
            ListCOSO = dalCOSO.getall();

            GridView.DataSource = ListCOSO;
            GridView.DataBind();

        }
    }
}