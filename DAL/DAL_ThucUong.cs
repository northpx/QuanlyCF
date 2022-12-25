using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThucUong
    {
        public DataTable DanhSachThucUong()
        {
            string s = "SELECT * FROM thuc_uong";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachLoaiThucUong()
        {
            string s = "select * FROM loai_thuc_uong";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public void ThemThucUong(DTO_ThucUong TU)
        {
            string s = "INSERT INTO thuc_uong(ma_thuc_uong,ten_thuc_uong,ma_loai,don_gia,so_luong,ghi_chu)  VALUES ( '" + TU.MaMon + "',N'" + TU.TenMon + "','" + TU.MaLoai + "'," + TU.DonGia + "," + TU.SoLuong + ",N'" + TU.GhiChu + "')";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public int KiemTraThucUongTonTai(string ma_thuc_uong)
        {
            int i = 0;
            string s = "SELECT * FROM thuc_uong WHERE ma_thuc_uong = '" + ma_thuc_uong + "'";
            DataTable dt = DBConnect.Instance.ExcuteQuery(s);
            if (dt == null || dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
        public void SuaThucUong(DTO_ThucUong TU)
        {
            string s = @"UPDATE thuc_uong set ma_thuc_uong = '" + TU.MaMon + "',ten_thuc_uong = N'" + TU.TenMon + "',ma_loai = '" + TU.MaLoai + "',don_gia = " + TU.DonGia + ",so_luong = " + TU.SoLuong + ",ghi_chu = N'" + TU.GhiChu + "'  where ma_thuc_uong = '" + TU.MaMon_Sua + "'";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public void XoaThucUong(DTO_ThucUong TU)
        {
            string s = "DELETE thuc_uong  where ma_thuc_uong = '" + TU.MaMon + "'";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            string s = "SELECT * FROM thuc_uong WHERE " + value + " LIKE N'%" + text + "%'";
            return DBConnect.Instance.ExcuteQuery(s);
        }

    }
}
