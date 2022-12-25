using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BanHang
    {
        public DataTable DanhSachBanTrong()
        {
            string s = "SELECT * FROM ban WHERE ma_ban NOT IN (SELECT ma_ban FROM hoa_don)";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachBanCoNguoi()
        {
            string s = "SELECT * FROM ban WHERE ma_ban IN (SELECT ma_ban FROM hoa_don)";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachThucUong()
        {
            string s = "SELECT ma_thuc_uong,ten_thuc_uong,ma_loai,don_gia FROM thuc_uong";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            string s = "SELECT ma_thuc_uong,ten_thuc_uong,ma_loai,don_gia FROM thuc_uong WHERE " + value + " LIKE N'%" + text + "%'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachGoiMon(string ma_ban)
        {
            string s = "SELECT ma_hoa_don,b.ten_ban,c.ten_thuc_uong,a.don_gia,a.so_luong,a.thanh_tien FROM hoa_don a LEFT JOIN ban b ON a.ma_ban = b.ma_ban LEFT JOIN thuc_uong c ON a.ma_thuc_uong = c.ma_thuc_uong WHERE a.ma_ban = '" + ma_ban + "'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachHoaDon(DateTime d1, DateTime d2, string table)
        {
            string s = "SELECT ngay_hoa_don,b.ten_ban,c.ten_thuc_uong,a.don_gia,a.so_luong,thanh_tien FROM luu_hoa_don a LEFT JOIN ban b ON a.ma_ban = b.ma_ban LEFT JOIN thuc_uong c On a.ma_thuc_uong = c.ma_thuc_uong WHERE CONVERT(DATETIME, ngay_hoa_don,103) BETWEEN CONVERT(DATETIME, '" + d1 + "',103) AND CONVERT(DATETIME, '" + d2 + "',103) AND a.ma_ban ='" + table + "' ";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable TongHoaDon(DateTime d1, DateTime d2)
        {
            string s = "SELECT SUM(thanh_tien) AS tong_tien FROM luu_hoa_don WHERE CONVERT(DATETIME, ngay_hoa_don,103) BETWEEN CONVERT(DATETIME, '" + d1 + "',103) AND CONVERT(DATETIME, '" + d2 + "',103) ";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DoanhThu(DateTime d1, DateTime d2)
        {
            string s = "SELECT a.ma_ban,b.ten_ban,SUM(thanh_tien) AS Total FROM luu_hoa_don a LEFT JOIN ban b ON a.ma_ban = b.ma_ban WHERE CONVERT(DATETIME, ngay_hoa_don,103) BETWEEN CONVERT(DATETIME, '" + d1 + "',103) AND CONVERT(DATETIME, '" + d2 + "',103) GROUP BY a.ma_ban,ten_ban ";
            return DBConnect.Instance.ExcuteQuery(s);
        }
    }
}
