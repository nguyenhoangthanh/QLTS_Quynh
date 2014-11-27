using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizKHU
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TEN;
        public string TEN
        {
            get { return _TEN; }
            set { _TEN = value; }
        }

        private bizCOSO _COSO;
        public bizCOSO COSO
        {
            get { return _COSO; }
            set { _COSO = value; }
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

        public bizKHU()
        {
            _COSO = null;
            _ID = 0;
            _SUBID = _TEN = _MOTA = "";
            _NGAYTAO = _NGAYSUA = DateTime.Now;
        }

        public bizKHU(int ID, string TEN, bizCOSO COSO, string SUBID, string MOTA, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _TEN = TEN;
            _COSO = COSO;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
