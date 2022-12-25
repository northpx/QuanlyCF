using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        public DataTable DanhSachNhanVien()
        {
            string s = "SELECT * FROM nhan_vien";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachGioiTinh()
        {
            return DBConnect.Instance.ExcuteQuery(string.Format("select * FROM gioi_tinh"));
        }
        public void ThemNhanVien(DTO_NhanVien NV)
        {
            string s = "INSERT INTO nhan_vien(ma_nhan_vien,ten_nhan_vien,ma_gioi_tinh,dien_thoai,dia_chi)  VALUES ( '" + NV.MaNhanVien + "',N'" + NV.TeNhanVien + "','" + NV.GioiTinh + "',N'" + NV.DienThoai + "',N'" + NV.DiaChi + "')";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public int KiemTraNhanVienTonTai(string ma_nhan_vien)
        {
            int i = 0;
            string s = "SELECT * FROM nhan_vien WHERE ma_nhan_vien = '" + ma_nhan_vien + "'";
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
        public void SuaNhanVien(DTO_NhanVien NV)
        {
            string s = string.Format(@"UPDATE nhan_vien set ma_nhan_vien = '" + NV.MaNhanVien + "',ten_nhan_vien = N'" + NV.TeNhanVien + "',ma_gioi_tinh = '" + NV.GioiTinh + "',dien_thoai = '" + NV.DienThoai + "',dia_chi = N'" + NV.DiaChi + "'  where ma_nhan_vien = '" + NV.MaNhanVien_Sua + "'");
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public void XoaNhanVien(DTO_NhanVien NV)
        {
            string s = "DELETE nhan_vien  where ma_nhan_vien = '" + NV.MaNhanVien + "'";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            string s = "SELECT * FROM nhan_vien WHERE " + value + " LIKE N'%" + text + "%'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
    }
}
