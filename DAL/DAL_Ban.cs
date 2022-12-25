using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Ban
    {
        public DataTable DanhSachBan()
        {
            string s = "SELECT * FROM ban";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachKhuVuc()
        {
            return DBConnect.Instance.ExcuteQuery(string.Format("select * FROM khu_vuc"));
        }
        public void ThemBan(DTO_Ban Ban)
        {
            string s = "INSERT INTO ban(ma_ban,ten_ban,ma_khu_vuc,so_luong,ghi_chu)  VALUES ( '" + Ban.MaBan + "',N'" + Ban.TenBan + "','" + Ban.KhuVuc + "'," + Ban.SoLuong + ",N'" + Ban.GhIChu + "')";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public int KiemTraBanTonTai(string ma_ban)
        {
            int i = 0;
            string s = "SELECT * FROM ban WHERE ma_ban = '" + ma_ban + "'";
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
        public void SuaBan(DTO_Ban Ban)
        {
            string s = string.Format(@"UPDATE ban set ma_ban = '" + Ban.MaBan + "',ten_ban = N'" + Ban.TenBan + "',ma_khu_vuc = '" + Ban.KhuVuc + "',so_luong = " + Ban.SoLuong + ",ghi_chu = N'" + Ban.GhIChu + "'  where ma_ban = '" + Ban.MaBan_Sua + "'");
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public void XoaBan(DTO_Ban Ban)
        {
            string s = "DELETE ban  where ma_ban = '" + Ban.MaBan + "'";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            string s = "SELECT * FROM ban WHERE " + value + " LIKE N'%" + text + "%'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
    }
}
