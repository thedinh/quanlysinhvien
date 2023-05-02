using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public class HocSinhinfo
    {
        private string _maHS;
        private string _tenHS;
        //protected bool _gioitinh;
        private DateTime _ngaysinh;
        private string _diachi;
        private string _DTB;
        private string _maLop;
        public string MaHS
        {
            get
            {
                return _maHS;
            }
            set
            {
                if (value == null)
                    throw new Exception("Ma HS khong duoc rong");
                _maHS = value;
            }
        }
        public string TenHS
        {
            get
            {
                return _tenHS;
            }
            set
            {
                if (value == null)
                    throw new Exception("Ten HS khong duoc rong");
                _tenHS = value;
            }
        }
        //public bool GioiTinh
        //{
        //    get
        //    {
        //        return _gioitinh;
        //    }
        //    set
        //    {
        //        _gioitinh = value;
        //    }
        //}
        public DateTime NgaySinh
        {
            get
            {
                return _ngaysinh;
            }
            set
            {
                _ngaysinh = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return _diachi;
            }
            set
            {
                if (value == null)
                    throw new Exception("Dia chi HS khong duoc rong");
                _diachi = value;
            }
        }
        public string DTB {
            get 
            {
                return _DTB;
            }
            set 
            {
                _DTB = value;
            }
        
        }
        public string MaLop
        {
            get
            {
                return _maLop;
            }
            set
            {
                _maLop = value;
            }
        }

    }
}
