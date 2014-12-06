using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizGIANGVIEN
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TENGV;
        public string TENGV
        {
            get { return _TENGV; }
            set { _TENGV = value; }
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

        private DateTime? _NGAYSINH;
        public DateTime? NGAYSINH
        {
            get { return _NGAYSINH; }
            set { _NGAYSINH = value; }
        }

        private string _GIOITINH;
        public string GIOITINH
        {
            get { return _GIOITINH; }
            set { _GIOITINH = value; }
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

        public bizGIANGVIEN()
        {
            _ID = 0;
            _TENGV = "";
            _EMAIL = "";
            _USERNAME = "";
            _PASSWORD = "";
            _NGAYSINH = null;
            _GIOITINH = "";
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizGIANGVIEN(int ID, string TENGV, string EMAIL, string USERNAME, string PASSWORD, DateTime NGAYSINH, string GIOITINH, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _TENGV = TENGV;
            _EMAIL = EMAIL;
            _USERNAME = USERNAME;
            _PASSWORD = PASSWORD;
            _NGAYSINH = NGAYSINH;
            _GIOITINH = GIOITINH;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
