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
    public class BUS_ThucUong
    {
        public DataTable DanhSachThucUong()
        {
            DAL_ThucUong Food = new DAL_ThucUong();
            DataTable dtList = Food.DanhSachThucUong();
            return dtList;
        }
        public DataTable DanhSachLoaiThucUong()
        {
            DAL_ThucUong Food = new DAL_ThucUong();
            return Food.DanhSachLoaiThucUong();
        }
        public void ThemThucUong(DTO_ThucUong ma_thuc_uong)
        {
            DAL_ThucUong Food = new DAL_ThucUong();
            Food.ThemThucUong(ma_thuc_uong);
        }
        public int KiemTraThucUongTonTai(string ma_thuc_uong)
        {
            DAL_ThucUong Food = new DAL_ThucUong();
            int i = Food.KiemTraThucUongTonTai(ma_thuc_uong);
            return i;
        }
        public void SuaThucUong(DTO_ThucUong ma_thuc_uong)
        {
            DAL_ThucUong Food = new DAL_ThucUong();
            Food.SuaThucUong(ma_thuc_uong);
        }
        public void XoaThucUong(DTO_ThucUong ma_thuc_uong)
        {
            DAL_ThucUong Food = new DAL_ThucUong();
            Food.XoaThucUong(ma_thuc_uong);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            DAL_ThucUong Food = new DAL_ThucUong();
            DataTable dtList = Food.LoadDanhSachTimKiem(value, text);
            return dtList;
        }
    }
}
