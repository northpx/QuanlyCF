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
    public class BUS_KhuVuc
    {
        public DataTable DanhSachKhuVuc()
        {
            DAL_KhuVuc Area = new DAL_KhuVuc();
            DataTable dtList = Area.DanhSachKhuVuc();
            return dtList;
        }

        public void ThemKhuVuc(DTO_KhuVuc ma_khu_vuc)
        {
            DAL_KhuVuc Area = new DAL_KhuVuc();
            Area.ThemKhuVuc(ma_khu_vuc);
        }
        public int KiemTraKhuVucTonTai(string ma_khu_vuc)
        {
            DAL_KhuVuc Area = new DAL_KhuVuc();
            int i = Area.KiemTraKhuVucTonTai(ma_khu_vuc);
            return i;
        }

        public void SuKhuVuc(DTO_KhuVuc ma_khu_vuc)
        {
            DAL_KhuVuc Area = new DAL_KhuVuc();
            Area.SuaKhuVuc(ma_khu_vuc);
        }
        public void XoaKhuVuc(DTO_KhuVuc ma_khu_vuc)
        {
            DAL_KhuVuc Area = new DAL_KhuVuc();
            Area.XoaKhuVuc(ma_khu_vuc);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            DAL_KhuVuc Area = new DAL_KhuVuc();
            DataTable dtList = Area.LoadDanhSachTimKiem(value, text);
            return dtList;
        }
    }
}
