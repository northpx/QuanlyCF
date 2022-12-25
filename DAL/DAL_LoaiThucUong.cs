using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LoaiThucUong
    {
        public DataTable DanhSachLoaiThucUong()
        {
            string s = "SELECT * FROM loai_thuc_uong";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public void ThemLoai(DTO_LoaiThucUong LTU)
        {
            string s = "INSERT INTO loai_thuc_uong(ma_loai,ten_loai,ghi_chu)  VALUES ( '" + LTU.MaLoai + "',N'" + LTU.TenLoai + "',N'" + LTU.GhiChu + "')";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public int KiemTraLoaiThucUongTonTai(string ma_loai)
        {
            int i = 0;
            string s = "SELECT * FROM loai_thuc_uong WHERE ma_loai = '" + ma_loai + "'";
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
        public void SuaLoai(DTO_LoaiThucUong LTU)
        {
            string s = string.Format(@"UPDATE loai_thuc_uong set ma_loai = '" + LTU.MaLoai + "', ten_loai = N'" + LTU.TenLoai + "',ghi_chu = N'" + LTU.GhiChu + "'  where ma_loai = '" + LTU.MaLoai_Sua + "'");
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public void XoaLoai(DTO_LoaiThucUong LTU)
        {
            string s = "DELETE loai_thuc_uong  where ma_loai = '" + LTU.MaLoai + "'";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            string s = "SELECT * FROM loai_thuc_uong WHERE " + value + " LIKE N'%" + text + "%'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
    }
}
