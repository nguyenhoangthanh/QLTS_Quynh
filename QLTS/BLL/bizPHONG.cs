using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizPHONG
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TENPHONG;
        public string TENPHONG
        {
            get { return _TENPHONG; }
            set { _TENPHONG = value; }
        }

        private bizDIADIEM _DIADIEM;
        public bizDIADIEM DIADIEM
        {
            get { return _DIADIEM; }
            set { _DIADIEM = value; }
        }

        private bizNHANVIEN _NHANVIEN;
        public bizNHANVIEN NHANVIEN
        {
            get { return _NHANVIEN; }
            set { _NHANVIEN = value; }
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

        public bizPHONG()
        {
            _ID = 0;
            _TENPHONG = "";
            _DIADIEM = null;
            _NHANVIEN = null;
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizPHONG(int ID, string TENPHONG, bizDIADIEM DIADIEM, bizNHANVIEN NHANVIEN, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _TENPHONG = TENPHONG;
            _DIADIEM = DIADIEM;
            _NHANVIEN = NHANVIEN;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
