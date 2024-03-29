﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizPHIEUMUONPHONG
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _KHOA;
        public string KHOA
        {
            get { return _KHOA; }
            set { _KHOA = value; }
        }

        private DateTime? _NGAYMUON;
        public DateTime? NGAYMUON
        {
            get { return _NGAYMUON; }
            set { _NGAYMUON = value; }
        }

        private DateTime? _NGAYTRA;
        public DateTime? NGAYTRA
        {
            get { return _NGAYTRA; }
            set { _NGAYTRA = value; }
        }

        private string _LYDOMUON;
        public string LYDOMUON
        {
            get { return _LYDOMUON; }
            set { _LYDOMUON = value; }
        }

        private string _GHICHU;
        public string GHICHU
        {
            get { return _GHICHU; }
            set { _GHICHU = value; }
        }

        private int _SOLUONGSV;
        public int SOLUONGSV
        {
            get { return _SOLUONGSV; }
            set { _SOLUONGSV = value; }
        }

        private int _NGUOIMUON_ID;
        public int NGUOIMUON_ID
        {
            get { return _NGUOIMUON_ID; }
            set { _NGUOIMUON_ID = value; }
        }

        private bizQUANTRIVIEN _QUANTRIVIEN;
        public bizQUANTRIVIEN QUANTRIVIEN
        {
            get { return _QUANTRIVIEN; }
            set { _QUANTRIVIEN = value; }
        }

        private string _TINHTRANG;
        public string TINHTRANG
        {
            get { return _TINHTRANG; }
            set { _TINHTRANG = value; }
        }

        private bool _GIANGVIENMUON;
        public bool GIANGVIENMUON
        {
            get { return _GIANGVIENMUON; }
            set { _GIANGVIENMUON = value; }
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

        public bizPHIEUMUONPHONG()
        {
            _ID = 0;
            _KHOA = "";
            _NGAYMUON = null;
            _NGAYTRA = null;
            _LYDOMUON = "";
            _GHICHU = "";
            _SOLUONGSV = 0;
            _NGUOIMUON_ID = 0;
            _QUANTRIVIEN = null;
            _TINHTRANG = "";
            _GIANGVIENMUON = true;
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizPHIEUMUONPHONG(int ID, string KHOA, DateTime NGAYMUON, DateTime NGAYTRA, string LYDOMUON, string GHICHU, int SOLUONGSV, int NGUOIMUON_ID, bizQUANTRIVIEN QUANTRIVIEN, string TINHTRANG, bool GIANGVIENMUON, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _KHOA = KHOA;
            _NGAYMUON = NGAYMUON;
            _NGAYTRA = NGAYTRA;
            _LYDOMUON = LYDOMUON;
            _GHICHU = GHICHU;
            _SOLUONGSV = SOLUONGSV;
            _NGUOIMUON_ID = NGUOIMUON_ID;
            _QUANTRIVIEN = QUANTRIVIEN;
            _TINHTRANG = TINHTRANG;
            _GIANGVIENMUON = GIANGVIENMUON;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
