using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_BanHang
    {
        public DataTable DanhSachThucUong()
        {
            DAL_BanHang Food = new DAL_BanHang();
            DataTable dtList = Food.DanhSachThucUong();
            return dtList;
        }
        public DataTable TongHoaDon(DateTime d1, DateTime d2)
        {
            DAL_BanHang Food = new DAL_BanHang();
            DataTable dtList = Food.TongHoaDon(d1, d2);
            return dtList;
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            DAL_BanHang Food = new DAL_BanHang();
            DataTable dtList = Food.LoadDanhSachTimKiem(value, text);
            return dtList;
        }
        public DataTable DanhSachGoiMon(string ma_ban)
        {
            DAL_BanHang Order = new DAL_BanHang();
            DataTable dtList = Order.DanhSachGoiMon(ma_ban);
            return dtList;
        }
        public DataTable DanhSachHoaDon(DateTime d1, DateTime d2, string table)
        {
            DAL_BanHang Order = new DAL_BanHang();
            DataTable dtList = Order.DanhSachHoaDon(d1, d2, table);
            return dtList;
        }
        public DataTable DoanhThu(DateTime d1, DateTime d2)
        {
            DAL_BanHang Order = new DAL_BanHang();
            DataTable dtList = Order.DoanhThu(d1, d2);
            return dtList;
        }
    }
}
