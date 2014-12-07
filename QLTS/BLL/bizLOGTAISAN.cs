using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizLOGTAISAN
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private bizPHONG _PHONG;
        public bizPHONG PHONG
        {
            get { return _PHONG; }
            set { _PHONG = value; }
        }

        private DateTime _NGAYTAO;
        public DateTime NGAYTAO
        {
            get { return _NGAYTAO; }
            set { _NGAYTAO = value; }
        }

        private string _MOTA;
        public string MOTA
        {
            get { return _MOTA; }
            set { _MOTA = value; }
        }

        public bizLOGTAISAN()
        {
            _ID = 0;
            _PHONG = null;
            _NGAYTAO = DateTime.Now;
            _MOTA = "";
        }

        public bizLOGTAISAN(int ID, bizPHONG PHONG, DateTime NGAYTAO, string MOTA)
        {
            _ID = ID;
            _PHONG = PHONG;
            _NGAYTAO = NGAYTAO;
            _MOTA = MOTA;
        }
    }
}
