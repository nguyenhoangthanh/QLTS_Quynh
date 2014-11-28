using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizNHANVIEN
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _HOTEN;
        public string HOTEN
        {
            get { return _HOTEN; }
            set { _HOTEN = value; }
        }

        private string _SODIENTHOAI;
        public string SODIENTHOAI
        {
            get { return _SODIENTHOAI; }
            set { _SODIENTHOAI = value; }
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

        public bizNHANVIEN()
        {
            _ID = 0;
            _HOTEN = "";
            _SODIENTHOAI = "";
            _GIOITINH = "";
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizNHANVIEN(int ID, string HOTEN, string SODIENTHOAI, string GIOITINH, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _HOTEN = HOTEN;
            _SODIENTHOAI = SODIENTHOAI;
            _GIOITINH = GIOITINH;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
