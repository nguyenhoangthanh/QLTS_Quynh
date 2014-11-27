using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizCOSO
    {
        private int _MACOSO;
        public int MACOSO
        {
            get { return _MACOSO; }
            set { _MACOSO = value; }
        }

        private string _TENCOSO;
        public string TENCOSO
        {
            get { return _TENCOSO; }
            set { _TENCOSO = value; }
        }

        private string _DIACHI;
        public string DIACHI
        {
            get { return _DIACHI; }
            set { _DIACHI = value; }
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

        public bizCOSO()
        {
            _MACOSO = 0;
            _SUBID = _TENCOSO = _DIACHI = _MOTA = "";
            _NGAYTAO = _NGAYSUADOI = DateTime.Now;
        }

        public bizCOSO(int MACOSO, string TENCOSO, string DIACHI, string MOTA, string SUBID, DateTime NGAYTAO, DateTime NGAYSUADOI)
        {
            _MACOSO = MACOSO;
            _TENCOSO = TENCOSO;
            _DIACHI = DIACHI;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUADOI = NGAYSUADOI;
        }
    }
}
