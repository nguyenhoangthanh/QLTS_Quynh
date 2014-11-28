using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizLOAITAISAN
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TENLOAI;
        public string TENLOAI
        {
            get { return _TENLOAI; }
            set { _TENLOAI = value; }
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

        public bizLOAITAISAN()
        {
            _ID = 0;
            _TENLOAI = "";
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizLOAITAISAN(int ID, string TENLOAI, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _TENLOAI = TENLOAI;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
