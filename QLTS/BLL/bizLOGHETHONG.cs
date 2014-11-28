using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizLOGHETHONG
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
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

        public bizLOGHETHONG()
        {
            _ID = 0;
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizLOGHETHONG(int ID, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
