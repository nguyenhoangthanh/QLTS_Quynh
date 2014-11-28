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

        private int _SOLUONG;
        public int SOLUONG
        {
            get { return _SOLUONG; }
            set { _SOLUONG = value; }
        }

        private bizPHONG _PHONG;
        public bizPHONG PHONG
        {
            get { return _PHONG; }
            set { _PHONG = value; }
        }

        private bizTAISAN _TAISAN;
        public bizTAISAN TAISAN
        {
            get { return _TAISAN; }
            set { _TAISAN = value; }
        }

        private bizTINHTRANG _TINHTRANG;
        public bizTINHTRANG TINHTRANG
        {
            get { return _TINHTRANG; }
            set { _TINHTRANG = value; }
        }

        private bizQUANTRIVIEN _QUANTRIVIEN;
        public bizQUANTRIVIEN QUANTRIVIEN
        {
            get { return _QUANTRIVIEN; }
            set { _QUANTRIVIEN = value; }
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

        public bizLOGTAISAN()
        {
            _ID = 0;
            _SOLUONG = 0;
            _PHONG = null;
            _TAISAN = null;
            _TINHTRANG = null;
            _QUANTRIVIEN = null;
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizLOGTAISAN(int ID, int SOLUONG, bizPHONG PHONG, bizTAISAN TAISAN, bizTINHTRANG TINHTRANG, bizQUANTRIVIEN QUANTRIVIEN, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _SOLUONG = SOLUONG;
            _PHONG = PHONG;
            _TAISAN = TAISAN;
            _TINHTRANG = TINHTRANG;
            _QUANTRIVIEN = QUANTRIVIEN;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
