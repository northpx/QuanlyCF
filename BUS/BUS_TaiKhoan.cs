using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        public DataTable DangNhapHeThong(string ma_tai_khoan, string mat_khau, string ma_quyen)
        {
            DAL_TaiKhoan LG_DAL = new DAL_TaiKhoan();
            return LG_DAL.DangNhapHeThong(ma_tai_khoan, mat_khau, ma_quyen);
        }
        public DataTable DanhSachQuyen()
        {
            DAL_TaiKhoan User = new DAL_TaiKhoan();
            return User.DanhSachQuyen();
        }
        public DataTable DanhSachTaiKhoan()
        {
            DAL_TaiKhoan User = new DAL_TaiKhoan();
            DataTable dtList = User.DanhSachTaiKhoan();
            return dtList;
        }
        public DataTable DanhSachMatKhau(string ma_tai_khoan)
        {
            DAL_TaiKhoan User = new DAL_TaiKhoan();
            DataTable dtList = User.DanhSachMatKhau(ma_tai_khoan);
            return dtList;
        }
        public DataTable LoadDanhSachTimKiem(string value,string text)
        {
            DAL_TaiKhoan User = new DAL_TaiKhoan();
            DataTable dtList = User.LoadDanhSachTimKiem(value, text);
            return dtList;
        }
        
        public void ThemTaiKhoan(DTO_TaiKhoan ma_tai_khoan)
        {
            DAL_TaiKhoan User = new DAL_TaiKhoan();
            User.ThemTaiKhoan(ma_tai_khoan);
        }
        public int KiemTraTaiKhoanTonTai(string ma_tai_khoan)
        {
            DAL_TaiKhoan User = new DAL_TaiKhoan();
            int i = User.KiemTraTaiKhoanTonTai(ma_tai_khoan);
            return i;
        }
        public void SuaTaiKhoan(DTO_TaiKhoan ma_tai_khoan)
        {
            DAL_TaiKhoan User = new DAL_TaiKhoan();
            User.SuaTaiKhoan(ma_tai_khoan);
        }
        public void XoaTaiKhoan(DTO_TaiKhoan ma_tai_khoan)
        {
            DAL_TaiKhoan User = new DAL_TaiKhoan();
            User.XoaTaiKhoan(ma_tai_khoan);
        }
    }
}
