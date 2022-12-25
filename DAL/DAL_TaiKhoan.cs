using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        public DataTable DangNhapHeThong(string ma_tai_khoan, string mat_khau, string ma_quyen)
        {
            string s = "Select * From tai_khoan Where ma_tai_khoan =  '" + ma_tai_khoan + "' And mat_khau = '" + mat_khau + "' And ma_quyen = '" + ma_quyen + "'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachQuyen()
        {
            return DBConnect.Instance.ExcuteQuery(string.Format("select * FROM quyen"));
        }
        public DataTable DanhSachTaiKhoan()
        {
            string s = "SELECT ma_tai_khoan,ten_tai_khoan,ma_quyen,ghi_chu FROM tai_khoan";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        
        public DataTable LoadDanhSachTimKiem(string value,string text)
        {
            string s = "SELECT ma_tai_khoan,ten_tai_khoan,ma_quyen,ghi_chu FROM tai_khoan WHERE "+ value + " LIKE N'%"+text+"%'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public DataTable DanhSachMatKhau(string ma_tai_khoan)
        {
            string s = "SELECT mat_khau FROM tai_khoan WHERE ma_tai_khoan = '"+ ma_tai_khoan + "'";
            return DBConnect.Instance.ExcuteQuery(s);
        }
        public void ThemTaiKhoan(DTO_TaiKhoan TK)
        {
            string s = "INSERT INTO tai_khoan(ma_tai_khoan,ten_tai_khoan,ma_quyen,mat_khau,ghi_chu)  VALUES ( '" + TK.TaiKhoan + "',N'" + TK.TenTaiKhoan + "','" + TK.Quyen + "',N'" + TK.MatKhau + "',N'" + TK.GhiChu + "')";
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public int KiemTraTaiKhoanTonTai(string ma_tai_khoan)
        {
            int i = 0;
            string s = "SELECT * FROM tai_khoan WHERE ma_tai_khoan = '" + ma_tai_khoan + "'";
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
        public void SuaTaiKhoan(DTO_TaiKhoan TK)
        {
            string s = string.Format(@"UPDATE tai_khoan set ma_tai_khoan = '" + TK.TaiKhoan + "', ten_tai_khoan = N'" + TK.TenTaiKhoan + "',ma_quyen = '" + TK.Quyen + "',mat_khau = '" + TK.MatKhau + "',ghi_chu = N'" + TK.GhiChu + "'  where ma_tai_khoan = '" + TK.TaiKhoanSua + "'");
            DBConnect.Instance.ExecuteNonQuery(s);
        }
        public void XoaTaiKhoan(DTO_TaiKhoan TK)
        {
            string s = "DELETE tai_khoan  where ma_tai_khoan = '" + TK.TaiKhoan + "'";
            DBConnect.Instance.ExecuteNonQuery(s);
        }

        
    }
}
