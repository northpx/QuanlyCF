using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhuVuc
    {
        public DataTable DanhSachKhuVuc()
        {
            string s = "SELECT * FROM khu_vuc";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public void ThemKhuVuc(DTO_KhuVuc KV)
        {
            string s = "INSERT INTO khu_vuc(ma_khu_vuc,ten_khu_vuc,ghi_chu)  VALUES ( '" + KV.MaKhuVuc + "',N'" + KV.TenKhuVuc + "',N'" + KV.GhiChu + "')";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public int KiemTraKhuVucTonTai(string ma_khu_vuc)
        {
            int i = 0;
            string s = "SELECT * FROM khu_vuc WHERE ma_khu_vuc = '" + ma_khu_vuc + "'";
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
        public void SuaKhuVuc(DTO_KhuVuc KV)
        {
            string s = string.Format(@"UPDATE khu_vuc set ma_khu_vuc = '" + KV.MaKhuVuc + "', ten_khu_vuc = N'" + KV.TenKhuVuc + "',ghi_chu = N'" + KV.GhiChu + "'  where ma_khu_vuc = '" + KV.MaKhuVuc_Sua + "'");
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public void XoaKhuVuc(DTO_KhuVuc KV)
        {
            string s = "DELETE khu_vuc  where ma_khu_vuc = '" + KV.MaKhuVuc + "'";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            string s = "SELECT * FROM khu_vuc WHERE " + value + " LIKE N'%" + text + "%'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
    }
}
