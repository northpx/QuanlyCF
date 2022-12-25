using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan
    {
        public static string ma_tai_khoan;
        public static string ma_tai_khoan_sua;
        public static string ten_tai_khoan;
        public static string ghi_chu;
        public static string mat_khau;
        public static string ma_quyen;
        public string TaiKhoan
        {
            get { return ma_tai_khoan; }
            set { ma_tai_khoan = value; }
        }
        public string TaiKhoanSua
        {
            get { return ma_tai_khoan_sua; }
            set { ma_tai_khoan_sua = value; }
        }
        public string MatKhau
        {
            get { return mat_khau; }
            set { mat_khau = value; }
        }
        public string Quyen
        {
            get { return ma_quyen; }
            set { ma_quyen = value; }
        }
        public string TenTaiKhoan
        {
            get { return ten_tai_khoan; }
            set { ten_tai_khoan = value; }
        }
        public string GhiChu
        {
            get { return ghi_chu; }
            set { ghi_chu = value; }
        }
        public DTO_TaiKhoan()
        {
            ma_tai_khoan = "";
            mat_khau = "";
        }
    }
}
