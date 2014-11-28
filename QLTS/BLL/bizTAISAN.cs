using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTS.BLL
{
    public class bizTAISAN
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TENTAISAN;
        public string TENTAISAN
        {
            get { return _TENTAISAN; }
            set { _TENTAISAN = value; }
        }

        private DateTime? _NGAYMUA;
        public DateTime? NGAYMUA
        {
            get { return _NGAYMUA; }
            set { _NGAYMUA = value; }
        }

        private bizLOAITAISAN _LOAITAISAN;
        public bizLOAITAISAN LOAITAISAN
        {
            get { return _LOAITAISAN; }
            set { _LOAITAISAN = value; }
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

        public bizTAISAN()
        {
            _ID = 0;
            _TENTAISAN = "";
            _NGAYMUA = null;
            _LOAITAISAN = null;
            _SUBID = "";
            _MOTA = "";
            _NGAYTAO = DateTime.Now;
            _NGAYSUA = DateTime.Now;
        }

        public bizTAISAN(int ID, string TENTAISAN, DateTime NGAYMUA, bizLOAITAISAN LOAITAISAN, string SUBID, DateTime NGAYTAO, DateTime NGAYSUA)
        {
            _ID = ID;
            _TENTAISAN = TENTAISAN;
            _NGAYMUA = NGAYMUA;
            _LOAITAISAN = LOAITAISAN;
            _SUBID = SUBID;
            _MOTA = MOTA;
            _NGAYTAO = NGAYTAO;
            _NGAYSUA = NGAYSUA;
        }
    }
}
