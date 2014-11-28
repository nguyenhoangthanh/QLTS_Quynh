using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizDIADIEM
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private bizCOSO _COSO;
        public bizCOSO COSO
        {
            get { return _COSO; }
            set { _COSO = value; }
        }

        private bizKHU _KHU;
        public bizKHU KHU
        {
            get { return _KHU; }
            set { _KHU = value; }
        }

        private bizTANG _TANG;
        public bizTANG TANG
        {
            get { return _TANG; }
            set { _TANG = value; }
        }

        private string _SUBID;
        public string SUBID
        {
            get { return _SUBID; }
            set { _SUBID = value; }
        }

        private string _MOTA;
        public string MOTA
        {
            get { return _MOTA; }
            set { _MOTA = value; }
        }

        private DateTime _NGAYTAO;
        public DateTime NGAYTAO
        {
            get { return _NGAYTAO; }
            set { _NGAYTAO = value; }
        }

        private DateTime _NGAYSUA;
        public DateTime NGAYSUA
        {
            get { return _NGAYSUA; }
            set { _NGAYSUA = value; }
        }

        public bizDIADIEM()
        {
            _ID = 0;
            _COSO = null;
            _KHU = null;
            _TANG = null;
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizDIADIEM(int ID, bizCOSO COSO,bizKHU KHU, bizTANG TANG, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _COSO = COSO;
            _KHU = KHU;
            _TANG = TANG;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
