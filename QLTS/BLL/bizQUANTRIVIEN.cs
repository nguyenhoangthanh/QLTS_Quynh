using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizQUANTRIVIEN
    {
        private int _MAQTVIEN;
        public int MAQTVIEN
        {
            get { return _MAQTVIEN; }
            set { _MAQTVIEN = value; }
        }

        private string _TENQTVIEN;
        public string TENQTVIEN
        {
            get { return _TENQTVIEN; }
            set { _TENQTVIEN = value; }
        }

        private string _EMAIL;
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }

        private string _USENAME;
        public string USENAME
        {
            get { return _USENAME; }
            set { _USENAME = value; }
        }

        private string _PASSWORD;
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
        }

        private string _MOTA;
        public string MOTA
        {
            get { return _MOTA; }
            set { _MOTA = value; }
        }

        private string _SUBID;
        public string SUBID
        {
            get { return _SUBID; }
            set { _SUBID = value; }
        }

        private DateTime _NGAYTAO;
        public DateTime NGAYTAO
        {
            get { return _NGAYTAO; }
            set { _NGAYTAO = value; }
        }

        private DateTime _NGAYSUADOI;
        public DateTime NGAYSUADOI
        {
            get { return _NGAYSUADOI; }
            set { _NGAYSUADOI = value; }
        }

        public bizQUANTRIVIEN()
        {
            _MAQTVIEN = 0;
            _SUBID = _TENQTVIEN = _EMAIL = _USENAME =_PASSWORD =_MOTA = "";
            _NGAYTAO = _NGAYSUADOI = DateTime.Now;
        }

        public bizQUANTRIVIEN(int MAQTVIEN, string TENQTVIEN, string EMAIL, string USENAME, string PASSWORD, string MOTA, string SUBID, DateTime NGAYTAO, DateTime NGAYSUADOI)
        {
            _MAQTVIEN = MAQTVIEN;
            _TENQTVIEN = TENQTVIEN;
            _EMAIL = EMAIL;
            _USENAME = USENAME;
            _PASSWORD = PASSWORD;
            _MOTA = MOTA;
            _SUBID = SUBID;
            _NGAYTAO = NGAYTAO;
            _NGAYSUADOI = NGAYSUADOI;
        }
    }
}
