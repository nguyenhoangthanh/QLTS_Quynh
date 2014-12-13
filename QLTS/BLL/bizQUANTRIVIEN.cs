using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizQUANTRIVIEN
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
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

        private string _USERNAME;
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }

        private string _PASSWORD;
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
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

        public bizQUANTRIVIEN()
        {
            _ID = 0;
            _TENQTVIEN = "";
            _EMAIL = "";
            _USERNAME = "";
            _PASSWORD = "";
            _MOTA = "";
            _SUBID = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizQUANTRIVIEN(int ID, string TENQTVIEN, string EMAIL, string USERNAME, string PASSWORD, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _TENQTVIEN = TENQTVIEN;
            _EMAIL = EMAIL;
            _USERNAME = USERNAME;
            _PASSWORD = PASSWORD;
            _MOTA = MOTA;
            _SUBID = SUBID;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
