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
    public class BUS_NhanVien
    {
        public DataTable DanhSachNhanVien()
        {
            DAL_NhanVien Staff = new DAL_NhanVien();
            DataTable dtList = Staff.DanhSachNhanVien();
            return dtList;
        }
        public DataTable DanhSachGioiTinh()
        {
            DAL_NhanVien Staff = new DAL_NhanVien();
            return Staff.DanhSachGioiTinh();
        }
        public void ThemNhanVien(DTO_NhanVien ma_nhan_vien)
        {
            DAL_NhanVien Staff = new DAL_NhanVien();
            Staff.ThemNhanVien(ma_nhan_vien);
        }
        public int KiemTraNhanVienTonTai(string ma_nhan_vien)
        {
            DAL_NhanVien Staff = new DAL_NhanVien();
            int i = Staff.KiemTraNhanVienTonTai(ma_nhan_vien);
            return i;
        }
        public void SuaNhanVien(DTO_NhanVien ma_nhan_vien)
        {
            DAL_NhanVien Staff = new DAL_NhanVien();
            Staff.SuaNhanVien(ma_nhan_vien);
        }
        public void XoaNhanVien(DTO_NhanVien ma_nhan_vien)
        {
            DAL_NhanVien Staff = new DAL_NhanVien();
            Staff.XoaNhanVien(ma_nhan_vien);
        }

        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            DAL_NhanVien User = new DAL_NhanVien();
            DataTable dtList = User.LoadDanhSachTimKiem(value, text);
            return dtList;
        }
    }
}
