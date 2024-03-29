﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizCTTAISAN
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private DateTime _NGAY;
        public DateTime NGAY
        {
            get { return _NGAY; }
            set { _NGAY = value; }
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

        public bizCTTAISAN()
        {
            _ID = 0;
            _NGAY = DateTime.Now;
            _SOLUONG = 0;
            _PHONG = null;
            _TAISAN = null;
            _TINHTRANG = null;
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizCTTAISAN(int ID, DateTime NGAY, int SOLUONG, bizPHONG PHONG, bizTAISAN TAISAN, bizTINHTRANG TINHTRANG, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _NGAY = NGAY;
            _SOLUONG = SOLUONG;
            _PHONG = PHONG;
            _TAISAN = TAISAN;
            _TINHTRANG = TINHTRANG;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
